using Eventrix_Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GuestEdit" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GuestEdit.svc or GuestEdit.svc.cs at the Solution Explorer and start debugging.
    public class GuestEdit : IGuestEdit
    {
        public string removeGuest(string guestId)
        {
            int tcktTempId = 0;
            int guestTicketID = 0;
            string strResult = "There is no guest to remove";
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var guests = from _guest in db.Guests
                             where _guest.G_ID == Convert.ToInt32(guestId)
                             select _guest;
                var guestTickts = from g in db.Guest_Tickets
                                  where g.G_ID == Convert.ToInt32(guestId)
                                  select g;

                //Get an ID Guest_Ticket Bridging table row
                foreach (Guest_Ticket gt in guestTickts)
                {

                    if (guestTickts.Count() != 0)
                    {
                        tcktTempId = gt.ticket_temp_id;
                        guestTicketID = gt.ticket_Id;
                        break;
                    }
                    else { break; }
                }

                var gstTickts = from gstQR in db.Guest_QRCodes
                                where gstQR.ticket_Id == guestTicketID
                                select gstQR;
                //Delete QRcode row on the Guest_QRCode
                foreach (Guest_QRCode g_QR in gstTickts)
                {
                    if (gstTickts.Count() != 0)
                    {
                        db.Guest_QRCodes.DeleteOnSubmit(g_QR);
                        db.SubmitChanges();
                        strResult = "QR Code Ticket Deleted";
                    }
                    else { break; }
                }

                foreach (Guest_Ticket gt in guestTickts)
                {

                    if (guestTickts.Count() != 0)
                    {
                        tcktTempId = gt.ticket_temp_id;
                        db.Guest_Tickets.DeleteOnSubmit(gt);
                        db.SubmitChanges();
                        strResult = "Guest_Ticket Cancelled";
                        break;
                    }
                    else { break; }
                }

                var tcketTemplate = from tck in db.Ticket_Templates
                                    where tck.TicketID == tcktTempId
                                    select tck;

                foreach (Ticket_Template ticket in tcketTemplate)
                {
                    if (tcketTemplate.Count() != 0)
                    {
                        db.Ticket_Templates.DeleteOnSubmit(ticket);
                        db.SubmitChanges();
                        strResult = "Guest Deleted from Ticket_Template";
                        break;
                    }
                    else { break; }
                }

                foreach (Guest guest in guests)
                {

                    if (guests.Count() != 0)
                    {

                        db.Guests.DeleteOnSubmit(guest);
                        db.SubmitChanges();
                        strResult = "Guest Ticket Cancelled";
                        return strResult;
                    }
                    else { break; }
                }


            }
            //
            return strResult;
        }

        /** REQUEST FOR ANEW PASSWORD **/
        public string requestPassword(string email)
        {
            string password = "";
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var validateEventHost = from u in db.EventHosts
                                        where u.Email == email
                                        select u;

                var validateGuest = from g in db.Guests
                                    where g.Email == email
                                    select g;

                var validateStaff = from stf in db.Staffs
                                    where stf.Name == email
                                    select stf;

                foreach (EventHost eventHost in validateEventHost)
                {
                    if (validateEventHost.Count() == 1)
                    {
                        password = genCode();
                        eventHost.Password = password;
                        db.SubmitChanges();
                        //sendMsg(email, password);
                        return "New Password has been emailed to your email address";
                    }
                    else { break; }

                }

                foreach (Staff staff in validateStaff)
                {
                    if (validateStaff.Count() == 1)
                    {
                        password = genCode();
                        staff.Password = password;
                        db.SubmitChanges();
                        return "New Password has been emailed to your email address";
                    }
                    else { break; }
                }

                foreach (Guest guest in validateGuest)
                {
                    if (validateGuest.Count() == 1)
                    {
                        password = genCode();
                        guest.Password = password;
                        db.SubmitChanges();
                        return "New Password has been emailed to your email address";
                    }
                    else { break; }
                }
            }
            return "Email Address does not exist";
        }


        /***Private Supporting Methods******/
        private string genCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public GuestModel updateGuest(string id, GuestModel eventGuest)
        {
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {

                    var query = (from add in db.Guests where add.G_ID == Convert.ToInt32(id) select add);
                    if (query.Count() == 1)
                    {
                        Guest res = query.Single();
                        res.Name = eventGuest.NAME;
                        res.Surname = eventGuest.SURNAME;
                        res.Email = eventGuest.EMAIL;
                        res.Password = eventGuest.PASS;
                        db.SubmitChanges();

                        eventGuest = new GuestModel()
                        {
                            ID = res.G_ID,
                            NAME = res.Name,
                            SURNAME = res.Surname,
                            EMAIL = res.Email,
                            PASS = res.Password,
                            TYPE = res.Type
                        };
                        return eventGuest;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public string editGuest(string guestId, string name, string surname, string email, string oldPassword, string newPassword, string confrmNewPassword)
        {
            Guest newGuest = null;
            string oldpssword = "";
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var guests = from Guest g in db.Guests
                             where g.G_ID == Convert.ToInt32(guestId)
                             select g;
                foreach (Guest gst in guests)
                {
                    newGuest = gst;
                    oldpssword = gst.Password;
                }
                newGuest.Name = name;
                newGuest.Surname = surname;
                newGuest.Email = email;
                newGuest.Type = "USER";
                newGuest.Password = newPassword;
                if (oldPassword.Equals(oldpssword))
                {
                    if (newPassword.Equals(confrmNewPassword))
                    {
                        db.SubmitChanges();
                        return "Guest successfully updated";
                    }
                    else
                    {
                        return "New password does not match";
                    }

                }
                else { return "Password does not match"; }


            }

        }

        public GuestModel getGuestByGuestID(string guestID)
        {
            int _id = Convert.ToInt32(guestID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    return db.Guests.Where(ev => ev.G_ID == _id).Select(ev => new GuestModel
                    {
                        ID = ev.G_ID,
                        NAME = ev.Name,
                        SURNAME = ev.Surname,
                        EMAIL = ev.Email,
                        PASS = ev.Password,
                        TYPE = ev.Type
                    }).First();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string saveImage(ImageFile imageUp)
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var query = from image in db.GuestImages where image.GuestImageId.Equals(imageUp.ImageId) select image;
                    if (query.Count() == 0)
                    {
                        GuestImage fileToSave = new GuestImage();
                        fileToSave.Name = imageUp.ImageName;
                        fileToSave.Location = imageUp.Location;
                        fileToSave.Size = (int)imageUp.FileSize;
                        fileToSave.DateUploaded = imageUp.DateUploaded;
                        fileToSave.ContentType = imageUp.ContentType;
                        fileToSave.G_ID = Convert.ToInt32(imageUp.EventID);
                        db.GuestImages.InsertOnSubmit(fileToSave);
                        db.SubmitChanges();
                    }
                    else if (query.Count() == 1)
                    {
                        return "File Exist";
                    }

                }
                return "Success File Uploaded";
            }
            catch (NullReferenceException ex)
            {
                return ex.Message;
            }
            catch (Exception)
            {
                return "Failed Upload Failed";
            }
        }

        //Retrieve image from the database
        public ImageFile getImageById(string GuestID)
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                        from file in db.GuestImages
                        where file.G_ID.Equals(Convert.ToInt32(GuestID))
                        select new ImageFile
                        {
                            ImageId = file.GuestImageId,
                            ImageName = file.Name,
                            Location = file.Location,
                            ContentType = file.ContentType,
                            FileSize = (long)file.Size,
                            DateUploaded = file.DateUploaded.ToString(),
                        };
                    foreach (ImageFile img in innerJoinQuery)
                    {
                        return img;
                    }
                    return null;
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Edit Profile picture from the client directory & WCF database
        public string editProfilePic(string guestId, string ImageName, string fileSize, string location, string fileExtention)
        {
            int _id = Convert.ToInt32(guestId);
            GuestImage fileToSave = null;
            string response = "";
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var query = from image in db.GuestImages where image.G_ID == _id select image;
                    foreach (GuestImage img in query)
                    {
                        fileToSave = img;
                    }
                    fileToSave.Name = ImageName;
                    fileToSave.Location = "Prototype_TNT_Der1/Prototype_TNT_Der1/Events/" + _id + "/Profile_Pic/" + location;
                    fileToSave.Size = Convert.ToInt32(fileSize);
                    fileToSave.DateUploaded = DateTime.Now.ToString();
                    fileToSave.ContentType = fileExtention;
                    fileToSave.G_ID = Convert.ToInt32(_id);
                    if (query.Count() == 1)
                    {
                        db.SubmitChanges();
                        response = "Success File Uploaded";
                    }
                    else if (query.Count() == 0)
                    {
                        response = "User Image Not Found";
                    }
                    return response;
                }
            }
            catch (NullReferenceException ex)
            {
                return ex.Message;
            }
            catch (Exception)
            {
                return "Failed Upload Failed";
            }
        }

        //Delete the guest Image from the WCF Database
        public string deleteImageByGuestID(string guestID)
        {
            int _id = Convert.ToInt32(guestID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<GuestImage> toDelete = (from dl in db.GuestImages where dl.G_ID == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "success: Image Not Found";
                    }
                    else
                    {
                        db.GuestImages.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success";
                    }
                };
            }
            catch (Exception)
            {
                return "Failed";
            }
        }
    }
}

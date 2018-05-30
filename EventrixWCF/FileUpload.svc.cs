using Eventrix_Client.Model;
using Eventrix_Client.Model.ClientDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FileUpload" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FileUpload.svc or FileUpload.svc.cs at the Solution Explorer and start debugging.
    public class FileUpload : IFileUpload
    {

        //connectoin string EventrixDBConnectionString
        public string deleteImage(string id)
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    EventImage fileToDelete = (from file in db.EventImages where file.EventImageId.Equals(Convert.ToInt32(id)) select file).Single();
                    string name = fileToDelete.Name;
                    db.EventImages.DeleteOnSubmit(fileToDelete);
                    db.SubmitChanges();

                    return "Deleted " + name + " successfully";
                }
            }
            catch (Exception)
            {
                return "Failed Unable to perform deletion";
            }
        }

        public string deleteImageByEventID(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<EventImage> toDelete = (from dl in db.EventImages where dl.EventID == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "success: Image Not Found";
                    }
                    else
                    {
                        db.EventImages.DeleteAllOnSubmit(toDelete);
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

        public List<ImageFile> getAllImages()
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    return db.EventImages.Select(image => new ImageFile
                    {
                        ImageId = image.EventImageId,
                        ImageName = image.Name,
                        EventID = Convert.ToInt32(image.EventID),
                        ContentType = image.ContentType,
                        FileSize = (long)image.Size,
                        //Data = image.DATA.ToArray(),
                        DateUploaded = image.DateUploaded.ToString(),
                        //Location = image.LOCATION
                    }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ImageFile getImageById(string EventID)
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                        from file in db.EventImages
                        where file.EventID.Equals(Convert.ToInt32(EventID))
                        select new ImageFile
                        {
                            ImageId = file.EventImageId,
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

        public List<ImageFile> getMultipleImagesById(string eventID)
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                        from file in db.EventImages
                        where file.EventID.Equals(Convert.ToInt32(eventID))
                        select new ImageFile
                        {
                            ImageId = file.EventImageId,
                            ImageName = file.Name,
                            Location = file.Location,
                            ContentType = file.ContentType,
                            FileSize = (long)file.Size,
                            DateUploaded = file.DateUploaded.ToString(),
                        };
                    List<ImageFile> item = new List<ImageFile>();
                    foreach (ImageFile img in innerJoinQuery)
                    {
                        item.Add(img);
                    }
                    return item;
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string ImportData(string Name, string Surname, string Email)
        {
            var result = false;
            try
            {
                //check exists
                EventrixDBDataContext db = new EventrixDBDataContext();
                if (db.Guests.Where(t => t.Email.Equals(Email)).Count() == 0)   //create new guest
                {
                    var item = new Guest();
                    item.Name = Name;
                    item.Surname = Surname;
                    item.Email = Email;
                    item.Password = "random";
                    item.Type = "Private";
                    db.Guests.InsertOnSubmit(item);
                    db.SubmitChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                return "Failed";
            }
            if (result == true)
            {
                return "Success";
            }
            return "Failed";
        }
        public string saveImage(ImageFile imageUp)
        {
            //trim string location
            String imgLocation = imageUp.Location;
            string output = imgLocation.Substring(imgLocation.IndexOf('E')); //trim string path from Event
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var query = from image in db.EventImages where image.EventImageId.Equals(imageUp.ImageId) select image;
                    if (query.Count() == 0)
                    {
                        EventImage fileToSave = new EventImage();
                        fileToSave.Name = imageUp.ImageName;
                        fileToSave.Location = output;
                        fileToSave.Size = (int)imageUp.FileSize;
                        fileToSave.DateUploaded = imageUp.DateUploaded;
                        fileToSave.ContentType = imageUp.ContentType;
                        fileToSave.EventID = Convert.ToInt32(imageUp.EventID);
                        db.EventImages.InsertOnSubmit(fileToSave);
                        db.SubmitChanges();
                    }
                    else
                    if (query.Count() == 1)
                    {
                        return "File Exist";
                    }

                }
                return "Success File Uploaded";
            }
            catch (Exception)
            {
                return "Failed Upload Failed";
            }
        }

        public int saveQRCodeImage(QRCodeImage imageUp)
        {
            try
            {
                Guest_QRCode fileToSave = new Guest_QRCode();
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var query = from image in db.Guest_QRCodes where image.QR_Id.Equals(imageUp.QRCodeID) select image;
                    if (query.Count() == 0)
                    {
                        fileToSave.Name = imageUp.Name;
                        fileToSave.ticket_Id = imageUp.ticket_ID;
                        fileToSave.Location = imageUp.Location;
                        fileToSave.EntranceTime = imageUp.EntranceTime;
                        fileToSave.Checked_In = 0;
                        fileToSave.Credit = imageUp.Credit;
                        // fileToSave.tick = Convert.ToInt32(imageUp.EventID);
                        db.Guest_QRCodes.InsertOnSubmit(fileToSave);
                        db.SubmitChanges();
                    }
                    else
                    if (query.Count() == 1)
                    {
                        return 0;
                    }

                };
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var query = (from tk in db.Guest_QRCodes select tk).ToList();
                    Guest_QRCode tick = query.Last();
                    int ID = tick.QR_Id;
                    return ID;
                };
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public string saveMultipleImages(List<ImageFile> imagesToUpload)
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    foreach (ImageFile f in imagesToUpload)
                    {
                        saveImage(f);
                    }

                    return "Files Uploaded";
                }
            }
            catch (Exception e)
            {
                return "Failed " + e.Message;
            }
        }

        public string deleteQRCodeFileByTicketID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    List<Guest_QRCode> toDelete = (from dl in db.Guest_QRCodes where dl.ticket_Id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Image Not Found";
                    }
                    else
                    {
                        db.Guest_QRCodes.DeleteAllOnSubmit(toDelete);
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

        public string getImageLocationByEventId(string strID)
        {
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    var innerJoinQuery =
                       (from file in db.EventImages
                        where file.EventID.Equals(Convert.ToInt32(strID)) select file).FirstOrDefault();
                    string fileImage = innerJoinQuery.Location;

                    string output = "";
                    if (fileImage == null)
                    {
                        output = "Events/Eventrix_Default_Image.png";
                    }
                    else
                    {
                        output = fileImage.Substring(fileImage.IndexOf('E')); //trim string path from Event
                    }
                    return output;
                };
            }
            catch (Exception)
            {
                return "Events/Eventrix_Default_Image.png";
            }
        }

        public bool UpdateQRCode(QRCodeImage image, string ID)
        {
            int _id = Convert.ToInt32(ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var query = (from img in db.Guest_QRCodes
                             where img.QR_Id.Equals(_id)
                             select img);
                if (query.Count() != 0)
                {
                    Guest_QRCode toinsert = query.Single();
                    toinsert.Name = image.Name;
                    toinsert.Location = image.Location;
                    
                //    db.EventViews.InsertOnSubmit(toinsert);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            };
        }
    }
}

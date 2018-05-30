
using Eventrix_Client.Model;
using Eventrix_Client.Model.ServiceClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class Registration : System.Web.UI.Page
    {
        string SUBFOLDER = "Profile_Pic";
        GuestSvcClient svcClient = new GuestSvcClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Page.Validate();
                if (!(String.IsNullOrEmpty(txtPass.Text.Trim())))
                {
                    txtPass.Attributes["value"] = txtPass.Text;
                }
                if (!(String.IsNullOrEmpty(txtPass2.Text.Trim())))
                {
                    txtPass2.Attributes["value"] = txtPass2.Text;
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string pass = "";
            pass = txtPass.Text;
            string hashedPass = PassWords.HashPassword(pass);
            if (mycheckbox.Checked == false)  // register as Guest
            {
                GuestModel _guest = new GuestModel();
                Eventrix_Client.Registration reg = new Eventrix_Client.Registration();
                _guest.NAME = txtName.Text;
                _guest.SURNAME = txtSurname.Text;
                _guest.EMAIL = txtEmail.Text;
                _guest.PASS = hashedPass;
                _guest.TYPE = "PUBLIC";
                int response =  reg.RegisterGuest(_guest);
              //  txtName.Text = response;
                if (response != -1)
                {
                    EmailClient emailClient = new EmailClient();
                   emailClient.sendMsg_SuccessRegistration(_guest);
                    if (profilePic.HasFile)
                    {
                        makeDirectory(response);
                        ImageFile mainPic = new ImageFile();
                        mainPic = UploadFile(profilePic, response, SUBFOLDER);
                        string res = svcClient.saveImage(mainPic);
                    }
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Redirect("Registration.aspx");
                }
            }
            else  //register as event host
            {
                EventHostModel _host = new EventHostModel();
                Eventrix_Client.Registration reg = new Eventrix_Client.Registration();
                _host.NAME = txtName.Text;
                _host.EMAIL = txtEmail.Text;
                _host.SURNAME = txtSurname.Text;
                _host.PASS = hashedPass;
                string response = reg.RegisterHost(_host);
                if(response.Contains("successfully"))
                {
                    EmailClient emailClient = new EmailClient();
                    emailClient.sendMsg_SuccessRegistration(_host);
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Redirect("Registration.aspx");
                }
            }
        }


        protected void txtSurname_TextChanged(object sender, EventArgs e)
        {
            bool isVal = checkString(txtSurname.Text, 3);
            if (isVal == false)
            {
                txtSurname.BorderColor = System.Drawing.Color.Red;

            }
            if (isVal == true)
            {
                txtSurname.BorderColor = System.Drawing.Color.Green;
            }
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            String emailvalue = txtEmail.Text;
            bool emailIsval = isValidEmail(emailvalue);
            if (emailIsval == false)
            {
                txtEmail.BorderColor = System.Drawing.Color.Red;
            }
            if (emailIsval == true)
            {
                txtEmail.BorderColor = System.Drawing.Color.Green;
            }
        }

        protected void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.BorderColor = System.Drawing.Color.Red;
            }
            if (txtPass.Text != "")
            {
                txtPass.BorderColor = System.Drawing.Color.Green;
            }
        }

        protected void txtPass2_TextChanged(object sender, EventArgs e)
        {
            if (txtPass2.Text == "")
            {
                txtPass2.BorderColor = System.Drawing.Color.Red;
            }
            if (txtPass2.Text != "")
            {
                txtPass2.BorderColor = System.Drawing.Color.Green;
            }
        }

        //Utility Methods
        private bool isValidEmail(String email)
        {
            string emailReg = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (email != null)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(email, emailReg);
            }
            else
            {
                return false;
            }
        }
        private bool checkString(String input, int len)
        {
            bool isVal = false;

            if (input.Length < len)
            {
                isVal = false;
            }
            else if (input.Length > len)
            {
                isVal = true;
            }
            return isVal;
        }

        protected void mycheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string pass = "";
            pass = txtPass.Text;
            if (mycheckbox.Checked == false)  // register as Guest
            {
                GuestModel _guest = new GuestModel();
                Eventrix_Client.Registration reg = new Eventrix_Client.Registration();
                _guest.NAME = txtName.Text;
                _guest.SURNAME = txtSurname.Text;
                _guest.EMAIL = txtEmail.Text;
                _guest.PASS = pass;
                _guest.TYPE = "PUBLIC";
                int response = reg.RegisterGuest(_guest);
                //  txtName.Text = response;
                if (response != -1)
                {
                    EmailClient emailClient = new EmailClient();
                    emailClient.sendMsg_SuccessRegistration(_guest);
                    if (profilePic.HasFile)
                    {
                        makeDirectory(response);
                        ImageFile mainPic = new ImageFile();
                        mainPic = UploadFile(profilePic, response, SUBFOLDER);
                        string res = svcClient.saveImage(mainPic);
                    }
                    //  Response.Redirect("Login.aspx");
                    Popup(true, "Login.aspx");
                }
                else
                {
                    Popup(false, "Registration.aspx");
                   // Response.Redirect("Registration.aspx");
                }
            }
            else  //register as event host
            {
                EventHostModel _host = new EventHostModel();
                Eventrix_Client.Registration reg = new Eventrix_Client.Registration();
                _host.NAME = txtName.Text;
                _host.EMAIL = txtEmail.Text;
                _host.SURNAME = txtSurname.Text;
                _host.PASS = pass;
                string response = reg.RegisterHost(_host);
                if (response.Contains("successfully"))
                {
                    EmailClient emailClient = new EmailClient();
                    emailClient.sendMsg_SuccessRegistration(_host);
                    Popup(true, "Login.aspx");
                 //   Response.Redirect("Login.aspx");
                }
                else
                {
                    Popup(false, "Registration.aspx");
                    //.Redirect("Registration.aspx");
                }
            }
        }

        public void Popup(bool isSuccess, string strURL)
        {
            string htmltag = "";
            if (isSuccess == true)
            {
                htmltag = "<div class='alert alert-success text-center' role='alert'>";
                htmltag += "<button type = 'button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>";
                htmltag += " <strong> Success!</strong> You have been registered successfully! Please Check Your Email.";
                htmltag += "</div>";
                status.InnerHtml = htmltag;
                Response.AddHeader("REFRESH", "4;URL=" + strURL);
            }
            else
            {
                htmltag = "<div class='alert alert-danger text-center' role='alert'>";
                htmltag += "<button type = 'button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>";
                htmltag += " <strong> Danger!</strong> Oops! Something happened, please verify your details.";
                htmltag += "</div>";
                status.InnerHtml = htmltag;
                //    Response.AddHeader("REFRESH", "6;URL=" + strURL);
            }
        }

        protected void makeDirectory(int userID)
        {
            string directoryPath = Server.MapPath(string.Format("~/{0}/", "Events/" + userID));

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Directory.CreateDirectory(Path.Combine(directoryPath, "Profile_Pic"));
                Directory.CreateDirectory(Path.Combine(directoryPath, "Event_Images"));
                Directory.CreateDirectory(Path.Combine(directoryPath, "Main_Image"));
                Directory.CreateDirectory(Path.Combine(directoryPath, "QR_Codes"));

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory already exists.');", true);
            }
        }

        private ImageFile UploadFile(FileUpload fileToUpload, int ID, string subfolder)
        {
            int eventID = Convert.ToInt32(ID);
            if (fileToUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileToUpload.FileName);
                    string serverLocation = "~/Events/" + eventID.ToString() + "/" + subfolder + "/" + filename;
                    string SaveLoc = Server.MapPath(serverLocation);
                    int fileSize = fileToUpload.PostedFile.ContentLength;
                    string fileExtention = Path.GetExtension(fileToUpload.FileName);

                    if (fileExtention.ToLower() == ".jpg" || fileExtention.ToLower() == ".png" || fileExtention.ToLower() == ".jpeg" && fileSize <= 15728640)
                    {
                        fileToUpload.SaveAs(SaveLoc);
                        ImageFile file = new ImageFile()
                        {
                            ImageId = eventID,
                            EventID = eventID,
                            ImageName = filename,
                            FileSize = fileSize,
                            Location = "Prototype_TNT_Der1/Prototype_TNT_Der1/Events/" + eventID.ToString() + "/" + subfolder + "/" + filename,
                            ContentType = fileExtention,
                            DateUploaded = DateTime.Now.ToString(),
                        };
                        return file;
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
            else
                return null;
        }
    }
}
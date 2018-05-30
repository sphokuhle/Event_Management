using Eventrix_Client.Model;
using Eventrix_Client.Model.ServiceClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class EditGuest : System.Web.UI.Page
    {
        private string guestId;
        //private string type;
        private string password;
        private string guestUrl;
        private WebClient proxy;
        private char quote = '"';
        private string SUBFOLDER = "Profile_Pic";

        private GuestSvcClient guestClient = new GuestSvcClient();
        private ImageFile img = new ImageFile();

        private GuestModel gstModel = new GuestModel();
        private string pasword;
        private string imgLocation;

        protected void Page_Load(object sender, EventArgs e)
        {
            guestId = Convert.ToString(Session["ID"]);
            if (Session["ID"] != null)
            {
                gstModel = guestClient.getGuestByGuestID(guestId);
                pasword = gstModel.PASS;
                if (IsPostBack)
                {
                    Page.Validate();
                    if (!(String.IsNullOrEmpty(txtNewPas.Text.Trim())))
                    {
                        txtNewPas.Attributes["value"] = txtNewPas.Text;
                    }
                    if (!(String.IsNullOrEmpty(txtConfirmPas.Text.Trim())))
                    {
                        txtConfirmPas.Attributes["value"] = txtConfirmPas.Text;
                    }
                }
                else if (!IsPostBack)
                {

                    password = gstModel.PASS;
                    txtName.Text = gstModel.NAME;
                    txtLastname.Text = gstModel.SURNAME;
                    txtEmail.Text = gstModel.EMAIL;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GuestModel newGuest = new GuestModel();
            if (txtNewPas.Text.Equals("") && txtConfirmPas.Text.Equals("") && txtOldpassword.Text.Equals(""))
            {
                //newGuest.NAME = txtName.Text;
                //newGuest.SURNAME = txtLastname.Text;
                //newGuest.EMAIL = txtEmail.Text;
                //newGuest.PASS = guestClient.getGuestByGuestID(guestId).PASS;
                //newGuest.USERTYPE = txtUserType.Text;
                //guestClient.updateGuest(guestId, newGuest);
                proxy = new WebClient();
                guestUrl =
                    string.Format("http://localhost:53056/GuestEdit.svc/editGuest/{0},{1},{2},{3},{4},{5},{6}", guestId, txtName.Text, txtLastname.Text, txtEmail.Text, pasword, pasword, pasword);
                byte[] _data = proxy.DownloadData(guestUrl);
                Stream memory = new MemoryStream(_data);
                var reader = new StreamReader(memory);
                string result = reader.ReadToEnd().Replace("editGuest", "").Replace("Result", "").Replace(quote + "", "").Replace("{", "").Replace("}", "").Replace(":", "");
                btnEdit.Visible = false;
                //Changing the profile picture
                if (profilePic.HasFile)
                {
                    string response = updateProfilePic(profilePic); //Store attribute of the new profile pic in the WCF database
                    if (response.Contains("Success"))
                    {
                        string filename = Path.GetFileName(profilePic.FileName);
                        string serverLocation = "~/Events/" + guestId + "/" + SUBFOLDER + "/" + filename;
                        string SaveLoc = Server.MapPath(serverLocation); //Get the full image directory location

                        profilePic.SaveAs(SaveLoc); //Save the picture in the given directory
                        img = guestClient.getImageById(guestId);
                        if (img == null)
                        {
                            Session["DEFAULT_IMAGE"] = "ProfilePic.png";
                        }
                        else
                        {
                            imgLocation = img.Location;
                            Session["PROFILE_IMAGE"] = imgLocation.Substring(imgLocation.IndexOf('E'));
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Profile picture failed to update.');", true);
                    }
                }
                //Check if the edit is successful or not
                if (result.Contains("successfully"))
                {
                    lblWarning.ForeColor = System.Drawing.Color.White;
                    lblWarning.Text = result; lblWarning.Visible = true;
                    Response.Redirect("EditGuest.aspx"); // Refresh the page to display the updated picture
                }
            }
            else
            {
                //Response.Write("<script>alert('Cant edit with null values');</script>");
                lblWarning.Text = "Cannot edit with empty values";
                lblWarning.Visible = true;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string hashedPass = "";
            if ((!txtNewPas.Text.Equals("") && !txtConfirmPas.Text.Equals("") && !txtOldpassword.Text.Equals("")))
            {
                hashedPass = PassWords.HashPassword(txtOldpassword.Text);
                if (pasword == hashedPass)
                {
                    proxy = new WebClient();
                    guestUrl =
                        string.Format("http://localhost:53056/GuestEdit.svc/editGuest/{0},{1},{2},{3},{4},{5},{6}", guestId, txtName.Text, txtLastname.Text, txtEmail.Text, hashedPass, PassWords.HashPassword(txtNewPas.Text), PassWords.HashPassword(txtNewPas.Text));
                    byte[] _data = proxy.DownloadData(guestUrl);
                    Stream memory = new MemoryStream(_data);
                    var reader = new StreamReader(memory);
                    string result = reader.ReadToEnd().Replace("editGuest", "").Replace("Result", "").Replace(quote + "", "").Replace("{", "").Replace("}", "").Replace(":", "");
                    btnEdit.Visible = false;
                    //Changing the profile picture
                    if (profilePic.HasFile)
                    {
                        string response = updateProfilePic(profilePic); //Store attribute of the new profile pic in the WCF database
                        if (response.Contains("Success"))
                        {
                            string filename = Path.GetFileName(profilePic.FileName);
                            string serverLocation = "~/Events/" + guestId + "/" + SUBFOLDER + "/" + filename;
                            string SaveLoc = Server.MapPath(serverLocation); //Get the full image directory location

                            profilePic.SaveAs(SaveLoc); //Save the picture in the given directory
                            img = guestClient.getImageById(guestId);
                            if (img == null)
                            {
                                Session["DEFAULT_IMAGE"] = "ProfilePic.png";
                            }
                            else
                            {
                                imgLocation = img.Location;
                                Session["PROFILE_IMAGE"] = imgLocation.Substring(imgLocation.IndexOf('E'));
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Profile picture failed to update.');", true);
                        }
                    }

                    //Check if the edit is successful or not
                    if (result.Contains("successfully"))
                    {
                        lblWarning.ForeColor = System.Drawing.Color.White;
                        lblWarning.Text = result; lblWarning.Visible = true;
                        Response.Redirect("EditGuest.aspx"); // Refresh the page to display the picture
                    }

                }
                else
                {
                    lblWarning.Text = "Current password is incorrect";
                    lblWarning.Visible = true;
                    btnReset.Visible = false;
                }
            }
            else
            {
                lblWarning.Text = "Cannot edit with empty values";
                lblWarning.Visible = true;
            }

        }

        /* Change profile picture details */
        protected string updateProfilePic(FileUpload fileToUpload)
        {
            string response = "";
            proxy = new WebClient();
            string filename = Path.GetFileName(fileToUpload.FileName);
            string serverLocation = "~/Events/" + guestId + "/" + SUBFOLDER + "/" + filename;
            string SaveLoc = Server.MapPath(serverLocation);
            int fileSize = fileToUpload.PostedFile.ContentLength;
            string fileExtention = Path.GetExtension(fileToUpload.FileName);

            if (fileExtention.ToLower() == ".jpg" || fileExtention.ToLower() == ".png" || fileExtention.ToLower() == ".jpeg" || fileExtention.ToLower() == ".gif" && fileSize <= 15728640)
            {
                guestUrl =
                    string.Format("http://localhost:53056/GuestEdit.svc/editProfilePic/{0},{1},{2},{3},{4}",
                    guestId, filename, fileSize.ToString(), filename, fileExtention);
                byte[] _data = proxy.DownloadData(guestUrl);
                Stream memory = new MemoryStream(_data);
                var reader = new StreamReader(memory);
                response = reader.ReadToEnd().Replace("editProfilePic", "").Replace("Result", "").Replace(quote + "", "").Replace("{", "").Replace("}", "").Replace(":", "");
            }

            return response;
        }

        /* Validating use input */
        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            bool isVal = checkString(txtName.Text, 3);
            RequiredFieldValidator3.Enabled = true;
            if (isVal == false)
            {
                txtName.BorderColor = System.Drawing.Color.Red;
            }
            if (isVal == true)
            {
                txtName.BorderColor = System.Drawing.Color.Green;
            }
        }

        protected void txtSurname_TextChanged(object sender, EventArgs e)
        {
            bool isVal = checkString(txtLastname.Text, 3);
            if (isVal == false)
            {
                txtLastname.BorderColor = System.Drawing.Color.Red;

            }
            if (isVal == true)
            {
                txtLastname.BorderColor = System.Drawing.Color.Green;
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
            if (txtNewPas.Text == "")
            {
                txtNewPas.BorderColor = System.Drawing.Color.Red;
            }
            if (txtNewPas.Text != "")
            {
                txtNewPas.BorderColor = System.Drawing.Color.Green;
            }
        }

        protected void txtPass2_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPas.Text == "")
            {
                txtConfirmPas.BorderColor = System.Drawing.Color.Red;
            }
            if (txtConfirmPas.Text != "")
            {
                txtConfirmPas.BorderColor = System.Drawing.Color.Green;
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
    }
}
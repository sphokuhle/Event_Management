using Eventrix_Client;
using Eventrix_Client.Model;
using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model.ServiceClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string SUBFOLDER = "Main_Image";
        string EVENT_TRACKER = "";
        protected void btnSubmitEvent_Click(object sender, EventArgs e)
        {

        }
        public bool ValidateStaffColumns(ExcelWorksheet worksheet)
        {
            int startColumn = 1;  //where the file in the class excel start
            int startRow = 1;
            int Hitscount = 0;  //Checks number of matching columns
            List<string> columnNames = new List<string>();
            //foreach (var startRowCell in worksheet.Cells[worksheet.Dimension.Start.Row, worksheet.Dimension.Start.Column, 1, worksheet.Dimension.End.Column])
            foreach (var startRowCell in worksheet.Cells[startRow, startColumn, 1, worksheet.Dimension.End.Column])
            {
                columnNames.Add(startRowCell.Text);
            }
            for (int i = 0; i < columnNames.Count; i++)
            {
                if (columnNames[i].Contains("Name") || columnNames[i].Contains("Email") || columnNames[i].Contains("Occupation"))
                {
                    Hitscount++;
                }
            }
            if (Hitscount == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateGuestColumns(ExcelWorksheet worksheet)
        {
            int startColumn = 1;  //where the file in the class excel start
            int startRow = 1;
            int Hitscount = 0;  //Checks number of matching columns
            List<string> columnNames = new List<string>();
            //foreach (var startRowCell in worksheet.Cells[worksheet.Dimension.Start.Row, worksheet.Dimension.Start.Column, 1, worksheet.Dimension.End.Column])
            foreach (var startRowCell in worksheet.Cells[startRow, startColumn, 1, worksheet.Dimension.End.Column])
            {
                columnNames.Add(startRowCell.Text);
            }
            for (int i = 0; i < columnNames.Count; i++)
            {
                if (columnNames[i].Contains("Name") || columnNames[i].Contains("Surname") || columnNames[i].Contains("Email") || columnNames[i].Contains("Ticket_Type"))
                {
                    Hitscount++;
                }
            }
            if (Hitscount == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateProductColumns(ExcelWorksheet worksheet)
        {
            int startColumn = 1;  //where the file in the class excel start
            int startRow = 1;
            int Hitscount = 0;  //Checks number of matching columns
            List<string> columnNames = new List<string>();
            //foreach (var startRowCell in worksheet.Cells[worksheet.Dimension.Start.Row, worksheet.Dimension.Start.Column, 1, worksheet.Dimension.End.Column])
            foreach (var startRowCell in worksheet.Cells[startRow, startColumn, 1, worksheet.Dimension.End.Column])
            {
                columnNames.Add(startRowCell.Text);
            }
            for (int i = 0; i < columnNames.Count; i++)
            {
                if (columnNames[i].ToLower().Contains("name") || columnNames[i].ToLower().Contains("description") || columnNames[i].ToLower().Contains("quantity") || columnNames[i].ToLower().Contains("price"))
                {
                    Hitscount++;
                }
            }
            if (Hitscount == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        string ImportData(FileUpload flInfo, int EventID, EventModel _event)
        {
            string path = "";
            string response = "";
            bool isValidGuestColumn = false;
            bool isValidStaffColumn = false;
            bool isValidProductColumn = false;
            int startColumn;
            int startRow;
            ExcelWorksheet GuestworkSheet;
            ExcelWorksheet StaffworkSheet;
            ExcelWorksheet ProductworkSheet;
            int count = 0;
            if (flInfo.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(flInfo.FileName);
                    string serverLocation = "~/temp/" + "/" + filename;
                    string SaveLoc = Server.MapPath(serverLocation);
                    flInfo.SaveAs(SaveLoc);
                    path = Server.MapPath("/") + "\\temp\\" + filename;

                    var package = new ExcelPackage(new System.IO.FileInfo(path));
                    ////  package.Workbook.Worksheets["TABNAME"].View.TabSelected = true;
                    startColumn = 1;  //where the file in the class excel start
                    startRow = 2;
                    GuestworkSheet = package.Workbook.Worksheets[1]; //read sheet one
                    StaffworkSheet = package.Workbook.Worksheets[2]; //read sheet two
                    ProductworkSheet = package.Workbook.Worksheets[3];

                    isValidGuestColumn = ValidateGuestColumns(GuestworkSheet);
                    isValidStaffColumn = ValidateStaffColumns(StaffworkSheet);
                    isValidProductColumn = ValidateProductColumns(ProductworkSheet);
                    // isValidColumn = true;
                }
                catch
                {
                    response = "Failed";
                    return response;
                }
                //check staff sheet
                object data = null;
                if (isValidStaffColumn == true && isValidGuestColumn == true && isValidProductColumn == true)
                {
                    do
                    {
                        data = StaffworkSheet.Cells[startRow, startColumn].Value; //column Number 
                        if (data == null)
                        {
                            continue;
                        }
                        //read column class name
                        object Name = StaffworkSheet.Cells[startRow, startColumn].Value;
                        object Email = StaffworkSheet.Cells[startRow, startColumn + 1].Value;
                        object Occupation = StaffworkSheet.Cells[startRow, startColumn + 2].Value;
                        StaffModel _staff = new StaffModel();
                        _staff.NAME = Name.ToString();
                        _staff.EMAIL = Email.ToString();
                        _staff.Occupation = Occupation.ToString();
                        _staff.PASS = "staff1";
                        _staff.EventID = EventID;
                        //import db
                        Eventrix_Client.Registration reg = new Eventrix_Client.Registration();
                        response = reg.RegisterStaff(_staff);
                        if (response.Contains("successfully"))
                        {
                            count++;
//====================-----------Send Email TO Staff-----------------=====================================//


//=========================================================================================================//

                        }
                        startRow++;
                    } while (data != null);

                    data = null;
                    startColumn = 1;  //where the file in the class excel start
                    startRow = 2;
                    do
                    {
                        data = GuestworkSheet.Cells[startRow, startColumn].Value; //column Number 
                        if (data == null)
                        {
                            continue;
                        }
                        object Name = GuestworkSheet.Cells[startRow, startColumn].Value;
                        object Surname = GuestworkSheet.Cells[startRow, startColumn + 1].Value;
                        object Email = GuestworkSheet.Cells[startRow, startColumn + 2].Value;
                        object Tyicket_Type = GuestworkSheet.Cells[startRow, startColumn + 3].Value;
                        GuestModel _guest = new GuestModel();
                        _guest.NAME = Name.ToString();
                        _guest.SURNAME = Surname.ToString();
                        _guest.EMAIL = Email.ToString();
                        _guest.PASS = "1212";
                        _guest.TYPE = Tyicket_Type.ToString();
                    
                        Eventrix_Client.Registration reg = new Eventrix_Client.Registration();
                        int G_ID = reg.RegisterGuest(_guest);
                        //Generate OTP
                        string pass = genCode(Convert.ToString(G_ID));
                        //HashPass
                        GuestModel gWithPass = new GuestModel();
                        gWithPass.PASS = pass;
                        response = reg.InsertOTP(gWithPass, Convert.ToString(G_ID));
                      //  response = reg.RegisterGuest(_guest);
                        if (G_ID != -1)
                        {
                            count++;
//====================-----------Send Invitation Email-----------------=====================================//

                            EmailClient email = new EmailClient();
                            email.sendMsgInvite(_guest, _event, pass, EventID);

//=========================================================================================================//

                        }
                        startRow++;
                    } while (data != null);

                    //upload product details
                    data = null;
                    startColumn = 1;  //where the file in the class excel start
                    startRow = 2;
                    do
                    {
                        data = ProductworkSheet.Cells[startRow, startColumn].Value; //column Number 
                        if (data == null)
                        {
                            continue;
                        }
                        object Name = ProductworkSheet.Cells[startRow, startColumn].Value;
                        object Description = ProductworkSheet.Cells[startRow, startColumn + 1].Value;
                        object Quantity = ProductworkSheet.Cells[startRow, startColumn + 2].Value;
                        object Price = ProductworkSheet.Cells[startRow, startColumn + 3].Value;
                        EventProduct _product = new EventProduct();
                        _product._Name = Name.ToString();
                   //     _product._Desc = Description.ToString();
                        _product._Quantity = Convert.ToInt32(Quantity.ToString());
                        _product.ProdRemaining = Convert.ToInt32(Quantity.ToString());
                        _product._Price = Convert.ToInt32(Price.ToString());
                        _product.EventID = EventID;
                        ProductServiceClient psv = new ProductServiceClient();
                        string isProductUpdated = psv.createProduct(_product);
                        if (isProductUpdated.Contains("success"))
                        {
                            count++;
                        }
                        startRow++;
                    } while (data != null);
                    //check record
                    if (count == (GuestworkSheet.Dimension.Rows - 1) + (StaffworkSheet.Dimension.Rows - 1) + (ProductworkSheet.Dimension.Rows - 1))
                    {
                        response = "success: All Records uploaded";
                    }
                    else
                    {
                        response = "success: Not All Records uploaded";
                    }

                }
                else
                {
                    response += " Failed to upload Exceel: Check columns";
                }

            }
            else
            {
                response = "Failed: File not found";
            }

            return response;
        }
        //uplaoding event image
        private ImageFile UploadFile(FileUpload fileToUpload, string ID, string subfolder)
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
                            EventID = eventID,
                            ImageName = filename,
                            FileSize = fileSize,
                            Location = "TNT_Innovation_09/Prototype_TNT_Der1/Prototype_TNT_Der1/Events/" + eventID.ToString() + "/" + subfolder + "/" + filename,
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
        public bool isLoadedTicket(EventModel _event, int ID)
        {
            if (!txtE_Quantity.Text.Equals(""))
            {
                _event.EB_Quantity = Convert.ToInt32(txtE_Quantity.Text);
            }
            else
            {
                _event.EB_Quantity = 0;
            }

            if (!txtR_Quantity.Text.Equals(""))
            {
                _event.Reg_Quantity = Convert.ToInt32(txtR_Quantity.Text);
            }
            else
            {
                _event.Reg_Quantity = 0;
            }

            if (!txtV_Quantity.Text.Equals(""))
            {
                _event.VIP_Quantity = Convert.ToInt32(txtV_Quantity.Text);
            }
            else
            {
                _event.VIP_Quantity = 0;
            }
            if (!txtVV_Quantity.Text.Equals(""))
            {
                _event.VVIP_Quantity = Convert.ToInt32(txtVV_Quantity.Text);
            }
            else
            {
                _event.VVIP_Quantity = 0;
            }


            string EB_Startdate = txtE_OpenDate.Text;
            string EB_Enddate = txtE_ClosingDate.Text;
            DateTime EB_SDate = new DateTime();
            DateTime EB_EDate = new DateTime();

            string Reg_Startdate = txtR_OpenDate.Text;
            string Reg_Enddate = txtR_ClosingDate.Text;
            DateTime R_SDate = new DateTime();
            DateTime R_EDate = new DateTime();


            string V_Startdate = txtV_OpenDate.Text;
            string V_Enddate = txtV_ClosingDate.Text;
            DateTime VIP_SDate = new DateTime();
            DateTime VIP_EDate = new DateTime();

            string VV_Startdate = txtVV_OpenDate.Text;
            string VV_Enddate = txtVV_ClosingDate.Text;
            DateTime VVIP_SDate = new DateTime();
            DateTime VVIP_EDate = new DateTime();


            if (!txtE_OpenDate.Text.Equals(""))
            {
                EB_SDate = DateTime.ParseExact(EB_Startdate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            }else
            {
                EB_SDate = DateTime.Now;
            }

            if (!txtE_ClosingDate.Text.Equals(""))
            {
                EB_EDate = DateTime.ParseExact(EB_Enddate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            }else
            {
                EB_EDate = DateTime.Now;
            }

            if (!txtR_OpenDate.Text.Equals(""))
            {
                R_SDate = DateTime.ParseExact(Reg_Startdate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            }else
            {
                R_SDate = DateTime.Now;
            }

            if (!txtR_ClosingDate.Text.Equals(""))
            {
                R_EDate = DateTime.ParseExact(Reg_Enddate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            }else
            {
                R_EDate = DateTime.Now;
            }

            if (!txtV_OpenDate.Text.Equals(""))
            {
                VIP_SDate = DateTime.ParseExact(V_Startdate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            }else
            {
                VIP_SDate = DateTime.Now;
            }

            if (!txtV_ClosingDate.Text.Equals(""))
            {
                VIP_EDate = DateTime.ParseExact(V_Enddate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            }else
            {
                VIP_EDate = DateTime.Now;
            }

            if (!txtVV_OpenDate.Text.Equals(""))
            {
                VVIP_SDate = DateTime.ParseExact(VV_Startdate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            }else
            {
                VVIP_SDate = DateTime.Now;
            }

            if (!txtVV_ClosingDate.Text.Equals(""))
            {
                VVIP_EDate = DateTime.ParseExact(VV_Enddate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            }else
            {
                VVIP_EDate = DateTime.Now;
            }

            //Check price
            decimal EB_Price;
            if (!txtE_Price.Text.Equals(""))
            {
                EB_Price = Convert.ToDecimal(txtE_Price.Text);
            }
            else
            {
                EB_Price = 0;
            }

            decimal R_Price;
            if (!txtR_Price.Text.Equals(""))
            {
                R_Price = Convert.ToDecimal(txtR_Price.Text);
            }
            else
            {
                R_Price = 0;
            }

            decimal V_Price;
            if (!txtV_Price.Text.Equals(""))
            {
                V_Price = Convert.ToDecimal(txtV_Price.Text);
            }
            else
            {
                V_Price = 0;
            }

            decimal VV_Price;
            if (!txtVV_Price.Text.Equals(""))
            {
                VV_Price = Convert.ToDecimal(txtVV_Price.Text);
            }
            else
            {
                VV_Price = 0;
            }


            //Check tokens
            int EB_Token;
            if (!txtE_Token.Text.Equals(""))
            {
                EB_Token = Convert.ToInt32(txtE_Token.Text);
            }
            else
            {
                EB_Token = 0;
            }

            int R_Token;
            if (!txtR_Token.Text.Equals(""))
            {
                R_Token = Convert.ToInt32(txtR_Token.Text);
            }
            else
            {
                R_Token = 0;
            }

            int V_Token;
            if (!txtV_Token.Text.Equals(""))
            {
                V_Token = Convert.ToInt32(txtV_Token.Text);
            }
            else
            {
                V_Token = 0;
            }

            int VV_Token;
            if (!txtVV_Token.Text.Equals(""))
            {
                VV_Token = Convert.ToInt32(txtVV_Token.Text);
            }
            else
            {
                VV_Token = 0;
            }


            bool controller = false;
            if (_event.EB_Quantity != 0)
            {
                    EventTicket EB_Ticket = new EventTicket();
                    TicketServiceClient tsc = new TicketServiceClient();
                    //  EB_Ticket._GuestID = null;
                    EB_Ticket._EventID = ID;
                    EB_Ticket._Type = "Early Bird";
                    EB_Ticket._Credit = EB_Token;
                    EB_Ticket._Refund = "No refund";
                    EB_Ticket._StartDate = EB_SDate;
                    EB_Ticket._EndDate = EB_EDate;
                    EB_Ticket._Price = EB_Price;

                    string ticketresponse = tsc.createTicket(EB_Ticket);
                    string res = ticketresponse;
                    if (ticketresponse.Contains("success"))
                    {
                        controller = true;
                    }
                    else
                    {
                        controller = false;
                    }
            }

            if (_event.Reg_Quantity != 0)
            {
                
                    EventTicket R_Ticket = new EventTicket();
                    TicketServiceClient tsc = new TicketServiceClient();
                    //  EB_Ticket._GuestID = null;
                    R_Ticket._EventID = ID;
                    R_Ticket._Type = "Regular";
                    R_Ticket._Credit = R_Token;
                    R_Ticket._Refund = "No refund";
                    R_Ticket._StartDate = R_SDate;
                    R_Ticket._EndDate = R_EDate;
                    R_Ticket._Price = R_Price;

                    string ticketresponse = tsc.createTicket(R_Ticket);
                    string res = ticketresponse;
                    if (ticketresponse.Contains("success"))
                    {
                        controller = true;
                    }
                    else
                    {
                        controller = false;
                    }
            }

            if (_event.VIP_Quantity != 0)
            {
                    EventTicket VIP_Ticket = new EventTicket();
                    TicketServiceClient tsc = new TicketServiceClient();
                    //  EB_Ticket._GuestID = null;
                    VIP_Ticket._EventID = ID;
                    VIP_Ticket._Type = "VIP";
                    VIP_Ticket._Credit = V_Token;
                    VIP_Ticket._Refund = "No refund";
                    VIP_Ticket._StartDate = VIP_SDate;
                    VIP_Ticket._EndDate = VIP_EDate;
                    VIP_Ticket._Price = V_Price;

                    string ticketresponse = tsc.createTicket(VIP_Ticket);
                    string res = ticketresponse;
                    if (ticketresponse.Contains("success"))
                    {
                        controller = true;
                    }
                    else
                    {
                        controller = false;
                    }
            }
            if (_event.VVIP_Quantity != 0)
            {
                    EventTicket VVIP_Ticket = new EventTicket();
                    TicketServiceClient tsc = new TicketServiceClient();
                    //  EB_Ticket._GuestID = null;
                    VVIP_Ticket._EventID = ID;
                    VVIP_Ticket._Type = "VVIP";
                    VVIP_Ticket._Credit = VV_Token;
                    VVIP_Ticket._Refund = "No refund";
                    VVIP_Ticket._StartDate = VVIP_SDate;
                    VVIP_Ticket._EndDate = VVIP_EDate;
                    VVIP_Ticket._Price = VV_Price;

                    string ticketresponse = tsc.createTicket(VVIP_Ticket);
                    string res = ticketresponse;
                    if (ticketresponse.Contains("success"))
                    {
                        controller = true;
                    }
                    else
                    {
                        controller = false;
                    }
            }
            return controller;
        }
        public int getAddressID()
        {
            string strStreet = "";
            string strCity = "";
            string strProvince = "";
            string strCountry = "";
            //Validate inputs
            if (!txtStreet.Text.Equals(""))
            {
                strStreet = txtStreet.Text;
            }
            if (!txtCity.Text.Equals(""))
            {
                strCity = txtCity.Text;
            }
            if (!txtProvince.Text.Equals(""))
            {
                strProvince = txtProvince.Text;
            }
            if (!txtCountry.Text.Equals(""))
            {
                strCountry = txtCountry.Text;
            }
            EventAddress add = new EventAddress();
            add.STREET = strStreet;
            add.CITY = strCity;
            add.PROVINCE = strProvince;
            add.COUNTRY = strCountry;
            MappingClient mapp = new MappingClient();
            int addID = mapp.createAddress(add);
            return addID;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Upload images
            string ID = "1";
            makeDirectory(ID);
            ImageFile mainPic = new ImageFile();
            mainPic = UploadFile(flEventImages, ID, SUBFOLDER); //replace 1 with actual event ID 
            FileUploadClient fuc = new FileUploadClient();
            string res = fuc.saveImage(mainPic);
            string number = res;
        }
        protected void makeDirectory(string EventID)
        {
            string directoryPath = Server.MapPath(string.Format("~/{0}/", "Events/" + EventID));

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Directory.CreateDirectory(Path.Combine(directoryPath, "Event_Images"));
                Directory.CreateDirectory(Path.Combine(directoryPath, "Main_Image"));
                Directory.CreateDirectory(Path.Combine(directoryPath, "QR_Codes"));
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory already exists.');", true);
            }
        }
        //Generate OTP
        public string genCode(string G_ID)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            string Pass = G_ID + finalString;
            return Pass;
        }
        public EventModel getDetails(string eventID)
        {
            EventModel _event = new EventModel();
            EventServiceClient eventClient = new EventServiceClient();
            _event = eventClient.findByEventID(eventID);
           
            return _event;
        }

        //btnCancel: Button for modal popup
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //EventList.aspx?dl={{ev.EventID}}
            string eventID = Convert.ToString(Session["CurrentEventID"]);
            Response.Redirect("EventList.aspx?dl=" + eventID);
        }
        //btnContinue: Button for modal popup
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            string LoggedID = Convert.ToString(Session["ID"]);
            Response.Redirect("EventManagement.aspx?HostID=" + LoggedID);
        }

        protected void btnSubmitEvent_Click1(object sender, EventArgs e)
        {
            int hostID = Convert.ToInt32(Session["ID"].ToString());
            //Creating Address
            int AddressID = getAddressID();
            int intEventID = 0;
            EventServiceClient _eventClient = new EventServiceClient();
            EventModel _event = new EventModel();
            _event.HostID = hostID;
            _event.Name = txtEventName.Text;    //Event Name
            _event.Category = txtCategory.Text;
            if (chkBoxPrivate.Checked == true)   //Public or Private Event
            {
                _event.Type = "Private";
            }
            else
            {
                _event.Type = "Public";
            }

            //Allowed to share?
            //chkShare
            if (chkShare.Checked == true)
            {
                //Share on Eventrix FB adn Twitter Page
            }
            _event.Desc = txtDesc.Value; //Event Description
            string startdate = txtStart.Text;
            string enddate = txtEnd.Text;
            //Convert user input to DateTime format 
            DateTime sDate = DateTime.ParseExact(txtStart.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            DateTime eDate = DateTime.ParseExact(txtEnd.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            int result = DateTime.Compare(sDate, eDate);
            int currentDate = DateTime.Compare(sDate, DateTime.Now);
            string htmltag = "";
            if (result > 0 || currentDate < 0)
            {
               
                htmltag = "<div class='alert alert-danger text-center' role='alert'>";
                htmltag += "<button type = 'button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>";
                htmltag += " <strong> Danger!</strong> Please Check Date!";
                htmltag += "</div>";
                status.InnerHtml = htmltag;
                Response.Redirect("CreateEvent.aspx");
            }


            _event.Start_Date = sDate;
            _event.sDate = Convert.ToString(sDate); //Event Start Date
            _event.eDate = Convert.ToString(eDate); //Event End Date
            _event.EventAddress = AddressID;   //Event's address ID  
                                               //check ticket field
            if (!txtE_Quantity.Text.Equals(""))
            {
                _event.EB_Quantity = Convert.ToInt32(txtE_Quantity.Text);
            }
            else
            {
                _event.EB_Quantity = 0;
            }

            if (!txtR_Quantity.Text.Equals(""))
            {
                _event.Reg_Quantity = Convert.ToInt32(txtR_Quantity.Text);
            }
            else
            {
                _event.Reg_Quantity = 0;
            }

            if (!txtV_Quantity.Text.Equals(""))
            {
                _event.VIP_Quantity = Convert.ToInt32(txtV_Quantity.Text);
            }
            else
            {
                _event.VIP_Quantity = 0;
            }
            if (!txtVV_Quantity.Text.Equals(""))
            {
                _event.VVIP_Quantity = Convert.ToInt32(txtVV_Quantity.Text);
            }
            else
            {
                _event.VVIP_Quantity = 0;
            }
            //Create Event
            EventServiceClient _createEvent = new EventServiceClient();
            string res = _createEvent.createEvent(_event);
            bool isCreatedTicket = false;   //Ticket Controller
            if (res.ToLower().Contains("success"))  //Event Created
            {
                EVENT_TRACKER = "Event Created successfully";
                intEventID = _createEvent.findEventID(_event); //Get Event ID
                string _strEventID = Convert.ToString(intEventID);
                makeDirectory(_strEventID); //Create Event Directory
                EVENT_TRACKER += "\n ID Exist";

                //------------------------------Upload Guest, Staff and Product-----------------------//
                string ImportSpreadsheet = "";
                ImportSpreadsheet = ImportData(flGuest, intEventID, _event);
                ///-------------------------------------------------------------------------------------//
                ///
                if (ImportSpreadsheet.Contains("success"))
                {
                    EVENT_TRACKER += "\n Spreadsheet Uploaded";
                    //Create Tickets
                    isCreatedTicket = isLoadedTicket(_event, intEventID);
                    if (isCreatedTicket == true)
                    {
                        EVENT_TRACKER += "\n Ticket Created";
                    }
                    else
                    {
                        EVENT_TRACKER += "\n Failed to upload ticket";
                    }
                }
                else
                {
                    //Unable to upload guest
                    EVENT_TRACKER += "\n failed to upload spreadsheet";
                    EVENT_TRACKER += "\n Spreadsheet Uploaded";
                    //Create Tickets
                    isCreatedTicket = isLoadedTicket(_event, intEventID);
                    if (isCreatedTicket == true)
                    {
                        EVENT_TRACKER += "\n Ticket Created";
                    }
                    else
                    {
                        EVENT_TRACKER += "\n Failed to upload ticket";
                    }
                }

                ////Upload images
                if(flEventImages.HasFile)
                {
                    ImageFile mainPic = new ImageFile();
                    mainPic = UploadFile(flEventImages, _strEventID, SUBFOLDER); //Upload Event Main's Image to client directory
                    FileUploadClient fuc = new FileUploadClient();
                    string res1 = fuc.saveImage(mainPic); //Upload Event Main's Image to Database
                    string number = res1;
                }

                //Populate the modal popup-------------------------------

                //EventModel _createdEvent = getDetails(_strEventID);
                //MappingClient mc = new MappingClient();
                //EventAddress _eventAddress = new EventAddress();
                //_eventAddress = mc.getAddressById(Convert.ToString(AddressID));
                //myModalLabel.InnerHtml = _createdEvent.Name;
                //mdl_Image.InnerHtml = "<img class='img-responsive' src='" + _createdEvent.ImageLocation + "'/>";
                //string htmltag = "";
                //htmltag += "<p>" + _createdEvent.Desc + "</p>";
                //htmltag += "<strong>Date: </strong> " + _createdEvent.sDate + " -" + _createdEvent.eDate;
                //htmltag += "<br/>";
                //htmltag += "<strong> Address: </strong><br/>";
                //htmltag += _eventAddress.STREET + "<br/>";
                //htmltag += _eventAddress.CITY + "<br/>";
                //htmltag += _eventAddress.PROVINCE + "<br/>";
                //htmltag += _eventAddress.COUNTRY + "<br/>";

                //mld_Details.InnerHtml = htmltag;


                //Session.Add("CurrentEventID", _strEventID);
                //string strModalButton = "";
                //       strModalButton += "<a href='EventList.aspx?dl="+ _strEventID + "' runat='server' class='btn btn-default'>Cancel</a>";
                //       strModalButton += "<a href='EventDetails.aspx?EventID="+ _strEventID + "' runat='server' class='btn btn-default'>Conitnue</a>";
                //btn_MDL.InnerHtml = strModalButton;
                //cssMapModal.Visible = true;

                 Response.Redirect("EventDetails.aspx?ev=" + intEventID);
            }
            else
            {
                EVENT_TRACKER += "\n Event already exist";
                Response.Redirect("CreateEvent.aspx");
            }
            //  Response.Write("<script> Alert("+ EVENT_TRACKER + ");</script>");

        }


        //Working Download button
        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            string filename = "Tester.xlsx";
            //Response.ContentType = "Application/x-msexcel";
            //Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            //string aaa = Server.MapPath("~/Template/" + filename);
            //Response.TransmitFile(aaa);
            //Response.End();

            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            byte[] data = req.DownloadData(Server.MapPath("~/Download/" + filename));
            response.BinaryWrite(data);
            response.End();
        }
    }
}
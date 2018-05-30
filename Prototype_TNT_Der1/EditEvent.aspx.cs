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
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class EditEvent : System.Web.UI.Page
    {
        int strEventID;
        int AddressID = 0;
        // string reqEventID = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            String request = (Request.QueryString["EventID"]);
            // reqEventID = request;
            if (!IsPostBack)
            {
                if (request == null)
                {
                    request = (Request.QueryString["ed"]);
                }
                int EventID = Convert.ToInt32(request);
                strEventID = EventID;
                EventModel em = new EventModel();
                ImageFile img = new ImageFile();
                List<EventProduct> products = new List<EventProduct>();
                EventTicket EB_tickets = new EventTicket();
                EventTicket REG_tickets = new EventTicket();
                EventTicket VIP_tickets = new EventTicket();
                EventTicket VVIP_tickets = new EventTicket();
                EventAddress _address = new EventAddress();
                //Service Clients
                EventServiceClient eventClient = new EventServiceClient();
                FileUploadClient fuc = new FileUploadClient();
                TicketServiceClient tsc = new TicketServiceClient();
                ProductServiceClient psc = new ProductServiceClient();
                MappingClient mc = new MappingClient();

                //Gett Functions
                em = eventClient.findByEventID(request);
                string addID = Convert.ToString(em.EventAddress);
                AddressID = Convert.ToInt32(addID);
                img = fuc.getImageById(request);
                EB_tickets = tsc.getEBTicket(request);
                REG_tickets = tsc.getRegularTicket(request);
                VIP_tickets = tsc.getVIPTicket(request);
                VVIP_tickets = tsc.getVVIPTicket(request);
                products = psc.getProductByEventID(request);
                _address = mc.getAddressById(addID);
                //First Tab
                divHearderName.InnerHtml = "Edit " + em.Name;
                txtEventName.Text = em.Name;
                txtDesc.Text = em.Desc;
                txtStart.Text = Convert.ToString(em.sDate);
                txtEnd.Text = Convert.ToString(em.eDate);

                //Ticket Section
                if (EB_tickets == null)
                {
                    txtE_Price.Text = "";
                    txtE_Quantity.Text = "";
                    txtE_Token.Text = "";
                    txtE_OpenDate.Text = "";
                    txtE_ClosingDate.Text = "";
                }
                else
                {
                    txtE_Price.Text = Convert.ToString(EB_tickets._Price);
                    txtE_Quantity.Text = Convert.ToString(em.EB_Quantity);
                    txtE_Token.Text = Convert.ToString(EB_tickets._Credit);
                    txtE_OpenDate.Text = Convert.ToString(EB_tickets._StartDate);
                    txtE_ClosingDate.Text = Convert.ToString(EB_tickets._EndDate);
                }

                if (REG_tickets == null)
                {
                    txtR_Price.Text = "";
                    txtR_Quantity.Text = "";
                    txtR_Token.Text = "";
                    txtR_OpenDate.Text = "";
                    txtR_ClosingDate.Text = "";
                }
                else
                {
                    txtR_Price.Text = Convert.ToString(REG_tickets._Price);
                    txtR_Quantity.Text = Convert.ToString(em.Reg_Quantity);
                    txtR_Token.Text = Convert.ToString(REG_tickets._Credit);
                    txtR_OpenDate.Text = Convert.ToString(REG_tickets._StartDate);
                    txtR_ClosingDate.Text = Convert.ToString(REG_tickets._EndDate);
                }
                if (VIP_tickets == null)
                {
                    txtV_Price.Text = "";
                    txtV_Quantity.Text = "";
                    txtV_Token.Text = "";
                    txtV_OpenDate.Text = "";
                    txtV_ClosingDate.Text = "";
                }
                else
                {
                    txtV_Price.Text = Convert.ToString(VIP_tickets._Price);
                    txtV_Quantity.Text = Convert.ToString(em.VIP_Quantity);
                    txtV_Token.Text = Convert.ToString(VIP_tickets._Credit);
                    txtV_OpenDate.Text = Convert.ToString(VIP_tickets._StartDate);
                    txtV_ClosingDate.Text = Convert.ToString(VIP_tickets._EndDate);
                }

                if (VVIP_tickets == null)
                {
                    txtVV_Price.Text = "";
                    txtVV_Quantity.Text = "";
                    txtVV_Token.Text = "";
                    txtVV_OpenDate.Text = "";
                    txtVV_ClosingDate.Text = "";
                }
                else
                {
                    txtVV_Price.Text = Convert.ToString(VVIP_tickets._Price);
                    txtVV_Quantity.Text = Convert.ToString(em.VVIP_Quantity);
                    txtVV_Token.Text = Convert.ToString(VVIP_tickets._Credit);
                    txtVV_OpenDate.Text = Convert.ToString(VVIP_tickets._StartDate);
                    txtVV_ClosingDate.Text = Convert.ToString(VVIP_tickets._EndDate);
                }

                //Address
                txtStreet.Text = _address.STREET;
                txtCity.Text = _address.CITY;
                txtProvince.Text = _address.PROVINCE;
                txtCountry.Text = _address.COUNTRY;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventList.aspx?dl=" + strEventID);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }




        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string EVENT_TRACKER;
            string SUBFOLDER = "Main_Image";
            int hostID = Convert.ToInt32(Session["ID"].ToString());
            String request = (Request.QueryString["EventID"]);
            if (request == null)
            {
                request = (Request.QueryString["ed"]);
            }
            EventServiceClient _eventClient = new EventServiceClient();
            EventModel oldEvent = new EventModel();
            oldEvent = _eventClient.findByEventID(request);

            //Editing  Address
            EventAddress currentAdd = new EventAddress();
            EventAddress Oldadd = new EventAddress();
            MappingClient mc = new MappingClient();
            currentAdd = mc.getAddressById(Convert.ToString(oldEvent.EventAddress));
            if (txtCountry.Text.Equals(""))
            {
                Oldadd.COUNTRY = currentAdd.COUNTRY;
            } else
            {
                Oldadd.COUNTRY = txtCountry.Text;
            }
            if (txtCity.Text.Equals(""))
            {
                Oldadd.CITY = currentAdd.CITY;
            }
            else
            {
                Oldadd.CITY = txtCity.Text;
            }
            if (txtStreet.Text.Equals(""))
            {
                Oldadd.STREET = currentAdd.STREET;
            }
            else
            {
                Oldadd.STREET = txtStreet.Text;
            }
            if (txtProvince.Text.Equals(""))
            {
                Oldadd.PROVINCE = currentAdd.PROVINCE;
            }
            else
            {
                Oldadd.PROVINCE = txtProvince.Text;
            }
            EventAddress newAddress = new EventAddress();
            newAddress = mc.EditAddress(Oldadd, Convert.ToString(oldEvent.EventAddress));

            EventModel _event = new EventModel();
            _event.HostID = oldEvent.HostID;
            _event.Name = txtEventName.Text;    //Event Name
            if (chkBoxPrivate.Checked == true)   //Public or Private Event
            {
                _event.Type = "Private";
            }
            else
            {
                _event.Type = "Public";
            }
            _event.Desc = txtDesc.Text; //Event Description
            string startdate = "";
            string enddate = "";

            //DateTime sDate = DateTime.ParseExact(startdate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            //DateTime eDate = DateTime.ParseExact(enddate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            //_event.sDate = sDate; //Event Start Date
            //_event.eDate = eDate; //Event End Date

            if (txtStart.Text.Equals(""))
            {
                _event.sDate = oldEvent.sDate;
            }
            else
            {
               // _event.sDate = DateTime.ParseExact(txtStart.Text, "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                //var date = DateTime.Parse(strDate,new CultureInfo("en-US", true))
                _event.sDate = Convert.ToString(DateTime.Parse(txtStart.Text, new CultureInfo("en-US", true)));
            }
            if (txtEnd.Text.Equals(""))
            {
                _event.eDate = oldEvent.eDate;
            }
            else
            {
              //  _event.eDate = DateTime.ParseExact(txtEnd.Text, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
                _event.eDate = Convert.ToString(DateTime.Parse(txtEnd.Text, new CultureInfo("en-US", true)));
            }
            _event.EventAddress = newAddress.ID;   //Event's address ID  
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
            //Edit Event Event
            EventServiceClient _editEvent = new EventServiceClient();
            EventModel newEvent = new EventModel();
            newEvent = _editEvent.updateEvent(_event, request);
            bool isCreatedTicket = false;   //Ticket Controller

            EVENT_TRACKER = "Event Edited successfully";
            //Import users
            //string ImportSpreadsheet = "";
            //ImportSpreadsheet = ImportData(flGuest, newEvent.EventID);

            //===================Import guest,staff and products============================//

            string path = "";
            string response = "";
            bool isValidGuestColumn = false;
            bool isValidStaffColumn = false;
            bool isValidProductColumn = false;
            int startColumn = 0;
            int startRow =0;
            ExcelWorksheet GuestworkSheet = null ;
            ExcelWorksheet StaffworkSheet = null;
            ExcelWorksheet ProductworkSheet = null;
            int count = 0;
            if (flGuest.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(flGuest.FileName);
                    string serverLocation = "~/Temp/" + "/" + filename;
                    string SaveLoc = Server.MapPath(serverLocation);
                    flGuest.SaveAs(SaveLoc);
                    path = Server.MapPath("/") + "\\Temp\\" + filename;

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
                    response += "Failed";
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
                        _staff.PASS = "myUpdatedPass";
                        _staff.EventID = newEvent.EventID;
                        //edit to db
                        StaffServiceClient ssv = new StaffServiceClient();
                        bool isCreated = ssv.createStaff(_staff);
                        if (isCreated == true)
                        {
                            count++;
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
                        GuestModel _guest = new GuestModel();
                        _guest.NAME = Name.ToString();
                        _guest.SURNAME = Surname.ToString();
                        _guest.EMAIL = Email.ToString();
                        _guest.PASS = "GuestPass";
                        _guest.TYPE = "Private";
                        Eventrix_Client.Registration reg = new Eventrix_Client.Registration();
                     //   response = reg.RegisterGuest(_guest);
                        sendMsg( _guest, _event);
                        if (response.Contains("successfully"))
                        {
                            count++;
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
                        _product._Price = Convert.ToInt32(Price.ToString());
                        _product.EventID = newEvent.EventID;
                        ProductServiceClient psv = new ProductServiceClient();
                        //  string isProductUpdated = psv.createProduct(_product);
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


            //==============================================================================//
            if (response.Contains("success"))
            {
                EVENT_TRACKER += "\n Spreadsheet Uploaded";
                //Create Tickets
                isCreatedTicket = isLoadedTicket(newEvent, newEvent.EventID);
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
                EVENT_TRACKER += "\n Spreadsheet Uploaded";
                //Create Tickets
                isCreatedTicket = isLoadedTicket(newEvent, newEvent.EventID);
                if (isCreatedTicket == true)
                {
                    EVENT_TRACKER += "\n Ticket Created";
                }
                else
                {
                    EVENT_TRACKER += "\n Failed to upload ticket";
                }
                //Unable to upload guest
                EVENT_TRACKER += "\n failed to upload spreadsheet";
            }

            ////Upload images
            ImageFile mainPic = new ImageFile();
            mainPic = UploadFile(flEventImages, Convert.ToString(newEvent.EventID), SUBFOLDER); //Upload Event Main's Image to client directory
            if(mainPic != null)
            {
                FileUploadClient fuc = new FileUploadClient();
                string res1 = fuc.saveImage(mainPic); //Upload Event Main's Image to Database
                string number = res1;
            }
            Response.Redirect("EventDetails.aspx?EventID=" + newEvent.EventID);

            //  Response.Write("<script> Alert("+ EVENT_TRACKER + ");</script>");
        }

        //importing users
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
                if (columnNames[i].Contains("Name") || columnNames[i].Contains("Surname") || columnNames[i].Contains("Email"))
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
        string ImportData(FileUpload flInfo, int EventID)
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
                    string serverLocation = "~/Temp/" + "/" + filename;
                    string SaveLoc = Server.MapPath(serverLocation);
                    flInfo.SaveAs(SaveLoc);
                    path = Server.MapPath("/") + "\\Temp\\" + filename;

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
                        _staff.PASS = "myUpdatedPass";
                        _staff.EventID = EventID;
                        //edit to db
                        StaffServiceClient ssv = new StaffServiceClient();
                        bool isCreated = ssv.createStaff(_staff);
                        if (isCreated == true)
                        {
                            count++;
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
                        GuestModel _guest = new GuestModel();
                        _guest.NAME = Name.ToString();
                        _guest.SURNAME = Surname.ToString();
                        _guest.EMAIL = Email.ToString();
                        _guest.PASS = "GuestPass";
                        _guest.TYPE = "Private";
                        Eventrix_Client.Registration reg = new Eventrix_Client.Registration();
                      //  response = reg.RegisterGuest(_guest);
                        if (response.Contains("successfully"))
                        {
                            count++;
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
                        _product._Desc = Description.ToString();
                        _product._Quantity = Convert.ToInt32(Quantity.ToString());
                        _product._Price = Convert.ToInt32(Price.ToString());
                        _product.EventID = EventID;
                        ProductServiceClient psv = new ProductServiceClient();
                        //  string isProductUpdated = psv.createProduct(_product);
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

            //Directory.Delete(path, true);
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
            {
                return null;
            }
        }

        //====================Editing ticket=====================================
        //=======================================================================
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
                EB_SDate = DateTime.Parse(EB_Startdate, new CultureInfo("en-US", true));
            }

            if (!txtE_ClosingDate.Text.Equals(""))
            {
                EB_EDate = DateTime.Parse(EB_Enddate, new CultureInfo("en-US", true));
            }

            if (!txtR_OpenDate.Text.Equals(""))
            {
                R_SDate = DateTime.Parse(Reg_Startdate, new CultureInfo("en-US", true));
            }

            if (!txtR_ClosingDate.Text.Equals(""))
            {
                R_EDate = DateTime.Parse(Reg_Enddate, new CultureInfo("en-US", true));
            }

            if (!txtV_OpenDate.Text.Equals(""))
            {
                VIP_SDate = DateTime.Parse(V_Startdate, new CultureInfo("en-US", true));
            }

            if (!txtV_ClosingDate.Text.Equals(""))
            {
                VIP_EDate = DateTime.Parse(V_Enddate, new CultureInfo("en-US", true));
            }

            if (!txtVV_OpenDate.Text.Equals(""))
            {
                VVIP_SDate = DateTime.Parse(VV_Startdate, new CultureInfo("en-US", true));
            }

            if (!txtVV_ClosingDate.Text.Equals(""))
            {
                VVIP_EDate = DateTime.Parse(VV_Enddate, new CultureInfo("en-US", true));
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

                    string ticketresponse = tsc.UpdateTiket(EB_Ticket);
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

                    string ticketresponse = tsc.UpdateTiket(R_Ticket);
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

                    string ticketresponse = tsc.UpdateTiket(VIP_Ticket);
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

                    string ticketresponse = tsc.UpdateTiket(VVIP_Ticket);
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
        public bool EditAddress(int ID)
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
            EventAddress addID = mapp.EditAddress(add, Convert.ToString(ID));
            return true;
        }
        protected void makeDirectory(string EventID)
        {
            string directoryPath = Server.MapPath(string.Format("~/{0}/", "Events/" + EventID));

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Directory.CreateDirectory(Path.Combine(directoryPath, "Event_Images"));
                Directory.CreateDirectory(Path.Combine(directoryPath, "Main_Image"));
                Directory.CreateDirectory(Path.Combine(directoryPath, "Uploads"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory already exists.');", true);
            }
        }


        public static void sendMsg(GuestModel _guest, EventModel _event)
        {

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("mtumelo2011@gmail.com", "Tsm5surprise11");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Invitation";
            msg.Body = "Hello " + _guest.NAME + ", You have been invited to " + _event.Name;
            msg.Body += "<tr>";
            msg.Body += "<td>Event Details</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Please use the details below to RSVP:</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>User Name :" + _guest.EMAIL + "</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            //msg.Body += "<td>One Time Password:" + random + "</td>";
            msg.Body += "</tr>";

            msg.Body += "<tr>";
            msg.Body += "<td>Kind Regards,</td><td>TNT Team</td>";
            msg.Body += "</tr>";

            string toAddress = _guest.EMAIL; // Add Recepient address
            msg.To.Add(toAddress);
            msg.To.Add(new MailAddress(toAddress));

            string FromAddress = "mtumelo2011@gmail.com";
            msg.From = new MailAddress(FromAddress);
            msg.IsBodyHtml = true;


            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model.ClientDefinition.Survey;
using Eventrix_Client.Model.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype_TNT_Der1
{
    public partial class EventSurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                //createSurvey
                //eventDesc
                int eventID = Convert.ToInt32(Request.QueryString["eventID"]);
                EventServiceClient eventClient = new EventServiceClient();
                EventModel _event = eventClient.findByEventID(Convert.ToString(eventID));
                eventDesc.InnerHtml = _event.Name + " Survey";
        
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
                int eventID = Convert.ToInt32(Request.QueryString["eventID"]);
                SurveyServiceClient surveyClient = new SurveyServiceClient();
                Survey _surv = new Survey();
                _surv.E_ID = eventID;
                int surveyID = surveyClient.createSurvey(_surv);
                 _surv.S_ID = surveyID;
                if (surveyID != 0)
                {
                    //Overal Satisfaction
                    if (OS_VeryDisa.Checked == true)
                    {
                        _surv.veryDissatisfied = 1;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Overall_Satisfaction(_surv);
                    }
                    else if (OS_Disa.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 1;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Overall_Satisfaction(_surv);
                    }
                    else if (OS_Neutral.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 1;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Overall_Satisfaction(_surv);
                    }
                    else if (OS_Satis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 1;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Overall_Satisfaction(_surv);
                    }
                    else if (OS_VerySatis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 1;
                        bool isCreated = surveyClient.Rec_Overall_Satisfaction(_surv);
                    }

                    //Overall satisfaction with respective aspect
                    //Date
                    if (Date_VeryDis.Checked == true)
                    {
                        _surv.veryDissatisfied = 1;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Date(_surv);
                    }
                    else if (Date_Disat.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 1;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Date(_surv);
                    }
                    else if (Date_Neutral.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 1;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Date(_surv);
                    }
                    else if (Date_Satis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 1;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Date(_surv);
                    }
                    else if (Date_VerySatis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 1;
                        bool isCreated = surveyClient.Rec_Date(_surv);
                    }

                    //Location
                    if (Loc_VeryDisat.Checked == true)
                    {
                        _surv.veryDissatisfied = 1;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Location(_surv);
                    }
                    else if (Loc_Disatis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 1;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Location(_surv);
                    }
                    else if (Loc_Neutral.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 1;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Location(_surv);
                    }
                    else if (Loc_Satis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 1;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Location(_surv);
                    }
                    else if (Loc_VerySatis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 1;
                        bool isCreated = surveyClient.Rec_Location(_surv);
                    }
                    //Session
                    if (Ses_VeryDis.Checked == true)
                    {
                        _surv.veryDissatisfied = 1;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Session(_surv);
                    }
                    else if (Ses_Dis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 1;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Session(_surv);
                    }
                    else if (Ses_Neutral.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 1;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Session(_surv);
                    }
                    else if (Ses_Satis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 1;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Session(_surv);
                    }
                    else if (Ses_VerySatis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 1;
                        bool isCreated = surveyClient.Rec_Session(_surv);
                    }
                    //Speakers
                    if (Spk_VeryDisat.Checked == true)
                    {
                        _surv.veryDissatisfied = 1;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Speaker(_surv);
                    }
                    else if (Spk_Dis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 1;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Speaker(_surv);
                    }
                    else if (Spk_Neutral.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 1;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Speaker(_surv);
                    }
                    else if (Spk_Satis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 1;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Speaker(_surv);
                    }
                    else if (Spk_VerySatis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 1;
                        bool isCreated = surveyClient.Rec_Speaker(_surv);
                    }
                    //Vendors
                    if (Ven_VeryDis.Checked == true)
                    {
                        _surv.veryDissatisfied = 1;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Vendor(_surv);
                    }
                    else if (Ven_Dis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 1;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Vendor(_surv);
                    }
                    else if (Ven_Neutral.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 1;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Vendor(_surv);
                    }
                    else if (Ven_Satis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 1;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Vendor(_surv);
                    }
                    else if (Ven_VerySatis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 1;
                        bool isCreated = surveyClient.Rec_Vendor(_surv);
                    }
                    //Food
                    if (Fd_VeryDis.Checked == true)
                    {
                        _surv.veryDissatisfied = 1;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Food(_surv);
                    }
                    else if (Fd_Dis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 1;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Food(_surv);
                    }
                    else if (Fd_Neutral.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 1;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Food(_surv);
                    }
                    else if (Fd_Satis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 1;
                        _surv.VerySatisfied = 0;
                        bool isCreated = surveyClient.Rec_Food(_surv);
                    }
                    else if (Fd_VerySatis.Checked == true)
                    {
                        _surv.veryDissatisfied = 0;
                        _surv.Dissatisfied = 0;
                        _surv.Neutral = 0;
                        _surv.Satisfied = 0;
                        _surv.VerySatisfied = 1;
                        bool isCreated = surveyClient.Rec_Food(_surv);
                    }
                  //  //Liked Most
                  //  if (txtLikedMost.Value != null)
                  //  {
                  //      _surv.Long_LikedMost = txtLikedMost.Value;
                  //  }
                  //  //Liked Least
                  //  if (txtLikedLeast.Value != null)
                  //  {
                  //      _surv.Long_LikedLeast = txtLikedLeast.Value;
                  //  }
                  //  //Improvement
                  //  if (txtImprovement.Value != null)
                  //  {
                  //      _surv.Long_Improvement = txtImprovement.Value;
                  //  }
                  //  //Comments
                  //  if (txtComments.Value != null)
                  //  {
                  //      _surv.Long_Other_Suggestion = txtComments.Value;
                  //  }
                  ////  bool isLongQuizCreated = surveyClient.Rec_Long_Quiz(_surv);
                    //First time attending event
                    if (FT_Yes.Checked == true)
                    {
                        _surv.Yes = 1;
                        _surv.No = 0;
                        bool isCreated = surveyClient.Rec_FirstTime(_surv);
                    }
                    else
                    {
                        _surv.Yes = 0;
                        _surv.No = 1;
                        bool isCreated = surveyClient.Rec_FirstTime(_surv);
                    }
                    //Likely to attend future events
                    if (Future_NotLikelyAtAll.Checked == true)
                    {
                        _surv.NotLikely = 1;
                        _surv.Neutral = 0;
                        _surv.Likely = 0;
                        _surv.VeryLikely = 0;
                        bool isCreated = surveyClient.Rec_FutureAttendence(_surv);
                    }
                    else if (Future_NotLikely.Checked == true)
                    {
                        _surv.NotLikely = 1;
                        _surv.Neutral = 0;
                        _surv.Likely = 0;
                        _surv.NotLikely = 0;
                        bool isCreated = surveyClient.Rec_FutureAttendence(_surv);
                    }
                    else if (Future_Neutral.Checked == true)
                    {
                        _surv.NotLikely = 0;
                        _surv.Neutral = 1;
                        _surv.Likely = 0;
                        _surv.VeryLikely = 0;
                        bool isCreated = surveyClient.Rec_FutureAttendence(_surv);
                    }
                    else if (Future_Likely.Checked == true)
                    {
                        _surv.NotLikely = 0;
                        _surv.Neutral = 0;
                        _surv.Likely = 1;
                        _surv.VeryLikely = 0;
                        bool isCreated = surveyClient.Rec_FutureAttendence(_surv);
                    }
                    else if (Future_VeryLikely.Checked == true)
                    {
                        _surv.NotLikely = 0;
                        _surv.Neutral = 0;
                        _surv.Likely = 0;
                        _surv.VeryLikely = 1;
                        bool isCreated = surveyClient.Rec_FutureAttendence(_surv);
                    }
                    //Recommend a friend?
                    if (RecFriend_NotLikelyAtAll.Checked == true)
                    {
                        _surv.NotLikely = 1;
                        _surv.Neutral = 0;
                        _surv.Likely = 0;
                        _surv.VeryLikely = 0;
                        bool isCreated = surveyClient.Rec_Recommendation(_surv);
                    }
                    else if (RecFriend_NotLikely.Checked == true)
                    {
                        _surv.NotLikely = 1;
                        _surv.Neutral = 0;
                        _surv.Likely = 0;
                        _surv.NotLikely = 0;
                        bool isCreated = surveyClient.Rec_Recommendation(_surv);
                    }
                    else if (RecFriend_Neutral.Checked == true)
                    {
                        _surv.NotLikely = 0;
                        _surv.Neutral = 1;
                        _surv.Likely = 0;
                        _surv.VeryLikely = 0;
                        bool isCreated = surveyClient.Rec_Recommendation(_surv);
                    }
                    else if (RecFriend_Likely.Checked == true)
                    {
                        _surv.NotLikely = 0;
                        _surv.Neutral = 0;
                        _surv.Likely = 1;
                        _surv.VeryLikely = 0;
                        bool isCreated = surveyClient.Rec_Recommendation(_surv);
                    }
                    else if (RecFriend_VeryLikely.Checked == true)
                    {
                        _surv.NotLikely = 0;
                        _surv.Neutral = 0;
                        _surv.Likely = 0;
                        _surv.VeryLikely = 1;
                        bool isCreated = surveyClient.Rec_Recommendation(_surv);
                    }


                Response.Redirect("EventDetails.aspx?ev=" + eventID);
                }
                else
                {
                    //Something went wrong
                }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string check = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            string check = "";
        }
    }
}
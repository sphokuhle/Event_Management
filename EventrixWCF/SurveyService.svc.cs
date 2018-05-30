using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eventrix_Client.Model.ClientDefinition;
using Eventrix_Client.Model.ClientDefinition.Survey;

namespace EventrixWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SurveyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SurveyService.svc or SurveyService.svc.cs at the Solution Explorer and start debugging.
    public class SurveyService : ISurveyService
    {
        /// <summary>
        /// Create Survey instance for the briding table
        /// </summary>
        /// <param name="_surv"></param>
        /// <returns></returns>
        public int createAnswers(Survey _surv)
        {
            int eventID = Convert.ToInt32(_surv.E_ID);
            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {

                    int query = (from quiz in db.SURVEYs
                                 where quiz.E_ID.Equals(eventID)
                                 select quiz).Count();
                    if (query == 0)
                    {
                        SURVEY toInsert = new SURVEY();
                        toInsert.E_ID = eventID;
                        db.SURVEYs.InsertOnSubmit(toInsert);
                        db.SubmitChanges();
                    }
                    else
                    {
                        SURVEY query2 = (from quiz in db.SURVEYs
                                         where quiz.E_ID.Equals(eventID)
                                         select quiz).Single();
                        return query2.S_Id;
                    }

                };

                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {

                    var query = (from quiz in db.SURVEYs
                                 where quiz.E_ID.Equals(eventID)
                                 select quiz).First();
                    int surveyID = query.S_Id;
                    return surveyID;

                };
            }
            catch(Exception)
            {
                return 0;
            }
          
        }

  

        /// <summary>
        /// record answers from survey filled by guest by incrementing the count of each option selected.
        /// by default, if no option is chosen, the first choice will be recorded.
        /// </summary>
        /// <param name="_surv"></param>
        /// <returns></returns>
        //public bool InsertAnswers(Survey _surv)
        //{
        //    bool Date = Rec_Date(_surv);
        //    bool FirstTimeVisit = Rec_FirstTime(_surv);
        //    bool FoodImpression = Rec_Food(_surv);
        //    bool FutureAttendence = Rec_FutureAttendence(_surv);
        //    bool LocationImpression = Rec_Location(_surv);
        //    bool LongQuiz = Rec_Long_Quiz(_surv);
        //    bool Overall = Rec_Overall_Satisfaction(_surv);
        //    bool recomment = Rec_Recommendation(_surv);
        //    bool isSession = Rec_Session(_surv);

        //    if(Date == true && FirstTimeVisit == true && FoodImpression == true 
        //        && FutureAttendence == true && LocationImpression == true 
        //        && LongQuiz == true && Overall == true && recomment == true && isSession == true)
        //    {
        //        return true;
        //    }else
        //    {
        //        return false;
        //    }
        //}

        public bool Rec_Date(Survey _surv)
        {
            int surveyID = Convert.ToInt32(_surv.S_ID);
           // int Q_ID = Convert.ToInt32(_surv.ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _query = (from res in db.DATEs
                                 where res.S_Id.Equals(surveyID)
                                 select res).Count();
                    if (_query == 0) //Create New Answer
                    {
                        DATE toinsert = new DATE();
                        toinsert.S_Id = _surv.S_ID;
                        toinsert.Very_Dissatisfied = _surv.veryDissatisfied;
                        toinsert.Dissatisfied = _surv.Dissatisfied;
                        toinsert.Neutral = _surv.Neutral;
                        toinsert.Very_Satisfied = _surv.VerySatisfied;
                        toinsert.Satisfied = _surv.Satisfied;
                        db.DATEs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return true;
                    }else //Update Record
                    {
                        DATE query = (from res in db.DATEs
                                      where res.S_Id.Equals(surveyID)
                                      select res).First();
                        query.Very_Dissatisfied += _surv.veryDissatisfied;
                        query.Dissatisfied += _surv.Dissatisfied;
                        query.Neutral += _surv.Neutral;
                        query.Satisfied += _surv.Neutral;
                        query.Very_Satisfied += _surv.VerySatisfied;
                        db.SubmitChanges();
                        return true;
                    }
                }
                catch(Exception)
                {
                    return false;
                }
            };
        }

        public bool Rec_FirstTime(Survey _surv)
        {
            int surveyID = Convert.ToInt32(_surv.S_ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _query = (from res in db.FIRST_TIMEs
                                        where res.S_Id.Equals(surveyID)
                                  select res).Count();
                    if (_query == 0) //Create New Answer
                    {
                        FIRST_TIME toinsert = new FIRST_TIME();
                        toinsert.S_Id = _surv.S_ID;
                        toinsert.Yes = _surv.Yes;
                        toinsert.No = _surv.No;
                        db.FIRST_TIMEs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return true;
                    }
                    else //Update Record
                    {
                        var query = (from res in db.FIRST_TIMEs
                                     where res.S_Id.Equals(surveyID)
                                     select res).First();
                        query.Yes += _surv.Yes;
                        query.No += _surv.No;
                        
                        db.SubmitChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public bool Rec_Food(Survey _surv)
        {
            int surveyID = Convert.ToInt32(_surv.S_ID);
            int Q_ID = Convert.ToInt32(_surv.ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _query = (from res in db.FOODs
                                        where res.S_Id.Equals(surveyID)
                                        select res).Count();
                    if (_query == 0) //Create New Answer
                    {
                        FOOD toinsert = new FOOD();
                        toinsert.S_Id = _surv.S_ID;
                        toinsert.Very_Dissatisfied = _surv.veryDissatisfied;
                        toinsert.Dissatisfied = _surv.Dissatisfied;
                        toinsert.Neutral = _surv.Neutral;
                        toinsert.Very_Satisfied = _surv.VerySatisfied;
                        toinsert.Satisfied = _surv.Satisfied;

                        db.FOODs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return true;
                    }
                    else //Update Record
                    {
                        FOOD query = (from res in db.FOODs
                                      where res.S_Id.Equals(surveyID)
                                      select res).First();
                        query.Very_Dissatisfied += _surv.veryDissatisfied;
                        query.Dissatisfied += _surv.veryDissatisfied;
                        query.Neutral += _surv.Neutral;
                        query.Satisfied += _surv.Satisfied;
                        query.Very_Satisfied += _surv.VerySatisfied;

                        db.SubmitChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public bool Rec_FutureAttendence(Survey _surv)
        {
            int surveyID = Convert.ToInt32(_surv.S_ID);
            int Q_ID = Convert.ToInt32(_surv.ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _query = (from res in db.FUTURE_ATTENDANCEs
                                               where res.S_Id.Equals(surveyID)
                                  select res).Count();
                    if (_query == 0) //Create New Answer
                    {
                        FUTURE_ATTENDANCE toinsert = new FUTURE_ATTENDANCE();
                        toinsert.S_Id = _surv.S_ID;
                        toinsert.Not_Likely = _surv.NotLikely;
                        toinsert.Neutral = _surv.Neutral;
                        toinsert.Likey = _surv.Likely;
                        toinsert.Very_Likey = _surv.VeryLikely;

                        db.FUTURE_ATTENDANCEs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return true;
                    }
                    else //Update Record
                    {
                        FUTURE_ATTENDANCE query = (from res in db.FUTURE_ATTENDANCEs
                                                   where res.S_Id.Equals(surveyID)
                                                   select res).First();
                        query.Not_Likely += _surv.NotLikely;
                        query.Neutral += _surv.Neutral;
                        query.Likey += _surv.Likely;
                        query.Very_Likey += _surv.VeryLikely;

                        db.SubmitChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public bool Rec_Location(Survey _surv)
        {
            int surveyID = Convert.ToInt32(_surv.S_ID);
            int Q_ID = Convert.ToInt32(_surv.ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _query = (from res in db.LOCATIONs
                                               where res.S_Id.Equals(surveyID)
                                               select res).Count();
                    if (_query == 0) //Create New Answer
                    {
                        LOCATION toinsert = new LOCATION();
                        toinsert.S_Id = _surv.S_ID;
                        toinsert.Very_Dissatisfied = _surv.veryDissatisfied;
                        toinsert.Dissatisfied = _surv.Dissatisfied;
                        toinsert.Neutral = _surv.Neutral;
                        toinsert.Very_Satisfied = _surv.VerySatisfied;
                        toinsert.Satisfied = _surv.Satisfied;

                        db.LOCATIONs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return true;
                    }
                    else //Update Record
                    {
                        LOCATION query = (from res in db.LOCATIONs
                                          where res.S_Id.Equals(surveyID)
                                          select res).First();
                        query.Very_Dissatisfied += _surv.veryDissatisfied;
                        query.Dissatisfied += _surv.Dissatisfied;
                        query.Neutral += _surv.Neutral;
                        query.Satisfied += _surv.Satisfied;
                        query.Very_Satisfied += _surv.VerySatisfied;
                        db.SubmitChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public bool Rec_Long_Quiz(Survey _surv)
        {
            int surveyID = Convert.ToInt32(_surv.S_ID);
            int Q_ID = Convert.ToInt32(_surv.ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _query = (from res in db.LONG_QUESTIONs
                                           where res.S_Id.Equals(surveyID)
                                      select res).Count();
                    if (_query == 0) //Create New Answer
                    {
                        LONG_QUESTION toinsert = new LONG_QUESTION();
                        toinsert.S_Id = _surv.S_ID;
                        toinsert.LikedMost = "NULL";
                        toinsert.LikedLeast = "NULL";
                        toinsert.Other_Suggestion = "NULL";
                        toinsert.Improvement = "NULL";

                        db.LONG_QUESTIONs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return true;
                    }
                    else //Update Record
                    {
                        LONG_QUESTION query = (from res in db.LONG_QUESTIONs
                                               where res.S_Id.Equals(surveyID)
                                               select res).First();
                        query.LikedLeast = _surv.Long_LikedLeast;
                        query.LikedMost = _surv.Long_LikedMost;
                        query.Other_Suggestion = _surv.Long_Other_Suggestion;
                        query.Improvement = _surv.Long_Improvement;
                        db.SubmitChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public bool Rec_Overall_Satisfaction(Survey _surv)
        {
            int surveyID = Convert.ToInt32(_surv.S_ID);
          //  int Q_ID = Convert.ToInt32(_surv.ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {

                    int _query = (from res in db.OVERALL_SATISFACTIONs
                                                  where res.S_Id.Equals(surveyID)
                                      select res).Count();
                    if (_query == 0) //Create New Answer
                    {
                        OVERALL_SATISFACTION toinsert = new OVERALL_SATISFACTION();
                        toinsert.S_Id = _surv.S_ID;
                        toinsert.Very_Dissatisfied = _surv.veryDissatisfied;
                        toinsert.Dissatisfied = _surv.Dissatisfied;
                        toinsert.Neutral = _surv.Neutral;
                        toinsert.Very_Satisfied = _surv.VerySatisfied;
                        toinsert.Satisfied = _surv.Satisfied;

                        db.OVERALL_SATISFACTIONs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return true;
                    }
                    else //Update Record
                    {

                    OVERALL_SATISFACTION query = (from res in db.OVERALL_SATISFACTIONs
                                 where res.S_Id.Equals(surveyID)
                                 select res).FirstOrDefault();
                         query.Very_Dissatisfied += _surv.veryDissatisfied;
                        query.Dissatisfied += _surv.Dissatisfied;
                        query.Neutral += _surv.Neutral;
                        query.Satisfied += _surv.Satisfied;
                        query.Very_Satisfied += _surv.VerySatisfied;
                        db.SubmitChanges();
                        return true;
                    }
               
            };
        }

        public bool Rec_Recommendation(Survey _surv)
        {
            int surveyID = Convert.ToInt32(_surv.S_ID);
          //  int Q_ID = Convert.ToInt32(_surv.ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _query = (from res in db.RECOMMENDATIONs
                                            where res.S_Id.Equals(surveyID)
                                               select res).Count();
                    if (_query == 0) //Create New Answer
                    {
                        RECOMMENDATION toinsert = new RECOMMENDATION();
                        toinsert.S_Id = _surv.S_ID;
                        toinsert.Not_Likely = _surv.NotLikely;
                        toinsert.Neutral = _surv.Neutral;
                        toinsert.Likey = _surv.Likely;
                        toinsert.Very_Likey = _surv.VeryLikely;

                        db.RECOMMENDATIONs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return true;
                    }
                    else //Update Record
                    {
                        RECOMMENDATION query = (from res in db.RECOMMENDATIONs
                                                where res.S_Id.Equals(surveyID)
                                                select res).First();
                        query.Not_Likely += _surv.NotLikely;
                        query.Neutral += _surv.Neutral;
                        query.Likey += _surv.Likely;
                        query.Very_Likey += _surv.VeryLikely;

                        db.SubmitChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public bool Rec_Session(Survey _surv)
        {
            int surveyID = Convert.ToInt32(_surv.S_ID);
            int Q_ID = Convert.ToInt32(_surv.ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _query = (from res in db.SESSIONs
                                     where res.S_Id.Equals(surveyID)
                                                  select res).Count();
                    if (_query == 0) //Create New Answer
                    {
                        SESSION toinsert = new SESSION();
                        toinsert.S_Id = _surv.S_ID;
                        toinsert.Very_Dissatisfied = _surv.veryDissatisfied;
                        toinsert.Dissatisfied = _surv.Dissatisfied;
                        toinsert.Neutral = _surv.Neutral;
                        toinsert.Very_Satisfied = _surv.VerySatisfied;
                        toinsert.Satisfied = _surv.Satisfied;

                        db.SESSIONs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return true;
                    }
                    else //Update Record
                    {
                        SESSION query = (from res in db.SESSIONs
                                         where res.S_Id.Equals(surveyID)
                                         select res).First();
                        query.Very_Dissatisfied += _surv.veryDissatisfied;
                        query.Dissatisfied += _surv.Dissatisfied;
                        query.Neutral += _surv.Neutral;
                        query.Satisfied += _surv.Satisfied;
                        query.Very_Satisfied += _surv.VerySatisfied;
                        db.SubmitChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public bool Rec_Speaker(Survey _surv)
        {
            int surveyID = Convert.ToInt32(_surv.S_ID);
            int Q_ID = Convert.ToInt32(_surv.ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _query = (from res in db.SPEAKERs
                                     where res.S_Id.Equals(surveyID)
                                     select res).Count();
                    if (_query == 0) //Create New Answer
                    {
                        SPEAKER toinsert = new SPEAKER();
                        toinsert.S_Id = _surv.S_ID;
                        toinsert.Very_Dissatisfied = _surv.veryDissatisfied;
                        toinsert.Dissatisfied = _surv.Dissatisfied;
                        toinsert.Neutral = _surv.Neutral;
                        toinsert.Very_Satisfied = _surv.VerySatisfied;
                        toinsert.Satisfied = _surv.Satisfied;

                        db.SPEAKERs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return true;
                    }
                    else //Update Record
                    {
                        SPEAKER query = (from res in db.SPEAKERs
                                         where res.S_Id.Equals(surveyID)
                                         select res).First();
                        query.Very_Dissatisfied += _surv.veryDissatisfied;
                        query.Dissatisfied += _surv.Dissatisfied;
                        query.Neutral += _surv.Neutral;
                        query.Satisfied += _surv.Satisfied;
                        query.Very_Satisfied += _surv.VerySatisfied;
                        db.SubmitChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public bool Rec_Vendor(Survey _surv)
        {
            int surveyID = Convert.ToInt32(_surv.S_ID);
            int Q_ID = Convert.ToInt32(_surv.ID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    int _query = (from res in db.VENDORs
                                    where res.S_Id.Equals(surveyID)
                                     select res).Count();
                    if (_query == 0) //Create New Answer
                    {
                        VENDOR toinsert = new VENDOR();
                        toinsert.S_Id = _surv.S_ID;
                        toinsert.Very_Dissatisfied = _surv.veryDissatisfied;
                        toinsert.Dissatisfied = _surv.Dissatisfied;
                        toinsert.Neutral = _surv.Neutral;
                        toinsert.Very_Satisfied = _surv.VerySatisfied;
                        toinsert.Satisfied = _surv.Satisfied;

                        db.VENDORs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return true;
                    }
                    else //Update Record
                    {
                        VENDOR query = (from res in db.VENDORs
                                        where res.S_Id.Equals(surveyID)
                                        select res).First();
                        query.Very_Dissatisfied += _surv.veryDissatisfied;
                        query.Dissatisfied += _surv.Dissatisfied;
                        query.Neutral += _surv.Neutral;
                        query.Satisfied += _surv.Satisfied;
                        query.Very_Satisfied += _surv.VerySatisfied;
                        db.SubmitChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        //=============================-----Get-Record----==============================
        public List<int> GetAnswer(string type, string eventID)
        {

            int survID = GetSurveyID(eventID);
            if(survID == 0)
            {
                return null;
            }

            try
            {
                if (type.Equals("Overal_Satis"))
                {
                    return getOveral_Satis(survID);
                }
                else if (type.Equals("Date"))
                {
                    return getDate_Satis(survID);
                }
                else if (type.Equals("First_Time"))
                {
                    return getFirstTime_Satis(survID);
                }
                else if (type.Equals("Food"))
                {
                    return getFood_Satis(survID);
                }
                else if (type.Equals("Future_Attendance"))
                {
                    return getFuture_Attendance_Satis(survID);
                }
                else if (type.Equals("Location"))
                {
                    return getLocation_Satis(survID);
                }
                else if (type.Equals("Recommendation"))
                {
                    return getRecommendation_Satis(survID);
                }
                else if (type.Equals("Session"))
                {
                    return getSession_Satis(survID);
                }
                else if (type.Equals("Speaker"))
                {
                    return getSpeaker_Satis(survID);
                }
                else if (type.Equals("Vendor"))
                {
                    return getVendor_Satis(survID);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<int> getOveral_Satis(int survID)
        {
            List<int> data = new List<int>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var query = (from res in db.OVERALL_SATISFACTIONs
                             where res.S_Id.Equals(survID)
                             select new Survey
                             {
                                 S_ID = Convert.ToInt32(res.S_Id),
                                 ID = Convert.ToInt32(res.Id),
                                 veryDissatisfied = Convert.ToInt32(res.Very_Dissatisfied),
                                 Dissatisfied = Convert.ToInt32(res.Dissatisfied),
                                 Neutral = Convert.ToInt32(res.Neutral),
                                 Satisfied = Convert.ToInt32(res.Satisfied),
                                 VerySatisfied  =Convert.ToInt32(res.Very_Satisfied),
                             }).ToList();
                foreach(Survey _surv in query)
                {
                    data.Add(_surv.veryDissatisfied);
                    data.Add(_surv.Dissatisfied);
                    data.Add(_surv.Neutral);
                    data.Add(_surv.Satisfied);
                    data.Add(_surv.VerySatisfied);
                }
                return data;
            };
        }

        public List<int> getDate_Satis(int survID)
        {
            List<int> data = new List<int>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var query = (from res in db.DATEs
                             where res.S_Id.Equals(survID)
                             select new Survey
                             {
                                 S_ID = Convert.ToInt32(res.S_Id),
                                 ID = Convert.ToInt32(res.Id),
                                 veryDissatisfied = Convert.ToInt32(res.Very_Dissatisfied),
                                 Dissatisfied = Convert.ToInt32(res.Dissatisfied),
                                 Neutral = Convert.ToInt32(res.Neutral),
                                 Satisfied = Convert.ToInt32(res.Satisfied),
                                 VerySatisfied = Convert.ToInt32(res.Very_Satisfied),
                             }).ToList();
                foreach (Survey _surv in query)
                {
                    data.Add(_surv.veryDissatisfied);
                    data.Add(_surv.Dissatisfied);
                    data.Add(_surv.Neutral);
                    data.Add(_surv.Satisfied);
                    data.Add(_surv.VerySatisfied);
                }
                return data;
            };
        }
        public List<int> getFirstTime_Satis(int survID)
        {
            List<int> data = new List<int>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var query = (from res in db.FIRST_TIMEs
                             where res.S_Id.Equals(survID)
                             select new Survey
                             {
                                 S_ID = Convert.ToInt32(res.S_Id),
                                 ID = Convert.ToInt32(res.Id),
                                 Yes = Convert.ToInt32(res.Yes),
                                 No = Convert.ToInt32(res.No),
                             }).ToList();
                foreach(Survey _surv in query)
                {
                    data.Add(_surv.Yes);
                    data.Add(_surv.No);
                }
                return data;
            };
        }
        public List<int> getFood_Satis(int survID)
        {
            List<int> data = new List<int>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var query = (from res in db.FOODs
                             where res.S_Id.Equals(survID)
                             select new Survey
                             {
                                 S_ID = Convert.ToInt32(res.S_Id),
                                 ID = Convert.ToInt32(res.Id),
                                 veryDissatisfied = Convert.ToInt32(res.Very_Dissatisfied),
                                 Dissatisfied = Convert.ToInt32(res.Dissatisfied),
                                 Neutral = Convert.ToInt32(res.Neutral),
                                 Satisfied = Convert.ToInt32(res.Satisfied),
                                 VerySatisfied = Convert.ToInt32(res.Very_Satisfied),
                             }).ToList();
                foreach (Survey _surv in query)
                {
                    data.Add(_surv.veryDissatisfied);
                    data.Add(_surv.Dissatisfied);
                    data.Add(_surv.Neutral);
                    data.Add(_surv.Satisfied);
                    data.Add(_surv.VerySatisfied);
                }
                return data;
            };
        }

        public List<int> getFuture_Attendance_Satis(int survID)
        {
            List<int> data = new List<int>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var query = (from res in db.FUTURE_ATTENDANCEs
                             where res.S_Id.Equals(survID)
                             select new Survey
                             {
                                 S_ID = Convert.ToInt32(res.S_Id),
                                 ID = Convert.ToInt32(res.Id),
                                 NotLikely = Convert.ToInt32(res.Not_Likely),
                                 Neutral = Convert.ToInt32(res.Neutral),
                                 Likely = Convert.ToInt32(res.Likey),
                                 VeryLikely = Convert.ToInt32(res.Very_Likey),
                             }).ToList();
                foreach(Survey _surv in query)
                {
                    data.Add(_surv.NotLikely);
                    data.Add(_surv.Neutral);
                    data.Add(_surv.Likely);
                    data.Add(_surv.VeryLikely);
                }
                return data;
            };
        }

        public List<int> getLocation_Satis(int survID)
        {
            List<int> data = new List<int>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var query = (from res in db.LOCATIONs
                             where res.S_Id.Equals(survID)
                             select new Survey
                             {
                                 S_ID = Convert.ToInt32(res.S_Id),
                                 ID = Convert.ToInt32(res.Id),
                                 veryDissatisfied = Convert.ToInt32(res.Very_Dissatisfied),
                                 Dissatisfied = Convert.ToInt32(res.Dissatisfied),
                                 Neutral = Convert.ToInt32(res.Neutral),
                                 Satisfied = Convert.ToInt32(res.Satisfied),
                                 VerySatisfied = Convert.ToInt32(res.Very_Satisfied),
                             }).ToList();
                foreach (Survey _surv in query)
                {
                    data.Add(_surv.veryDissatisfied);
                    data.Add(_surv.Dissatisfied);
                    data.Add(_surv.Neutral);
                    data.Add(_surv.Satisfied);
                    data.Add(_surv.VerySatisfied);
                }
                return data;
            };
        }

        public List<int> getRecommendation_Satis(int survID)
        {
            List<int> data = new List<int>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var query = (from res in db.RECOMMENDATIONs
                             where res.S_Id.Equals(survID)
                             select new Survey
                             {
                                 S_ID = Convert.ToInt32(res.S_Id),
                                 ID = Convert.ToInt32(res.Id),
                                 NotLikely = Convert.ToInt32(res.Not_Likely),
                                 Neutral = Convert.ToInt32(res.Neutral),
                                 Likely = Convert.ToInt32(res.Likey),
                                 VeryLikely = Convert.ToInt32(res.Very_Likey),
                             }).ToList();
                foreach(Survey _surv in query)
                {
                    data.Add(_surv.NotLikely);
                    data.Add(_surv.Neutral);
                    data.Add(_surv.Likely);
                    data.Add(_surv.VeryLikely);
                }
                return data;
            };
        }
        public List<int> getSession_Satis(int survID)
        {
            List<int> data = new List<int>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var query = (from res in db.SESSIONs
                             where res.S_Id.Equals(survID)
                             select new Survey
                             {
                                 S_ID = Convert.ToInt32(res.S_Id),
                                 ID = Convert.ToInt32(res.Id),
                                 veryDissatisfied = Convert.ToInt32(res.Very_Dissatisfied),
                                 Dissatisfied = Convert.ToInt32(res.Dissatisfied),
                                 Neutral = Convert.ToInt32(res.Neutral),
                                 Satisfied = Convert.ToInt32(res.Satisfied),
                                 VerySatisfied = Convert.ToInt32(res.Very_Satisfied),
                             }).ToList();
                foreach (Survey _surv in query)
                {
                    data.Add(_surv.veryDissatisfied);
                    data.Add(_surv.Dissatisfied);
                    data.Add(_surv.Neutral);
                    data.Add(_surv.Satisfied);
                    data.Add(_surv.VerySatisfied);
                }
                return data;
            };
        }
        public List<int> getSpeaker_Satis(int survID)
        {
            List<int> data = new List<int>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var query = (from res in db.SPEAKERs
                             where res.S_Id.Equals(survID)
                             select new Survey
                             {
                                 S_ID = Convert.ToInt32(res.S_Id),
                                 ID = Convert.ToInt32(res.Id),
                                 veryDissatisfied = Convert.ToInt32(res.Very_Dissatisfied),
                                 Dissatisfied = Convert.ToInt32(res.Dissatisfied),
                                 Neutral = Convert.ToInt32(res.Neutral),
                                 Satisfied = Convert.ToInt32(res.Satisfied),
                                 VerySatisfied = Convert.ToInt32(res.Very_Satisfied),
                             }).ToList();
                foreach (Survey _surv in query)
                {
                    data.Add(_surv.veryDissatisfied);
                    data.Add(_surv.Dissatisfied);
                    data.Add(_surv.Neutral);
                    data.Add(_surv.Satisfied);
                    data.Add(_surv.VerySatisfied);
                }
                return data;
            };
        }
        public List<int> getVendor_Satis(int survID)
        {
            List<int> data = new List<int>();
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                var query = (from res in db.VENDORs
                             where res.S_Id.Equals(survID)
                             select new Survey
                             {
                                 S_ID = Convert.ToInt32(res.S_Id),
                                 ID = Convert.ToInt32(res.Id),
                                 veryDissatisfied = Convert.ToInt32(res.Very_Dissatisfied),
                                 Dissatisfied = Convert.ToInt32(res.Dissatisfied),
                                 Neutral = Convert.ToInt32(res.Neutral),
                                 Satisfied = Convert.ToInt32(res.Satisfied),
                                 VerySatisfied = Convert.ToInt32(res.Very_Satisfied),
                             }).ToList();
                foreach (Survey _surv in query)
                {
                    data.Add(_surv.veryDissatisfied);
                    data.Add(_surv.Dissatisfied);
                    data.Add(_surv.Neutral);
                    data.Add(_surv.Satisfied);
                    data.Add(_surv.VerySatisfied);
                }
                return data;
            };
        }

        /// <summary>
        /// function to recieve event id and return corresponding survey ID
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns>integer</returns>
        public int GetSurveyID(string eventID)
        {
            int E_ID = Convert.ToInt32(eventID);
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from res in db.SURVEYs where res.E_ID.Equals(E_ID) select res).First();
                    if(query != null)
                    {
                        return query.S_Id;
                    }else
                    {
                        return 0;
                    }
                }catch(Exception)
                {
                    return 0;
                }
            };
        }

        //=============---Delete Reord--==========================
        public bool dl_Survey(string eventID)
        {
            int _id = Convert.ToInt32(eventID);
            int S_ID = GetSurveyID(eventID);
            if(S_ID == 0)
            {
                return true;
            }

            try
            {
                using (EventrixDBDataContext db = new EventrixDBDataContext())
                {
                    dl_Date(S_ID);
                    dl_FirstTime(S_ID);
                    dl_Food(S_ID);
                    dl_FutureAttendance(S_ID);
                    dl_LOCATION(S_ID);
                    dl_OverallSatis(S_ID);
                    dl_Recommendation(S_ID);
                    dl_Session(S_ID);
                    dl_Speaker(S_ID);
                    dl_Vendor(S_ID);
                    
                    List<SURVEY> toDelete = (from dl in db.SURVEYs where dl.E_ID.Equals(_id) && dl.S_Id.Equals(S_ID) select dl).ToList();
                    if (toDelete == null)
                    {
                        return false;
                    }
                    else
                    {
                        db.SURVEYs.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return true;
                    }
                };
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void dl_Date(int S_ID)
        {
            
            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from res in db.DATEs where res.S_Id.Equals(S_ID) select res).ToList();
                    db.DATEs.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                }catch(Exception)
                {

                }
            };
        }
        public void dl_FirstTime(int S_ID)
        {

            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from res in db.FIRST_TIMEs where res.S_Id.Equals(S_ID) select res).ToList();
                    db.FIRST_TIMEs.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                }
                catch (Exception)
                {

                }
            };
        }
        public void dl_Food(int S_ID)
        {

            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from res in db.FOODs where res.S_Id.Equals(S_ID) select res).ToList();
                    db.FOODs.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                }
                catch (Exception)
                {

                }
            };
        }
        public void dl_FutureAttendance(int S_ID)
        {

            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from res in db.FUTURE_ATTENDANCEs where res.S_Id.Equals(S_ID) select res).ToList();
                    db.FUTURE_ATTENDANCEs.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                }
                catch (Exception)
                {

                }
            };
        }
        public void dl_LOCATION(int S_ID)
        {

            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from res in db.LOCATIONs where res.S_Id.Equals(S_ID) select res).ToList();
                    db.LOCATIONs.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                }
                catch (Exception)
                {

                }
            };
        }
        public void dl_OverallSatis(int S_ID)
        {

            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from res in db.OVERALL_SATISFACTIONs where res.S_Id.Equals(S_ID) select res).ToList();
                    db.OVERALL_SATISFACTIONs.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                }
                catch (Exception)
                {

                }
            };
        }
        public void dl_Recommendation(int S_ID)
        {

            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from res in db.RECOMMENDATIONs where res.S_Id.Equals(S_ID) select res).ToList();
                    db.RECOMMENDATIONs.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                }
                catch (Exception)
                {

                }
            };
        }
        public void dl_Session(int S_ID)
        {

            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from res in db.SESSIONs where res.S_Id.Equals(S_ID) select res).ToList();
                    db.SESSIONs.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                }
                catch (Exception)
                {

                }
            };
        }
        public void dl_Speaker(int S_ID)
        {

            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from res in db.SPEAKERs where res.S_Id.Equals(S_ID) select res).ToList();
                    db.SPEAKERs.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                }
                catch (Exception)
                {

                }
            };
        }
        public void dl_Vendor(int S_ID)
        {

            using (EventrixDBDataContext db = new EventrixDBDataContext())
            {
                try
                {
                    var query = (from res in db.VENDORs where res.S_Id.Equals(S_ID) select res).ToList();
                    db.VENDORs.DeleteAllOnSubmit(query);
                    db.SubmitChanges();
                }
                catch (Exception)
                {

                }
            };
        }

    }
}

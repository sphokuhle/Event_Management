using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventrix_Client.Model.ClientDefinition.Survey
{
    public class Survey
    {
        public int E_ID
        {
            get; set;
        }
        public int S_ID
        {
            get; set;
        }
        public int ID
        {
            get; set;
        }

        //Long questions
        public string Long_LikedMost
        {
            get; set;
        }
        public string Long_Improvement
        {
            get; set;
        }
        public string Long_Other_Suggestion
        {
            get; set;
        }
        public string Long_LikedLeast
        {
            get; set;
        }

        //Multiple Choice Answers
        public int veryDissatisfied
        {
            get; set;
        }
        public int Dissatisfied
        {
            get; set;
        }
        public int Neutral
        {
            get; set;
        }
        public int Satisfied
        {
            get; set;
        }
        public int VerySatisfied
        {
            get; set;
        }
        //Other Multiple Choice Answers
        public int NotLikely
        {
            get; set;
        }
        public int Likely
        {
            get; set;
        }
        public int VeryLikely
        {
            get; set;
        }

        //Yes and No
        public int Yes
        {
            get; set;
        }
        public int No
        {
            get; set;
        }

    }
}
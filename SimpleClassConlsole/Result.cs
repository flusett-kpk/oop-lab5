using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassConlsole
{
    class Result
    {
        protected string Subject;
        protected string Teacher;
        protected int Points;

        public Result() { }

        public Result(string t)
        {
            Teacher = t;
        }

        public Result(string s, string t, int p)
        {
            Subject = s;
            Teacher = t;
            Points = p;
        }

        public Result(Result objResult)
        {
            Subject = objResult.Subject;
            Teacher = objResult.Teacher;
            Points = objResult.Points;
        }

        public string GSSubject
        {
            get { return Subject; }
            set { Subject = value; }
        }

        public string GSTeacher
        {
            get { return Teacher; }
            set { Teacher = value; }
        }

        public int GSPoints
        {
            get { return Points; }
            set { Points = value; }
        }
    }
}

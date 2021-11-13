using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassConlsole
{
    class Student
    {
        protected string Name;
        protected string Surname;
        protected string Group;
        protected int Year;
        protected Result[] Results;

        public Student() { }

        public Student(string n, string s)
        {
            Name = n;
            Surname = s;
        }

        public Student(string n, string s, string g, int y, Result[] r)
        {
            Name = n;
            Surname = s;
            Group = g;
            Year = y;
            Results = r;
        }

        public Student(Student objStudent) 
        {
            Name = objStudent.Name;
            Surname = objStudent.Surname;
            Group = objStudent.Group;
            Year = objStudent.Year;
            Results = objStudent.Results;
        }

        public string GSName
        {
            get { return Name; }
            set { Name = value; }
        }

        public string GSSurname
        {
            get { return Surname; }
            set { Surname = value; }
        }

        public string GSGroup
        {
            get { return Group; }
            set { Group = value; }
        }

        public int GSYear
        {
            get { return Year; }
            set { Year = value; }
        }

        public Result[] GSResults
        {
            get { return Results; }
            set { Results = value; }
        }

        public int GetAveragePoints()
        {
            int tempPoints = 0;
            int countPoints = 0;

            for (; countPoints < Results.Length; countPoints++)
            {
                tempPoints += Results[countPoints].GSPoints;
            }

            tempPoints /= countPoints;

            return tempPoints;
        }

        public int[] GetSortedPoints()
        {
            int[] sortedPoints = new int[Results.Length];

            for(int value = 0; value < Results.Length; value++)
            {
                sortedPoints[value] = Results[value].GSPoints;
            }

            Array.Sort(sortedPoints);

            return sortedPoints;
        }

        public string GetBestSubject()
        {
            int[] sortedPoints = GetSortedPoints();

            string bestSubject = "Unknown";

            for(int value = 0; value < Results.Length; value++)
            {
                if (sortedPoints[sortedPoints.Length - 1] == Results[value].GSPoints)
                    bestSubject = Results[value].GSSubject;
            }

            return bestSubject;
        }

        public string GetWorstSubject()
        {
            int[] sortedPoints = GetSortedPoints();

            string worstSubject = "Unknown";

            for (int value = 0; value < Results.Length; value++)
            {
                if (sortedPoints[0] == Results[value].GSPoints)
                    worstSubject = Results[value].GSSubject;
            }

            return worstSubject;
        }
    }
}

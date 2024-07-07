using System;

namespace TripManagement
{
    public class Trips
    {
       
        private string country;
        private string person;
        private int days;

       
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string Person
        {
            get { return person; }
            set { person = value; }
        }

        public int Days
        {
            get { return days; }
            set { days = value; }
        }

        
        public Trips(string country, string person, int days)
        {
            this.country = country;
            this.person = person;
            this.days = days;
        }
    }
}

using _01.Defining_Classes_Part_1.Contracts;
using System;

namespace _01.Defining_Classes_Part_1
{
    public class Call : ICall
    {
        // fields
        private long? duration;
        private DateTime time;
        private string phoneNumber;

        // constructor
        public Call(long? duration, DateTime time, string phoneNumber)
        {
            this.Duration = duration;
            this.Time = time;
            this.PhoneNumber = phoneNumber;
        }

        // properties
        public DateTime Time { get; set; }
       
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (value.Length < 6)
                {
                    throw new ArgumentException();
                }

                this.phoneNumber = value;
            }
        }

        public long? Duration { get; set; }

    }
}

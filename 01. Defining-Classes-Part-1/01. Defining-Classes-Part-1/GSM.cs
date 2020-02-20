using _01.Defining_Classes_Part_1.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Defining_Classes_Part_1
{
    public class GSM
    {
        // private fields
        private string model = null;
        private string owner = null;
        private decimal? price = null;
        private string manufacturer = null;
        private static readonly GSM iPhone4S = new GSM("iPhone 4S", "Apple");
        public List<ICall> callHistory = new List<ICall>();
        private const double pricePerMinute = 0.37;

        // constructors
        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }
        public GSM(string model, string manufacturer, decimal? price)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
        }

        public GSM(string model, string manufacturer, string owner, decimal? price)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.owner = owner;
            this.price = price;
        }

        public GSM(string model, string manufacturer, string owner, decimal? price, Battery battery)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.owner = owner;
            this.price = price;
            this.Battery = battery;
        }

        public GSM(string model, string manufacturer, decimal? price, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.Display = display;
        }

        // properties
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("The model name is too long");
                }
                this.model = value;
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }
        public Battery Battery { get; set; }
        public Display Display { get; set; }
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }
        public decimal? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        // Methods
        public void AddCall(ICall call)
        {
            callHistory.Add(call);
        }
        public void DeleteCall(ICall call)
        {
            callHistory.Remove(call);
        }
        public void ClearHistory()
        {
            callHistory.Clear();
        }
        public double? CalculateTotalPrice()
        {
            double? duration = 0;
            foreach (var call in callHistory)
            {
                duration += call.Duration;
            }
            return duration = (duration / 60) * pricePerMinute;
        }
        public long? CalculateDuration()
        {
            long? duration = 0;
            foreach (var call in callHistory)
            {
                duration += call.Duration;
            }
            return duration;
        }
        // ToString() Method
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            if (model != null)
            {
                output.AppendLine("Model: " + Model);
            }

            if (manufacturer != null)
            {
                output.AppendLine("Manufacturer: " + Manufacturer);
            }

            if (price != null)
            {
                output.AppendLine("Price: " + Price + "lv.");
            }

            if (owner != null)
            {
                output.AppendLine("Owner: " + Owner);
            }

            if (Display != null && Display.Size != null)
            {
                output.AppendLine("Display size: " + Display.Size);
            }

            if (Display != null && Display.Colors != null)
            {
                output.AppendLine("Display : " + Display.Colors);
            }

            if (Battery != null && Battery.Type != null)
            {
                output.AppendLine("Battery type: " + Battery.Type);
            }

            if (Battery != null && Battery.Model != null)
            {
                output.AppendLine("Battery model: " + Battery.Model);
            }

            if (Battery != null && Battery.HoursIdle != null)
            {
                output.AppendLine("Hours idle: " + Battery.HoursIdle + " hours");
            }

            if (Battery != null && Battery.HoursTalk != null)
            {
                output.AppendLine("Hours talk: " + Battery.HoursTalk + " hours");
            }

            return output.ToString();
        }
    }
}

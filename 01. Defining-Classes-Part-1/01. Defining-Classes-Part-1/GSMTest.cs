﻿using _01.Defining_Classes_Part_1.Contracts;
using System;
using System.Collections.Generic;

namespace _01.Defining_Classes_Part_1
{
    public class GSMTest
    {
        public static void Main()
        {
            var phoneCollection = new List<GSM>();

            var batteryHours = new Battery(150, 80);
            var screenSize = new Display(5.5);

            GSM samsung = new GSM("Galaxy S7", "Samsung", 1000, screenSize);
            phoneCollection.Add(samsung);
            var nokia = new GSM("nokia3310", "Nokia");
            phoneCollection.Add(nokia);
            var lenovo = new GSM("Lenovo A7700", "Lenovo", "Somebody", 700, batteryHours);
            phoneCollection.Add(lenovo);

            for (int i = 0; i < phoneCollection.Count; i++)
            {
                Console.WriteLine(phoneCollection[i]);
            }

            Console.WriteLine(GSM.IPhone4S);


            Display samsungDysplay = new Display(16000000, 5.1);
            GSM phone = new GSM("Galaxy S7 ", "Samsung", 1000, samsungDysplay);

            ICall currentCall = new Call(850, DateTime.Now, "0888999999");
            phone.AddCall(currentCall);

            currentCall = new Call(1200, DateTime.Now.AddDays(4), "0899777777");
            phone.AddCall(currentCall);

            currentCall = new Call(120, DateTime.Now.AddHours(150), "0877111111");
            phone.AddCall(currentCall);

            foreach (var currCall in phone.callHistory)
            {
                Console.WriteLine("Call: {0}, Phone number: {1}, Call duration: {2}",
                    currCall.Time, currCall.PhoneNumber, currCall.Duration);
            }
            Console.WriteLine("Total price: {0:f2}lv.", phone.CalculateTotalPrice());

            long? maxCallDuration = long.MinValue;
            ICall longestCall = new Call(0, DateTime.Now, "0888111111");

            foreach (var currCallCheck in phone.callHistory)
            {
                if (currCallCheck.Duration > maxCallDuration)
                {
                    maxCallDuration = currCallCheck.Duration;
                    longestCall = currCallCheck;
                }
            }

            phone.DeleteCall(longestCall);

            Console.WriteLine("Total price without the longest call is: {0:f2}lv.", phone.CalculateTotalPrice());
            phone.ClearHistory();
        }
    }
}

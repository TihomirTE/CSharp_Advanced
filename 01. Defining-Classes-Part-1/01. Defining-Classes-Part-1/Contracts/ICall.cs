using System;

namespace _01.Defining_Classes_Part_1.Contracts
{
    public interface ICall
    {
        DateTime Time { get; set; }

        string PhoneNumber { get; set; }

        long? Duration { get; set; }
    }
}

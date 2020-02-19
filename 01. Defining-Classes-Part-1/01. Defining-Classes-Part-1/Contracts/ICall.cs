using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Defining_Classes_Part_1.Contracts
{
    public interface ICall
    {
        DateTime Time { get; set; }

        string PhoneNumber { get; set; }

        long? Duration { get; set; }
    }
}

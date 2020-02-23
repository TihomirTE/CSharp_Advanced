using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Defining_Classes_Part_1.Contracts
{
    public interface IGSM
    {
        string Model { get; set; }
        string Owner { get; set; }
        string Manufacturer { get; set; }
        Battery Battery { get; set; }
        Display Display { get; set; }
        decimal? Price { get; set; }
        void AddCall(ICall call);
        void DeleteCall(ICall call);
        void ClearHistory();
        double? CalculateTotalPrice();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Prodat.Models
{
    public class VinResponse
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public Results[] results { get; set; }
    }

    public class Results
    {
        public int vehicle_model { get; set; }
        public int sub_model { get; set; }
        public int model_year { get; set; }
        public object[] sw_part_no { get; set; }
    }
}
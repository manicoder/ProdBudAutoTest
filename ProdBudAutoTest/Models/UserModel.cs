using System;
using System.Collections.Generic;
using System.Text;

namespace Prodat.Models
{
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string mac_id { get; set; }
        public string device_type { get; set; }
        public string station_id { get; set; }
    }
}

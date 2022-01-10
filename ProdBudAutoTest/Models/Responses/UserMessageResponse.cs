using System;
using System.Collections.Generic;
using System.Text;

namespace Prodat.Models
{
    public class UserMessageResponse
    {
        public string role { get; set; }
        public string oem_name { get; set; }
        public Licences licences { get; set; }
        public string token { get; set; }
        public Station_List[] station_list { get; set; }
        public string workshop_name { get; set; }
        public string first_name { get; set; }
        public int workshop_id { get; set; }
        public string user { get; set; }
        public object[] vehicle_models { get; set; }
        public string workshop_group_name { get; set; }
        public int workshop_group_id { get; set; }
        public int id { get; set; }
        public string user_m_id { get; set; }
        public string last_name { get; set; }
        public DateTime expires { get; set; }
        public int oem_id { get; set; }
        public string error { get; set; }
    }

    public class Licences
    {
        public bool dtc_read_clear { get; set; }
        public bool terminal { get; set; }
        public bool live_parameter { get; set; }
        public bool flash { get; set; }
        public bool createlog { get; set; }
        public bool dms_job_card { get; set; }
        public bool rdtechnician { get; set; }
        public bool iotest { get; set; }
        public bool rdexpert { get; set; }
        public bool guided_diagnostics { get; set; }
        public bool write_parameter { get; set; }
    }

    public class Station_List
    {
        public int id { get; set; }
        public string stations_id { get; set; }
        public string plants { get; set; }
        public string description { get; set; }
        public string is_active { get; set; }
    }

}

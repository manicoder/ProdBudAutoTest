using System;
namespace Prodat.Models
{
    public class StationData
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
        public Process process { get; set; }
    }

    public class Process
    {
        public Sp_Process[] sp_process { get; set; }
    }

    public class Sp_Process
    {
        public Station_Process[] station_process { get; set; }
        public int ecu { get; set; }
        public int year { get; set; }
    }

    public class Station_Process
    {
        public Station_Process_Steps[] station_process_steps { get; set; }
        public string name { get; set; }
        public int priority { get; set; }
        public string station_author_step_type { get; set; }
        public object[] ior_test { get; set; }
        public object[] parameter { get; set; }
    }

    public class Station_Process_Steps
    {
        public int priority { get; set; }
        public string min_value { get; set; }
        public string max_value { get; set; }
        public string equals { get; set; }
        public string station_author_pid_type { get; set; }
        public int? pid_code { get; set; }
        public int? compare_pid_code { get; set; }
        public string tolerance { get; set; }
        public string stage1_equals_value { get; set; }
        public string stage2_equals_value { get; set; }
        public string stage1_min { get; set; }
        public string stage1_max { get; set; }
        public string stage2_min { get; set; }
        public string stage2_max { get; set; }
        public string description { get; set; }
        public string chassis_api_pid { get; set; }
        public Pid_Type_Station_Process[] pid_type_station_process { get; set; }
        public string evel_time_in_mili_second { get; set; }
    }

    public class Pid_Type_Station_Process
    {
        public string x_breakpoint { get; set; }
        public string ymax_breakpoint { get; set; }
        public string ymin_breakpoint { get; set; }
    }
}
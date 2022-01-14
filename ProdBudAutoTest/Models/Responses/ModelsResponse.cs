using System;
using System.Collections.Generic;

namespace Prodat.Models
{

    public class ModelsResponse
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<ModelResult> results { get; set; }
    }

    public class ModelResult
    {
        public int id { get; set; }
        public int oem { get; set; }
        public string name { get; set; }
        public List<Sub_Models> sub_models { get; set; }
    }

    public class Sub_Models
    {
        public int id { get; set; }
        public string name { get; set; }
        public string model_year { get; set; }
        public Ecu[] ecus { get; set; }
    }

    public class Ecu
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tx_header { get; set; }
        public string rx_header { get; set; }
        public Dataset[] datasets { get; set; }
        public Pid_Datasets[] pid_datasets { get; set; }
        public Protocol protocol { get; set; }
        public Read_Dtc_Fn_Index read_dtc_fn_index { get; set; }
        public Clear_Dtc_Fn_Index clear_dtc_fn_index { get; set; }
        public Read_Data_Fn_Index read_data_fn_index { get; set; }
        public Write_Data_Fn_Index write_data_fn_index { get; set; }
        public Seedkeyalgo_Fn_Index seedkeyalgo_fn_index { get; set; }
        public Ecu1[] ecu { get; set; }
    }

    public class Protocol
    {
        public string name { get; set; }
        public string elm { get; set; }
        public string autopeepal { get; set; }
    }

    public class Read_Dtc_Fn_Index
    {
        public string value { get; set; }
    }

    public class Clear_Dtc_Fn_Index
    {
        public string value { get; set; }
    }

    public class Read_Data_Fn_Index
    {
        public string value { get; set; }
    }

    public class Write_Data_Fn_Index
    {
        public string value { get; set; }
    }

    public class Seedkeyalgo_Fn_Index
    {
        public string value { get; set; }
    }

    public class Dataset
    {
        public int id { get; set; }
        public string code { get; set; }
    }

    public class Pid_Datasets
    {
        public int id { get; set; }
        public string code { get; set; }
    }

    public class Ecu1
    {
        public int id { get; set; }
        public string sequence_file_name { get; set; }
        public string sequence_file { get; set; }
        public File[] file { get; set; }
    }

    public class File
    {
        public int id { get; set; }
        public string data_file_name { get; set; }
        public string data_file { get; set; }
    }

}

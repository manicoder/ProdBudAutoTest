using System;
using System.Collections.Generic;

namespace Prodat.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Dataset
    {
        public int id { get; set; }
        public string code { get; set; }
    }

    public class PidDataset
    {
        public int id { get; set; }
        public string code { get; set; }
    }

    public class Protocol
    {
        public string name { get; set; }
        public string elm { get; set; }
        public string autopeepal { get; set; }
    }

    public class ReadDtcFnIndex
    {
        public string value { get; set; }
    }

    public class ClearDtcFnIndex
    {
        public string value { get; set; }
    }

    public class ReadDataFnIndex
    {
        public string value { get; set; }
    }

    public class WriteDataFnIndex
    {
        public string value { get; set; }
    }

    public class SeedkeyalgoFnIndex
    {
        public string value { get; set; }
    }

    public class File
    {
        public int id { get; set; }
        public string data_file_name { get; set; }
        public string data_file { get; set; }
    }

    public class Ecu2
    {
        public int id { get; set; }
        public string sequence_file_name { get; set; }
        public string sequence_file { get; set; }
        public List<File> file { get; set; }
    }

    public class Ecu
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tx_header { get; set; }
        public string rx_header { get; set; }
        public List<Dataset> datasets { get; set; }
        public List<PidDataset> pid_datasets { get; set; }
        public Protocol protocol { get; set; }
        public ReadDtcFnIndex read_dtc_fn_index { get; set; }
        public ClearDtcFnIndex clear_dtc_fn_index { get; set; }
        public ReadDataFnIndex read_data_fn_index { get; set; }
        public WriteDataFnIndex write_data_fn_index { get; set; }
        public SeedkeyalgoFnIndex seedkeyalgo_fn_index { get; set; }
        public List<Ecu> ecu { get; set; }
    }

    public class SubModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string model_year { get; set; }
        public List<Ecu> ecus { get; set; }
    }

    public class ModelResult
    {
        public int id { get; set; }
        public int oem { get; set; }
        public string name { get; set; }
        public List<SubModel> sub_models { get; set; }
    }

    public class ModelsResponse
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<ModelResult> results { get; set; }
    }


}

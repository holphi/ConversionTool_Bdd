using System;

namespace DAX2.DTT.Convertion.Test.Entities
{
    public class Profile_EndpointType
    {
        public string Device_ID {get; set;}
        public string Profile {get; set;}   
        public string Endpoint_Type {get; set;}
        public string calibration_boost {get; set;}
        public string dialog_enhancer_enable {get; set;}
        public string dialog_enhancer_amount {get; set;}
        public string dialog_enhancer_ducking {get; set;}
        public string surround_boost {get; set;}
        public string volmax_boost {get; set;}
        public string volume_leveler_enable {get; set;}
        public string volume_leveler_amount {get; set;}
        public string intermediate_profile_partial_virtualizer_enable { get; set; }
    }
}

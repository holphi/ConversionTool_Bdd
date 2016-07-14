using System;

namespace DAX2.DTT.Convertion.Test.Entities
{
    public class Device_Tuning
    {
        public string Device_ID { get; set; }
        public string name { get; set; }
        public string profile_restrictions { get; set; }
        public string classification { get; set; }
        public string endpoint_type { get; set; }
        public string mono_device { get; set; }

        public string has_sub { get; set; }
        public string tuned_rate { get; set; }
        public string preGain { get; set; }
        public string postGain { get; set; }
        public string audio_optimizer_bands_Frequency { get; set; }
        public string audio_optimizer_bands_Gain0 { get; set; }
        public string audio_optimizer_bands_Gain1 { get; set; }
        public string audio_optimizer_bands_Gain2 { get; set; }
        public string audio_optimizer_bands_Gain3 { get; set; }
        public string audio_optimizer_bands_Gain4 { get; set; }
        public string audio_optimizer_bands_Gain5 { get; set; }
        public string audio_optimizer_bands_Gain6 { get; set; }
        public string audio_optimizer_bands_Gain7 { get; set; }
        public string audio_optimizer_bands_Gain8 { get; set; }
        public string audio_optimizer_bands_Gain9 { get; set; }

        public string process_optimizer_bands_Frequency { get; set; }
        public string process_optimizer_bands_Gain0 { get; set; }
        public string process_optimizer_bands_Gain1 { get; set; }
        public string process_optimizer_bands_Gain2 { get; set; }
        public string process_optimizer_bands_Gain3 { get; set; }
        public string process_optimizer_bands_Gain4 { get; set; }
        public string process_optimizer_bands_Gain5 { get; set; }
        public string process_optimizer_bands_Gain6 { get; set; }
        public string process_optimizer_bands_Gain7 { get; set; }
        public string process_optimizer_bands_Gain8 { get; set; }
        public string process_optimizer_bands_Gain9 { get; set; }
        
        public string audio_regulator_frequency {get;set;}
        public string audio_regulator_threshold_low {get;set;}
        public string audio_regulator_threshold_high {get;set;}
        public string audio_regulator_isolated_band { get; set; }
        public string bass_enhancer_boost {get;set;}
        public string bass_enhancer_cutoff_frequency {get;set;}
        public string bass_enhancer_width {get;set;}
        public string bass_extraction_cutoff_frequency {get;set;}

        public string height_filter_mode { get; set; }
        public string regulator_overdrive { get; set; }
        public string regulator_timbre_preservation { get; set; }
        public string regulator_relaxation_amount { get; set; }

        public string virtual_bass_overall_gain {get; set;}
        public string virtual_bass_slope_gain {get; set;}
        public string virtual_bass_mix_freqs_low {get; set;}
        public string virtual_bass_mix_freqs_high {get; set;}
        public string virtual_bass_src_freqs_low {get; set;}
        public string virtual_bass_src_freqs_high {get; set;}
        public string virtual_bass_subgains_num {get; set;}
        public string virtual_bass_subgains_harmonic_2 {get; set;}
        public string virtual_bass_subgains_harmonic_3 {get; set;}
        public string virtual_bass_subgains_harmonic_4 {get; set;}
        public string virtualizer_speaker_angle {get; set;}
        public string virtualizer_front_speaker_angle {get; set;}
        public string virtualizer_height_speaker_angle {get; set;}
        public string virtualizer_surround_speaker_angle {get; set;}
        public string volume_modeler_calibration { get; set; }

        public string intermediate_tuning_audio_optimizer_enable {get;set;}
        public string intermediate_tuning_bass_enhancer_enable {get;set;}
        public string intermediate_tuning_bass_extraction_enable {get;set;}
        public string intermediate_tuning_process_optimizer_enable {get;set;}
        public string intermediate_tuning_regulator_enable {get;set;}
        public string intermediate_tuning_regulator_speaker_dist_enable  {get;set;}
        public string intermediate_tuning_surround_decoder_enable  {get;set;}
        public string intermediate_tuning_volume_modeler_enable {get;set;}
        public string intermediate_tuning_partial_output_mode_channels {get;set;}
        public string intermediate_tuning_partial_output_mode_mixmatrix {get;set;}
        public string intermediate_tuning_partial_virtual_bass_enable {get;set;}
        public string intermediate_tuning_partial_virtual_bass_mode {get;set;}
        public string intermediate_tuning_partial_virtualizer_enable {get;set;}
    }
}

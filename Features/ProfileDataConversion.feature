Feature: Profile data converstion
	As a profession tuner for Windows platform
	I want to be able to convert profile data from the tuning xml to the DAX2 Database
	So the profile tuning data can be applied by the DAX2 Windows product when user swithing between profiles

Background:
	Given I have opened the DTT conversion tool with argument --import-endpoint-port --import-profile-tuning

@mytag
Scenario: Convert Profile data
	When I set the DB file to DAX2.sdf
	And I set the XML file to Tuning_File_Profile.xml
	And I click on the convert button
	Then I should see a message box with the title Great News and the message Successfully Converted the XML to Database shows up
	When I press OK button on the message box
	And I close the DTT conversion tool
	Then I should be able to query below 7 new records in the table Profile_Tuning of the DAX2 DB
	| id	| name			| graphic_equalizer_enable | ieq_enable | ieq_amount | mi_dialog_enhancer_steering_enable | mi_dv_leveler_steering_enable | mi_ieq_steering_enable | mi_surround_compressor_steering_enable | virtualizer_headphone_reverb_gain | intermediate_profile_audio_optimizer_enable | intermediate_profile_bass_enhancer_enable | intermediate_profile_bass_extraction_enable | intermediate_profile_process_optimizer_enable | intermediate_profile_regulator_enable | intermediate_profile_regulator_speaker_dist_enable | intermediate_profile_surround_decoder_enable | intermediate_profile_volume_modeler_enable | intermediate_profile_partial_virtual_bass_enable | ieq_bands | geq_bands			|
	| auto	| Dynamic		| 0                        | 1          | 10         | 1                                  | 1                             | 1                      | 1                                      | 0                                 | 1                                           | 1                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 0                                          | 1                                                | ieq_open  | geq_auto_open		|
	| game	| Game			| 0                        | 0          | 10         | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 1                                           | 1                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 0                                          | 1                                                | ieq_open  | geq_game_off		|
	| movie | Movie			| 0                        | 0          | 10         | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 1                                           | 1                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 0                                          | 1                                                | ieq_open  | geq_movie_off		|
	| music | Music			| 0                        | 1          | 10         | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 1                                           | 1                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 0                                          | 1                                                | ieq_open  | geq_music_open	|
	| off	| Off			| 0                        | 0          | 0          | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 0                                           | 0                                         | 0                                           | 0                                             | 0                                     | 0                                                  | 0                                            | 0                                          | 0                                                | ieq_open  | geq_off_off		|
	| user1 | Personalized	| 1                        | 0          | 10         | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 1                                           | 1                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 0                                          | 1                                                | ieq_open  | geq_user1_off		|
	| voice | Voice			| 0                        | 0          | 10         | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 1                                           | 0                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 0                                          | 0                                                | ieq_rich  | geq_voice_off		|
	And I should be able to query below 49 new records in the table Profile_EndpointPort of the DAX2 DB
	| Profile | Endpoint_Port | volume_leveler_in_target | volume_leveler_out_target |
	| auto    | bluetooth        | -320                     | -320                      |
	| auto    | hdmi             | -496                     | -496                      |
	| auto    | headphone_port   | -320                     | -320                      |
	| auto    | internal_speaker | -320                     | -320                      |
	| auto    | miracast         | -496                     | -496                      |
	| auto    | other            | -496                     | -496                      |
	| auto    | usb              | -320                     | -320                      |
	| game    | bluetooth        | -320                     | -320                      |
	| game    | hdmi             | -496                     | -496                      |
	| game    | headphone_port   | -320                     | -320                      |
	| game    | internal_speaker | -320                     | -320                      |
	| game    | miracast         | -496                     | -496                      |
	| game    | other            | -496                     | -496                      |
	| game    | usb              | -320                     | -320                      |
	| movie   | bluetooth        | -320                     | -320                      |
	| movie   | hdmi             | -496                     | -496                      |
	| movie   | headphone_port   | -320                     | -320                      |
	| movie   | internal_speaker | -320                     | -320                      |
	| movie   | miracast         | -496                     | -496                      |
	| movie   | other            | -496                     | -496                      |
	| movie   | usb              | -320                     | -320                      |
	| music   | bluetooth        | -320                     | -320                      |
	| music   | hdmi             | -496                     | -496                      |
	| music   | headphone_port   | -320                     | -320                      |
	| music   | internal_speaker | -320                     | -320                      |
	| music   | miracast         | -496                     | -496                      |
	| music   | other            | -496                     | -496                      |
	| music   | usb              | -320                     | -320                      |
	| off     | bluetooth        | -320                     | -320                      |
	| off     | hdmi             | -496                     | -496                      |
	| off     | headphone_port   | -320                     | -320                      |
	| off     | internal_speaker | -320                     | -320                      |
	| off     | miracast         | -496                     | -496                      |
	| off     | other            | -496                     | -496                      |
	| off     | usb              | -320                     | -320                      |
	| user1   | bluetooth        | -320                     | -320                      |
	| user1   | hdmi             | -496                     | -496                      |
	| user1   | headphone_port   | -320                     | -320                      |
	| user1   | internal_speaker | -320                     | -320                      |
	| user1   | miracast         | -496                     | -496                      |
	| user1   | other            | -496                     | -496                      |
	| user1   | usb              | -320                     | -320                      |
	| voice   | bluetooth        | -320                     | -320                      |
	| voice   | hdmi             | -496                     | -496                      |
	| voice   | headphone_port   | -320                     | -320                      |
	| voice   | internal_speaker | -320                     | -320                      |
	| voice   | miracast         | -496                     | -496                      |
	| voice   | other            | -496                     | -496                      |
	| voice   | usb              | -320                     | -320                      |
	And I should be able to query below 28 new records in the table Profile_EndpointType of the DAX2 DB
	| Profile | Endpoint_Type | calibration_boost | dialog_enhancer_enable | dialog_enhancer_amount | dialog_enhancer_ducking | surround_boost | volmax_boost | volume_leveler_enable | volume_leveler_amount | intermediate_profile_partial_virtualizer_enable |	
	| auto    | headphone     | 0                 | 1                      | 10                     | 0                       | 96             | 144          | 1                     | 7                     | 1                                               |
	| auto    | other         | 0                 | 1                      | 10                     | 0                       | 0              | 144          | 1                     | 7                     | 0                                               |
	| auto    | passthrough   | 0                 | 1                      | 10                     | 0                       | 0              | 0            | 1                     | 7                     | 0                                               |
	| auto    | speaker       | 0                 | 1                      | 12                     | 0                       | 96             | 144          | 1                     | 7                     | 1                                               |
	| game    | headphone     | 0                 | 0                      | 7                      | 0                       | 0              | 144          | 1                     | 0                     | 1                                               |
	| game    | other         | 0                 | 0                      | 7                      | 0                       | 0              | 144          | 1                     | 0                     | 0                                               |
	| game    | passthrough   | 0                 | 0                      | 7                      | 0                       | 0              | 0            | 1                     | 0                     | 0                                               |
	| game    | speaker       | 0                 | 0                      | 7                      | 0                       | 0              | 144          | 1                     | 0                     | 1                                               |
	| movie   | headphone     | 0                 | 1                      | 10                     | 0                       | 96             | 144          | 1                     | 7                     | 1                                               |
	| movie   | other         | 0                 | 1                      | 10                     | 0                       | 0              | 144          | 1                     | 7                     | 0                                               |
	| movie   | passthrough   | 0                 | 1                      | 10                     | 0                       | 0              | 0            | 1                     | 7                     | 0                                               |
	| movie   | speaker       | 0                 | 1                      | 12                     | 0                       | 96             | 144          | 1                     | 7                     | 1                                               |
	| music   | headphone     | 0                 | 0                      | 7                      | 0                       | 48             | 144          | 1                     | 4                     | 0                                               |
	| music   | other         | 0                 | 0                      | 7                      | 0                       | 0              | 144          | 1                     | 4                     | 0                                               |
	| music   | passthrough   | 0                 | 0                      | 7                      | 0                       | 0              | 0            | 1                     | 4                     | 0                                               |
	| music   | speaker       | 0                 | 0                      | 7                      | 0                       | 0              | 144          | 1                     | 4                     | 0                                               |
	| off     | headphone     | 0                 | 0                      | 0                      | 0                       | 0              | 0            | 0                     | 0                     | 0                                               |
	| off     | other         | 0                 | 0                      | 0                      | 0                       | 0              | 0            | 0                     | 0                     | 0                                               |
	| off     | passthrough   | 0                 | 0                      | 0                      | 0                       | 0              | 0            | 0                     | 0                     | 0                                               |
	| off     | speaker       | 0                 | 0                      | 0                      | 0                       | 0              | 0            | 0                     | 0                     | 0                                               |
	| user1   | headphone     | 0                 | 1                      | 12                     | 0                       | 48             | 144          | 1                     | 5                     | 1                                               |
	| user1   | other         | 0                 | 1                      | 12                     | 0                       | 0              | 144          | 1                     | 5                     | 0                                               |
	| user1   | passthrough   | 0                 | 1                      | 12                     | 0                       | 0              | 0            | 1                     | 5                     | 0                                               |
	| user1   | speaker       | 0                 | 1                      | 14                     | 0                       | 48             | 144          | 1                     | 5                     | 1                                               |
	| voice   | headphone     | 0                 | 1                      | 14                     | 0                       | 0              | 144          | 0                     | 0                     | 0                                               |
	| voice   | other         | 0                 | 1                      | 14                     | 0                       | 0              | 144          | 0                     | 0                     | 0                                               |
	| voice   | passthrough   | 0                 | 1                      | 14                     | 0                       | 0              | 0            | 0                     | 0                     | 0                                               |
	| voice   | speaker       | 0                 | 1                      | 16                     | 0                       | 0              | 144          | 0                     | 0                     | 0                                               |


@mytag
Scenario: Update Profile data
	And I convert the tuning file Tuning_File_Profile.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	When I open the DTT conversion tool with argument --import-endpoint-port --import-profile-tuning
	And I set the DB file to DAX2.sdf
	And I set the XML file to Tuning_File_Profile_Update.xml
	When I click on the convert button
	Then I should see a message box with the title Already Exists and the message Entries with same System ID exists in the DB.. Would you like to Replace? shows up
	When I press Yes button on the message box
	Then I should see a message box with the title Great News and the message Successfully Converted the XML to Database shows up
	When I press OK button on the message box
	And I close the DTT conversion tool
	Then I should be able to query below 7 new records in the table Profile_Tuning of the DAX2 DB
	| id	| name			| graphic_equalizer_enable | ieq_enable | ieq_amount | mi_dialog_enhancer_steering_enable | mi_dv_leveler_steering_enable | mi_ieq_steering_enable | mi_surround_compressor_steering_enable | virtualizer_headphone_reverb_gain | intermediate_profile_audio_optimizer_enable | intermediate_profile_bass_enhancer_enable | intermediate_profile_bass_extraction_enable | intermediate_profile_process_optimizer_enable | intermediate_profile_regulator_enable | intermediate_profile_regulator_speaker_dist_enable | intermediate_profile_surround_decoder_enable | intermediate_profile_volume_modeler_enable | intermediate_profile_partial_virtual_bass_enable | ieq_bands | geq_bands			|
	| auto	| Dynamic		| 1                        | 0          | 9          | 1                                  | 1                             | 1                      | 1                                      | 0                                 | 1                                           | 1                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 1                                          | 1                                                | ieq_rich  | geq_auto_open		|
	| game	| Game			| 1                        | 1          | 10         | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 1                                           | 1                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 1                                          | 1                                                | ieq_open  | geq_off_off		|
	| movie | Movie			| 1                        | 1          | 10         | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 1                                           | 1                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 1                                          | 1                                                | ieq_rich  | geq_movie_off		|
	| music | Music			| 1                        | 0          | 10         | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 1                                           | 1                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 1                                          | 1                                                | ieq_open  | geq_music_open	|
	| off	| Off			| 1                        | 1          | 9          | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 0                                           | 0                                         | 0                                           | 0                                             | 0                                     | 0                                                  | 0                                            | 0                                          | 0                                                | ieq_open  | geq_user1_off		|
	| user1 | Personalized	| 0                        | 1          | 10         | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 1                                           | 1                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 1                                          | 1                                                | ieq_open  | geq_user1_off		|
	| voice | Voice			| 1                        | 1          | 10         | 0                                  | 0                             | 0                      | 0                                      | 0                                 | 1                                           | 0                                         | 0                                           | 0                                             | 1                                     | 1                                                  | 1                                            | 1                                          | 0                                                | ieq_rich  | geq_voice_off		|
	And I should be able to query below 49 new records in the table Profile_EndpointPort of the DAX2 DB
	| Profile | Endpoint_Port    | volume_leveler_in_target | volume_leveler_out_target |
	| auto    | bluetooth        | 0                        | -320                      |
	| auto    | hdmi             | -496                     | 0                         |
	| auto    | headphone_port   | 0                        | -320                      |
	| auto    | internal_speaker | 0                        | -320                      |
	| auto    | miracast         | -496                     | 0                         |
	| auto    | other            | -496                     | 0                         |
	| auto    | usb              | 0                        | -320                      |
	| game    | bluetooth        | 0                        | -320                      |
	| game    | hdmi             | -496                     | 0                         |
	| game    | headphone_port   | 0                        | -320                      |
	| game    | internal_speaker | 0                        | -320                      |
	| game    | miracast         | -496                     | 0                         |
	| game    | other            | -496                     | 0                         |
	| game    | usb              | 0                        | -320                      |
	| movie   | bluetooth        | 0                        | -320                      |
	| movie   | hdmi             | -496                     | 0                         |
	| movie   | headphone_port   | 0                        | -320                      |
	| movie   | internal_speaker | 0                        | -320                      |
	| movie   | miracast         | -496                     | 0                         |
	| movie   | other            | -496                     | 0                         |
	| movie   | usb              | 0                        | -320                      |
	| music   | bluetooth        | 0                        | -320                      |
	| music   | hdmi             | -496                     | 0                         |
	| music   | headphone_port   | 0                        | -320                      |
	| music   | internal_speaker | 0                        | -320                      |
	| music   | miracast         | -496                     | 0                         |
	| music   | other            | -496                     | 0                         |
	| music   | usb              | 0                        | -320                      |
	| off     | bluetooth        | 0                        | -320                      |
	| off     | hdmi             | -496                     | 0                         |
	| off     | headphone_port   | 0                        | -320                      |
	| off     | internal_speaker | 0                        | -320                      |
	| off     | miracast         | -496                     | 0                         |
	| off     | other            | -496                     | 0                         |
	| off     | usb              | 0                        | -320                      |
	| user1   | bluetooth        | 0                        | -320                      |
	| user1   | hdmi             | -496                     | 0                         |
	| user1   | headphone_port   | 0                        | -320                      |
	| user1   | internal_speaker | 0                        | -320                      |
	| user1   | miracast         | -496                     | 0                         |
	| user1   | other            | -496                     | 0                         |
	| user1   | usb              | 0                        | -320                      |
	| voice   | bluetooth        | 0                        | -320                      |
	| voice   | hdmi             | -496                     | 0                         |
	| voice   | headphone_port   | 0                        | -320                      |
	| voice   | internal_speaker | 0                        | -320                      |
	| voice   | miracast         | -496                     | 0                         |
	| voice   | other            | -496                     | 0                         |
	| voice   | usb              | 0                        | -320                      |
	And I should be able to query below 28 new records in the table Profile_EndpointType of the DAX2 DB
	| Profile | Endpoint_Type | calibration_boost | dialog_enhancer_enable | dialog_enhancer_amount | dialog_enhancer_ducking | surround_boost | volmax_boost | volume_leveler_enable | volume_leveler_amount | intermediate_profile_partial_virtualizer_enable |	
	| auto    | headphone     | 1                 | 1                      | 10                     | 0                       | 96             | 100          | 1                     | 7                     | 1                                               |
	| auto    | other         | 1                 | 1                      | 10                     | 0                       | 0              | 100          | 1                     | 7                     | 0                                               |
	| auto    | passthrough   | 1                 | 1                      | 10                     | 0                       | 0              | 0            | 1                     | 7                     | 0                                               |
	| auto    | speaker       | 1                 | 1                      | 12                     | 0                       | 96             | 100          | 1                     | 7                     | 1                                               |
	| game    | headphone     | 1                 | 0                      | 7                      | 0                       | 0              | 100          | 1                     | 0                     | 1                                               |
	| game    | other         | 1                 | 0                      | 7                      | 0                       | 0              | 100          | 1                     | 0                     | 0                                               |
	| game    | passthrough   | 1                 | 0                      | 7                      | 0                       | 0              | 0            | 1                     | 0                     | 0                                               |
	| game    | speaker       | 1                 | 0                      | 7                      | 0                       | 0              | 100          | 1                     | 0                     | 1                                               |
	| movie   | headphone     | 1                 | 1                      | 10                     | 0                       | 96             | 100          | 1                     | 7                     | 1                                               |
	| movie   | other         | 1                 | 1                      | 10                     | 0                       | 0              | 100          | 1                     | 7                     | 0                                               |
	| movie   | passthrough   | 1                 | 1                      | 10                     | 0                       | 0              | 0            | 1                     | 7                     | 0                                               |
	| movie   | speaker       | 1                 | 1                      | 12                     | 0                       | 96             | 100          | 1                     | 7                     | 1                                               |
	| music   | headphone     | 1                 | 0                      | 7                      | 0                       | 48             | 100          | 1                     | 4                     | 0                                               |
	| music   | other         | 1                 | 0                      | 7                      | 0                       | 0              | 100          | 1                     | 4                     | 0                                               |
	| music   | passthrough   | 1                 | 0                      | 7                      | 0                       | 0              | 0            | 1                     | 4                     | 0                                               |
	| music   | speaker       | 1                 | 0                      | 7                      | 0                       | 0              | 100          | 1                     | 4                     | 0                                               |
	| off     | headphone     | 1                 | 0                      | 0                      | 0                       | 0              | 0            | 0                     | 0                     | 0                                               |
	| off     | other         | 1                 | 0                      | 0                      | 0                       | 0              | 0            | 0                     | 0                     | 0                                               |
	| off     | passthrough   | 1                 | 0                      | 0                      | 0                       | 0              | 0            | 0                     | 0                     | 0                                               |
	| off     | speaker       | 1                 | 0                      | 0                      | 0                       | 0              | 0            | 0                     | 0                     | 0                                               |
	| user1   | headphone     | 1                 | 1                      | 12                     | 0                       | 48             | 100          | 1                     | 5                     | 1                                               |
	| user1   | other         | 1                 | 1                      | 12                     | 0                       | 0              | 100          | 1                     | 5                     | 0                                               |
	| user1   | passthrough   | 1                 | 1                      | 12                     | 0                       | 0              | 0            | 1                     | 5                     | 0                                               |
	| user1   | speaker       | 1                 | 1                      | 14                     | 0                       | 48             | 100          | 1                     | 5                     | 1                                               |
	| voice   | headphone     | 1                 | 1                      | 14                     | 0                       | 0              | 100          | 0                     | 0                     | 0                                               |
	| voice   | other         | 1                 | 1                      | 14                     | 0                       | 0              | 100          | 0                     | 0                     | 0                                               |
	| voice   | passthrough   | 1                 | 1                      | 14                     | 0                       | 0              | 0            | 0                     | 0                     | 0                                               |
	| voice   | speaker       | 1                 | 1                      | 16                     | 0                       | 0              | 100          | 0                     | 0                     | 0                                               |

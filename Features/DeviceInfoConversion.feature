Feature: Device info convertion
	As a profession tuner for Windows platform
	I want to be able to import device information being tuned to DAX2 Database
	So I can convert all device tuning data in one unique DAX2 Database

@mytag
Scenario: Retrieving default device info
	Given I have the default DAX2 Database named DAX2.sdf
	Then I should be able to query below 3 default records in the table Device_Info of the DAX2 DB
	| Device_ID | System_ID         | SKU_Name  | opp_logo_id | default_profile | geq_maximum_range | install_options |
	| 1         | default_hdac      | hdac      | 0           | 0               | 192               |                 |
	| 2         | default_hdac_core | hdac_core | 0           | 0               | 192               |                 |
	| 3         | default_dsp       | dsp       | 0           | 0               | 192               |                 |

@mytag
Scenario: Import device info with the configurable GEQ node to DB
	Given I have opened the DTT conversion tool
	When I set the DB file to DAX2.sdf
	And I set the XML file to Tuning_File_Device_Info.xml
	When I click on the convert button
	And I press OK button on the message box
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range |
	| hdac     | 0           | 0               | 100               |

@mytag
Scenario: Import device info without the configurable GEQ node to DB
	Given I have opened the DTT conversion tool
	When I set the DB file to DAX2.sdf
	And I set the XML file to Tuning_File_Device_Info_Without_GEQ_Nodes.xml
	When I click on the convert button
	And I press OK button on the message box
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range |
	| hdac     | 0           | 0               | 192               |

@mytag
Scenario: Update Operator info from the GUI
	Given I have opened the DTT conversion tool
	When I set the DB file to DAX2.sdf
	And I set the XML file to Tuning_File_Device_Info_Without_GEQ_Nodes.xml
	When I set the operator to Lenovo
	And I click on the convert button
	And I press OK button on the message box
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range |
	| hdac     | 1           | 0               | 192               |

@mytag
Scenario: Update profile info from the GUI
	Given I have opened the DTT conversion tool
	When I set the DB file to DAX2.sdf
	And I set the XML file to Tuning_File_Device_Info_Without_GEQ_Nodes.xml
	And I set default profile to Voice
	When I click on the convert button
	And I press OK button on the message box
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range |
	| hdac     | 0           | 3               | 192               |

@mytag
Scenario: Import device info for the HD Core devices
	Given I have opened the DTT conversion tool
	When I convert the tuning file Tuning_File_Device_Info_HD_Core.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name  | opp_logo_id | default_profile | geq_maximum_range |
	| hdac_core | 0           | 0               | 192               |

@mytag
Scenario: Import device info for the DSP devices 
	Given I have opened the DTT conversion tool
	When I convert the tuning file Tuning_File_Device_Info_DSP.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range |
	| dsp      | 0           | 0               | 192               |

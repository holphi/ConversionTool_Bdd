Feature: Set Install Options
	As a profession tuner for Windows platform
	I want to be able to set install options while I am importing tuning data to database
	So I can customize the intallation options for DAX2 App

@mytag
Scenario: Default install options
	Given I have opened the DTT conversion tool
    When I convert the tuning file Tuning_File_Device_Info.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range | install_options											|
	| hdac     | 0           | 0               | 100               | DesktopIcon=1,TrayIcon=1,HelpImprove=2,ToastNotification=1 |

Scenario: Check desktop icon only
	Given I have opened the DTT conversion tool
	When I check Desktop Icon in install options section
	And I uncheck Tray Icon in install options section
	And I uncheck Toast Notification in install options section
    When I convert the tuning file Tuning_File_Device_Info.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range | install_options											  |
	| hdac     | 0           | 0               | 100               | DesktopIcon=1,TrayIcon=0,HelpImprove=2,ToastNotification=0   |

Scenario: Check tray icon only
	Given I have opened the DTT conversion tool
	When I check Tray Icon in install options section
	And I uncheck Desktop Icon in install options section
	And I uncheck Toast Notification in install options section
    When I convert the tuning file Tuning_File_Device_Info.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range | install_options											  |
	| hdac     | 0           | 0               | 100               | DesktopIcon=0,TrayIcon=1,HelpImprove=2,ToastNotification=0   |

Scenario: Check toast notification only
	Given I have opened the DTT conversion tool
	When I uncheck Tray Icon in install options section
	And I uncheck Desktop Icon in install options section
	And I check Toast Notification in install options section
    When I convert the tuning file Tuning_File_Device_Info.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range | install_options											  |
	| hdac     | 0           | 0               | 100               | DesktopIcon=0,TrayIcon=0,HelpImprove=2,ToastNotification=1   |

Scenario: Check tray icon & desktop icon
	Given I have opened the DTT conversion tool
	When I check Tray Icon in install options section
	And I check Desktop Icon in install options section
	And I uncheck Toast Notification in install options section
    When I convert the tuning file Tuning_File_Device_Info.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range | install_options											  |
	| hdac     | 0           | 0               | 100               | DesktopIcon=1,TrayIcon=1,HelpImprove=2,ToastNotification=0   |

Scenario: Check tray icon and toast notification
	Given I have opened the DTT conversion tool
	When I check Tray Icon in install options section
	And I uncheck Desktop Icon in install options section
	And I check Toast Notification in install options section
    When I convert the tuning file Tuning_File_Device_Info.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range | install_options											  |
	| hdac     | 0           | 0               | 100               | DesktopIcon=0,TrayIcon=1,HelpImprove=2,ToastNotification=1   |

Scenario: Check desktop icon and toast notification
	Given I have opened the DTT conversion tool
	When I uncheck Tray Icon in install options section
	And I check Desktop Icon in install options section
	And I check Toast Notification in install options section
    When I convert the tuning file Tuning_File_Device_Info.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range | install_options											  |
	| hdac     | 0           | 0               | 100               | DesktopIcon=1,TrayIcon=0,HelpImprove=2,ToastNotification=1   |

Scenario: Select UX improvement to Yes
	Given I have opened the DTT conversion tool
	When I uncheck Tray Icon in install options section
	And I uncheck Desktop Icon in install options section
	And I uncheck Toast Notification in install options section
	And I set UX Improvement to Yes in install options section
    When I convert the tuning file Tuning_File_Device_Info.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range | install_options											  |
	| hdac     | 0           | 0               | 100               | DesktopIcon=0,TrayIcon=0,HelpImprove=1,ToastNotification=0   |

Scenario: Select UX improvement to No
	Given I have opened the DTT conversion tool
	When I uncheck Tray Icon in install options section
	And I uncheck Desktop Icon in install options section
	And I uncheck Toast Notification in install options section
	And I set UX Improvement to No in install options section
    When I convert the tuning file Tuning_File_Device_Info.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range | install_options											  |
	| hdac     | 0           | 0               | 100               | DesktopIcon=0,TrayIcon=0,HelpImprove=0,ToastNotification=0   |

Scenario: Select UX improvement to User choose
	Given I have opened the DTT conversion tool
	When I uncheck Tray Icon in install options section
	And I uncheck Desktop Icon in install options section
	And I uncheck Toast Notification in install options section
	And I set UX Improvement to User Choose in install options section
    When I convert the tuning file Tuning_File_Device_Info.xml to the database DAX2.sdf
	And I close the DTT conversion tool
	Then I should be able to query below 1 new records in the table Device_Info of the DAX2 DB
	| SKU_Name | opp_logo_id | default_profile | geq_maximum_range | install_options											  |
	| hdac     | 0           | 0               | 100               | DesktopIcon=0,TrayIcon=0,HelpImprove=2,ToastNotification=0   |

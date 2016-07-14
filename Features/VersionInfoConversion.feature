Feature: VersionInfoConversion
	As a profession tuner for Windows platform
	I want to be able to check the tuning file version
	So the tuning data can be successfully applied to the database
Background: 
Given I have opened the DTT conversion tool
@mytag
Scenario: XML Version Check
	When I set the DB file to DAX2.sdf
	And I set the XML file to Tuning_File_Version_Check.xml
	And I click on the convert button
	Then I should see a message box with the title Error... and the message This tuning file is NOT compatible with this tool. shows up

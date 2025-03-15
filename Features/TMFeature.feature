Feature: TMFeature

As a Turnup Portal admin user
I would like to create, edit and delete time and material records
So that I can manage the employee time and materials successfully

Background: 	
    Given I logged into turnup Portal successfully
	And I navigate to Time and material page

@regression @bvt @timeandmaterial
Scenario: Create new time and material record with valid data
	When I create a new time and material record
	Then The record should be successfully created

	
Scenario Outline: edit time and material record with valid data
	When update time and material record with code '<Code>' , description '<Description>'
	Then The updated record with code '<Code>' , description '<Description>' should be successfully updated

	Examples: 
	| Code        | Description |
	| EditedTest1 | Description1|
	| EditedTest2 | Description2 |
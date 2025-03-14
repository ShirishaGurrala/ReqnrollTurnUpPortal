Feature: TMFeature

As a Turnup Portal admin user
I would like to create, edit and delete time and material records
So that I can manage the employee time and materials successfully

@regression @bvt @timeandmaterial
Scenario: Create new time and material record with valid data
	Given I logged into turnup Portal successfully
	And I navigate to Time and material page
	When I create a new time and material record
	Then The record should be successfully created

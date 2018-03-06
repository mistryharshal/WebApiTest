Feature: Spell Check
In order to search incorrectly
As an API Consumer
I want the API to correct the mistake and return results for correct speliing 
And the response will include a flag to inform the consumer that the spell-check function has been used.

Scenario: Mispelt search request
	Given I search for mispelt item Nik carps 
	When the response is received
	Then I will receive an OK response



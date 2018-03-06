Feature: Search API
	In order to search
	As an API Consumer
	I want the API to return appropriate http response codes

Scenario: Valid search request
	Given I search for red items
	When the response is received
	Then I will receive an OK response


Scenario: Search with missing search term
	Given I search without a search term
	When the response is received
	Then I will receive an BadRequest response
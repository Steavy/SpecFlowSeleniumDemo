Feature: Search on Google page
	In order to search an answer on internet
	As an internet user
	I want to search an item automatically with Google
	
@GoogleIntakeTest
Scenario Outline: Controleer het zoekresultaat van een zoekopdracht via Google
	Given I navigate to the page <Website>
    And I see the page is loaded
	When I enter Search Keyword in the Search Text box
    | Keyword      |
    | <SearchItem> |
    And I click on Search Button
	Then Search items <Answer> shows the items related to SpecFlow
Examples: 
| Website    | SearchItem   | Answer                                                            |
| google.com | Specflow     | SpecFlow - Cucumber for .NET                                      |
| google.com | cucumber     | Cucumber                                                          |
| google.com | nu.nl        | NU - Het laatste nieuws het eerst op NU.nl                        |
| google.com | ad.nl        | AD.nl, het laatste nieuws uit binnen- en buitenland, sport en ... |
| google.com | test         | Test - Wikipedia                                                  |


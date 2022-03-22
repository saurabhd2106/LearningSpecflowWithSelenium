Feature: Post Articles
	
	Scenario: Add an article
		Given As a writer
		When I post an article
		Then posted article should be visible for my learners
Feature: Post Articles
	
	Scenario: Add an article
		Given As a writer
		When I post an article with title as Learning Specflow
		Then posted article should be visible for my learners
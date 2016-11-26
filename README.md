# Chalenge TDD: RSS-Most-Relevant-Terms 
We would like to analyze the most relevant terms of the website ARS Technica. 

To do so please write a code that loads the most recent articles from ARS Technica’s RSS feed and returns the top 5 most frequent words and its frequency by article. We are interested only on relevant terms so you should ignore articles, prepositions and other irrelevant words. Please implement unit tests to test your code they will also be analyzed. Send us both the code and unit tests source code. Beware that what will be analyzed on this exercise is the not only the correction of the code but also code best practices, like OOP, SOLID, unit tests and mocks.
Technical Specifications:

•	The code should be written in C#
•	The code should return a list of the top 5 most frequent words by article. The result should return the words and the number of times (count) it appears on each article.
•	Only the content of the tag <content:encoded> should be analyzed
•	The unit tests can be done on your preferred Unit Tests framework
•	ARS Technica rss feed: http://feeds.arstechnica.com/arstechnica/technology-lab

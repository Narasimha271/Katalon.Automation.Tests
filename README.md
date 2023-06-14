# Katalon.Automation.Tests
Instructions on setting up your project locally. To get a local copy up and running follow these simple example steps.
Prerequisites:
Visual Studio
SpecFlow installed in Visual Studio 2022

Copy the repository link: https://github.com/Narasimha271/Katalon.Automation.Tests.git
Ope Visual Stodio and select Clone a Repository.
Select GitHub from Browse a repository section.
Login to the GitHub and paste the above URL in search box.
Press Clone and then open the cloned Project and Install any missing nuget packages.

Build the project >> open Test Explorer and run the Test: WebAUtomationTaskFeature.


Future Improvements.
1.	Integrate reporting into the Test Project to produce HTML reports 
Investigate the different reporting packages, Allure, ExtentReports, etc and select the best one for DHCW. Implement the reporting within the project.  This work would provide reporting for all automation work carried out to date and any future automation improvements.

2.	Introduce an appsettings.json file for config parameters 
To allow for the framework to enable url and test data changes seamlessly, the framework needs an appsettings file that can store these variables and can be used within the test automation. Would allow us to run across multiple testing environments.

3.	Integrate with the Data Importer Solution 
Refactor the tests to allow it to work with the ImportScenario project that allows the creation of Test data directly to the database.  



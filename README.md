**Repository URL:** https://github.com/cgholap/WoltersKluwerAssignment.git

**Automation tools used:**
Selenium with C# language.
NUnit framework.

**Steps to run the tests:**
Clone repository on local – "WoltersKluwerAssignment"
Install Visual Studio Community 2022 on local machine.
Open 'Solution Explorer' -> Right click on assembly 'WoltersKluwerAssignment' -> Select 'Load Direct Dependencies'.
In Visual Studio -> Go to 'Build' -> 'Rebuild Solution'.
In Visual Studio -> Go to 'Test Explorer'.
Right Click on 'ToDoTests' -> Select 'Run'. It will run all the tests. To run any single test, right click on required test -> Select 'Run'.

**Framework Structure:**
There are 2 folders in framework: 'PageObjects' and 'Tests'.
'PageObjects' folder contain 'todos' web page used in an application along with the web elements and methods to access to those web elements.
'Tests' folder contain actual test cases where we are validating functionality.
'BrowserManager' class contain methods which will do initial setup of browser, launch an application and close an application.
'ReportManager' class contain methods which are used to generate test report.

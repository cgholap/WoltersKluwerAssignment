**Repository URL:** https://github.com/cgholap/WoltersKluwerAssignment.git

**Automation tools used:**
- Selenium with C# language.
- NUnit framework.

**Steps to run the tests:**

1. Clone the repository on local – "WoltersKluwerAssignment".  
2. Install Visual Studio Community 2022 on your local machine.  
3. Open 'Solution Explorer' -> Right click on assembly 'WoltersKluwerAssignment' -> Select 'Load Direct Dependencies'.  
4. In Visual Studio -> Go to 'Build' -> 'Rebuild Solution'.  
5. In Visual Studio -> Go to 'Test Explorer'.  
6. Right click on 'ToDoTests' -> Select 'Run'. It will run all the tests.  
7. To run any single test, right-click on the required test -> Select 'Run'.  

**Framework Structure:**

- There are 2 folders in the framework: 'PageObjects' and 'Tests'.
- 'PageObjects' folder contains the 'todos' web page used in the application along with the web elements and methods to access those web elements.
- 'Tests' folder contains the actual test cases where we are validating functionality.
- 'BrowserManager' class contains methods which will do the initial setup of the browser, launch an application, and close the application.
- 'ReportManager' class contains methods that are used to generate test reports.

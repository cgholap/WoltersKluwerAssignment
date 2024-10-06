using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace WoltersKluwerAssignment
{
    public static class ReportManager
    {
        private static ExtentReports _extent;
        private static ExtentHtmlReporter _htmlReporter;
        private static ExtentTest _test;

        public static void InitializeReport()
        {
            // Specify the report path
            var reportPath = @"C:\Reports\TestReport.html";

            // Initialize the HTML Reporter
            _htmlReporter = new ExtentHtmlReporter(reportPath);
            
            // Configure the report (new method to configure)
            _htmlReporter.Configuration().DocumentTitle = "Test Execution Report";
            _htmlReporter.Configuration().ReportName = "Automation Test Report";
            _htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

           // Initialize ExtentReports and attach the reporter(s)
           _extent = new ExtentReports();
            _extent.AttachReporter(_htmlReporter);

            // Add system or environment information if needed
            _extent.AddSystemInfo("Tester", "Chaitanya");
            _extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
            _extent.AddSystemInfo("Browser", "Chrome");
        }

        public static void StartTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static void LogTestStep(string stepDescription)
        {
            _test.Log(Status.Pass, stepDescription);
        }

        public static void LogTestFailure(string stepDescription)
        {
            _test.Log(Status.Fail, stepDescription);
        }

        public static void LogTestWarning(string stepDescription)
        {
            _test.Log(Status.Warning, stepDescription);
        }

        public static void EndTest()
        {
            _test.Log(Status.Info, "Test completed");
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
using WoltersKluwerAssignment.PageObjects;
using OpenQA.Selenium;

namespace WoltersKluwerAssignment
{
    public class ToDoTests
    {
        IWebDriver driver;
        BrowserManager browserManager;
        ToDosPage todosPage;

        [SetUp]
        public void SetupApplication()
        {
            browserManager = new BrowserManager();
            driver = browserManager.LaunchApplication();
            todosPage = new ToDosPage(driver);
            ReportManager.InitializeReport();
        }

        [Test, Order(1)]
        [TestCase(TestName = "TC#1", Description = "Verify textbox is visible and enabled. Verify textbox placeholder.")]
        public void VerifyToDoTextbox()
        {
            ReportManager.StartTest("TC#1: Verify ToDo Textbox");

            try
            {
                todosPage.verifyToDoTextBox();
                ReportManager.LogTestStep("Textbox is visible, enabled and placeholder verified.");
            }
            catch (Exception e)
            {
                ReportManager.LogTestFailure($"Test failed: {e.Message}");
                throw;
            }

            ReportManager.EndTest();
        }

        [Test, Order(2)]
        [TestCase(TestName = "TC#2", Description = "Add multiple ToDo items. Verify Added items. Verify item count as 4.")]
        public void VerifyByAddingMultipleToDoItems()
        {
            ReportManager.StartTest("TC#2: Verify Adding Multiple ToDo Items");

            try
            {
                todosPage.addToDoItems("Item 1", "Item 2", "Item 3", "Item 4");
                todosPage.verifyAddedToDoItems("Item 1", "Item 2", "Item 3", "Item 4");
                todosPage.verifyCountOfToDoItems(4);
                ReportManager.LogTestStep("Multiple items added and verified successfully.");
            }
            catch (Exception e)
            {
                ReportManager.LogTestFailure($"Test failed: {e.Message}");
                throw;
            }

            ReportManager.EndTest();
        }

        [Test, Order(3)]
        [TestCase(TestName = "TC#3", Description = "Remove single ToDo item. Verify removed item is not displayed. Verify count of remaining ToDo ietms as 3.")]
        public void VerifyByRemovingSingleToDoItem()
        {
            ReportManager.StartTest("TC#3: Verify Removing Single ToDo Item");

            try
            {
                todosPage.addToDoItems("Item 1", "Item 2", "Item 3", "Item 4");
                todosPage.removeToDoItem("Item 4");
                todosPage.verifyRemovedToDoItem("Item 4");
                todosPage.verifyCountOfToDoItems(3);
                ReportManager.LogTestStep("Item removed successfully, verified item count as 3.");
            }
            catch (Exception e)
            {
                ReportManager.LogTestFailure($"Test failed: {e.Message}");
                throw;
            }

            ReportManager.EndTest();
        }

        [Test, Order(4)]
        [TestCase(TestName = "TC#4", Description = "Add multiple ToDo items. From 'All' tab, complete all ToDo items. Go to 'Active' tab and verify count as 0. Go to 'Completed' tab and verify count as 4. Clear completed ToDos and verify count as 0.")]
        public void VerifyCompletedToDoItems() 
        {
            ReportManager.StartTest("TC#4: Verify Completed ToDo Items");

            try
            {
                todosPage.addToDoItems("Item 1", "Item 2", "Item 3", "Item 4");
                todosPage.completeAllToDoItems();
                todosPage.gotoTab("Active");
                todosPage.verifyCountOfToDoItems(0);
                todosPage.gotoTab("Completed");
                todosPage.verifyCountOfToDoItems(4);
                todosPage.clearCompletedToDoItems();
                todosPage.verifyCountOfToDoItems(0);
                ReportManager.LogTestStep("Completed ToDo items verified and cleared successfully.");
            }
            catch (Exception e)
            {
                ReportManager.LogTestFailure($"Test failed: {e.Message}");
                throw;
            }

            ReportManager.EndTest();
        }

        [Test, Order(5)]
        [TestCase(TestName = "TC#5", Description = "Try to add empty todo item. It should't add ToDo item. Verify count of ToDos as 0.")]
        public void VerifyByAddingEmptyToDoItem()
        {
            ReportManager.StartTest("TC#5: Verify Adding Empty ToDo Item");

            try
            {
                todosPage.addToDoItems("  ");
                todosPage.verifyCountOfToDoItems(0);
                ReportManager.LogTestStep("Verified that empty ToDo item can't be added.");
            }
            catch (Exception e)
            {
                ReportManager.LogTestFailure($"Test failed: {e.Message}");
                throw;
            }

            ReportManager.EndTest();
        }

        [Test, Order(6)]
        [TestCase(TestName = "TC#6", Description = "Add multiple ToDos. From 'Active' tab, click on 'Clear completed'. Active ToDos should not be cleared. Verify count of ToDos as 4.")]
        public void VerifyActiveToDos()
        {
            ReportManager.StartTest("TC#6: Verify active ToDo items");

            try
            {
                todosPage.addToDoItems("Item 1", "Item 2", "Item 3", "Item 4");
                todosPage.gotoTab("Active");
                todosPage.clearCompletedToDoItems();
                todosPage.verifyCountOfToDoItems(4);
                ReportManager.LogTestStep("Verified active ToDo items successfully.");
            }
            catch (Exception e)
            {
                ReportManager.LogTestFailure($"Test failed: {e.Message}");
                throw;
            }

            ReportManager.EndTest();
        }

        [Test, Order(7)]
        [TestCase(TestName = "TC#7", Description = "Add Todo item with a single character. It should't add ToDo item. Verify count of ToDos as 0.")]
        public void VerifyToDoItemWithSingleCharacter()
        {
            ReportManager.StartTest("TC#7: Verify ToDo with single character");

            try
            {
                todosPage.addToDoItems("A");
                todosPage.verifyCountOfToDoItems(0);
                ReportManager.LogTestStep("Verified that ToDo with single character can't be added.");
            }
            catch (Exception e)
            {
                ReportManager.LogTestFailure($"Test failed: {e.Message}");
                throw;
            }

            ReportManager.EndTest();
        }

        [Test, Order(8)]
        [TestCase(TestName = "TC#8", Description = "Add Todo item with more that 1 white spaces. ToDo item should be added with only 1 white space.")]
        public void VerifyToDoItemWithWhiteSpaces()
        {
            ReportManager.StartTest("TC#8: Verify ToDo with multiple white spaces");

            try
            {
                todosPage.addToDoItems("Do      Shopping");
                todosPage.verifyAddedToDoItems("Do Shopping");
                ReportManager.LogTestStep("Verified ToDo with multiple white spaces.");
            }
            catch (Exception e)
            {
                ReportManager.LogTestFailure($"Test failed: {e.Message}");
                throw;
            }

            ReportManager.EndTest();
        }

        [TearDown]
        public void CloseApplication()
        {
            browserManager.CloseApplication();
            driver.Dispose();
        }
    }
}
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WoltersKluwerAssignment.PageObjects
{
    public class ToDosPage
    {
        IWebDriver driver;

        public ToDosPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Web Elements

        By enterTodoTextbox = By.Id("todo-input");

        By selectAllToDosArrow = By.ClassName("toggle-all");

        By todoItem = By.XPath("//li/div/label");

        By clearCompletedLink = By.XPath("//button[text()='Clear completed']");

        #endregion

        #region Methods

        // Helper method to get the element.
        private IWebElement getElement(By locator)
        {
            return driver.FindElement(locator);
        }

        // Switch tab.
        public void gotoTab(string tabName)
        {
            driver.FindElement(By.XPath(String.Format("//a[text()='{0}']", tabName))).Click();
        }

        // Verify ToDo Textbox.
        public void verifyToDoTextBox()
        {
            Assert.IsTrue(driver.FindElement(enterTodoTextbox).Displayed, "ToDo textbox is not displayed.");
            Assert.IsTrue(driver.FindElement(enterTodoTextbox).Enabled, "ToDo textbox is not enabled.");
            string placeholderText = getElement(enterTodoTextbox).GetAttribute("placeholder");
            Assert.That(placeholderText, Is.EqualTo("What needs to be done?"), "Plaxeholder text is not matching.");
        }

        // Add ToDo item(s).
        public void addToDoItems(params string[] todoItems)
        {
            foreach (string item in todoItems) {
                getElement(enterTodoTextbox).Click();
                getElement(enterTodoTextbox).SendKeys(item);
                getElement(enterTodoTextbox).SendKeys(Keys.Enter);
            }
        }

        // Verify added ToDo item(s).
        public void verifyAddedToDoItems(params string[] todoItems)
        {
            foreach (string item in todoItems) {
                Assert.IsTrue(driver.FindElement(By.XPath(String.Format("//li/div/label[normalize-space(text())='{0}']", item))).Displayed, $"ToDo '{item}' is not displayed.");
            }
        }

        // Verify count of ToDo item(s).
        public void verifyCountOfToDoItems(int expectedCount)
        {
            IList<IWebElement> todos = driver.FindElements(By.XPath("//li/div/label"));
            int totalToDoItems = todos.Count;
            Assert.That(totalToDoItems, Is.EqualTo(expectedCount), "Count of ToDo items is not correct.");
        }

        // Remove ToDo item.
        public void removeToDoItem(string todoItem)
        {
            IWebElement removeToDo = driver.FindElement(By.XPath(String.Format("//li/div/label[text()='{0}']", todoItem)));
            Actions actions = new Actions(driver);
            actions.MoveToElement(removeToDo).Perform();
            driver.FindElement(By.XPath(String.Format("//li/div/label[text()='{0}']//following-sibling::button", todoItem))).Click();
        }

        // Verify removed ToDo item.
        public void verifyRemovedToDoItem(string todoItem)
        {
            // Find all elements matching the XPath.
            IList<IWebElement> todos = driver.FindElements(By.XPath(String.Format("//li/div/label[text()='{0}']", todoItem)));
            // Assert that no matching elements are found.
            Assert.IsTrue(todos.Count == 0, $"ToDo '{todoItem}' is still displayed.");
        }

        // Complete All ToDo items.
        public void completeAllToDoItems()
        {
            driver.FindElement(selectAllToDosArrow).Click();
        }

        // Clear completed ToDo items.
        public void clearCompletedToDoItems()
        {
            driver.FindElement(clearCompletedLink).Click();
        }



        #endregion
    }
}

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Test2
{
    [TestFixture]
    public class UnitTest1
    {
        private Actions _actions;
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [Test]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            _actions.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);
        }

        [Test]
        public void TestMethod2()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));


            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));

            var drag = _actions
                .ClickAndHold(sourceElement)
                .MoveToElement(targetElement)
                .Release(sourceElement)
                .Build();

            drag.Perform();
            Assert.AreEqual("Dropped!", targetElement.Text);
        }

        [SetUp]
        public void Setup()
        {
            string outPutDirectory = @"C:\Users\SzymonK\Desktop\Selenium-git\DragAndDrop2\Test2\Test2";
            _driver = new ChromeDriver(outPutDirectory);
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}

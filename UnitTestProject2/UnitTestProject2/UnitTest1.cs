using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace UnitTestProject2
{
    [TestFixture]
    public class UnitTest1
    {

               
        ChromeDriver chrom;
        [Test]
        public void TestMethod1()
        {

            chrom = new ChromeDriver();
            chrom.Navigate().GoToUrl("https://github.com/");
      
            IWebElement signField = chrom.FindElement(By.XPath("//a[@href='/login']"));
            signField.Click();

            IWebElement loginField = chrom.FindElement(By.Name("login"));
            loginField.SendKeys("testautomationuser");

            IWebElement passwordField = chrom.FindElement(By.Name("password"));
            passwordField.SendKeys("Time4Death!");

            IWebElement buttonSign = chrom.FindElement(By.Name("commit"));
            buttonSign.Click();


        }
    }
}

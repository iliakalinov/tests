using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace UnitTestProject2


{


    static class Email
    {

        public static string email()
        {
            {
                string e = "";
                string s = "qwertyuiopasdfghjklzxcvbnm";
                Random r = new Random((int)DateTime.Now.Ticks);
                for (int i = 0; i <= 10; i++)
                {
                    e += s[r.Next(20)];

                }
                e += "@mail.ru";

                return e;
            }

        }

        
        [TestFixture]
        public class UnitTest1
        {

            public string newemail = Email.email();

            ChromeDriver chrom;


            //(Проверка на заполнение полей)
            [Test]
            public void TestMethod1()
            {

                chrom = new ChromeDriver();
                chrom.Manage().Window.Maximize();

                chrom.Navigate().GoToUrl("https://tickets.by/gd");
                IWebElement first = chrom.FindElement(By.Name("from_name"));
                first.SendKeys("минск");
                IWebElement input = chrom.FindElement(By.XPath("//*[@id='page']/div[1]/div/form/div[3]/input"));
                input.Click();

                IWebElement second = chrom.FindElement(By.XPath("//*[@id='from_name_as']"));
                string s = second.Text.ToString();

                NUnit.Framework.Assert.AreEqual(s, string.Empty);

            }

            //(Проверка на несуществующие маршруты)
            [Test]
            public void TestMethod2()
            {

                chrom = new ChromeDriver();
                chrom.Manage().Window.Maximize();

                chrom.Navigate().GoToUrl("https://tickets.by/gd");
                chrom.FindElement(By.XPath("//*[@id='page']/div[1]/div/form/div[2]/div/div[4]/img")).Click();
                chrom.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div[1]/table/tbody/tr[4]/td[6]/a")).Click();

                IWebElement first = chrom.FindElement(By.Name("from_name"));
                first.SendKeys("Минкс");
                IWebElement second = chrom.FindElement(By.XPath("//*[@id='to_name']"));
                second.SendKeys("Минск");
                IWebElement input = chrom.FindElement(By.XPath("//*[@id='page']/div[1]/div/form/div[3]/input"));
                input.Click();
                string s = first.Text.ToString();
                NUnit.Framework.Assert.AreEqual(s, string.Empty);

            }
            //(Проверка на работоспособность )
            [Test]
            public void TestMethod3()
            {

                chrom = new ChromeDriver();
                chrom.Manage().Window.Maximize();

                chrom.Navigate().GoToUrl("https://tickets.by/gd");
                chrom.FindElement(By.XPath("//*[@id='page']/div[1]/div/form/div[2]/div/div[4]/img")).Click();
                chrom.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div[1]/table/tbody/tr[4]/td[6]/a")).Click();

                IWebElement first = chrom.FindElement(By.Name("from_name"));
                first.SendKeys("Минск");
                Thread.Sleep(2000);

                first.SendKeys(OpenQA.Selenium.Keys.Enter);

                IWebElement second = chrom.FindElement(By.XPath("//*[@id='to_name']"));
                second.SendKeys("Борисов");
                Thread.Sleep(2000);
                second.SendKeys(OpenQA.Selenium.Keys.Enter);

                IWebElement input = chrom.FindElement(By.XPath("//*[@id='page']/div[1]/div/form/div[3]/input"));
                input.Click();
                Thread.Sleep(6000);
                IWebElement itog = chrom.FindElement(By.XPath("//*[@id='content']/div[3]/div/ul[2]/li[1]/div[2]/ul/li[1]/div[2]/a"));
                string s = itog.Text.ToString();
                NUnit.Framework.Assert.AreEqual(s, "Выбрать");

            }
            
            //(Проверка успешной регистрации)
            [Test]
            public void TestMethod4()
            {


                chrom = new ChromeDriver();
                chrom.Manage().Window.Maximize();

                chrom.Navigate().GoToUrl("https://tickets.by/gd");

                IWebElement my_tickets_button = chrom.FindElement(By.XPath("//*[@id='header']/div/div/div/div[3]/a[1]/span"));
                my_tickets_button.Click();

                IWebElement authorization_button = chrom.FindElement(By.XPath("//*[@id='login_popup']/div[1]/a"));
                authorization_button.Click();

                IWebElement name = chrom.FindElement(By.XPath("//*[@id='first_name']"));
                name.SendKeys("Name");

                IWebElement surname = chrom.FindElement(By.XPath("//*[@id='last_name']"));
                surname.SendKeys("surname");

                IWebElement email = chrom.FindElement(By.XPath("//*[@id='email']"));
                email.SendKeys(newemail.ToString());

                IWebElement password = chrom.FindElement(By.XPath("//*[@id='pass_register']"));
                password.SendKeys("my_passwort");

                IWebElement phone = chrom.FindElement(By.XPath("//*[@id='phone_number']"));
                phone.SendKeys("123456789");


                IWebElement input = chrom.FindElement(By.XPath("//*[@id='reg_popup']/form/div[5]/input"));
                input.Click();

                Thread.Sleep(2000);
                IWebElement Exit = chrom.FindElement(By.XPath("//*[@id='header' ]/div/div/div/div[3]/a[1]"));
                string s = Exit.Text.ToString();
                NUnit.Framework.Assert.AreEqual(s, "(Выйти)");

            }
            //(Проверка на авторизацию)
            [Test]
            public void TestMethod5()
            {
                chrom = new ChromeDriver();
                chrom.Manage().Window.Maximize();

                chrom.Navigate().GoToUrl("https://tickets.by/gd");

                IWebElement my_tickets_button = chrom.FindElement(By.XPath("//*[@id='header']/div/div/div/div[3]/a[1]/span"));
                my_tickets_button.Click();

                IWebElement login = chrom.FindElement(By.XPath("//*[@id='email_login']"));
                login.SendKeys(newemail.ToString());

                IWebElement password = chrom.FindElement(By.XPath("//*[@id='pass_login']"));
                password.SendKeys("my_passwort");

                IWebElement input = chrom.FindElement(By.XPath("//*[@id='login_popup']/div[5]/form/div[2]/div/input"));
                input.Click();
                Thread.Sleep(2000);
                IWebElement Exit = chrom.FindElement(By.XPath("//*[@id='header']/div/div/div/div[3]/a[1]"));
                string s = Exit.Text.ToString();
                NUnit.Framework.Assert.AreEqual(s, "(Выйти)");

            }

            //  (Проверка на авторизацию по неверным данным )
            [Test]
            public void TestMethod6()
            {
                chrom = new ChromeDriver();
                chrom.Manage().Window.Maximize();

                chrom.Navigate().GoToUrl("https://tickets.by/gd");

                IWebElement my_tickets_button = chrom.FindElement(By.XPath("//*[@id='header']/div/div/div/div[3]/a[1]/span"));
                my_tickets_button.Click();

                IWebElement login = chrom.FindElement(By.XPath("//*[@id='email_login']"));
                login.SendKeys("qw" + newemail.ToString());

                IWebElement password = chrom.FindElement(By.XPath("//*[@id='pass_login']"));
                password.SendKeys("mmy_passwort");

                IWebElement input = chrom.FindElement(By.XPath("//*[@id='login_popup']/div[5]/form/div[2]/div/input"));
                input.Click();
                Thread.Sleep(2000);

                IWebElement Exit = chrom.FindElement(By.XPath("//*[@id='login_popup']/div[5]/form/div[1]/div[1]/samp"));
                string s = Exit.Text.ToString();
                NUnit.Framework.Assert.AreEqual(s, "Вам не удалось авторизоваться. Для ознакомления с возможными причинами, перейдите по ссылке");

            }

            //(Проверка валидации при регистрации )
            [Test]
            public void TestMethod7()
            {

                chrom = new ChromeDriver();
                chrom.Manage().Window.Maximize();

                chrom.Navigate().GoToUrl("https://tickets.by/gd");

                IWebElement my_tickets_button = chrom.FindElement(By.XPath("//*[@id='header']/div/div/div/div[3]/a[1]/span"));
                my_tickets_button.Click();

                IWebElement authorization_button = chrom.FindElement(By.XPath("//*[@id='login_popup']/div[1]/a"));
                authorization_button.Click();

                IWebElement input = chrom.FindElement(By.XPath("//*[@id='reg_popup']/form/div[5]/input"));
                input.Click();

                Thread.Sleep(2000);


                IWebElement Exit = chrom.FindElement(By.XPath("//*[@id='reg_popup']/form/div[1]/div[1]/samp"));
                string s = Exit.Text.ToString();
                NUnit.Framework.Assert.AreEqual(s, "Это поле необходимо заполнить");
            }

            //(Проверка на обязательное написание номера телефона при регистрации)
            [Test]
            public void TestMethod8()
            {

                chrom = new ChromeDriver();
                chrom.Manage().Window.Maximize();

                chrom.Navigate().GoToUrl("https://tickets.by/gd");

                IWebElement my_tickets_button = chrom.FindElement(By.XPath("//*[@id='header']/div/div/div/div[3]/a[1]/span"));
                my_tickets_button.Click();

                IWebElement authorization_button = chrom.FindElement(By.XPath("//*[@id='login_popup']/div[1]/a"));
                authorization_button.Click();

                IWebElement name = chrom.FindElement(By.XPath("//*[@id='first_name']"));
                name.SendKeys("Name");

                IWebElement surname = chrom.FindElement(By.XPath("//*[@id='last_name']"));
                surname.SendKeys("surname");

                IWebElement email = chrom.FindElement(By.XPath("//*[@id='email']"));
                email.SendKeys(Email.email());


                IWebElement password = chrom.FindElement(By.XPath("//*[@id='pass_register']"));
                password.SendKeys("my_passwort");


                IWebElement input = chrom.FindElement(By.XPath("//*[@id='reg_popup']/form/div[5]/input"));
                input.Click();

                Thread.Sleep(2000);

                IWebElement Exit = chrom.FindElement(By.XPath("//*[@id='reg_popup']/form/div[4]/samp"));
                string s = Exit.Text.ToString();
                NUnit.Framework.Assert.AreEqual(s, "Пожалуйста, введите корректный номер телефона");
            }
            //(Проверка валидацию Email при регистрации )
            [Test]
            public void TestMethod9()
            {
                chrom = new ChromeDriver();
                chrom.Manage().Window.Maximize();

                chrom.Navigate().GoToUrl("https://tickets.by/gd");

                IWebElement my_tickets_button = chrom.FindElement(By.XPath("//*[@id='header']/div/div/div/div[3]/a[1]/span"));
                my_tickets_button.Click();

                IWebElement authorization_button = chrom.FindElement(By.XPath("//*[@id='login_popup']/div[1]/a"));
                authorization_button.Click();

                IWebElement name = chrom.FindElement(By.XPath("//*[@id='first_name']"));
                name.SendKeys("Name");

                IWebElement surname = chrom.FindElement(By.XPath("//*[@id='last_name']"));
                surname.SendKeys("surname");

                IWebElement email = chrom.FindElement(By.XPath("//*[@id='email']"));
                email.SendKeys("ewwwktr66620zamgecom");


                IWebElement password = chrom.FindElement(By.XPath("//*[@id='pass_register']"));
                password.SendKeys("my_passwort");

                IWebElement phone = chrom.FindElement(By.XPath("//*[@id='phone_number']"));
                phone.SendKeys("123456789");


                IWebElement input = chrom.FindElement(By.XPath("//*[@id='reg_popup']/form/div[5]/input"));
                input.Click();

                Thread.Sleep(2000);
                IWebElement Exit = chrom.FindElement(By.XPath("//*[@id='reg_popup']/form/div[2]/samp"));
                string s = Exit.Text.ToString();
                NUnit.Framework.Assert.AreEqual(s, "Пожалуйста, введите корректный адрес электронной почты");
            }

            //(Проверка на изменение маршрута)
            [Test]
            public void TestMethod10()
            {
                chrom = new ChromeDriver();
                chrom.Manage().Window.Maximize();

                chrom.Navigate().GoToUrl("https://tickets.by/gd");
                chrom.FindElement(By.XPath("//*[@id='page']/div[1]/div/form/div[2]/div/div[4]/img")).Click();
                chrom.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div[1]/table/tbody/tr[4]/td[6]/a")).Click();

                IWebElement first = chrom.FindElement(By.Name("from_name"));
                first.SendKeys("Минск");
                Thread.Sleep(2000);

                first.SendKeys(OpenQA.Selenium.Keys.Enter);

                IWebElement second = chrom.FindElement(By.XPath("//*[@id='to_name']"));
                second.SendKeys("Борисов");
                Thread.Sleep(2000);
                second.SendKeys(OpenQA.Selenium.Keys.Enter);

                IWebElement input = chrom.FindElement(By.XPath("//*[@id='page']/div[1]/div/form/div[3]/input"));
                input.Click();
                Thread.Sleep(6000);
                IWebElement itog = chrom.FindElement(By.XPath("//*[@id='content']/div[3]/div/ul[2]/li[1]/div[1]/span[1]"));
                string s = itog.Text.ToString();



                IWebElement substitution = chrom.FindElement(By.XPath("//*[@id='page']/div[2]/div/div/div/a"));
                substitution.Click();
                Thread.Sleep(2000);
                second = chrom.FindElement(By.XPath("//*[@id='to_name']"));

                second.Clear();
                second.SendKeys("Витебск");
                Thread.Sleep(2000);
                second.SendKeys(OpenQA.Selenium.Keys.Enter);

                Thread.Sleep(6000);
                itog = chrom.FindElement(By.XPath("//*[@id='content']/div[3]/div/ul[2]/li[1]/div[1]/span[1]"));
                string s1 = itog.Text.ToString();
                Boolean b = s1.Equals(s);
                NUnit.Framework.Assert.AreEqual(b, false);
            }
        }
    }
}

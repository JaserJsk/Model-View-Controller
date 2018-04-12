using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;

namespace MvcAuth.UI.Tests
{
    [TestClass]
    public class AuthenticationTests
    {
        [TestMethod]
        public void Register_WithUsername_ShouldRegisterUserWithCorrectUsername()
        {
            // ARRANGE 
            var email = $"{Guid.NewGuid().ToString().Replace("-", "")}@fekberg.com";
            var username = Guid.NewGuid().ToString().Replace("-", "");
            var password = "p@ssw0rD!";

            var firefox = new FirefoxDriver();

            firefox.Navigate().GoToUrl("http://localhost:3996/Authentication/Register");

            // ACT
            firefox.FindElementById("username").SendKeys(username);
            firefox.FindElementById("password").SendKeys(password);
            firefox.FindElementById("email").SendKeys(email);

            firefox.FindElementByTagName("form").Submit();

            // ASSERT

            Thread.Sleep(2000);

            var h2Text = firefox.FindElementByTagName("h2").Text;

            Assert.IsTrue(h2Text.Contains(username));

            firefox.Close();
        }

        [TestMethod]
        public void Login_CouldLoginWithAdministrator_ShouldShowDashboard()
        {
            var firefox = new FirefoxDriver();

            firefox.Navigate().GoToUrl("http://localhost:3996/Authentication/Login");

            firefox.FindElementById("username").SendKeys("fekberg1");
            firefox.FindElementById("password").SendKeys("mail1@filipekberg.se");
            firefox.FindElementByTagName("form").Submit();
            

            Thread.Sleep(2000);

            firefox.Navigate().GoToUrl("http://localhost:3996/Administration/Dashboard");

            Thread.Sleep(2000);

            var body = firefox.FindElementByTagName("body").Text;

            Assert.AreEqual("You are an Admin!", body);

            firefox.Close();
        }


        [TestMethod]
        public void Register_GetRegistrationPage_ReturnsAHTMLResponse()
        {
            using (var client = new HttpClient())
            {
                var respsonse =
                    Task.Run(async () => await client.GetAsync("http://localhost:3996/Authentication/Register")).Result;

                var html = Task.Run(async () => await respsonse.Content.ReadAsStringAsync()).Result;

                Assert.IsNotNull(html);
            }
        }
    }
}

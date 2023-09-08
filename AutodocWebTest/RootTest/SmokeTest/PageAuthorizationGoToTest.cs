using Allure.Commons;
using AutodocWebTest.Data;
using AutodocWebTest.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.RootTest.SmokeTest
{
    [TestFixture]
    [AllureNUnit]
    [AllureEpic("AutodocAutomationWebUI")]
    [AllureFeature("Authorization/CriticalPath")]
    public class PageAuthorizationGoToTest : BaseTest
    {
        [AllureTag("CriticalPath", "Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Переход на страницу регистрации")]
        [Test(Description = "Открываем страницу авторизации; Нажимем ссылку 'Регистрация'.")]
        public void GoToRegistrationPageTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .ClickLinkRegistration();

            Assert.IsTrue(driver.FindElement(By.XPath(DataToTest.titleH1RegistrationUser)).Displayed);
        }

    }
}

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
    [AllureEpic("AutodocWebAutomationUI")]
    [AllureFeature("Пользователь выходит из системы : Smoke : Позитивные/негативные сценарии.")]
    public class UserLogOut_Tests : BaseTest
    {
        [AllureTag("Smoke", "Regression", "LogOut")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureStory("Выход из ЛК.")]
        [Test(Description = "Открываем страницу 'Авторизация'; Вводим валидный логин/пароль; Выполняем вход; Выполняем выход.")]
        public void LogOut_Successful_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn(DataToTest.validLogin, DataToTest.validPassword)
                .openPagePrivateCabinet()
                .clickButtonLogOut();

            Console.WriteLine("Проверяем, что произошёл выход из личного кабинета.Персональный логин не отображается.");
            Assert.IsTrue(driver.FindElement(By.XPath(MainUserNotSignInPageObject.linkPrivateCabinet)).Displayed);
        }
    }
}

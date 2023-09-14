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
    [AllureFeature("Выполняются позитивные/негативные smoke сценарии регистрации пользователя.")]
    public class RegistrationUser_Tests : BaseTest
    {
        [AllureTag("Smoke", "Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Регистрация пользователя : Валидные данные")]
        [Test(Description = "Открываем страницу 'Регистрация пользователя'; Заполняем обязательные поля валидными данными; Нажимаем зарегистрироваться")]
        public void RegistrationUser_ValidData_Successful()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageRegistrationUser();

            Console.WriteLine("Проверяем, что мы перешли на страницу 'Регистрация пользователя'");
            Assert.IsTrue(driver.FindElement(By.XPath(RegistrationUserPageObject.titleH1RegistrationUser)).Displayed);

            string classAttributeValue = driver.FindElement(By.XPath(RegistrationUserPageObject.buttonPhysicalPerson)).GetAttribute("class");
            Assert.That(classAttributeValue.Contains("active"), Is.True);

            Assert.IsTrue(driver.FindElement(By.XPath(RegistrationUserPageObject.titleRegistrationCrumbs)).Displayed);

            new RegistrationUserPageObject(driver)
                .ClickDropDownListShop();

        }
    }
}

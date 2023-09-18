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
    [AllureFeature("Выполняются взаимодействия с элементами расположенными на странице 'Авторизация'.")]
    public class AuthorizationPage_InteractionElement_Tests : BaseTest
    {
        [AllureTag("CriticalPath", "Regression", "GoTo")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Переход на страницу 'Регистрация пользователя'")]
        [Test(Description = "Открываем страницу 'Авторизация'; Нажимем ссылку 'Регистрация'.")]
        public void GoTo_RegistrationPage_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .ClickLinkRegistration();

            Console.WriteLine("Проверяем. что мы перешли на страницу 'Регистрация пользователя'");
            Assert.IsTrue(driver.FindElement(By.XPath(RegistrationUserPageObject.titleH1RegistrationUser)).Displayed);

            string classAttributeValue = driver.FindElement(By.XPath(RegistrationUserPageObject.buttonPhysicalPerson)).GetAttribute("class");
            Assert.That(classAttributeValue.Contains("active"), Is.True);

            Assert.IsTrue(driver.FindElement(By.XPath(RegistrationUserPageObject.titleRegistrationCrumbs)).Displayed);
        }

        [AllureTag("CriticalPath", "Regression", "GoTo")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Переход на страницу 'Восстановление пароля'")]
        [Test(Description = "Открываем страницу 'Авторизация'; Нажимем ссылку 'Восстановить пароль'.")]
        public void GoTo_RestorePasswordPage_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .ClickLinkRestorePassword();

            Console.WriteLine("Проверяем, что мы перешли на страницу 'Восстановить пароль'");
            Assert.IsTrue(driver.FindElement(By.XPath(RestorePasswordPageObject.titleRestorePassword)).Displayed);
        }

        [AllureTag("CriticalPath", "Regression", "GoTo")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureStory("Переход на ГС страницу с помощью логотипа Autodoc.ru")]
        [Test(Description = "Открываем страницу 'Авторизация'; Нажимем логотип 'Autodoc.ru'.")]
        public void GoTo_MainPage_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .ClickLogotypeAutodoc();

            Console.WriteLine("Проверяем, что мы перешли на ГС страницу.");
            Assert.IsTrue(driver.FindElement(By.XPath(MainUserNotSignInPageObject.titleH1onMainPage)).Displayed);
        }

        [AllureTag("CriticalPath", "Regression")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureStory("Закрыть страницу 'Авторизация'")]
        [Test(Description = "Открываем страницу 'Авторизация'; Нажимем кнопку 'Х'.")]
        public void Close_AuthorizationPage_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .ClickButtonCloseX();

            Console.WriteLine("Проверяем, что мы перешли на ГС страницу.");
            Assert.IsTrue(driver.FindElement(By.XPath(MainUserNotSignInPageObject.titleH1onMainPage)).Displayed);
        }

        [AllureTag("CriticalPath")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureStory("Показать/скрыть введённые значения в поле 'Пароль'")]
        [Test(Description = "Открываем страницу 'Авторизация'; Вводим пароль; Вкл/Выкл отображения пароля.")]
        public void Click_DisplayPassword_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .InputPassword(DataToTest.validPassword)
                .ClickButtonDisplayPasswordOn();

            Console.WriteLine("Проверяем, что пароль в поле 'Password' из type состояния 'password' перешёл в type состояние 'text'");
            Assert.That(driver.FindElement(By.XPath(AuthorizationPageObject.fieldPassword)).GetAttribute("type"), Is.EqualTo("text"));

            new AuthorizationPageObject(driver)
                .ClickButtonDisplayPasswordOff();

            Console.WriteLine("Проверяем, что пароль в поле 'Password' из type состояния 'text' перешёл в type состояние 'password'");
            Assert.That(driver.FindElement(By.XPath(AuthorizationPageObject.fieldPassword)).GetAttribute("type"), Is.EqualTo("password"));
        }

        [Ignore("Тест игнорируется, потому что чекБокс реализован не корректно, так же отсутствует внутренняя логика.")]
        [AllureTag("CriticalPath")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureStory("Работа чек-бокса 'Запомнить'.")]
        [Test(Description = "Открываем страницу 'Авторизация'; Вкл/Выкл чек-бокс 'Запомнить'.")]
        public void Click_CheckBoxMemorize_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .ClickCheckBoxMemorize();

            Assert.IsTrue(driver.FindElement(By.XPath(AuthorizationPageObject.checkBoxMemorize)).Selected);
                
        }
    }
}

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
    [AllureFeature("Выполняются возможные переходы и взаимодействия с элементами на странице 'Авторизация'.")]
    public class GoTo_AuthorizationPage_Tests : BaseTest
    {
        [AllureTag("CriticalPath", "Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Переход на страницу 'Регистрации' со страницы 'Авторизации'")]
        [Test(Description = "Открываем страницу Авторизации; Нажимем ссылку 'Регистрация'.")]
        public void GoTo_RegistrationPageTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .ClickLinkRegistration();

            Console.WriteLine("Проверяем. что мы перешли на страницу 'Регистрация'");
            Assert.IsTrue(driver.FindElement(By.XPath(DataToTest.titleH1RegistrationUser)).Displayed);
        }

        [AllureTag("CriticalPath", "Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Переход на страницу 'Восстановления пароля' со страницы 'Авторизации'.")]
        [Test(Description = "Открываем страницу авторизации; Нажимем ссылку 'Восстановить пароль'.")]
        public void GoTo_RestorePasswordPageTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .ClickLinkRestorePassword();

            Console.WriteLine("Проверяем. что мы перешли на страницу 'Восстановить пароль'");
            Assert.IsTrue(driver.FindElement(By.XPath(DataToTest.titleRestorePassword)).Displayed);
        }

        [AllureTag("CriticalPath", "Regression")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureStory("Переход со страницы 'Авторизации' на ГС страницу с помощью логотипа Autodoc.ru.")]
        [Test(Description = "Открываем страницу Авторизации; Нажимем логотипа 'Autodoc.ru'.")]
        public void GoTo_AuthorizationPage_MainPage_LogoAutodoc_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .ClickLogotypeAutodoc();

            Console.WriteLine("Проверяем, что мы перешли на ГС страницу.");
            Assert.IsTrue(driver.FindElement(By.XPath(DataToTest.titleH1onMainPage)).Displayed);
        }

        [AllureTag("CriticalPath", "Regression")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureStory("Закрыть страницу 'Авторизации'")]
        [Test(Description = "Открываем страницу Авторизации; Нажимем кнопку 'Х'.")]
        public void Close_AuthorizationPage_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .ClickButtonCloseX();

            Console.WriteLine("Проверяем, что мы перешли на ГС страницу.");
            Assert.IsTrue(driver.FindElement(By.XPath(DataToTest.titleH1onMainPage)).Displayed);
        }

        [AllureTag("CriticalPath")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureStory("Показать пароль.")]
        [Test(Description = "Открываем страницу Авторизации; Вводим пароль; Вкл/Выкл отображения пароля.")]
        public void Click_DisplayPassword_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .InputPassword(DataToTest.validPassword)
                .ClickButtonDisplayPasswordOn();

            Console.WriteLine("Проверяем, что пароль в поле 'Password' из type состояния 'password' перешёл в type состояние 'text'");
            Assert.That(driver.FindElement(By.XPath(DataToTest.fieldPassword)).GetAttribute("type"), Is.EqualTo("text"));

            new AuthorizationPageObject(driver)
                .ClickButtonDisplayPasswordOff();

            Console.WriteLine("Проверяем, что пароль в поле 'Password' из type состояния 'text' перешёл в type состояние 'password'");
            Assert.That(driver.FindElement(By.XPath(DataToTest.fieldPassword)).GetAttribute("type"), Is.EqualTo("password"));
        }

        [Ignore("Тест игнорируется, потому что чекБокс реализован не корректно, так же отсутствует внутренняя логика.")]
        [AllureTag("CriticalPath")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureStory("Работа чек-бокса 'Запомнить'.")]
        [Test(Description = "Открываем страницу Авторизации; Вкл/Выкл чек-бокс 'Запомнить'.")]
        public void Click_CheckBoxMemorize_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .ClickCheckBoxMemorize();

            Assert.IsTrue(driver.FindElement(By.XPath(AuthorizationPageObject.checkBoxMemorize)).Selected);
                
        }
    }
}

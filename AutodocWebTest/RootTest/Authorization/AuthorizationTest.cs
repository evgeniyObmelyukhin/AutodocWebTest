﻿using Allure.Commons;
using AutodocWebTest.Data;
using AutodocWebTest.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutodocWebTest.RootTest.Authorization
{
    [TestFixture]
    [AllureNUnit]
    [AllureEpic("AutodocAutomationWebUI")]
    [AllureFeature("Authorization/Authentication")]
    
    public class AuthorizationTest : BaseTest
    {
        [AllureTag("Smoke", "Regression", "SignIn")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureStory("Вход в личный кабинет(ЛК) : Валидный логин и пароль.")]
        [Test(Description = "Открываем страницу авторизации; Вводим валидный логин/пароль; Выполняем вход.")]
        public void ValidSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .SignIn(DataToTest.validLogin, DataToTest.validPassword);

            Console.WriteLine($"Логин: {DataToTest.validLogin}, Пароль: {DataToTest.validPassword}");

            string actualLoginUser = new MainUserSignInPageObject(driver).GetTextLinkLoginUser();//Присваиваем переменной actualLoginUser текст элемента 'Логин пользователя'

            Console.WriteLine("Сравниваем текст логина который ввели с тем что отображается на странице.");
            Assert.That(actualLoginUser, Is.EqualTo(DataToTest.validLogin));//Сравниваем текст логина 
        }

        [AllureTag("Smoke", "Regression", "LogOut")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureStory("Выход из ЛК.")]
        [Test(Description = "Открываем страницу авторизации; Вводим валидный логин/пароль; Выполняем вход; Выполняем выход.")]
        public void logOutTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .SignIn(DataToTest.validLogin, DataToTest.validPassword)
                .openPagePrivateCabinet()
                .clickButtonLogOut();

            Assert.IsTrue(driver.FindElement(By.XPath(DataToTest.linkPrivateCabinet)).Displayed);
        }

        [AllureTag("Smoke", "Regression", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Невалидный логин и пароль.")]
        [Test(Description = "Открываем страницу авторизации; Вводим невалидный логин/пароль; Выполняем вход.")]
        public void InvalidSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .SignIn(DataToTest.invalidLogin, DataToTest.invalidPassword);

            string actualErrorMessage = new AuthorizationPageObject(driver).GetTextTitleErrorMessage();
            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Не удалось авторизоваться.'");
            Assert.That(actualErrorMessage, Is.EqualTo(DataToTest.titleErrorMessage));
        }


        [AllureTag("Smoke", "Regression", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Пустые поля логин и пароль.")]
        [Test(Description = "Открываем страницу авторизации; Оставляем пустыми поля логин/пароль; Выполняем вход.")]
        public void emptyFieldsSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .SignIn("", "");
            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Логин и пароль не могут быть пустыми'");
            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }

        [AllureTag("CriticalPath", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Пустое поле логин и валидный пароль.")]
        [Test(Description = "Открываем страницу авторизации; Оставляем пустым поле логин; Вводим валидный пароль; Выполняем вход.")]
        public void emptyFieldLoginSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .SignIn("", DataToTest.validPassword);

            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Логин и пароль не могут быть пустыми'");
            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }

        [AllureTag("CriticalPath", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Валидный логин и пустое поле пароль.")]
        [Test(Description = "Открываем страницу авторизации; Вводим валидный логин; Оставляем пустым поле пароль; Выполняем вход.")]
        public void emptyFieldPasswordSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .SignIn(DataToTest.validLogin, "");

            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Логин и пароль не могут быть пустыми'");
            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }
    }
}
using Allure.Commons;
using AutodocWebTest.Data;
using AutodocWebTest.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutodocWebTest.RootTest.SmokeTest
{
    [TestFixture]
    [AllureNUnit]
    [AllureEpic("AutodocAutomationWebUI")]
    [AllureFeature("Выполняются позитивные/негативные сценарии входа в ЛК + выход из ЛК.")]
    
    public class AuthorizationUser_Tests : BaseTest
    {
        [AllureTag("Smoke", "Regression", "SignIn")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureStory("Вход в личный кабинет(ЛК) : Валидный логин и пароль.")]
        [Test(Description = "Открываем страницу авторизации; Вводим валидный логин/пароль; Выполняем вход.")]
        public void ValidSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn(DataToTest.validLogin, DataToTest.validPassword);

            Console.WriteLine($"Логин: {DataToTest.validLogin}, Пароль: {DataToTest.validPassword}");

            string actualLoginUser = new MainUserSignInPageObject(driver).GetTextLinkLoginUser();//Присваиваем переменной actualLoginUser текст элемента 'Логин пользователя'

            Console.WriteLine("Сравниваем текст логина который ввели с тем что отображается на странице.");
            Assert.That(actualLoginUser, Is.EqualTo(DataToTest.validLogin));
        }

        [AllureTag("Smoke", "Regression", "LogOut")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureStory("Выход из ЛК.")]
        [Test(Description = "Открываем страницу авторизации; Вводим валидный логин/пароль; Выполняем вход; Выполняем выход.")]
        public void LogOutTest()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn(DataToTest.validLogin, DataToTest.validPassword)
                .openPagePrivateCabinet()
                .clickButtonLogOut();

            Console.WriteLine("Проверяем, что произошёл выход из личного кабинета.Персональный логин не отображается.");
            Assert.IsTrue(driver.FindElement(By.XPath(DataToTest.linkPrivateCabinet)).Displayed);
        }

        [AllureTag("Smoke", "Regression", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Невалидный логин и пароль.")]
        [Test(Description = "Открываем страницу авторизации; Вводим невалидный логин/пароль; Выполняем вход.")]
        public void InvalidSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn(DataToTest.invalidLogin, DataToTest.invalidPassword);

            string actualErrorMessage = new AuthorizationPageObject(driver).GetTextTitleErrorMessage();
            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Не удалось авторизоваться.'");
            Assert.That(actualErrorMessage, Is.EqualTo(DataToTest.titleErrorMessage));
        }


        [AllureTag("Smoke", "Regression", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Пустые поля логин и пароль.")]
        [Test(Description = "Открываем страницу авторизации; Оставляем пустыми поля логин/пароль; Выполняем вход.")]
        public void EmptyFieldsSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn("", "");
            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Логин и пароль не могут быть пустыми'");
            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }

        [AllureTag("CriticalPath", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Пустое поле логин и валидный пароль.")]
        [Test(Description = "Открываем страницу авторизации; Оставляем пустым поле логин; Вводим валидный пароль; Выполняем вход.")]
        public void EmptyFieldLoginSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn("", DataToTest.validPassword);

            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Логин и пароль не могут быть пустыми'");
            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }

        [AllureTag("CriticalPath", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Валидный логин и пустое поле пароль.")]
        [Test(Description = "Открываем страницу авторизации; Вводим валидный логин; Оставляем пустым поле пароль; Выполняем вход.")]
        public void EmptyFieldPasswordSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn(DataToTest.validLogin, "");

            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Логин и пароль не могут быть пустыми'");
            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }
    }
}
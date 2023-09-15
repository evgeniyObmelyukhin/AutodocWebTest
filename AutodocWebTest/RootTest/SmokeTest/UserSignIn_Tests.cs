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
    [AllureEpic("AutodocWebAutomationUI")]
    [AllureFeature("Пользователь входит в систему : Smoke : Позитивные/негативные сценарии.")]
    public class UserSignIn_Tests : BaseTest
    {
        [AllureTag("Smoke", "Regression", "SignIn")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureStory("Вход в личный кабинет(ЛК) : Валидный логин и пароль : Успешно")]
        [Test(Description = "Открываем страницу 'Авторизация'; Вводим валидный логин/пароль; Выполняем вход.")]
        public void SignIn_ValidData_Successful_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn(DataToTest.validLogin, DataToTest.validPassword);

            Console.WriteLine($"Логин: {DataToTest.validLogin}, Пароль: {DataToTest.validPassword}");

            string actualLoginUser = new MainUserSignInPageObject(driver).GetTextLinkLoginUser();//Присваиваем переменной actualLoginUser текст элемента 'Логин пользователя'

            Console.WriteLine("Сравниваем текст логина который ввели с тем что отображается на странице.");
            Assert.That(actualLoginUser, Is.EqualTo(DataToTest.validLogin));
        }

        [AllureTag("Smoke", "Regression", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Невалидный логин и пароль : Ошибка")]
        [Test(Description = "Открываем страницу 'Авторизация'; Вводим невалидный логин/пароль; Выполняем вход.")]
        public void SignIn_InvalidData_Error_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn(DataToTest.invalidLogin, DataToTest.invalidPassword);

            string actualErrorMessage = new AuthorizationPageObject(driver).GetTextTitleErrorMessage();
            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Не удалось авторизоваться.'");
            Assert.That(actualErrorMessage, Is.EqualTo(AuthorizationPageObject.titleErrorMessage));
        }

        [AllureTag("Smoke", "Regression", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Пустые поля логин и пароль : Ошибка")]
        [Test(Description = "Открываем страницу 'Авторизация'; Оставляем пустыми поля логин/пароль; Выполняем вход.")]
        public void SignIn_EmptyFields_Error_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn("", "");
            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Логин и пароль не могут быть пустыми'");
            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(AuthorizationPageObject.titleErrorMessageNull));
        }

        [AllureTag("Smoke", "Regression", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Пустое поле логин и валидный пароль : Ошибка")]
        [Test(Description = "Открываем страницу 'Авторизация'; Оставляем пустым поле логин; Вводим валидный пароль; Выполняем вход.")]
        public void SignIn_EmptyFieldLogin_Error_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn("", DataToTest.validPassword);

            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Логин и пароль не могут быть пустыми'");
            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(AuthorizationPageObject.titleErrorMessageNull));
        }

        [AllureTag("Smoke", "Regression", "SignIn")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Вход в ЛК : Валидный логин и пустое поле пароль : Ошибка")]
        [Test(Description = "Открываем страницу 'Авторизация'; Вводим валидный логин; Оставляем пустым поле пароль; Выполняем вход.")]
        public void SignIn_EmptyFieldPassword_Error_Test()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageAuthorization()
                .SignIn(DataToTest.validLogin, "");

            Console.WriteLine("Получаем текст полученной ошибки и сравниваем его с текстом 'Логин и пароль не могут быть пустыми'");
            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(AuthorizationPageObject.titleErrorMessageNull));
        }
    }
}
using AutodocWebTest.Data;
using AutodocWebTest.PageObjects;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutodocWebTest.RootTest.Authorization
{
    [TestFixture]//Таким атрибутом нужно пометить класс, чтобы система тестирования начала искать в нем тесты.
    [AllureNUnit]
    public class AuthorizationTest : BaseTest
    {
        //Таким атрибутом нужно пометить метод, чтобы система тестирования поняла, что это тест.
        [Test]//Smoke : Вход в личный кабинет(ЛК) : Валидный
        public void ValidSignInTest()
        {
            new MainUserNotSignInPageObject(driver)//Открываем страницу авторизации, выполняем вход
                .openPageAuthorization()
                .SignIn(DataToTest.validLogin, DataToTest.validPassword);

            string actualLoginUser = new MainUserSignInPageObject(driver).GetTextLinkLoginUser();//Присваиваем переменной actualLoginUser текст элемента 'Логин пользователя'

            Assert.That(actualLoginUser, Is.EqualTo(DataToTest.validLogin));//Сравниваем текст логина 
        }

        [Test]//Smoke : Выход из ЛК 
        public void logOutTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .SignIn(DataToTest.validLogin, DataToTest.validPassword)
                .openPagePrivateCabinet()
                .clickButtonLogOut();

            Assert.IsTrue(driver.FindElement(By.XPath(DataToTest.linkPrivateCabinet)).Displayed);
        }

        [Test]//Smoke : Вход в личный кабинет(ЛК) : Невалидный
        public void InvalidSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .SignIn(DataToTest.invalidLogin, DataToTest.invalidPassword);

            string actualErrorMessage = new AuthorizationPageObject(driver).GetTextTitleErrorMessage();

            Assert.That(actualErrorMessage, Is.EqualTo(DataToTest.titleErrorMessage));
        }

        [Test]//CriticalPath : Вход в личный кабинет(ЛК) : Пустые поля логин/пароль
        public void emptyFieldsSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .SignIn("", "");

            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }

        [Test]//CriticalPath : Вход в личный кабинет(ЛК) : Пустое поле логин
        public void emptyFieldLoginSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .SignIn("", DataToTest.validPassword);

            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }

        [Test]//CriticalPath : Вход в личный кабинет(ЛК) : Пустое поле пароль
        public void emptyFieldPasswordSignInTest()
        {
            new MainUserNotSignInPageObject(driver)
                .openPageAuthorization()
                .SignIn(DataToTest.validLogin, "");

            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }



    }
}
using AutodocWebTest.RootTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class AuthorizationPageObject
    {
        private IWebDriver driver;

        private readonly By _fieldLogin = By.XPath("//input[@name='Login']");//Поле "Логин"
        private readonly By _fieldPassword = By.XPath("//input[@id='Password']");//Поле "Пароль"
        private readonly By _buttonInput = By.XPath("//button[@id='submit_logon_page']");//Кнопка "Вход"
        private readonly By _titleErrorMessage = By.XPath("//div[@id='errorMessage']");//Заголовок ошибки при некорректном входе
        private readonly By _buttonLogOut = By.XPath("//input[@value='Выйти из личного кабинета']");//Кнопка "Выйти из личного кабинета"


        public AuthorizationPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HeaderMenuPageObject SignIn(string login, string password)//Ввести логин и пароль, войти
        {
            WaitUntil.WaitElement(driver, _fieldLogin);
            driver.FindElement(_fieldLogin).SendKeys(login);
            driver.FindElement(_fieldPassword).SendKeys(password);
            driver.FindElement(_buttonInput).Click();

            return new HeaderMenuPageObject(driver);
        }

        public HeaderMenuPageObject clickButtonLogOut()
        {
            WaitUntil.WaitElement(driver, _buttonLogOut);
            driver.FindElement(_buttonLogOut).Click();

            return new HeaderMenuPageObject(driver);
        }

        public string GetTextTitleErrorMessage()
        {
            WaitUntil.WaitElement(driver, _titleErrorMessage);
            string textErrorMessage = driver.FindElement(_titleErrorMessage).Text;

            return textErrorMessage;
        }
    }
}

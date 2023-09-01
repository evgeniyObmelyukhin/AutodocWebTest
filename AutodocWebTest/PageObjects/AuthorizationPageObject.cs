﻿using AutodocWebTest.RootTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class AuthorizationPageObject//Страница Авторизации, пользователь НЕ вошёл
    {
        private IWebDriver driver;

        public AuthorizationPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        private readonly By _fieldLogin = By.XPath("//input[@name='Login']");//Поле "Логин"
        private readonly By _fieldPassword = By.XPath("//input[@id='Password']");//Поле "Пароль"
        private readonly By _buttonInput = By.XPath("//button[@id='submit_logon_page']");//Кнопка "Вход"
        private readonly By _titleErrorMessage = By.XPath("//div[@id='errorMessage']");//Заголовок ошибки при некорректном входе
        private readonly By _logotypeAutodoc = By.XPath("//div[@class='atd-popup-logo-red']");//Логотип Автодок

        public MainUserSignInPageObject SignIn(string login, string password)//Ввести логин и пароль, войти
        {
            WaitUntil.WaitElement(driver, _fieldLogin);
            driver.FindElement(_fieldLogin).SendKeys(login);
            driver.FindElement(_fieldPassword).SendKeys(password);
            driver.FindElement(_buttonInput).Click();

            return new MainUserSignInPageObject(driver);
        }

        public string GetTextTitleErrorMessage()//Получить текст ошибки при НЕкорректном входе
        {
            WaitUntil.WaitElement(driver, _titleErrorMessage);
            string textErrorMessage = driver.FindElement(_titleErrorMessage).Text;

            return textErrorMessage;
        }
    }
}

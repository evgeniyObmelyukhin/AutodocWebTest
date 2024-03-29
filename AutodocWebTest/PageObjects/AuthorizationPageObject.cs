﻿using AutodocWebTest.RootTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class AuthorizationPageObject//Страница "Авторизация", пользователь НЕ вошёл
    {
        private IWebDriver driver;
        public AuthorizationPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Элементы для методов
        private readonly By _fieldLogin = By.XPath("//input[@name='Login']");//Поле "Логин"
        private readonly By _fieldPassword = By.XPath("//input[@id='Password']");//Поле "Пароль"
        private readonly By _buttonDisplayPasswordOn = By.XPath("//i[@class='pi pi-eye']");//Кнопка отображения пароля(состояние вкл.= пароль скрыт).
        private readonly By _buttonDisplayPasswordOff = By.XPath("//i[@class='pi pi-eye-slash']");//Кнопка отображения пароля(состояние выкл.= пароль читаем).
        private readonly By _checkBoxMemorize = By.XPath("//span[@class='icon fa']");//Чек-бокс "Запомнить"
        private readonly By _buttonInput = By.XPath("//button[@id='submit_logon_page']");//Кнопка "Вход"
        private readonly By _titleErrorMessage = By.XPath("//div[@id='errorMessage']");//Заголовок ошибки при некорректном входе
        private readonly By _logotypeAutodoc = By.XPath("//div[@class='atd-popup-logo-red']");//Логотип Автодок
        private readonly By _linkRegistration = By.XPath("//a[text()='Регистрация']");//Ссылка 'Регистрация'
        private readonly By _linkRestorePassword = By.XPath("//a[text()='Восстановить пароль']");//Ссылка 'Восстановить пароль'
        private readonly By _buttonCloseX = By.XPath("//div[@class='atd-popup-close']");//Кнопка "Х"

        //Элементы для проверок
        public static string checkBoxMemorize { get; } = "//span[@class='icon fa']";//Чек-бокс "Запомнить"
        public static string titleErrorMessage { get; } = "Не удалось авторизоваться.";//Тест ошибки при некорректном логин/пароль
        public static string titleErrorMessageNull { get; } = "Логин и пароль не могут быть пустыми";//Тест ошибки при пустых полях
        public static string fieldPassword { get; } = "//input[@id='Password']";//Поле пароль

        //Методы взаимодействия с элементами
        public MainUserSignInPageObject SignIn(string login, string password)//Ввести логин и пароль, войти
        {
            WaitUntil.WaitElement(driver, _fieldLogin);
            driver.FindElement(_fieldLogin).SendKeys(login);
            driver.FindElement(_fieldPassword).SendKeys(password);
            driver.FindElement(_buttonInput).Click();

            return new MainUserSignInPageObject(driver);
        }

        public AuthorizationPageObject InputPassword(string password)//Ввести пароль
        {
            WaitUntil.WaitElement(driver, _fieldPassword);
            driver.FindElement(_fieldPassword).SendKeys(password);

            return this;
        }

        public string GetTextTitleErrorMessage()//Получить текст ошибки при НЕкорректном входе
        {
            WaitUntil.WaitElement(driver, _titleErrorMessage);
            string textErrorMessage = driver.FindElement(_titleErrorMessage).Text;

            return textErrorMessage;
        }

        public RegistrationUserPageObject ClickLinkRegistration()//Нажать ссылку 'Регистрация'
        {
            WaitUntil.WaitElement(driver, _linkRegistration);
            driver.FindElement(_linkRegistration).Click();

            return new RegistrationUserPageObject(driver);
        }

        public RestorePasswordPageObject ClickLinkRestorePassword()//Нажать ссылку 'Восстановить пароль'
        {
            WaitUntil.WaitElement(driver, _linkRestorePassword);
            driver.FindElement(_linkRestorePassword).Click();

            return new RestorePasswordPageObject(driver);
        }

        public MainUserNotSignInPageObject ClickLogotypeAutodoc()//Нажать логотип Автодок
        {
            WaitUntil.WaitElement(driver, _logotypeAutodoc);
            driver.FindElement(_logotypeAutodoc).Click();

            return new MainUserNotSignInPageObject(driver);
        }

        public MainUserNotSignInPageObject ClickButtonCloseX()//Нажать кнопку "Х"
        {
            WaitUntil.WaitElement(driver, _buttonCloseX);
            driver.FindElement(_buttonCloseX).Click();

            return new MainUserNotSignInPageObject(driver);
        }

        public AuthorizationPageObject ClickButtonDisplayPasswordOn()//Нажать кнопку отображения пароля(состояние вкл.= пароль скрыт).
        {
            WaitUntil.WaitElement(driver, _buttonDisplayPasswordOn);
            driver.FindElement(_buttonDisplayPasswordOn).Click();

            return this;
        }

        public AuthorizationPageObject ClickButtonDisplayPasswordOff()//Нажать кнопку отображения пароля(состояние выкл.= пароль читаем).
        {
            WaitUntil.WaitElement(driver, _buttonDisplayPasswordOff);
            driver.FindElement(_buttonDisplayPasswordOff).Click();

            return this;
        }
    
        public AuthorizationPageObject ClickCheckBoxMemorize()//Нажать чек-бокс "Запомнить"
        {
            WaitUntil.WaitElement(driver, _checkBoxMemorize);
            driver.FindElement(_checkBoxMemorize).Click();

            return this;
        }
    }
}

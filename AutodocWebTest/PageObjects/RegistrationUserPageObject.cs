﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class RegistrationUserPageObject
    {
        private IWebDriver driver;

        public RegistrationUserPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        private readonly By _titleH1RegistrationUser = By.XPath("//h1[text()=' Регистрация пользователя ']");//Заголовок 'Регистрация пользователя'
        private readonly By _titleRegistration = By.XPath("//h1[text()=' Регистрация ']");//Заголовок 'Регистрация' в крошках
        private readonly By _buttonPhysicalPerson = By.XPath("//div[text()=' Физическое лицо ']");//Кнопка 'Физическое лицо'
        private readonly By _buttonLegalPerson = By.XPath("//div[text()=' Юридическое лицо ']");//Кнопка 'Юридическое лицо'



    }
}
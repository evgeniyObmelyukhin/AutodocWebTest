using AutodocWebTest.RootTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class PrivateCabinetPageObject//Страница "Личный кабинет", пользователь вошёл
    {
        private IWebDriver driver;
        public PrivateCabinetPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Элементы для методов
        private readonly By _buttonLogOut = By.XPath("//input[@value='Выйти из личного кабинета']");//Кнопка "Выйти из личного кабинета"
        private readonly By _logotypeAutodoc = By.XPath("//div[@class='atd-popup-logo-red']");//Логотип Автодок

        //Элементы для проверок

        //Методы взаимодействия с элементами
        public MainUserNotSignInPageObject clickButtonLogOut()//Нажать кнопку "Выйти из личного кабинета"
        {
            WaitUntil.WaitElement(driver, _buttonLogOut);
            driver.FindElement(_buttonLogOut).Click();

            return new MainUserNotSignInPageObject(driver);
        }
    }
}

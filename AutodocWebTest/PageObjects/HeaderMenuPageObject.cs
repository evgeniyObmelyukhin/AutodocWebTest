using AutodocWebTest.RootTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class HeaderMenuPageObject
    {
        private IWebDriver driver;

        //Создаём список элементов-полей в стиле PageObject для хедера на главной странице(ГС)

        private readonly By _linkPrivateCabinet = By.XPath("//a[contains(text(),'Личный кабинет')]");//Ссылка 'Личный кабинет' на ГС
        private readonly By _linkLoginUser = By.XPath("//span[@id='user_info']");//Ссылка 'Логин пользователя' после входа на ГС

        public HeaderMenuPageObject(IWebDriver driver)//Создаём конструктор класса HeaderMenuPageObject
        {
            this.driver = driver;
        }

        public AuthorizationPageObject openPageAuthorization()//Открываем страницу Авторизации
        {
            WaitUntil.WaitElement(driver, _linkPrivateCabinet);
            driver.FindElement(_linkPrivateCabinet).Click();

            return new AuthorizationPageObject(driver);
        }

        public AuthorizationPageObject openPagePrivateCabinet()
        {
            WaitUntil.WaitElement(driver, _linkLoginUser);
            driver.FindElement(_linkLoginUser).Click();

            return new AuthorizationPageObject(driver);
        }

        public string GetTextLinkLoginUser()//Получаем текст из элемента 'Логин пользователя'
        {
            WaitUntil.WaitElement(driver, _linkLoginUser);
            string textLoginUser = driver.FindElement(_linkLoginUser).Text;

            return textLoginUser;
        }
    }
}

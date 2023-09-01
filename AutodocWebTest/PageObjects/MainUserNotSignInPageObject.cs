using AutodocWebTest.RootTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class MainUserNotSignInPageObject
    {
        private IWebDriver driver;

        //Создаём список элементов-полей в стиле PageObject для хедера на главной странице(ГС) пользователь НЕ вошёл в ЛК

        private readonly By _linkPrivateCabinet = By.XPath("//a[contains(text(),'Личный кабинет')]");//Ссылка 'Личный кабинет' на ГС

        public MainUserNotSignInPageObject(IWebDriver driver)//Создаём конструктор класса HeaderMenuPageObject
        {
            this.driver = driver;
        }

        public AuthorizationPageObject openPageAuthorization()//Открываем страницу Авторизации
        {
            WaitUntil.WaitElement(driver, _linkPrivateCabinet);
            driver.FindElement(_linkPrivateCabinet).Click();

            return new AuthorizationPageObject(driver);
        }
    }
}

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

        //Создаём список элементов-полей в стиле PageObject для ГС пользователь НЕ вошёл в ЛК

        private readonly By _linkPrivateCabinet = By.XPath("//a[contains(text(),'Личный кабинет')]");//Ссылка 'Личный кабинет' на ГС
        private readonly By _linkSugnUp = By.XPath("//a[text()='Зарегистрируйся']");//Ссылка 'Зарегистрируйся'


        public MainUserNotSignInPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AuthorizationPageObject OpenPageAuthorization()//Открываем страницу Авторизации
        {
            WaitUntil.WaitElement(driver, _linkPrivateCabinet);
            driver.FindElement(_linkPrivateCabinet).Click();

            return new AuthorizationPageObject(driver);
        }

        public RegistrationUserPageObject OpenPageRegistrationUser()//Открываем страницу 'Регистрация пользователя'
        {
            WaitUntil.WaitElement(driver, _linkSugnUp);
            driver.FindElement(_linkSugnUp).Click();

            return new RegistrationUserPageObject(driver);
        }


    }
 }

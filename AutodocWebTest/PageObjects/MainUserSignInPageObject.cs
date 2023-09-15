using AutodocWebTest.RootTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class MainUserSignInPageObject//Главная страница(ГС), пользователь ВОШЁЛ в ЛК
    {
        private IWebDriver driver;
        public MainUserSignInPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Элементы для методов
        private readonly By _linkLoginUser = By.XPath("//span[@id='user_info']");//Ссылка 'Логин пользователя' после входа на ГС

        //Элементы для проверок
        public static string titleH1onMainPage { get; } = "//h1[text()='Запчасти в интернет-магазине Автодок']";//Заголовок 'Запчасти в интернет-магазине Автодок'

        //Методы взаимодействия с элементами
        public PrivateCabinetPageObject openPagePrivateCabinet()//Открываем страницу Личного кабинета
        {
            WaitUntil.WaitElement(driver, _linkLoginUser);
            driver.FindElement(_linkLoginUser).Click();

            return new PrivateCabinetPageObject(driver);
        }

        public string GetTextLinkLoginUser()//Получаем текст из элемента 'Логин пользователя'
        {
            WaitUntil.WaitElement(driver, _linkLoginUser);
            string textLoginUser = driver.FindElement(_linkLoginUser).Text;

            return textLoginUser;
        }

    }
}

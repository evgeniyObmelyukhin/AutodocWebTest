using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class RegistrationUserPageObject//Страница "Регистрация пользователя"
    {
        private IWebDriver driver;
        public RegistrationUserPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Элементы для методов
        private readonly By _titleH1RegistrationUser = By.XPath("//h1[text()=' Регистрация пользователя ']");//Заголовок 'Регистрация пользователя'
        private readonly By _titleRegistrationCrumbs = By.XPath("//h1[text()=' Регистрация ']");//Заголовок 'Регистрация' в крошках
        private readonly By _buttonPhysicalPerson = By.XPath("//div[text()=' Физическое лицо ']");//Кнопка 'Физическое лицо'
        private readonly By _buttonLegalPerson = By.XPath("//div[text()=' Юридическое лицо ']");//Кнопка 'Юридическое лицо'
        private readonly By _dropDownListShop = By.XPath("//div[@role='button']");//Выпадающий-список 'Магазин'

        //Элементы для проверок 
        public static string titleH1RegistrationUser { get; } = "//h1[text()=' Регистрация пользователя ']";//Заголовок 'Регистрация пользователя'
        public static string buttonPhysicalPerson { get; } = "//div[text()=' Физическое лицо ']";//Кнопка 'Физическое лицо'
        public static string titleRegistrationCrumbs { get; } = "//h1[text()=' Регистрация ']";//Заголовок 'Регистрация' в крошках

        //Методы взаимодействия с элементами
        public ShopAddressPageObject ClickDropDownListShop()//Раскрыть выпадающий-список "Магазины"
        {

            return new ShopAddressPageObject(driver);
        }
    }
}

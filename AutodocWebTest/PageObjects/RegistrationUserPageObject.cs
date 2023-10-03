using AutodocWebTest.RootTest;
using NUnit.Framework;
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
        private readonly By _fieldContactName = By.XPath("//input[@formcontrolname='contactName']");//Поле 'Контактное лицо (ФИО)*'
        private readonly By _fieldContactPhone = By.XPath("//p-inputmask[@type='tel']/input");//Поле 'Телефон*'
        private readonly By _fieldEMail = By.XPath("//input[@type='email']");//Поле 'Email*'
        private readonly By _buttonSignUp = By.XPath("//button[text()=' Зарегистрироваться ']");//Кнопка 'Зарегистрироваться'
        private readonly By _checkBoxOfferAgree = By.XPath("//input[@formcontrolname='offerAgree']");//Чек-Бокс " Я ознакомился и принимаю условия договора-оферты"

        //Элементы для проверок 
        public static string titleH1RegistrationUser { get; } = "//h1[text()=' Регистрация пользователя ']";//Заголовок 'Регистрация пользователя'
        public static string buttonPhysicalPerson { get; } = "//div[text()=' Физическое лицо ']";//Кнопка 'Физическое лицо'
        public static string titleRegistrationCrumbs { get; } = "//h1[text()=' Регистрация ']";//Заголовок 'Регистрация' в крошках
        public static string dropDownListShopFilled { get; } = "//span[@id='pr_id_2_label']";//Выпадающий-список 'Магазин' с выбранным магазином
        public static string checkBoxOfferAgree { get; } = "//input[@formcontrolname='offerAgree']";//Чек-Бокс " Я ознакомился и принимаю условия договора-оферты"

        //Методы взаимодействия с элементами
        public ShopAddressPageObject Click_DropDownListShop()//Раскрыть выпадающий-список "Магазины"
        {
            WaitUntil.WaitElement(driver, _dropDownListShop);
            driver.FindElement(_dropDownListShop).Click();

            return new ShopAddressPageObject(driver);
        }

        public RegistrationUserPageObject FillIn_FieldContactName(string fullname)//Заполнить поле 'Контактное лицо (ФИО)*'
        {
            WaitUntil.WaitElement(driver, _fieldContactName);
            driver.FindElement(_fieldContactName).SendKeys(fullname);

            return this;
        }

        public RegistrationUserPageObject FillIn_FieldContactPhone(string numberPhone)//Заполнить поле 'Телефон*'
        {
            WaitUntil.WaitElement(driver, _fieldContactPhone);
            driver.FindElement(_fieldContactPhone).Click();
            driver.FindElement(_fieldContactPhone).SendKeys(numberPhone);

            return this;
        }

        public RegistrationUserPageObject FillIn_FieldEMail(string email)//Заполнить поле 'Email*'
        {
            WaitUntil.WaitElement(driver, _fieldEMail);
            driver.FindElement(_fieldEMail).SendKeys(email);

            return this;
        }

        public ConfirmRegistrationPageObject Click_ButtonSignUp()//Нажать кнопку 'Зарегистрироваться'
        {
            WaitUntil.WaitElement(driver, _buttonSignUp);
            driver.FindElement(_buttonSignUp).Click();

            return new ConfirmRegistrationPageObject(driver);
        }




    }
}

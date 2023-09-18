using AutodocWebTest.RootTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class ShopAddressPageObject//Окно 'Адрес магазина' на странице "Регистрация пользователя"
    {
        private IWebDriver driver;
        public ShopAddressPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Элементы для методов
        private readonly By _dropDownListShopAddress = By.XPath("//p-dropdown[@optionlabel='address']");//Выпадающий-список 'Адрес магазина'
        private readonly By _elementFirstDropDownListShopAddress = By.XPath("//p-dropdownitem[@class='p-element ng-star-inserted'][1]");//Первый элемент списка 'Адрес магазина'
        private readonly By _buttonSelect = By.XPath("//button[@id='select-shop-btn']");//Кнопка "Выбрать" 

        //Элементы для проверок
        public static string windowShopAddress { get; } = "//div[@role='dialog']";//Окно 'Адрес магазина'

        //Методы взаимодействия с элементами
        public ShopAddressPageObject Click_DropDownListShopAddress()//Нажимаем выпадающий-список 'Адрес магазина'
        {
            WaitUntil.WaitElement(driver, _dropDownListShopAddress);
            driver.FindElement(_dropDownListShopAddress).Click();

            return this;
        }

        public ShopAddressPageObject Click_ElementFirstDropDownListShopAddress()//Нажимаем первый элемент списка 'Адрес магазина'
        {
            WaitUntil.WaitElement(driver, _dropDownListShopAddress);
            driver.FindElement(_elementFirstDropDownListShopAddress).Click();

            return this;
        }
    
        public RegistrationUserPageObject Click_ButtonSelect()//Нажимаем кнопку "Выбрать"
        {
            WaitUntil.WaitElement(driver, _buttonSelect);
            driver.FindElement(_buttonSelect).Click();

            return new RegistrationUserPageObject(driver);
        }
    }
}

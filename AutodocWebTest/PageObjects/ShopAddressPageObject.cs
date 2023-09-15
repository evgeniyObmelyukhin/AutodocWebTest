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
        
        //Элементы для проверок

        //Методы взаимодействия с элементами

    }
}

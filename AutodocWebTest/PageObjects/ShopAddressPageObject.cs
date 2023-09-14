using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class ShopAddressPageObject
    {
        private IWebDriver driver;

        public ShopAddressPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        private readonly By _dropDownListShopAddress = By.XPath("//p-dropdown[@optionlabel='address']");//Выпадающий-список 'Адрес магазина'


    }
}

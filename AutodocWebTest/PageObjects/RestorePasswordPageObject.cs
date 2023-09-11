using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class RestorePasswordPageObject
    {
        private IWebDriver driver;

        public RestorePasswordPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        private readonly By _titleRestorePassword = By.XPath("//h1[text()='Восстановление пароля']");//Загаловок 'Восстановление пароля'


    }
}

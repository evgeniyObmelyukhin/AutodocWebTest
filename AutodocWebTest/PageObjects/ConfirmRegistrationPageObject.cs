using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.PageObjects
{
    public class ConfirmRegistrationPageObject//Страница "Подтвердите регистрацию"
    {
        private IWebDriver driver;

        public ConfirmRegistrationPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Элементы для методов
        

        //Элементы для проверок 
        public static string titleConfirmRegistration = "//h2[text()='Подтвердите регистрацию']";//Заголовок 'Подтвердите регистрацию'
        public static string fieldConfirmPhone = "//p[text()=' Отправили вам СМС на номер: ']/strong";//Поле с номером на который был отправлен код
        public static string fieldConfirmMail = "//p[text()=' Отправили письмо с кодом на адрес: ']/strong";//Поле с адресом почты на которую был отправлен код

        //Методы взаимодействия с элементами

        
    }
}

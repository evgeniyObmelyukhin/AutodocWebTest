using AutodocWebTest.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.RootTest
{
    public class BaseTest
    {
        protected IWebDriver driver;//Обьявляем поле driver


        [OneTimeSetUp]//Выполняется один раз перед всеми тестами
        protected void DoBeforeAllTests()
        {
            driver = new ChromeDriver();//Инициализируем поле driver экземпляром класс ChromeDriver
        }

        [SetUp]//Выполняется перед каждым тестом
        protected void DoBeforeEachTest()
        {
            driver.Manage().Cookies.DeleteAllCookies();//Очистить все куки
            driver.Navigate().GoToUrl(TestSetting.Host);//Открыть ГС страницу сайта Автодок
            driver.Manage().Window.Size = new System.Drawing.Size(1400, 1050);//Открыть окно браузера заданного размера
            WaitUntil.ShouldLocated(driver, TestSetting.Host);//Ожидание загрузки URL страницы
            WaitUntil.WaitSomeInterval(2);
        }

        [TearDown]//Выполняется после каждого теста
        protected void DoAfterEachTest()
        {

        }

        [OneTimeTearDown]//Выполняется один раз после всех тестов
        protected void DoAfterAllTests()
        {
            driver.Quit();//Закрываем браузер и  завершаем сеанс WebDriver
            driver.Dispose();
        }
    }
}

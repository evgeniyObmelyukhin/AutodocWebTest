using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.RootTest
{
    public static class WaitUntil
    {
        public static void ShouldLocated(IWebDriver driver, string link)//Метод для ожидания загрузки URL страницы
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.UrlContains(link));
            }
            catch (WebDriverTimeoutException exception)
            {
                throw new NotFoundException($"Не могу найти страницу!", exception);
            }
        }

        public static void WaitSomeInterval(int second = 10)//Альтернатива Thread.Sleep
        {
            Task.Delay(TimeSpan.FromSeconds(second)).Wait();
        }

        public static void WaitElement(IWebDriver driver, By locator, int second = 10)//Ожидание заданного локатора в течении 10 сек.
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(second)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(driver, TimeSpan.FromSeconds(second)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}

using Allure.Commons;
using AutodocWebTest.Data;
using AutodocWebTest.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.RootTest.SmokeTest
{
    [TestFixture]
    [AllureNUnit]
    [AllureEpic("AutodocAutomationWebUI")]
    [AllureFeature("Регистрация пользователя : Smoke : Позитивные/негативные сценарии.")]
    public class RegistrationUser_Tests : BaseTest
    {
        [AllureTag("Smoke", "Regression", "SignUp")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Регистрация пользователя : Валидные данные : Успешно")]
        [Test(Description = "Открываем страницу 'Регистрация пользователя'; Заполняем обязательные поля валидными данными; Нажимаем зарегистрироваться")]
        public void RegistrationUser_ValidData_Successful()
        {
            new MainUserNotSignInPageObject(driver)
                .OpenPageRegistrationUser();

            WaitUntil.WaitSomeInterval(2);
            Console.WriteLine("Проверяем, что мы перешли на страницу 'Регистрация пользователя'");
            Assert.IsTrue(driver.FindElement(By.XPath(RegistrationUserPageObject.titleH1RegistrationUser)).Displayed);
            string classAttributeValue = driver.FindElement(By.XPath(RegistrationUserPageObject.buttonPhysicalPerson)).GetAttribute("class");
            Assert.That(classAttributeValue.Contains("active"), Is.True);
            Assert.IsTrue(driver.FindElement(By.XPath(RegistrationUserPageObject.titleRegistrationCrumbs)).Displayed);
            

            new RegistrationUserPageObject(driver)
                .Click_DropDownListShop();
            
            Console.WriteLine("Проверяем, что открылось окно 'Адрес магазина'");
            Assert.IsTrue(driver.FindElement(By.XPath(ShopAddressPageObject.windowShopAddress)).Displayed);
            

            new ShopAddressPageObject(driver)
                .Click_DropDownListShopAddress()
                .Click_ElementFirstDropDownListShopAddress()
                .Click_ButtonSelect();

            Console.WriteLine("Проверяем, что в выпадающем списке присутствует 'Адрес магазина'");
            IWebElement element = driver.FindElement(By.XPath(RegistrationUserPageObject.dropDownListShopFilled));
            Assert.IsNotNull(element, "Элемент не найден");
            Assert.IsFalse(string.IsNullOrEmpty(element.Text), "Текст элемента отсутствует");

            new RegistrationUserPageObject(driver)
                .FillIn_FieldContactName(DataToTest.validContactName)
                .FillIn_FieldContactPhone(DataToTest.validContactPhone)
                .FillIn_FieldEMail(DataToTest.validEMail);

            Console.WriteLine("Проверяем, что чек-бокс 'Я ознакомился и принимаю условия договора-оферты' включен");
            string classAttributeValueCheckBox = driver.FindElement(By.XPath(RegistrationUserPageObject.checkBoxOfferAgree)).GetAttribute("class");
            Assert.That(classAttributeValueCheckBox.Contains("invalid"), Is.False);

            new RegistrationUserPageObject(driver)
                .Click_ButtonSignUp();
            
            Console.WriteLine("Проверяем, что открылась страница 'Подтвердите регистрацию', телефон и почта на которую были отправлены проверочные коды соответствуют введённым данным.");
            WaitUntil.WaitSomeInterval(4);
            Assert.IsTrue(driver.FindElement(By.XPath(ConfirmRegistrationPageObject.titleConfirmRegistration)).Displayed);
            
            string textFieldConfirmPhone = driver.FindElement(By.XPath(ConfirmRegistrationPageObject.fieldConfirmPhone)).Text;
            string cleanedConfirmPhone = new string(textFieldConfirmPhone.Where(char.IsDigit).ToArray());
            string cleanPhoneNumber = cleanedConfirmPhone.Substring(1);
            Assert.That(cleanPhoneNumber, Is.EqualTo(DataToTest.validContactPhone));
            //Assert.That(textFieldConfirmPhone.Contains(DataToTest.validContactPhone));
            
            string textFieldEMail = driver.FindElement(By.XPath(ConfirmRegistrationPageObject.fieldConfirmMail)).Text;
            Assert.That(textFieldEMail, Is.EqualTo(DataToTest.validEMail)); 

        }
    }
}

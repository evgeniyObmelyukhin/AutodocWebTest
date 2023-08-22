using AutodocWebTest.Data;
using AutodocWebTest.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutodocWebTest.RootTest.Authorization
{
    [TestFixture]//����� ��������� ����� �������� �����, ����� ������� ������������ ������ ������ � ��� �����.
    public class AuthorizationTest : BaseTest
    {
        //����� ��������� ����� �������� �����, ����� ������� ������������ ������, ��� ��� ����.
        [Test]//Smoke : ���� � ������ �������(��) : ��������
        public void ValidSignInTest()
        {
            var headerMenu = new HeaderMenuPageObject(driver);

            headerMenu//��������� �������� �����������, ��������� ����
                .openPageAuthorization()
                .SignIn(DataToTest.validLogin, DataToTest.validPassword);

            string actualLoginUser = headerMenu.GetTextLinkLoginUser();//����������� ���������� actualLoginUser ����� �������� '����� ������������'

            Assert.That(actualLoginUser, Is.EqualTo(DataToTest.validLogin));//���������� ����� ������ 
        }

        [Test]//Smoke : ����� �� �� 
        public void logOutTest()
        {
            new HeaderMenuPageObject(driver)
                .openPageAuthorization()
                .SignIn(DataToTest.validLogin, DataToTest.validPassword)
                .openPagePrivateCabinet()
                .clickButtonLogOut();

            Assert.IsTrue(driver.FindElement(By.XPath(DataToTest.linkPrivateCabinet)).Displayed);
        }

        [Test]//Smoke : ���� � ������ �������(��) : ����������
        public void InvalidSignInTest()
        {
            new HeaderMenuPageObject(driver)
                .openPageAuthorization()
                .SignIn(DataToTest.invalidLogin, DataToTest.invalidPassword);

            string actualErrorMessage = new AuthorizationPageObject(driver).GetTextTitleErrorMessage();

            Assert.That(actualErrorMessage, Is.EqualTo(DataToTest.titleErrorMessage));
        }

        [Test]//CriticalPath : ���� � ������ �������(��) : ������ ���� �����/������
        public void emptyFieldsSignInTest()
        {
            new HeaderMenuPageObject(driver)
                .openPageAuthorization()
                .SignIn("", "");

            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }

        [Test]//CriticalPath : ���� � ������ �������(��) : ������ ���� �����
        public void emptyFieldLoginSignInTest()
        {
            new HeaderMenuPageObject(driver)
                .openPageAuthorization()
                .SignIn("", DataToTest.validPassword);

            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }

        [Test]//CriticalPath : ���� � ������ �������(��) : ������ ���� ������
        public void emptyFieldPasswordSignInTest()
        {
            new HeaderMenuPageObject(driver)
                .openPageAuthorization()
                .SignIn(DataToTest.validLogin, "");

            Assert.That(new AuthorizationPageObject(driver).GetTextTitleErrorMessage(), Is.EqualTo(DataToTest.titleErrorMessageNull));
        }



    }
}
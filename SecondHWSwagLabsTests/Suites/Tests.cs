using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SecondHWSwagLabsTests
{
    public class Tests
    {
        private IWebDriver driver;

        #region Locators
        private readonly By _loginField = By.Id("user-name");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _addJacketToCartButton = By.Id("add-to-cart-sauce-labs-fleece-jacket");
        private readonly By _shoppingCartBadgeButton = By.ClassName("shopping_cart_link");
        private readonly By _continueShoppingButton = By.Id("continue-shopping");
        private readonly By _addShirtToCartButton = By.Id("add-to-cart-sauce-labs-bolt-t-shirt");
        private readonly By _checkoutButton = By.ClassName("checkout_button");
        private readonly By _firstNameField = By.Id("first-name");
        private readonly By _lastNameField = By.Id("last-name");
        private readonly By _postalcodeField = By.Id("postal-code");
        private readonly By _continueButton = By.Id("continue");
        private readonly By _finishButton = By.Id("finish");
        #endregion

        #region Setup
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Utilities.URL);
            driver.Manage().Window.Maximize();
        }
        #endregion

        [TestCase(Description = "���� ������� �������� ��� ���� �� ��")]
        public void AllTests()
        {
            // �����������
            driver.FindElement(_loginField).SendKeys(Utilities.login);
            driver.FindElement(_passwordField).SendKeys(Utilities.password);
            driver.FindElement(_loginButton).Click();
            Console.WriteLine("����������� ������ �������");

            // ���������� ������ � �������
            driver.FindElement(_addJacketToCartButton).Click();
            Console.WriteLine("�������� ����� � �������: Sauce Labs Fleece Jacket");

            // �������� �������
            driver.FindElement(_shoppingCartBadgeButton).Click();
            Console.WriteLine("������� � �������");

            // ������� ������� � ������� (���������� �������)
            driver.FindElement(_continueShoppingButton).Click();
            Console.WriteLine("������� ������� � �������");

            // ���������� ������ � �������
            driver.FindElement(_addShirtToCartButton).Click();
            Console.WriteLine("�������� ����� � �������: Sauce Labs Bolt T-Shirt");

            // �������� �������
            driver.FindElement(_shoppingCartBadgeButton).Click();
            Console.WriteLine("������� � �������");

            // ������� � ������
            driver.FindElement(_checkoutButton).Click();
            Console.WriteLine("������� � ������");

            // ���������� ���������� � ���������� � ������� Continue
            driver.FindElement(_firstNameField).SendKeys(Utilities.firstName);
            driver.FindElement(_lastNameField).SendKeys(Utilities.lastName);
            driver.FindElement(_postalcodeField).SendKeys(Utilities.postalCode);
            driver.FindElement(_continueButton).Click();
            Console.WriteLine("���������� ���������� � ���������� � ������� Continue");

            // ���������� �������
            driver.FindElement(_finishButton).Click();
            Console.WriteLine("���������� �������");
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
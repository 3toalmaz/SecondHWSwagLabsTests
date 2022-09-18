using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace SecondHWSwagLabsTests
{
    public class Tests
    {
        public static IWebDriver driver;

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

        [TestCase(Description = "Тест который содержит все шаги из ДЗ")]
        public void AllTests()
        {
            // Авторизация
            Utilities.Wait(new List<By> { _loginField, _passwordField, _loginButton });
            driver.FindElement(_loginField).SendKeys(Utilities.login);
            driver.FindElement(_passwordField).SendKeys(Utilities.password);
            driver.FindElement(_loginButton).Click();
            Console.WriteLine("Авторизация прошла успешно");

            // Добавление товара в корзину
            Utilities.Wait(new List<By> { _addJacketToCartButton });
            driver.FindElement(_addJacketToCartButton).Click();
            Console.WriteLine("Добавлен товар в корзину: Sauce Labs Fleece Jacket");

            // Открытие корзины
            Utilities.Wait(new List<By> { _shoppingCartBadgeButton });
            driver.FindElement(_shoppingCartBadgeButton).Click();
            Console.WriteLine("Переход в корзину");

            // Переход обратно в каталог (Продолжить покупки)
            Utilities.Wait(new List<By> { _continueShoppingButton });
            driver.FindElement(_continueShoppingButton).Click();
            Console.WriteLine("Переход обратно в каталог");

            // Добавление товара в корзину
            Utilities.Wait(new List<By> { _addShirtToCartButton });
            driver.FindElement(_addShirtToCartButton).Click();
            Console.WriteLine("Добавлен товар в корзину: Sauce Labs Bolt T-Shirt");

            // Открытие корзины
            Utilities.Wait(new List<By> { _shoppingCartBadgeButton });
            driver.FindElement(_shoppingCartBadgeButton).Click();
            Console.WriteLine("Переход в корзину");

            // Перейти к оплате
            Utilities.Wait(new List<By> { _checkoutButton });
            driver.FindElement(_checkoutButton).Click();
            Console.WriteLine("Переход к оплате");

            // Заполнение информации о покупателе и нажатие Continue
            Utilities.Wait(new List<By> { _firstNameField, _lastNameField, _postalcodeField, _continueButton });
            driver.FindElement(_firstNameField).SendKeys(Utilities.firstName);
            driver.FindElement(_lastNameField).SendKeys(Utilities.lastName);
            driver.FindElement(_postalcodeField).SendKeys(Utilities.postalCode);
            driver.FindElement(_continueButton).Click();
            Console.WriteLine("Заполнение информации о покупателе и нажатие Continue");

            // Завершение покупки
            Utilities.Wait(new List<By> { _finishButton });
            driver.FindElement(_finishButton).Click();
            Console.WriteLine("Завершение покупки");
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
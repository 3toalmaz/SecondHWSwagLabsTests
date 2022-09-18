using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondHWSwagLabsTests
{
    internal class Utilities
    {
        private static WebDriverWait wait = new WebDriverWait(Tests.driver, TimeSpan.FromSeconds(30));

        public const string URL = "https://www.saucedemo.com/";
        public const string login = "performance_glitch_user";
        public const string password = "secret_sauce";
        public const string firstName = "Benjen";
        public const string lastName = "Stark";
        public const string postalCode = "Somewhere behind the ice wall";

        public static void Wait(List<By> locators)
        {
            foreach (var locator in locators)
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
        }
    }
}

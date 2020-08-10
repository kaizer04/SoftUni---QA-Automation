﻿namespace Exam0508
{
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using System;
    using System.IO;
    using System.Threading;

    public class BaseTest
    {
        public IWebDriver Driver { get; protected set; }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var path = Path.GetFullPath(Directory.GetCurrentDirectory()
                                      + @"\..\..\..\Screenshots\") +
                                      TestContext.CurrentContext.Test.Name + ".png";
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            }
            Driver.Quit();
        }

        public void DelayForVideo(int seconds = 1)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}

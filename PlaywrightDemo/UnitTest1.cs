using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightDemo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync(); //download the package, drivers

        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions{
                Headless = false
            }
        );

        //Page
        var page = await browser.NewPageAsync();

        await page.GotoAsync(url:"https://www.google.com/");
        

await page.ClickAsync(selector: "text=Gmail");
        await page.ScreenshotAsync(new PageScreenshotOptions{
            Path ="test.jpg"
        });
        Assert.Pass();
    }
}

using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Geidea.Web.Tests;

[Binding]
public class GmailSteps
{
    private IWebDriver driver;
    private ConfigReader config;
    private GmailLoginPage loginPage;
    private GmailComposePage composePage;
    private GmailInboxPage inboxPage;

    public GmailSteps()
    {
        // Get the base directory of the project (root directory)
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Check if we are in a debug/release folder and adjust the path accordingly
        string configPath = Path.Combine(baseDirectory, "..", "..", "..", "Utilities", "config.json");

        // Resolve the full path after going up three levels from the output directory
        configPath = Path.GetFullPath(configPath);

        // Read the config file
        config = ConfigReader.ReadConfig(configPath);

        // Initialize WebDriver and page objects
        driver = WebDriverSetupHelper.InitializeWebDriver();
        loginPage = new GmailLoginPage(driver);
        composePage = new GmailComposePage(driver);
        inboxPage = new GmailInboxPage(driver);
    }

    [Given(@"I open Gmail login page")]
    public void GivenIOpenGmailLoginPage()
    {
        try
        {
            driver.Navigate().GoToUrl(config.GmailUrl); // Fetch the URL from the config
            driver.Manage().Window.Maximize();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error initializing WebDriver: {ex.Message}");
            throw;
        }
    }

    [When(@"I log in with valid credentials")]
    public void WhenILogInWithValidCredentials()
    {
        loginPage.EnterUsername(config.GmailUsername);
        loginPage.ClickNextButton();
        loginPage.EnterPassword(config.GmailPassword);
        loginPage.ClickPasswordNextButton();
    }

    [When(@"I compose an email with subject, body and attachment")]
    public void WhenIComposeAnEmailWithSubjectBodyAndAttachment()
    {
        composePage.ClickComposeButton();
        composePage.EnterRecipient(config.GmailUsername); 
        composePage.EnterSubject(config.Subject); 
        composePage.EnterBody(config.Body);  
        composePage.AttachFile(config.AttachmentPath);  
    }

    [When(@"I label the email as ""(.*)""")]
    public void WhenILabelTheEmailAs(string label)
    {
        composePage.ClickOnMoreOptionsMenu();
        composePage.ClickLabelButton();
        composePage.SelectLabel(label);
    }

    [When(@"I send the email to myself")]
    public void WhenISendTheEmailToMyself()
    {
        composePage.ClickSendButton();
    }

    [Then(@"I should see the email under the Social label")]
    public void ThenIShouldSeeTheEmailUnderTheSocialLabel()
    {
        inboxPage.ClickOnSocialTab();
        Assert.That(driver.FindElement(By.XPath("//span[contains(text(),'Test Email Subject')]")), Is.Not.Null, "The email is not present");
    }

    [Then(@"the subject, body, and attachment should match the sent email")]
    public void ThenTheSubjectBodyAndAttachmentShouldMatchTheSentEmail()
    {
        inboxPage.ClickEmail();

        Assert.Multiple(() =>
        {
            Assert.That(inboxPage.GetEmailSubject(), Is.EqualTo(config.Subject), "Subject does not match.");
            Assert.That(inboxPage.GetEmailBody(), Is.EqualTo(config.Body), "Body does not match.");
            Assert.That(inboxPage.GetAttachmentName(), Is.EqualTo(Path.GetFileName(config.AttachmentPath)), "Attachment name does not match.");
        });
    }

    [AfterScenario]
    public void Cleanup()
    {
        driver?.Quit();
    }
}
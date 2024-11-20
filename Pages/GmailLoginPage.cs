using Gmail.Pages;
using OpenQA.Selenium;

public class GmailLoginPage : WebPage
{
    private readonly By UsernameField = By.Id("identifierId");
    private readonly By NextButton = By.Id("identifierNext");
    private readonly By PasswordField = By.Name("Passwd");
    private readonly By PasswordNextButton = By.Id("passwordNext");

    public GmailLoginPage(IWebDriver driver) : base(driver) { }

    public void EnterUsername(string username)
    {
        EnterTextInField(UsernameField, username);
    }

    public void ClickNextButton()
    {
        ClickOnElement(NextButton);
    }

    public void EnterPassword(string password)
    {
        EnterTextInField(PasswordField, password);
    }

    public void ClickPasswordNextButton()
    {
        ClickOnElement(PasswordNextButton);
    }
}
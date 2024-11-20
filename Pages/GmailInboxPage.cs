using Gmail.Pages;
using OpenQA.Selenium;

public class GmailInboxPage : WebPage
{
    private readonly By MyEmail = By.XPath("(//span[contains(text(),'Test Email Subject')])[2]");
    private readonly By EmailBody = By.XPath("//div[contains(text(), 'body')]");
    private readonly By AttachmentName = By.XPath("//span[text()='AttachmentFile.txt']");
    private readonly By EmailSubject = By.XPath("//h2[text()='Test Email Subject']");
    private readonly By SocialTab = By.XPath("//div[@aria-label='Social']");


    public GmailInboxPage(IWebDriver driver) : base(driver) { }

    public void ClickEmail()
    {
        ClickOnElement(MyEmail);
    }

    public void ClickOnSocialTab()
    {
        ClickOnElement(SocialTab);
    }

    public string GetEmailSubject()
    {
        return GetElementText(EmailSubject);
    }

    public string GetEmailBody()
    {
        return GetElementText(EmailBody);
    }

    public string GetAttachmentName()
    {
        return GetElementText(AttachmentName);
    }
}

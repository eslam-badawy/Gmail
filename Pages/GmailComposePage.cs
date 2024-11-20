using Gmail.Pages;
using OpenQA.Selenium;

public class GmailComposePage : WebPage
{
    private readonly By ComposeButton = By.XPath("//div[contains(text(),'Compose')]");
    private readonly By ToField = By.XPath("//input[@aria-label='To recipients']");
    private readonly By SubjectField = By.Name("subjectbox");
    private readonly By MessageBodyField = By.CssSelector("div[aria-label='Message Body']");
    private readonly By SendButton = By.XPath("//div[@aria-label='Send ‪(Ctrl-Enter)‬']");
    private readonly By MoreOptions = By.XPath("//div[@aria-label='More options']");
    private readonly By LabelButton = By.XPath("//div[@role='menuitem']//div[contains(text(),'Label')]");

    public GmailComposePage(IWebDriver driver) : base(driver) { }

    public void ClickComposeButton()
    {
        ClickOnElement(ComposeButton);
    }

    public void EnterRecipient(string recipient)
    {
        EnterTextInField(ToField, recipient);
    }

    public void EnterSubject(string subject)
    {
        EnterTextInField(SubjectField, subject);
    }

    public void ClickOnMoreOptionsMenu()
    {
        ClickOnElement(MoreOptions);
    }

    public void EnterBody(string body)
    {
        EnterTextInField(MessageBodyField, body);
    }

    public void AttachFile(string filePath)
    {
        var fileInput = Driver.FindElement(By.XPath("//input[@type='file']"));
        fileInput.SendKeys(filePath); // Use SendKeys to attach the file
    }


    public void ClickLabelButton()
    {
        ClickOnElement(LabelButton);
    }

    public void ClickSendButton()
    {
        ClickOnElement(SendButton);
    }

    public void SelectLabel(string label)
    {
        var labelLocator = By.XPath($"//div[@title = '{label}']"); 
        ClickOnElement(labelLocator);
    }
}
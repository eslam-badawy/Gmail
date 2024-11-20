# Gmail Automation Test

This repository contains an automation test for Gmail using Selenium with C# and Page Object Model (POM) structure. The test demonstrates logging into Gmail, composing and sending an email, verifying it under the "Social" label, and checking the subject, body, and attachment.

## Requirements

- **Selenium WebDriver**: For interacting with the web application (Gmail).
- **SpecFlow**: For defining the test in Gherkin format (BDD).
- **NUnit**: For running and managing tests.
- **Visual Studio**: IDE for C# development.
- **ChromeDriver**: Required to run the test in Chrome.
- **Config File**: The test relies on a `config.json` file for storing Gmail credentials, email subject, body, and attachment file path.

## Setup

### 1. Install Dependencies
Open the solution in Visual Studio and restore the required NuGet packages:

Selenium.WebDriver
SpecFlow
NUnit
You can restore the packages by right-clicking on the solution in Solution Explorer and selecting Restore NuGet Packages.

### 2. Configuration
The test requires a config.json file that contains the following information:

json
Copy code
{
  "GmailUsername": "your-email@gmail.com",
  "GmailPassword": "your-password",
  "Subject": "Test Email Subject",
  "Body": "This is a test email body.",
  "AttachmentPath": "path\\to\\your\\attachment.txt"
}
Ensure the GmailUsername and GmailPassword are filled in with valid Gmail credentials. The Subject, Body, and AttachmentPath fields can be customized.

### 3. ChromeDriver Setup
Download the appropriate ChromeDriver for your system from ChromeDriver download and place it in the project's bin directory, or update the WebDriverSetupHelper.cs to point to the location of your ChromeDriver.

### 4. Running the Test  
- **Build the Solution**: In Visual Studio, go to **Build > Build Solution**.
- **Run the Test**: Open **Test Explorer** in Visual Studio, right-click on the `Gmail.feature` file, and select **Run Tests** to execute the test.

### 5. Screen Video Recording
A screen recording of the test execution is provided for demonstration purposes. The video captures the entire execution of the test, including login, email composition, sending the email, and verification of the email under the "Social" label.
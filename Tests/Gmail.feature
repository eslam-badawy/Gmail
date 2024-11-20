Feature: Gmail Automation
  Verify the Gmail workflow: Login, send email, and verify labels.

Scenario: Login to Gmail, Compose and Send an Email, Verify it
  Given I open Gmail login page
  When I log in with valid credentials
  And I compose an email with subject, body and attachment
  And I label the email as "Social"
  And I send the email to myself
  Then I should see the email under the Social label
  And the subject, body, and attachment should match the sent email


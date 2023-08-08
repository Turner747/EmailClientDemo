# EmailClientDemo
Started out as a demo for using Microsoft dependency injection for WPF navigation; turned into an Email client that uses the Smtp2Go API

## Set Up an SMPT 2 Go Account
https://www.smtp2go.com/pricing/

*Free accounts are available

## Required to Run
1. Sign up for SMTP 2 Go
2. Get an API Key (https://support.smtp2go.com/hc/en-gb/articles/20733554340249-API-Keys)
3. Manage User-Secrets for the project
4. Add the following secret: "Smtp2Go:ApiKey": "[api-key]"

## Using the Application
1. Enter your email in the Setting View
2. Verify your email via the confirmation email
3. Go to the Home View and send an email as expected

## API Documention
https://apidoc.smtp2go.com/documentation/#/README

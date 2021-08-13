# IckleURl
Tech Test for URL Shortener

Ickle URl Generator provides a hostable ASP.Net MVC Site and API service thats enables users to create short URLs from longer ones.

# Build and Run Instructions

- Developer Environment:
- Server 2016 Standard
- Visual Studio 2019
- Sql Server (localDb)
- .Net 4.7.2

- Clone Repo to desired location.
- Open in Visual Studio
- Build
- Run (IIS Express(Google Chrome))

# Run Tests
- Open Test Explorer
- Run Tests

# API
- API URL:  https://localhost:44353/api/ickleurlapi/shorten
- Required Params: url

- Test API Query String:  https://localhost:44353/api/ickleurlapi/shorten?url=https://www.payroc.com
- Request Type: POST

Successful Return JSON (200 Repsonse): 
{
  "fullurl": "https://www.payroc.com",
  "shortendurl": "https://localhost:44353/0fb162",
  "error": null
}

Error Return JSON (400 Response):
{
  "Message": "<Specific Error Message>"
}

# APP
- Enter URL in Input
- Click Button

- Successful Response is Hyperlink - click to redirect to full URL
- Error:  Handled Errors will show error message, others redirect to error page.

Error Response
To make it generic we need to create and class
API RESPONSE
STATUSCODE MESSAGE
400,401,403,404,500
400 - BadRequest
401 - Authorization Error (Login)
403 - Forbidden Error(Not able access certain pages due to restriction.)
500 - Internal Error /Server Error when null reference error or the error that occurs during code or data issue.
404 - Page Not found
API EXCEPTION
Having the details of the page
If the route is not existing then we can create new middle ware to show the error
API VALIDATION ERROR RESPONSE

Swagger URL
https://localhost:5001/swagger/index.html
How to start the program
CD api
dotnet watch run

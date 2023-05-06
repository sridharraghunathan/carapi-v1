using System;

namespace API.error
{
    public class ApiResponse 
    {


        public ApiResponse(int statusCode, string message = null)
        {
            this.statusCode = statusCode;
            this.message = message ?? GetStaticMessageBasedonCode(statusCode);

        }
        public int statusCode { get; set; }
        public string message { get; set; }
        private static string GetStaticMessageBasedonCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Badrequest has been made.",
                401 => "You are not autheticated to perform this action.",
                403 => "You are not authorized to perform this action.",
                404 => "Requested Page not found",
                500 => "Internal Server Error, Please contact your system administrator",
                _ => "Unknown Error Occurred, Please contact your system administrator"

            };
        }
    }
}
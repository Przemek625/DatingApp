using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{   
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members
    // A static class is basically the same as a non-static class, but there is one difference: a static class cannot be instantiated. 
    // In other words, you cannot use the new keyword to create a variable of the class type
    public static class Extensions
    {
        public static void AddAplicationError(this HttpResponse response, string message)
        {

            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");

        }

        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;

            if (theDateTime.AddYears(age) > DateTime.Today)
                age--;
                
            return age;

        }
        
    }
}
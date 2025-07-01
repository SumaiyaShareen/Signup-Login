namespace LOGINSYSTEM.Models
{
    public class UserSignupRequest
    {// UserSignupRequest.cs
       
        
            public string ?FullName { get; set; } // Full name of the user
            public string ?Email { get; set; }     // Email address
            public string ?Password { get; set; }  // Password for the user
            public string ?PhoneNumber { get; set; } // Phone number of the user
            public DateTime ?DateOfBirth { get; set; } // Date of birth
            public string ?Address { get; set; }  // User's address
            public  IFormFile ?ProfilePicture { get; set; } // URL of profile picture
        }









    }


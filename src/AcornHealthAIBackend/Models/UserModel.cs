using System;
using System.Collections.Generic;

namespace AcornHealthAIBackend.Models {
    public class UserModel {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public List<string> Records { get; set; }
    }
}

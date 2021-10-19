using System;

namespace AcornHealthAIBackend.Models {
    public class SessionModel {
        public string Token { get; set; }
        public UserModel User { get; set; }
    }
}

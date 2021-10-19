using System;

namespace AcornHealthAIBackend.Models {
    public class AuthenticationResponse {
        public bool Success { get; set; }
        public string Token { get; set; }
    }
}

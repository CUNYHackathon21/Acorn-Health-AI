using AcornHealthAIBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcornHealthAIBackend.Services {
    public class AuthenticationService {
        public List<UserModel> Users { get; } = new();
        public Dictionary<string, SessionModel> Sessions { get; } = new();

        public AuthenticationService() {
            var user = new UserModel() {
                Email = "asd@asd.com",
                Password = "asd",
                FirstName = "asd",
                LastName = "asdl"
            };

            Users.Add(user);
        }

        public bool Login(string email, string password, out string token) {
            token = Guid.NewGuid().ToString();

            var user = Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user is null)
                return false;

            // Generate session
            var session = new SessionModel() {
                Token = token,
                User = user
            };

            Sessions.Add(token, session);

            return true;
        }
    }
}
using AcornHealthAIBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcornHealthAIBackend.Services {
    public class AuthenticationService {
        public List<UserModel> Users { get; } = new();
        public static Dictionary<string, SessionModel> Sessions { get; } = new();

        public AuthenticationService() {
            var user = new UserModel() {
                Email = "asd@asd.com",
                Password = "asd",
                FirstName = "asd",
                LastName = "asdl",
                DOB = DateTime.Today,
                Gender = "Attack Helicopter",
                Records = new()
            };

            // Records
            user.Records.Add("Asthma");
            user.Records.Add("Migraines");
            user.Records.Add("Brain tumor");
            user.Records.Add("Corona");

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

        public UserModel GetSession(string token) {
            if (!Sessions.TryGetValue(token, out var session))
                return null;

            return Clean(session.User);
        }

        private UserModel Clean(UserModel classinfo) {
            classinfo.Password = null;
            return classinfo;
        }
    }
}
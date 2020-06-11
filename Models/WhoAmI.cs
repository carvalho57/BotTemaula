using System;


namespace temAulaBotTelegram.Models {
    public class WhoAmI {
        public string UserName {get; private set;}
        public string FirstName {get;private set;}
        public WhoAmI(string username, string firstName) {
            UserName = username;
            FirstName = firstName;
        }
    }
}
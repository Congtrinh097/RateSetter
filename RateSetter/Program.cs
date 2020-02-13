using RateSetter.Logics;
using RateSetter.Models;
using System;
using System.Collections.Generic;

namespace RateSetter
{
    class Program
    {
        static void Main(string[] args)
        {
            //fake data from database
            List<User> existingUserList = new List<User>(){
                new User() {
                    Address = new Address(){ Latitude = 102.3M, Longitude = 12.23M, State="Da Nang",StreetAddress="3 Nguyen Thi Minh Khai", Suburb="ABC city !"},
                    Name = "Chris",
                    ReferralCode = "ABC123" },
                new User() {
                    Address = new Address(){ Latitude = 10.3M, Longitude = 12.23M, State="Da Nang",StreetAddress="Van Cao-", Suburb="ABC city !"},
                    Name = "Trinh",
                    ReferralCode = "HKT123" },
                new User() {
                    Address = new Address(){ Latitude = 10.3M, Longitude = 12.23M, State="Da Nang",StreetAddress="Van Cao", Suburb="Data test city !"},
                    Name = "Lan",
                    ReferralCode = "DMC123" },
                new User() {
                    Address = new Address(){ Latitude = 10.3M, Longitude = 12.23M, State="Da Nang",StreetAddress="Van Cao -", Suburb="ABC city !"},
                    Name = "John Joe",
                    ReferralCode = "IIS123" },
            };

            //fake input user info
            // match distance
            User newUser1 = new User()
            {
                Address = new Address() { Latitude = 102.131213M, Longitude = 9.233M, State = "Da Nang ", StreetAddress = "df3 T Thi Minh Khai", Suburb = "ABC city !" },
                Name = "Chris",
                ReferralCode = "KLD543"
            };
            // match name and andress
            User newUser2 = new User()
            {
                Address = new Address() { Latitude = 107.3M, Longitude = 12.23M, State = "Da Nang", StreetAddress = "Van Cao-", Suburb = "ABC city " },
                Name = "Trinh",
                ReferralCode = "NOT100"
            };

            // match name ReferralCode
            User newUser3 = new User()
            {
                Address = new Address() { Latitude = 11100.3M, Longitude = 022.23M, State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "NoName",
                ReferralCode = "HKT123"
            };

            // no match
            User newUser4 = new User()
            {
                Address = new Address() { Latitude = 1.3M, Longitude = 022.23M, State = "Da Nang", StreetAddress = "NoMatch Street-", Suburb = "No city " },
                Name = "NoMatch",
                ReferralCode = "NO1T23"
            };

            // user matcher Logic
            IUserMatcher userMatch = new UserMatcher();

            // check data if it's matches with existing user by the rules defined.
            // test 1
            Console.WriteLine("Test user 1: !");
            if ( existingUserList.Find(user => userMatch.IsMatch(newUser1, user)) != null) {
                Console.WriteLine("rejected");
            } else {
                Console.WriteLine("it's good");
            }
            // test 2
            Console.WriteLine("Test user 2: !");
            if (existingUserList.Find(user => userMatch.IsMatch(newUser2, user)) != null)
            {
                Console.WriteLine("rejected");
            }
            else
            {
                Console.WriteLine("it's good");
            }
            // test 3
            Console.WriteLine("Test user 3: !");
            if (existingUserList.Find(user => userMatch.IsMatch(newUser3, user)) != null)
            {
                Console.WriteLine("rejected");
            }
            else
            {
                Console.WriteLine("it's good");
            }
            // test 4
            Console.WriteLine("Test user 4: !");
            if (existingUserList.Find(user => userMatch.IsMatch(newUser4, user)) != null)
            {
                Console.WriteLine("rejected");
            }
            else
            {
                Console.WriteLine("it's good");
            }

            Console.WriteLine("End the function!");
            Console.ReadLine();
        }
    }
}

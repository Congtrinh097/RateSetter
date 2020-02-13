using RateSetter.Logics;
using RateSetter.Models;
using System;
using System.Collections.Generic;

namespace RateSetter
{
    class Program
    {
        //fake data from database
        static List<User> existingUserList = new List<User>(){
                new User() {
                    Address = new Address(){ Latitude = 19.3798091M, Longitude = 109.2164128M, State="Da Nang",StreetAddress="3 Nguyen Thi Minh Khai", Suburb="ABC city !"},
                    Name = "Chris",
                    ReferralCode = "ABC123" },
                new User() {
                    Address = new Address(){ Latitude = 16.3798091M, Longitude = 108.2164128M, State="Da Nang",StreetAddress="Van Cao-", Suburb="ABC city !"},
                    Name = "Trinh",
                    ReferralCode = "HKT123" },
                new User() {
                    Address = new Address(){ Latitude = 19.3798091M, Longitude = 107.2164128M, State="Da Nang",StreetAddress="Van Cao", Suburb="Data test city !"},
                    Name = "Lan",
                    ReferralCode = "DMC123" },
                new User() {
                    Address = new Address(){ Latitude = 19.4798091M, Longitude = 137.2164128M, State="Da Nang",StreetAddress="Van Cao -", Suburb="ABC city !"},
                    Name = "John Joe",
                    ReferralCode = "IIS123" },
        };

        static void Main(string[] args)
        {
            // match distance
            User newUser1 = new User()
            {
                Address = new Address() { Latitude = 19.3798091M, Longitude = 107.2164128M, State = "Da Nang ", StreetAddress = "df3 T Thi Minh Khai", Suburb = "ABC city !" },
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

            

            // check data if it's matches with existing user by the rules defined.
            // test 1
            Console.WriteLine("Check user 1:");
            if (IsExisting(newUser1))
            {  
                Console.WriteLine("rejected");
            } else {
                Console.WriteLine("it's good");
            }
            // test 2
            Console.WriteLine("Check user 2:");
            if (IsExisting(newUser2))
            {
                Console.WriteLine("rejected"); 
            }
            else
            {
                Console.WriteLine("it's good");
            }
            // test 3
            Console.WriteLine("Check user 3:");
            if (IsExisting(newUser3))
            {
                Console.WriteLine("rejected");
            }
            else
            {
                Console.WriteLine("it's good");
            }
            // test 4
            Console.WriteLine("Check user 4:");
            if (IsExisting(newUser4))
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

        public static bool IsExisting(User newUser)
        {
            IUserMatcher userMatch = new UserMatcher();

            if (existingUserList.Find(user => userMatch.IsMatch(newUser, user)) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

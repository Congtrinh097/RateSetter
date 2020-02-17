using NUnit.Framework;
using RateSetter.Models;
using RateSetter.Logics;

namespace RateSetter.Logics.Tests
{
    public class ReferralCodeMatcherTests
    {
        public static IUserRuleMatcher rule;

        [SetUp]
        public void Setup()
        {
            rule = new ReferralCodeMatcher();
        }
        
        [Test]
        public void TestCase_NoMatched_SameReferralCode()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M , State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Name 2",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.3798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Name 1",
                ReferralCode = "HKT123"
            };

            Assert.AreEqual(false, rule.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_Matched_InsensitiveUpperOrLowerCase()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Name 2",
                ReferralCode = "Hk1T23"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.3798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Name 1",
                ReferralCode = "hk13t2"
            };

            Assert.AreEqual(true, rule.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_NoMatched_DifferenceReferralCode()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Name 2",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.3798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Name 2",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(false, rule.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_NoMatched_ReferralDifferenceMoreThan3Positions()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Name 2",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.3798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Name 2",
                ReferralCode = "H123KT"
            };

            Assert.AreEqual(false, rule.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_NoMatched_ReferralDifferenceLessThan3Positions()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Name 2",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.3798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Name 2",
                ReferralCode = "HK312T"
            };

            Assert.AreEqual(false, rule.IsMatch(user1, user2));
        }
    }
}
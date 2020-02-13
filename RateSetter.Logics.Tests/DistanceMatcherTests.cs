using NUnit.Framework;
using RateSetter.Models;
using RateSetter.Logics;

namespace RateSetter.Logics.Tests
{
    public class DistanceMatcherTests
    {
        public static IUserRuleMatcher rule;

        [SetUp]
        public void Setup()
        {
            rule = new DistanceMatcher();
        }

        [Test]
        public void TestCase_Matched_DistanceIsZero()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Name 2",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Name 2",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(true, rule.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_Matched_DistanceLessThan500()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M , State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Name 2",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.4808091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Name 1",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(true, rule.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_NotMatched_DistanceMoreThan500()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Name 2",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.3798091M, Longitude = 109.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Name 1",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(false, rule.IsMatch(user1, user2));
        }
    }
}
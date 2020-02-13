using NUnit.Framework;
using RateSetter.Models;
using RateSetter.Logics;

namespace RateSetter.Logics.Tests
{
    public class NameAddressMatcherTests
    {
        public static IUserRuleMatcher rule;

        [SetUp]
        public void Setup()
        {
            rule = new  NameAddressMatcher();
        }

        [Test]
        public void TestCase_NoMatched()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Name 2",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 162.3798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Name 1",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(false, rule.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_NoMatched_SameNameAndDiffrenceAddress()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M , State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Same Name",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.3798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Same Name",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(false, rule.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_NoMatched_SameAddressAndDiffrenceName()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "26 Ta Hien", Suburb = "ABC " },
                Name = " Name 1",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.3798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "26 Ta Hien", Suburb = "ABC " },
                Name = " Name 2",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(false, rule.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_Matched_SameAddressAndSameName_WithoutSpecificCharacters()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "26 Ta Hien", Suburb = "ABC " },
                Name = " Name 1",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.3798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "26 Ta Hien", Suburb = "ABC " },
                Name = " Name 1",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(true, rule.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_Matched_SameAddressAndSameName_WithSpecificCharacters()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang !", StreetAddress = "26 Ta Hien", Suburb = "ABC " },
                Name = " Name 1",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.3798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "26 Ta Hien *", Suburb = "ABC " },
                Name = " Name 1",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(true, rule.IsMatch(user1, user2));
        }
    }
}
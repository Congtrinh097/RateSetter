using NUnit.Framework;
using RateSetter.Models;

namespace RateSetter.Logics.Tests
{
    public class UserMatcherTests
    {
        public static IUserMatcher userMatcher;

        [SetUp]
        public void Setup()
        {
            userMatcher = new UserMatcher();
            // add all rules
            userMatcher.AddRule(new DistanceMatcher());
            userMatcher.AddRule(new NameAddressMatcher());
            userMatcher.AddRule(new ReferralCodeMatcher());
        }

        [Test]
        public void TestCase_NoMatched_AtAll()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "Street 1-", Suburb = "ABC city " },
                Name = "Name 1",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.180788M, Longitude = 109.218108M, State = "Da Nang", StreetAddress = "Street 2-", Suburb = "No city " },
                Name = "Name 2",
                ReferralCode = "HKT000"
            };
            
            Assert.AreEqual(false, userMatcher.IsMatch(user1, user2));
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

            Assert.AreEqual(true, userMatcher.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_Matched_DistanceLessThan500()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Name 2",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.4808091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Name 1",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(true, userMatcher.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_NoMatched_DistanceMoreThan500()
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

            Assert.AreEqual(false, userMatcher.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_NoMatched_SameNameAndDiffrenceAddress()
        {
            User user1 = new User()
            {
                Address = new Address() { Latitude = 16.4798091M, Longitude = 108.2164128M, State = "Da Nang", StreetAddress = "NoName NoName-", Suburb = "ABC city " },
                Name = "Same Name",
                ReferralCode = "HKT123"
            };
            User user2 = new User()
            {
                Address = new Address() { Latitude = 16.3798091M, Longitude = 107.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Same Name",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(false, userMatcher.IsMatch(user1, user2));
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
                Address = new Address() { Latitude = 19.3798091M, Longitude = 109.2164128M, State = "Da Nang", StreetAddress = "26 Ta Hien", Suburb = "ABC " },
                Name = " Name 2",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(false, userMatcher.IsMatch(user1, user2));
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

            Assert.AreEqual(true, userMatcher.IsMatch(user1, user2));
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

            Assert.AreEqual(true, userMatcher.IsMatch(user1, user2));
        }

        [Test]
        public void TestCase_Matched_SameReferralCode()
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
                Name = "Name 1",
                ReferralCode = "HKT123"
            };

            Assert.AreEqual(true, userMatcher.IsMatch(user1, user2));
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
                Address = new Address() { Latitude = 16.4798091M, Longitude = 107.2164128M, State = "Da Nang", StreetAddress = "NoMatch Street", Suburb = "No city " },
                Name = "Name 2",
                ReferralCode = "NO1T23"
            };

            Assert.AreEqual(false, userMatcher.IsMatch(user1, user2));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using RateSetter.Models;
using RateSetter.Helpers;

namespace RateSetter.Logics
{
    public class DistanceMatcher : IUserRuleMatcher
    {
        public bool IsMatch(User newUser, User existingUser)
        {
            var dis = LocationHelper.GetDistance(newUser.Address.Latitude, newUser.Address.Longitude, existingUser.Address.Latitude, existingUser.Address.Longitude, 'M');
            return dis <= 500;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using RateSetter.Models;
using RateSetter.Helpers;

namespace RateSetter.Logics
{
    public class ReferralCodeMatcher : IUserRuleMatcher
    {
        public bool IsMatch(User newUser, User existingUser)
        {
            string sortedRefCodeOfNewUser = StringHelper.SortCharacters(newUser.ReferralCode.ToUpper());
            string sortedRefCodeExistingUser = StringHelper.SortCharacters(existingUser.ReferralCode.ToUpper());

            if (!sortedRefCodeOfNewUser.Equals(sortedRefCodeExistingUser))
            {
                return false;
            }
            
            return true;
        } 
    }
}
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
            string referralCodeOfNewUser = newUser.ReferralCode.ToUpper();
            string referralCodeOfExistingUser = existingUser.ReferralCode.ToUpper();

            if (referralCodeOfNewUser.Length != referralCodeOfExistingUser.Length)
            {
                return false;
            }

            string sortedRefCodeOfNewUser = StringHelper.SortCharacters(referralCodeOfNewUser);
            string sortedRefCodeExistingUser = StringHelper.SortCharacters(existingUser.ReferralCode.ToUpper());

            if (!sortedRefCodeOfNewUser.Equals(sortedRefCodeExistingUser))
            {
                return false;
            }

            if ( StringHelper.GetNumberOfDifferentCharacters(referralCodeOfNewUser, referralCodeOfExistingUser) != 3)
            {
                return false;
            }
            
            return true;
        } 
    }
}
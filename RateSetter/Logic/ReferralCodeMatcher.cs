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
            //About this rule. I'm not clearly about the buggy
            if (!newUser.ReferralCode.ToUpper().Equals(existingUser.ReferralCode.ToUpper()))
            {
                return false;
            }
            
            return true;
        } 
    }
}
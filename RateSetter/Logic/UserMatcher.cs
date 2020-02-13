using RateSetter.Logics;
using RateSetter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateSetter.Logics
{
    public class UserMatcher : IUserMatcher
    {
        public bool IsMatch(User newUser, User existingUser)
        {
            List<IUserRuleMatcher> listRules = new List<IUserRuleMatcher>();
            // add all rules
            listRules.Add(new DistanceMatcher());
            listRules.Add(new NameAddressMatcher());
            listRules.Add(new ReferralCodeMatcher());

            // check all rules if have more than one is matched return it's matched
            if (listRules.Find(rule => rule.IsMatch(newUser, existingUser)) != null) {
                return true;
            }
            return false;
        }
    }
}
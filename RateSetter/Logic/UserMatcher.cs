using RateSetter.Logics;
using RateSetter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateSetter.Logics
{
    public class UserMatcher : IUserMatcher
    {
        List<IUserRuleMatcher> listRules = new List<IUserRuleMatcher>();

        public void AddRule(IUserRuleMatcher rule)
        {
            listRules.Add(rule);
        }

        public bool IsMatch(User newUser, User existingUser)
        {
            // check all rules if have more than one is matched return it's matched
            if (listRules.Find(rule => rule.IsMatch(newUser, existingUser)) != null) {
                return true;
            }
            return false;
        }
    }
}
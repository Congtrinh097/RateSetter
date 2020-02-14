using RateSetter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateSetter.Logics
{
    public interface IUserMatcher
    {
        /// <summary>
        /// check matcher is match or not
        /// </summary>
        /// <param name="newUser"></param>
        /// <param name="existingUser"></param>
        /// <returns>Return true if rule is matched</returns>
        bool IsMatch(User newUser, User existingUser);

        /// <summary>
        /// Add the rule to matcher
        /// </summary>
        /// <param name="rule"></param>
        void AddRule(IUserRuleMatcher rule);
    }
}

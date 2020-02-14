using RateSetter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateSetter.Logics
{
    public interface IUserRuleMatcher
    {
        /// <summary>
        /// check the rule is match or not
        /// </summary>
        /// <param name="newUser"></param>
        /// <param name="existingUser"></param>
        /// <returns>Return true if rule is matched</returns>
        bool IsMatch(User newUser, User existingUser);
    }
}

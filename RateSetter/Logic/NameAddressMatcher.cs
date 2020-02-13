using System;
using System.Collections.Generic;
using System.Text;
using RateSetter.Models;
using RateSetter.Helpers;

namespace RateSetter.Logics
{
    public class NameAddressMatcher : IUserRuleMatcher
    {
        public bool IsMatch(User newUser, User existingUser)
        {
            if (!newUser.Name.ToUpper().Equals(existingUser.Name.ToUpper()))
            {
                return false;
            }
            if (!StringHelper.RemoveSpecialCharacters(newUser.Address.StreetAddress).Equals(StringHelper.RemoveSpecialCharacters(existingUser.Address.StreetAddress)))
            {
                return false;
            }
            if (!StringHelper.RemoveSpecialCharacters(newUser.Address.State).Equals(StringHelper.RemoveSpecialCharacters(existingUser.Address.State)))
            {
                return false;
            }
            if (!StringHelper.RemoveSpecialCharacters(newUser.Address.Suburb).Equals(StringHelper.RemoveSpecialCharacters(existingUser.Address.Suburb)))
            {
                return false;
            }
            return true;
        } 
    }
}
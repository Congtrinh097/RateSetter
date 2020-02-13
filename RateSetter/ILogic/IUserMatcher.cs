using RateSetter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RateSetter.Logics
{
    public interface IUserMatcher
    {
        bool IsMatch(User newUser, User existingUser);
    }
}

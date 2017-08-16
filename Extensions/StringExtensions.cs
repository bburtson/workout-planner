using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Parses prefix of a users email {someName}@domain.com
        /// converts to title case.
        /// </summary>
        /// <returns>string</returns>
        public static string ParseFromEmail(this string email)
        {
            return char.ToUpper(email[0]) + email.Substring(0, email.IndexOf('@'))
                                                 .Remove(0, 1);
        }
    }
}

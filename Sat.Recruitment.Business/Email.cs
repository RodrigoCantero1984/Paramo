using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sat.Recruitment.Business
{
    public static class Email
    {
        public static string NormalizeEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return email;

            var normalized = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

            string DomainMapper(Match match)
            {
                var idn = new IdnMapping();
                string domainName = idn.GetAscii(match.Groups[2].Value);
                return match.Groups[1].Value + domainName;
            }

            return normalized;
        }
    }
}

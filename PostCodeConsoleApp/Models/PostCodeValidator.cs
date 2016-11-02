using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PostCodeConsoleApp.Models
{
    public class PostCodeValidator
    {
        private const string PostCodeRegex = @"(GIR\s0AA) |
    (
        # A9 or A99 prefix
        ( ([A-PR-UWYZ][0-9][0-9]?) |
             # AA99 prefix with some excluded areas
            (([A-PR-UWYZ][A-HK-Y][0-9](?<!(BR|FY|HA|HD|HG|HR|HS|HX|JE|LD|SM|SR|WC|WN|ZE)[0-9])[0-9]) |
             # AA9 prefix with some excluded areas
             ([A-PR-UWYZ][A-HK-Y](?<!AB|LL|SO)[0-9]) |
             # WC1A prefix
             (WC[0-9][A-Z]) |
             (
                # A9A prefix
               ([A-PR-UWYZ][0-9][A-HJKPSTUW]) |
                # AA9A prefix
               ([A-PR-UWYZ][A-HK-Y][0-9][ABEHMNPRVWXY])
             )
            )
          )
          # 9AA suffix
        \s[0-9][ABD-HJLNP-UW-Z]{2}
        )";
        public string PostCodeToVerify { get; set; }

        public PostCodeValidator(string pCode)
        {
            PostCodeToVerify = pCode;
        }

        public bool IsValidPostCode()
        {
            var match = Regex.Match(PostCodeToVerify, PostCodeRegex, RegexOptions.IgnorePatternWhitespace);
            return match.Success && match.Value.Length == PostCodeToVerify.Length;
        }
    }
}
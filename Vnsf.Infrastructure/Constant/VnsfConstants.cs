using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Infrastructure.Constant
{
    public class VnsfConstants
    {
        public class ClaimTypes
        {
            public const string Tenant = "http://brockallen.com/membershipreboot/claims/tenant";
        }

        public class UserAccount
        {
            public const int VerificationKeyStaleDurationDays = 1;
            public const int MobileCodeLength = 6;
            public const int MobileCodeStaleDurationMinutes = 10;
        }

        public class AuthenticationService
        {
            public static readonly TimeSpan TwoFactorAuthTokenLifetime = TimeSpan.FromMinutes(30);
            public const int DefaultPersistentCookieDays = 30;
            public const string CookieBasedTwoFactorAuthPolicyCookieName = "mr.cbtfap";
        }
    }
}

﻿/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;

namespace Vnsf.Data
{
    public class VnsfConstants
    {
        public class AppSettingDefaults
        {
            internal const string BaseUrl = "/documents";
            internal const bool RequireAccountVerification = true;
            internal const bool AllowLoginAfterAccountCreation = true;
            internal const int AccountLockoutFailedLoginAttempts = 5;
            internal const string AccountLockoutDuration = "00:05:00";
            internal const bool AllowAccountDeletion = true;
            internal const int PasswordHashingIterationCount = 0;
            internal const int PasswordResetFrequency = 0;
            internal const string GoogleClientId = "212507878610-4b9qn1edep6iotto0muc273028icku4a.apps.googleusercontent.com";
            internal const string GoogleClientSecret = "7XbIZQekpt69tvwNJA4Lt3vW";
            internal const string FacebookClientId = "212507878610-4b9qn1edep6iotto0muc273028icku4a.apps.googleusercontent.com";
            internal const string FacebookClientSecret = "7XbIZQekpt69tvwNJA4Lt3vW";

        }

        public class UserAccount
        {
            internal const int VerificationKeyStaleDurationDays = 1;
            internal const int MobileCodeLength = 6;
            internal const int MobileCodeStaleDurationMinutes = 10;
        }

        public class Document
        {
            internal const string RootDirectory = "";
        }

        public class AuthenticationService
        {
            internal static readonly TimeSpan TwoFactorAuthTokenLifetime = TimeSpan.FromMinutes(30);
            internal const int DefaultPersistentCookieDays = 30;
            internal const string CookieBasedTwoFactorAuthPolicyCookieName = "mr.cbtfap";
        }
    }
}

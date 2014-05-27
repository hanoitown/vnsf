/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Configuration;
using System.Linq;

namespace Vnsf.Data
{
    public class AppSettings : ConfigurationSection
    {
        public static AppSettings Instance { get; set; }

        static AppSettings()
        {
            Instance = FromConfiguration();
        }

        public static AppSettings FromConfiguration()
        {
            var instance = new AppSettings();
            var configSection = GetConfigSection();
            if (configSection != null)
            {
                foreach (var prop in configSection.Properties.Cast<ConfigurationProperty>())
                {
                    var val = configSection[prop];
                    instance[prop] = val;
                }
            }
            return instance;
        }

        public const string SectionName = "Vnsf";

        static AppSettings GetConfigSection()
        {
            return (AppSettings)System.Configuration.ConfigurationManager.GetSection(SectionName);
        }

        private const string BASEURL = "/upload/";
        private const string REQUIREACCOUNTVERIFICATION = "requireAccountVerification";
        private const string ALLOWLOGINAFTERACCOUNTCREATION = "allowLoginAfterAccountCreation";
        private const string ACCOUNTLOCKOUTFAILEDLOGINATTEMPTS = "accountLockoutFailedLoginAttempts";
        private const string ACCOUNTLOCKOUTDURATION = "accountLockoutDuration";
        private const string ALLOWACCOUNTDELETION = "allowAccountDeletion";
        private const string PASSWORDHASHINGITERATIONCOUNT = "passwordHashingIterationCount";
        private const string PASSWORDRESETFREQUENCY = "passwordResetFrequency";


        [ConfigurationProperty(REQUIREACCOUNTVERIFICATION, DefaultValue = VnsfConstants.AppSettingDefaults.RequireAccountVerification)]
        public string BaseUrl
        {
            get { return (string)this[BASEURL]; }
            set { this[BASEURL] = value; }
        }

        [ConfigurationProperty(REQUIREACCOUNTVERIFICATION, DefaultValue = VnsfConstants.AppSettingDefaults.RequireAccountVerification)]
        public bool RequireAccountVerification
        {
            get { return (bool)this[REQUIREACCOUNTVERIFICATION]; }
            set { this[REQUIREACCOUNTVERIFICATION] = value; }
        }

        [ConfigurationProperty(ALLOWLOGINAFTERACCOUNTCREATION, DefaultValue = VnsfConstants.AppSettingDefaults.AllowLoginAfterAccountCreation)]
        public bool AllowLoginAfterAccountCreation
        {
            get { return (bool)this[ALLOWLOGINAFTERACCOUNTCREATION]; }
            set { this[ALLOWLOGINAFTERACCOUNTCREATION] = value; }
        }

        [ConfigurationProperty(ACCOUNTLOCKOUTFAILEDLOGINATTEMPTS, DefaultValue = VnsfConstants.AppSettingDefaults.AccountLockoutFailedLoginAttempts)]
        public int AccountLockoutFailedLoginAttempts
        {
            get { return (int)this[ACCOUNTLOCKOUTFAILEDLOGINATTEMPTS]; }
            set { this[ACCOUNTLOCKOUTFAILEDLOGINATTEMPTS] = value; }
        }

        [ConfigurationProperty(ACCOUNTLOCKOUTDURATION, DefaultValue=VnsfConstants.AppSettingDefaults.AccountLockoutDuration)]
        public TimeSpan AccountLockoutDuration
        {
            get { return (TimeSpan)this[ACCOUNTLOCKOUTDURATION]; }
            set { this[ACCOUNTLOCKOUTDURATION] = value; }
        }

        [ConfigurationProperty(ALLOWACCOUNTDELETION, DefaultValue = VnsfConstants.AppSettingDefaults.AllowAccountDeletion)]
        public bool AllowAccountDeletion
        {
            get { return (bool)this[ALLOWACCOUNTDELETION]; }
            set { this[ALLOWACCOUNTDELETION] = value; }
        }

        [ConfigurationProperty(PASSWORDHASHINGITERATIONCOUNT, DefaultValue = VnsfConstants.AppSettingDefaults.PasswordHashingIterationCount)]
        public int PasswordHashingIterationCount
        {
            get { return (int)this[PASSWORDHASHINGITERATIONCOUNT]; }
            set { this[PASSWORDHASHINGITERATIONCOUNT] = value; }
        }

        [ConfigurationProperty(PASSWORDRESETFREQUENCY, DefaultValue = VnsfConstants.AppSettingDefaults.PasswordResetFrequency)]
        public int PasswordResetFrequency
        {
            get { return (int)this[PASSWORDRESETFREQUENCY]; }
            set { this[PASSWORDRESETFREQUENCY] = value; }
        }
    }
}

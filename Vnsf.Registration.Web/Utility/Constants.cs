using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.Registration.Web.Utility
{
    public static class Constants
    {
        public static class Actions
        {
            public const string Issue = "Issue";
            public const string Administration = "Administration";
        }

        public static class Resources
        {
            // issue actions
            public const string WSFederation = "WSFederation";
            public const string SimpleHttp = "SimpleHttp";
            public const string OAuth2 = "OAuth2";
            public const string WRAP = "WRAP";
            public const string WSTrust = "WSTrust";
            public const string JSNotify = "JSNotify";

            // administration actions
            public const string General = "General";
            public const string Configuration = "Configuration";
            public const string RelyingParty = "RelyingParty";
            public const string ServiceCertificates = "ServiceCertificates";
            public const string ClientCertificates = "ClientCertificates";
            public const string Delegation = "Delegation";
            public const string UI = "UI";
        }

    }
}
/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Web;
namespace Vnsf.Data
{
    public class AspNetApplicationInformation : ApplicationInformation
    {
        public AspNetApplicationInformation(
            string appName,
            string relativeConfirmChangeEmailUrl)
        {
            this.ApplicationName = appName;
            this.EmailSignature = emailSig;
            this.RelativeLoginUrl = relativeLoginUrl;
            this.RelativeVerifyAccountUrl = relativeVerifyAccountUrl;
            this.RelativeCancelNewAccountUrl = relativeCancelNewAccountUrl;
            this.RelativeConfirmPasswordResetUrl = relativeConfirmPasswordResetUrl;
            this.RelativeConfirmChangeEmailUrl = relativeConfirmChangeEmailUrl;
        }

        string baseUrl;
        object urlLock = new object();
        string BaseUrl
        {
            get
            {
                if (baseUrl == null)
                {
                    lock (urlLock)
                    {
                        if (baseUrl == null)
                        {
                            // build URL
                            baseUrl = HttpContext.Current.GetApplicationUrl();
                        }
                    }
                }
                return baseUrl;
            }
        }


    }
}

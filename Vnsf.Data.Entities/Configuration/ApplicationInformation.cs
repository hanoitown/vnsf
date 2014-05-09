/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

namespace BrockAllen.MembershipReboot
{
    public class ApplicationInformation
    {
        public virtual string ApplicationName { get; set; }
        public virtual string LoginUrl { get; set; }
        public virtual string VerifyAccountUrl { get; set; }
        public virtual string BaseStorageUrl { get; set; }

        public ApplicationInformation()
        {

        }
    }
}

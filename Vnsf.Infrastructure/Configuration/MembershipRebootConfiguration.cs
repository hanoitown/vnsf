/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;

namespace Vnsf.Infrastructure.Configuration
{
    public class MembershipRebootConfiguration
    {
        public MembershipRebootConfiguration()
            : this(SecuritySettings.Instance)
        {
        }

        public MembershipRebootConfiguration(SecuritySettings securitySettings)
        {
            if (securitySettings == null) throw new ArgumentNullException("securitySettings");
            this.SecuritySettings = securitySettings;
        }

        public SecuritySettings SecuritySettings { get; private set; }
    }
}

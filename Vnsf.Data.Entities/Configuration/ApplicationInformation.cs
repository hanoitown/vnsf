/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

namespace Vnsf.Data
{
    public class ApplicationInformation
    {
        public virtual string ApplicationName { get; set; }
        public virtual string BaseStorageUrl { get; set; }

        public ApplicationInformation()
        {

        }
    }
}

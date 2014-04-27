/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Security.Cryptography.X509Certificates;
using Vnsf.Infrastructure.Tracing;

namespace Vnsf.Data.Entities.Extensions
{
    static class X509Certificate2Extensions
    {
        public static void Validate(this X509Certificate2 certificate)
        {
            if (certificate == null)
            {
                Tracing.Verbose("[X509Certificate2Extensions.Validate] failed -- null cert");
                throw new ArgumentNullException("certificate");
            }
            if (certificate.Handle == IntPtr.Zero)
            {
                Tracing.Verbose("[X509Certificate2Extensions.Validate] failed -- invalid cert handle");
                throw new ArgumentException("Invalid certificate");
            }
        }
    }
}

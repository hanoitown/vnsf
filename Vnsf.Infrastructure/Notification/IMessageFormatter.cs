﻿/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */


namespace BrockAllen.MembershipReboot
{
    public interface IMessageFormatter
    {
        Message Format(UserAccountEvent accountEvent);
    }
}

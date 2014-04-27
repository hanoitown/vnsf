/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */


using Vnsf.Data.Entities.Account;
namespace Vnsf.WebHost.Infrastructure.Notification
{
    public interface IMessageFormatter
    {
        Message Format(UserAccountEvent accountEvent);
    }
}

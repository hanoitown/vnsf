/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */


namespace Vnsf.WebHost.Infrastructure.Notification
{
    public interface IMessageDelivery
    {
        void Send(Message msg);
    }
}

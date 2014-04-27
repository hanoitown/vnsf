﻿/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;

namespace BrockAllen.MembershipReboot
{
    public class EmailEventHandler
    {
        IMessageFormatter messageFormatter;
        IMessageDelivery messageDelivery;

        public EmailEventHandler(IMessageFormatter messageFormatter)
            : this(messageFormatter, new SmtpMessageDelivery())
        {
        }

        public EmailEventHandler(IMessageFormatter messageFormatter, IMessageDelivery messageDelivery)
        {
            if (messageFormatter == null) throw new ArgumentNullException("messageFormatter");
            if (messageDelivery == null) throw new ArgumentNullException("messageDelivery");

            this.messageFormatter = messageFormatter;
            this.messageDelivery = messageDelivery;
        }

        public virtual void Process(UserAccountEvent evt, string email = null)
        {
            var msg = this.messageFormatter.Format(evt);
            if (msg != null)
            {
                msg.To = email ?? evt.Account.Email;
                this.messageDelivery.Send(msg);
            }
        }
    }

    public class EmailAccountCreatedEventHandler
        : EmailEventHandler//, IEventHandler<AccountCreatedEvent>
    {
        public EmailAccountCreatedEventHandler(IMessageFormatter messageFormatter)
            : base(messageFormatter)
        {
        }

        public EmailAccountCreatedEventHandler(IMessageFormatter messageFormatter, IMessageDelivery messageDelivery)
            : base(messageFormatter, messageDelivery)
        {
        }

        //public void Handle(AccountCreatedEvent evt)
        //{
        //    Process(evt);
        //}
    }

    public class EmailAccountEventsHandler :
        EmailEventHandler//,        IEventHandler<AccountVerifiedEvent>,
    {
        public EmailAccountEventsHandler(IMessageFormatter messageFormatter)
            : base(messageFormatter)
        {
        }
        public EmailAccountEventsHandler(IMessageFormatter messageFormatter, IMessageDelivery messageDelivery)
            : base(messageFormatter, messageDelivery)
        {
        }

        //public void Handle(AccountVerifiedEvent evt)
        //{
        //    Process(evt);
        //}

    }
}

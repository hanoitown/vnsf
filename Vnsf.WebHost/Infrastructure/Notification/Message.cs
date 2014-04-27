/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */


namespace Vnsf.WebHost.Infrastructure.Notification
{
    public class Message
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

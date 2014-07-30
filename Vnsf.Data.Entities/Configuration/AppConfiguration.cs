/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;

namespace Vnsf.Data
{
    public class AppConfiguration
    {
        public AppConfiguration()
            : this(AppSettings.Instance)
        {
        }

        public AppConfiguration(AppSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("AppSettings");
            this.BaseUrl = settings.BaseUrl;
        }

        public string BaseUrl { get; private set; }

        //AggregateValidator usernameValidators = new AggregateValidator();
        //public void RegisterUsernameValidator(params IValidator[] items)
        //{
        //    usernameValidators.AddRange(items);
        //}
        //public IValidator UsernameValidator { get { return usernameValidators; } }

        //AggregateValidator passwordValidators = new AggregateValidator();
        //public void RegisterPasswordValidator(params IValidator[] items)
        //{
        //    passwordValidators.AddRange(items);
        //}
        //public IValidator PasswordValidator { get { return passwordValidators; } }

        //AggregateValidator emailValidators = new AggregateValidator();
        //public void RegisterEmailValidator(params IValidator[] items)
        //{
        //    emailValidators.AddRange(items);
        //}
        //public IValidator EmailValidator { get { return emailValidators; } }

        //EventBus eventBus = new EventBus();
        //public IEventBus EventBus { get { return eventBus; } }
        //public void AddEventHandler(params IEventHandler[] handlers)
        //{
        //    eventBus.AddRange(handlers);
        //}

        //EventBus validationBus = new EventBus();
        //public IEventBus ValidationBus { get { return validationBus; } }
        //public void AddValidationHandler(params IEventHandler[] handlers)
        //{
        //    validationBus.AddRange(handlers);
        //}

        //public ITwoFactorAuthenticationPolicy TwoFactorAuthenticationPolicy { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;
using Vnsf.Infrastructure.Validations;

namespace Vnsf.Service.Account.Validations
{
    public class DelegateValidator : IValidator
    {
        Func<UserAccountService, UserAccount, string, ValidationResult> func;
        public DelegateValidator(Func<UserAccountService, UserAccount, string, ValidationResult> func)
        {
            if (func == null) throw new ArgumentNullException("func");

            this.func = func;
        }

        public ValidationResult Validate(UserAccountService service, UserAccount account, string value)
        {
            return func(service, account, value);
        }
    }
}

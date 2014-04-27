using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Infrastructure.Tracing;
using Vnsf.Infrastructure.Validations;

namespace Vnsf.Service.Account.Validations
{
    internal class UserAccountValidation
    {
        public static readonly IValidator UsernameDoesNotContainAtSign =
            new DelegateValidator((service, account, value) =>
            {
                if (value.Contains("@"))
                {
                    Tracing.Verbose("[UserAccountValidation.UsernameDoesNotContainAtSign] validation failed: {0}, {2}", account.Username, value);

                    return new ValidationResult("Username cannot contain the '@' character.");
                }
                return null;
            });

        public static readonly IValidator UsernameMustNotAlreadyExist =
            new DelegateValidator((service, account, value) =>
            {
                if (service.UsernameExists(value))
                {
                    Tracing.Verbose("[UserAccountValidation.EmailMustNotAlreadyExist] validation failed: {0}, {2}", account.Username, value);

                    return new ValidationResult("Username already in use.");
                }
                return null;
            });

        public static readonly IValidator EmailIsValidFormat =
            new DelegateValidator((service, account, value) =>
            {
                var validator = new EmailAddressAttribute();
                if (!validator.IsValid(value))
                {
                    Tracing.Verbose("[UserAccountValidation.EmailIsValidFormat] validation failed: {0}, {1}", account.Username, value);

                    return new ValidationResult("Email is invalid.");
                }
                return null;
            });

        public static readonly IValidator EmailMustNotAlreadyExist =
            new DelegateValidator((service, account, value) =>
            {
                if (service.EmailExists(value))
                {
                    Tracing.Verbose("[UserAccountValidation.EmailMustNotAlreadyExist] validation failed: {0}, {1}, ", account.Username, value);

                    return new ValidationResult("Email already in use.");
                }
                return null;
            });

        public static readonly IValidator PasswordMustBeDifferentThanCurrent =
            new DelegateValidator((service, account, value) =>
            {
                // Use LastLogin null-check to see if it's a new account
                // we don't want to run this logic if it's a new account
                if (account.LastLogin != null && account.VerifyHashedPassword(value))
                {
                    Tracing.Verbose("[UserAccountValidation.PasswordMustBeDifferentThanCurrent] validation failed: {0}", account.Username);

                    return new ValidationResult("The new password must be different than the old password.");
                }
                return null;
            });
    }
}

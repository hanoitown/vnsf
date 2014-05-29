/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Vnsf.Data.Entities.Extensions;
using Vnsf.Infrastructure.Constant;
using Vnsf.Infrastructure.Crypto;
using Vnsf.Infrastructure.Tracing;

namespace Vnsf.Data.Entities.Account
{
    public class UserAccount
    {
        public UserAccount()
        {
            this.Claims = new HashSet<UserClaim>();
            this.LinkedAccounts = new HashSet<LinkedAccount>();
            this.Certificates = new HashSet<UserCertificate>();
            this.Applications = new HashSet<Application>(); 
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime LastUpdated { get; internal set; }
        public virtual DateTime PasswordChanged { get; internal set; }
        public virtual bool IsAccountVerified { get; internal set; }
        public virtual bool IsLoginAllowed { get; set; }
        public virtual bool IsAccountClosed { get; internal set; }
        public virtual DateTime? AccountClosed { get; internal set; }
        public virtual DateTime? LastLogin { get; internal set; }
        public virtual DateTime? LastFailedLogin { get; internal set; }
        public virtual int FailedLoginCount { get; internal set; }
        public virtual string VerificationKey { get; internal set; }
        public virtual VerificationKeyPurpose? VerificationPurpose { get; internal set; }
        public virtual DateTime? VerificationKeySent { get; internal set; }
        public string HashedPassword { get; set; }
        public virtual string MobilePhoneNumber { get; set; }
        public virtual string MobileCode { get; set; }

        public virtual ICollection<UserClaim> Claims { get; internal set; }
        public virtual ICollection<LinkedAccount> LinkedAccounts { get; internal set; }
        public virtual ICollection<UserCertificate> Certificates { get; internal set; }
        public virtual ICollection<Application> Applications { get;  set; }

        public static UserAccount Init(string username, string password, string email)
        {
            return new UserAccount
            {
                Id = Guid.NewGuid(),
                Username = username,
                Email = email,
                Created = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                HashedPassword = HashPassword(password),
                PasswordChanged = DateTime.UtcNow,
                IsAccountVerified = false,
                IsLoginAllowed = false,
                VerificationPurpose = VerificationKeyPurpose.VerifyAccount
            };
        }

        public static UserAccount Register( string email, string mobile, string password)
        {
            return new UserAccount
            {
                Id = Guid.NewGuid(),
                Username = email,
                Email = email,
                MobilePhoneNumber = mobile,
                Created = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                HashedPassword = HashPassword(password),
                PasswordChanged = DateTime.UtcNow,
                IsAccountVerified = false,
                IsLoginAllowed = false,
                VerificationPurpose = VerificationKeyPurpose.VerifyAccount
            };
        }

        public void UpdateUser(string username, string email)
        {
            Username = username;
            Email = email;
        }

        protected internal static string HashPassword(string password)
        {
            return CryptoHelper.HashPassword(password);
        }
        protected internal virtual bool VerifyHashedPassword(string password)
        {
            return CryptoHelper.VerifyHashedPassword(HashedPassword, password);
        }


        #region Claims
        public virtual bool HasClaim(string type)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");

            return this.Claims.Any(x => x.Type == type);
        }

        public virtual bool HasClaim(string type, string value)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("value");

            return this.Claims.Any(x => x.Type == type && x.Value == value);
        }


        public virtual IEnumerable<string> GetClaimValues(string type)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");

            var query =
                from claim in this.Claims
                where claim.Type == type
                select claim.Value;
            return query.ToArray();
        }

        public virtual string GetClaimValue(string type)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");

            var query =
                from claim in this.Claims
                where claim.Type == type
                select claim.Value;
            return query.SingleOrDefault();
        }

        public virtual void AddClaim(string type, string value)
        {
            if (String.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("type");
            }
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value");
            }

            if (!this.HasClaim(type, value))
            {
                var claim = new UserClaim
                {
                    Type = type,
                    Value = value
                };
                this.Claims.Add(claim);
            }
        }

        public virtual void RemoveClaim(string type)
        {
            if (String.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("type");
            }

            var claimsToRemove =
                from claim in this.Claims
                where claim.Type == type
                select claim;
            foreach (var claim in claimsToRemove.ToArray())
            {
                this.Claims.Remove(claim);
            }
        }

        public virtual void RemoveClaim(string type, string value)
        {
            if (String.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("type");
            }
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value");
            }

            var claimsToRemove =
                from claim in this.Claims
                where claim.Type == type && claim.Value == value
                select claim;
            foreach (var claim in claimsToRemove.ToArray())
            {
                this.Claims.Remove(claim);
            }
        }

        #endregion

        #region LinkedAccount
        public virtual LinkedAccount GetLinkedAccount(string provider, string id)
        {
            return this.LinkedAccounts.Where(x => x.ProviderName == provider && x.ProviderAccountID == id).SingleOrDefault();
        }

        public virtual void AddOrUpdateLinkedAccount(string provider, string id, IEnumerable<Claim> claims = null)
        {

            if (String.IsNullOrWhiteSpace(provider))
            {
                throw new ArgumentNullException("provider");
            }
            if (String.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id");
            }

            var linked = GetLinkedAccount(provider, id);
            if (linked == null)
            {
                linked = new LinkedAccount
                {
                    ProviderName = provider,
                    ProviderAccountID = id
                };
                this.LinkedAccounts.Add(linked);
            }
            UpdateLinkedAccount(linked, claims);
        }

        protected virtual void UpdateLinkedAccount(LinkedAccount account, IEnumerable<Claim> claims = null)
        {
            if (account == null)
            {
                throw new ArgumentNullException("account");
            }

            account.LastLogin = DateTime.Now;
            account.UpdateClaims(claims);
        }

        public virtual void RemoveLinkedAccount(string provider)
        {
            var linked = this.LinkedAccounts.Where(x => x.ProviderName == provider);
            foreach (var item in linked)
            {
                this.LinkedAccounts.Remove(item);
            }
        }

        public virtual void RemoveLinkedAccount(string provider, string id)
        {
            var linked = GetLinkedAccount(provider, id);
            if (linked != null)
            {
                this.LinkedAccounts.Remove(linked);
            }
        }

        #endregion

        #region Certificate
        public virtual void AddCertificate(X509Certificate2 certificate)
        {
            Tracing.Information("[UserAccount.AddCertificate] called for accountID: {0}", this.Id);

            certificate.Validate();
            RemoveCertificate(certificate);
            AddCertificate(certificate.Thumbprint, certificate.Subject);
        }
        public virtual void AddCertificate(string thumbprint, string subject)
        {
            if (String.IsNullOrWhiteSpace(thumbprint))
            {
                throw new ArgumentNullException("thumbprint");
            }
            if (String.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException("subject");
            }

            var cert = new UserCertificate { User = this, Thumbprint = thumbprint, Subject = subject };
            this.Certificates.Add(cert);
        }

        public virtual void RemoveCertificate(X509Certificate2 certificate)
        {
            if (certificate == null)
            {
                throw new ArgumentNullException("certificate");
            }
            if (certificate.Handle == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid certificate");
            }

            RemoveCertificate(certificate.Thumbprint);
        }
        public virtual void RemoveCertificate(string thumbprint)
        {

            if (String.IsNullOrWhiteSpace(thumbprint))
            {
                throw new ArgumentNullException("thumbprint");
            }

            var certs = this.Certificates.Where(x => x.Thumbprint.Equals(thumbprint, StringComparison.OrdinalIgnoreCase)).ToArray();
            foreach (var cert in certs)
            {
                this.Certificates.Remove(cert);
            }
        }

        #endregion
        public Application ApplyForGrant(Opportunity opportunity)
        {
            var application = Applications.Where(a => a.OpportunityId == opportunity.Id).FirstOrDefault();
            if (application == null)
            {
                application = new Application();
                application.Init(opportunity, this);
                Applications.Add(application);
            }

            return application;
            // Raise event
        }
    }
}

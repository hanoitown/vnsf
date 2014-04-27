using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        [StringLength(100)]
        [Required]
        public virtual string Username { get; internal set; }
        [EmailAddress]
        [StringLength(100)]
        [Required]
        public virtual string Email { get; internal set; }

        public virtual int PreferCulture { get; set; }

        public virtual ICollection<UserClaim> Claims { get; internal set; }

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
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("value");

            if (!this.HasClaim(type, value))
            {
                //Tracing.Verbose(String.Format("[UserAccount.AddClaim] {0}, {1}, {2}, {3}", Tenant, Username, type, value));

                this.Claims.Add(
                    new UserClaim
                    {
                        Type = type,
                        Value = value
                    });
            }
        }

        public virtual void RemoveClaim(string type)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");

            var claimsToRemove =
                from claim in this.Claims
                where claim.Type == type
                select claim;
            foreach (var claim in claimsToRemove.ToArray())
            {
                //Tracing.Verbose(String.Format("[UserAccount.RemoveClaim] {0}, {1}, {2}, {3}", Tenant, Username, type, claim.Value));
                this.Claims.Remove(claim);
            }
        }

        public virtual void RemoveClaim(string type, string value)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new ArgumentException("type");
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("value");

            var claimsToRemove =
                from claim in this.Claims
                where claim.Type == type && claim.Value == value
                select claim;
            foreach (var claim in claimsToRemove.ToArray())
            {
                //Tracing.Verbose(String.Format("[UserAccount.RemoveClaim] {0}, {1}, {2}, {3}", Tenant, Username, type, value));
                this.Claims.Remove(claim);
            }
        }

        static readonly string[] UglyBase64 = { "+", "/", "=" };
        static string StripUglyBase64(string s)
        {
            if (s == null) return s;
            foreach (var ugly in UglyBase64)
            {
                s = s.Replace(ugly, "");
            }
            return s;
        }

        protected internal virtual DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}

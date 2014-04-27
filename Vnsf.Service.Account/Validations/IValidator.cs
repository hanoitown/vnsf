using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;
using Vnsf.Service.Account;

namespace Vnsf.Infrastructure.Validations
{
    public interface IValidator
    {
        ValidationResult Validate(UserAccountService service, UserAccount account, string value);
    }
}

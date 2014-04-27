using System;
using System.Collections.Generic;
using System.Linq;

namespace Vnsf.Data.Entities.Globalization
{
    public class Culture
    {
        public virtual Guid Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<LocalizedCulture> Localizeds { set; get; }

        public Culture()
        {
            this.Localizeds = new List<LocalizedCulture>();
        }

        public static Culture Init(string code, string name)
        {
            return new Culture
            {
                Id = Guid.NewGuid(),
                Code = code,
            };
        }

    }


    public class LocalizedCulture
    {
        // Id of the localized
        public virtual Guid Id { get; set; }
        // Id culture to be translated
        public virtual Guid CultureId { get; set; }
        public virtual string Name { get; set; }
        public virtual Culture Culture { get; set; }
    }
}

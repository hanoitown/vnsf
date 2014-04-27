using System;
using System.Collections.Generic;

namespace Vnsf.Data.Entities.Globalization
{
    public class Language
    {
        public Guid Id { get; set; }
        public String Iso2 { get; set; }
        public String Iso3 { get; set; }

        private ICollection<Culture> _cultures;
        public virtual ICollection<Culture> Cultures
        {
            get { return this._cultures ?? (this._cultures = new List<Culture>()); }
            set
            {
                this._cultures = value;
            }
        }

        // Name of the language is translated into other language
        private ICollection<LanguageLocalized> _localizations;
        public virtual ICollection<LanguageLocalized> Localizations
        {
            get { return this._localizations ?? (this._localizations = new List<LanguageLocalized>()); }
            set
            {
                this._localizations = value;
            }
        }
    }
    public class LanguageLocalized
    {
        public Guid LanguageId { get; set; }
        public Guid CultureId { get; set; }
        public String Name { get; set; }
        public virtual Culture Culture { get; set; }
        public virtual Language Language { get; set; }
    }
}


using System;
using System.Collections.Generic;

namespace Vnsf.Data.Entities.Globalization
{
    public class Culture
    {
        public int Id { get; set; }
        public int? LanguageId { get; set; }
        public String Code { get; set; }
        public int? ParentCultureId { get; set; }
        public string Type { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public Culture()
        {
            this.Localizations = new List<CultureLocalized>();
        }

        public Culture(int cultureId, string code, int languageId, int countryId)
        {
            this.Id = cultureId;
            this.LanguageId = languageId;
            this.CountryId = countryId;
        }

        private ICollection<Culture> _childCultures;
        public virtual ICollection<Culture> ChildCultures
        {
            get { return this._childCultures ?? (this._childCultures = new List<Culture>()); }
            set
            {
                this._childCultures = value;
            }
        }

        public virtual Culture ParentCulture { get; set; }

        public virtual Language Language { get; set; }

        private ICollection<CultureLocalized> _localizations;
        public virtual ICollection<CultureLocalized> Localizations
        {
            get { return this._localizations ?? (this._localizations = new List<CultureLocalized>()); }
            set
            {
                this._localizations = value;
            }
        }

        private ICollection<CountryLocalized> _countryLocalizeds;
        public virtual ICollection<CountryLocalized> CountryLocalizeds
        {
            get { return this._countryLocalizeds ?? (this._countryLocalizeds = new List<CountryLocalized>()); }
            set
            {
                this._countryLocalizeds = value;
            }
        }

        private ICollection<CultureLocalized> _localizedCultures;
        public virtual ICollection<CultureLocalized> LocalizedCultures
        {
            get { return this._localizedCultures ?? (this._localizedCultures = new List<CultureLocalized>()); }
            set
            {
                this._localizedCultures = value;
            }
        }

        private ICollection<LanguageLocalized> _languageLocalizeds;
        public virtual ICollection<LanguageLocalized> LanguageLocalizeds
        {
            get { return this._languageLocalizeds ?? (this._languageLocalizeds = new List<LanguageLocalized>()); }
            set
            {
                this._languageLocalizeds = value;
            }
        }

    }
    public class CultureLocalized
    {
        // Id of culture be localized
        public Int32 Id { get; set; }
        // Id of the target culture
        public Int32 CultureId { get; set; }
        public string Name { get; set; }
        public virtual Culture LocalizedCulture { get; set; }
        public virtual Culture Culture { get; set; }
    }
}

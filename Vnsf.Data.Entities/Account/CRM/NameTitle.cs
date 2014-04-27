using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.CRM
{
    public class NameTitle
    {
        public int Id { get; set; }
        public TitleType TitleType { get; set; }
        public string Degree { get; set; }
        public string Award { get; set; }
        
    }

    public class NameTitleLocalized
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public NameTitle NameTitle { get; set; }
        public Culture Culture { get; set; }
    }

    public enum TitleType
    {
        SirMadam =1,
        Science =2,
        Admin =3,
        Award=4
    }
}
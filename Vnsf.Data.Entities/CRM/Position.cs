using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.CRM
{
    public class Position
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public Culture Culture { get; set; }
    }
}
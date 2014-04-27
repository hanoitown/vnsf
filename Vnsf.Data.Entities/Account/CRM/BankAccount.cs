namespace Vnsf.Data.Entities.CRM
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Organization Issuer { get; set; }
    }
}
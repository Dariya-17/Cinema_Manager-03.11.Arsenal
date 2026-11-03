namespace Data_Cinema_Manager.Entities
{
    
    public class ScreeningCustomer
    {
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

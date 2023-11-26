namespace Lead_Management_System.Models
{
    public class LeadsEntity
    {
        public int Id { get; set; }
        public DateTime LeadDate { get; set; }
        public string LeadName { get; set;}
        public string EmailAddress { get; set;}
        public string Mobile { get; set;}

        public string LeadSource { get; set;}
        public string LeadStatus { get; set;}

        public DateTime NextFollowUpdate { get; set; }

    }
}

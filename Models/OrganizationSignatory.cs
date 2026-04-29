 namespace OnlineClearance.Models;
 
 public class OrganizationSignatory
    {
        public int    Id         { get; set; }
        public string OrgRole    { get; set; } = "";  // e.g. Organization Treasurer
        public string PersonName { get; set; } = "";  // e.g. Ms. Mila Marie Villamor
        public string Status     { get; set; } = "";  // "Approved" or "Pending"
    }
namespace OnlineClearance.Models
{
    public class StudentClearancePdfViewModel
    {
        public string StudentName  { get; set; } = "";  // e.g. Althea Jean Barnes
        public string StudentId    { get; set; } = "";  // e.g. 1239477509
        public string CourseYear   { get; set; } = "";  // e.g. BSIT – 2nd Year

        public List<PdfSubjectItem>      SubjectClearances      { get; set; } = new();
        public List<PdfOrganizationItem> OrganizationClearances { get; set; } = new();
    }

    public class PdfSubjectItem
    {
        public string Code   { get; set; } = "";  // e.g. GT-53
        public string Subj   { get; set; } = "";  // e.g. GEC – TCW
        public string Inst   { get; set; } = "";  // e.g. Ms. Dina Piedad
        public string Status { get; set; } = "";  // Approved / Pending
    }

    public class PdfOrganizationItem
    {
        public int    Num    { get; set; }
        public string Role   { get; set; } = "";  // e.g. Organization Treasurer
        public string Person { get; set; } = "";  // e.g. Ms. Mila Marie Villamor
        public string Status { get; set; } = "";  // Approved / Pending
    }
}
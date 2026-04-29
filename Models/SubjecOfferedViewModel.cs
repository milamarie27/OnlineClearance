namespace OnlineClearance.Models
{
    public class SubjectOfferedViewModel
    {
        public List<SubjectItem> AvailableSubjects { get; set; } = new();
    }

    public class SubjectItem
    {
        public string Id           { get; set; } = "";   // used in checkbox value
        public string MisCode      { get; set; } = "";   // e.g. GT-53
        public string SubjectCode  { get; set; } = "";   // e.g. GEC – TCW
        public string Description  { get; set; } = "";   // e.g. The Contemporary World
        public string InstructorName { get; set; } = ""; // e.g. Ms. Dina Piedad
    }
}
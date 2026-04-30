using System.ComponentModel.DataAnnotations;

namespace OnlineClearance.Models
{
    // ─── Subject Offerings ───────────────────────────────────────────────────
    public class SubjectOffering
    {
        public int Id { get; set; }

        [Display(Name = "MIS Code")]
        public string MisCode { get; set; } = string.Empty;

        [Display(Name = "Subject Code")]
        public string SubjectCode { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Display(Name = "Lab Unit")]
        public int LabUnit { get; set; }

        [Display(Name = "Lec Unit")]
        public int LecUnit { get; set; }

        public string AcademicYear { get; set; } = "2025-2026";
        public string Semester { get; set; } = "2nd";
    }

    // ─── Clearance Request (Subject Clearance) ───────────────────────────────
    public class ClearanceRequest
    {
        public int Id { get; set; }

        [Display(Name = "MIS Code")]
        public string MisCode { get; set; } = string.Empty;

        [Display(Name = "Subject Code")]
        public string SubjectCode { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Display(Name = "Student Name")]
        public string StudentName { get; set; } = string.Empty;

        [Display(Name = "Course")]
        public string StudentCourse { get; set; } = string.Empty;

        /// <summary>Pending | Approved | Declined</summary>
        public string Status { get; set; } = "Pending";

        public int InstructorId { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.Now;
        public DateTime? ActionAt { get; set; }
    }

    // ─── Organization Request ────────────────────────────────────────────────  ✅ NEW
    public class OrganizationRequest
    {
        public int    Id          { get; set; }
        public string Position    { get; set; } = "";  // e.g. Campus Director
        public string StudentName { get; set; } = "";  // e.g. Althea Jean Barnes
        public string Course      { get; set; } = "";  // e.g. BSIT-2A
        public string Status      { get; set; } = "";  // Cleared / Declined / None
    }

    // ─── Signed Clearance ────────────────────────────────────────────────────
    public class SignedClearance
    {
        public int Id { get; set; }

        [Display(Name = "MIS Code")]
        public string MisCode { get; set; } = string.Empty;

        [Display(Name = "Subject Code")]
        public string SubjectCode { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Display(Name = "Student Name")]
        public string StudentName { get; set; } = string.Empty;

        [Display(Name = "Course")]
        public string StudentCourse { get; set; } = string.Empty;

        /// <summary>Approved | Declined</summary>
        public string Status { get; set; } = "Approved";

        public string AcademicYear { get; set; } = "2025-2026";
        public string Semester { get; set; } = "2nd";
        public DateTime SignedAt { get; set; } = DateTime.Now;
    }

    // ─── Announcement ────────────────────────────────────────────────────────
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string SenderName { get; set; } = "System Administrator";

        /// <summary>Comma-separated: pinned, urgent, event</summary>
        public string Tags { get; set; } = string.Empty;

        public DateTime PostedAt { get; set; } = DateTime.Now;
    }

    // ─── Dashboard ViewModel ─────────────────────────────────────────────────
    public class DashboardViewModel
    {
        public int TotalSubjectOfferings { get; set; }
        public int TotalStudents { get; set; }
        public int ApprovedStudents { get; set; }
        public int PendingStudents { get; set; }
        public int ChecklistCompleted { get; set; } = 4;
        public int ChecklistTotal { get; set; } = 4;
        public string InstructorName { get; set; } = "Ian Comision";
        public List<Announcement> Announcements { get; set; } = new();
        public int TotalAssignedSubjects { get; internal set; }
    }

    // ─── Profile ViewModel ───────────────────────────────────────────────────
    public class InstructorProfileViewModel
    {
        public string FullName      { get; set; } = "";
        public string EmployeeId    { get; set; } = "";
        public string FirstName     { get; set; } = "";
        public string MiddleInitial { get; set; } = "";
        public string LastName      { get; set; } = "";
        public string OrgPosition   { get; set; } = "";
        public string ClassAdviser  { get; set; } = "";
        public string Password      { get; set; } = "";
        public List<string> Positions { get; set; } = new();
    }
}
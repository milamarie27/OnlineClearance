using System.Collections.Generic;

namespace OnlineClearance.Models
{
    // ───────── DASHBOARD ─────────
    public class StaffDashboardViewModel
    {
        public string StaffName { get; set; } = "";
        public int TotalRequests { get; set; }
        public int TotalStudents { get; set; }
        public int Approved { get; set; }
        public int Pending { get; set; }
    }

    // ───────── SIGNATORIES LIST ─────────
    public class SignatoryViewModel
    {
        public string StudentName { get; set; } = "";
        public string StudentId { get; set; } = "";
        public string Course { get; set; } = "";
        public string Status { get; set; } = "";
    }

    // ───────── STAFF PROFILE ─────────
    public class StaffProfileViewModel
    {
        // Display
        public string FullName { get; set; } = "";

        // Identity
        public string StaffId { get; set; } = "";

        // Editable fields
        public string FirstName { get; set; } = "";
        public string MiddleInitial { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Department { get; set; } = "";
        public string Password { get; set; } = "";

        // Role / Signatory position (e.g. Librarian, Registrar)
        public List<string> Positions { get; set; } = new List<string>();

        // Optional: signature storage (future-ready)
        public string? SignatureBase64 { get; set; }

        // Optional: avatar image
        public string? AvatarBase64 { get; set; }
    }
}
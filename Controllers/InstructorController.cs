using Microsoft.AspNetCore.Mvc;
using OnlineClearance.Models;

namespace OnlineClearance.Controllers
{
    public class InstructorController : Controller
    {
        // ✅ Add this — used by all actions
        private void SetLayoutData(string activePage)
        {
            ViewData["InstructorName"] = "Dr. Glicerio A. Baguia";  // 🔁 replace with session later
            ViewData["InstructorId"]   = "7240424";                  // 🔁 replace with session later
            ViewData["InstructorDept"] = "Instructor";
            ViewData["ActivePage"]     = activePage;
        }

        // ==========================================================
        // DASHBOARD
        // ==========================================================
        public IActionResult Dashboard()
        {
            SetLayoutData("Dashboard");  // ✅ added

            var vm = new DashboardViewModel
            {
                TotalSubjectOfferings = 3,
                TotalStudents         = 50,
                ApprovedStudents      = 26,
                PendingStudents       = 24,
                InstructorName        = "Ian Comision",

                Announcements = new List<Announcement>
                {
                    new Announcement
                    {
                        Id       = 1,
                        Title    = "Deadline for clearance submission — AY 2025-2026",
                        Body     = "All students are required to complete their clearance requirements on or before April 30, 2026.",
                        Tags     = "pinned,urgent",
                        PostedAt = new DateTime(2026, 4, 15)
                    },
                    new Announcement
                    {
                        Id       = 2,
                        Title    = "Enrollment for AY 2026-2027 opens May 5",
                        Body     = "The new academic year will begin on May 5, 2026.",
                        Tags     = "event",
                        PostedAt = new DateTime(2026, 4, 15)
                    }
                }
            };

            return View(vm);
        }

        // ==========================================================
        // SUBJECT OFFERINGS
        // ==========================================================
        public IActionResult SubjectOfferings()
        {
            SetLayoutData("SubjectOfferings");  // ✅ added

            var offerings = new List<SubjectOffering>
            {
                new SubjectOffering { Id=1, MisCode="GT-58", SubjectCode="P Elec 3",  Description="Platform Technology",                        LabUnit=3, LecUnit=2 },
                new SubjectOffering { Id=2, MisCode="GT-54", SubjectCode="AP 3",      Description="Integrative Programming and Technologies 1", LabUnit=3, LecUnit=2 },
                new SubjectOffering { Id=3, MisCode="GT-55", SubjectCode="PC 223",    Description="ASP .NET",                                   LabUnit=3, LecUnit=2 },
                new SubjectOffering { Id=4, MisCode="GT-54", SubjectCode="PC 223",    Description="Integrative Programming and Technologies 1", LabUnit=3, LecUnit=2 },
                new SubjectOffering { Id=5, MisCode="GT-54", SubjectCode="P Elec 3",  Description="Integrative Programming and Technologies 1", LabUnit=3, LecUnit=2 },
                new SubjectOffering { Id=6, MisCode="GT-58", SubjectCode="AP 3",      Description="Platform Technology",                        LabUnit=3, LecUnit=2 },
                new SubjectOffering { Id=7, MisCode="GT-59", SubjectCode="AP 3",      Description="ASP .NET",                                   LabUnit=3, LecUnit=2 }
            };

            return View(offerings);
        }

        // ==========================================================
        // SUBJECT CLEARANCE
        // ==========================================================
        public IActionResult SubjectClearance()
        {
            SetLayoutData("SubjectClearance");  // ✅ added

            var requests = new List<ClearanceRequest>
            {
                new ClearanceRequest { Id=1, MisCode="GT-58", SubjectCode="P Elec 3", Description="Platform Technology",                        StudentName="Althea Jean Barnes",  StudentCourse="BSIT-2A" },
                new ClearanceRequest { Id=2, MisCode="GT-54", SubjectCode="PC 223",   Description="Integrative Programming and Technologies 1", StudentName="Mila Marie Villamor", StudentCourse="BSIT-2A" },
                new ClearanceRequest { Id=3, MisCode="GT-55", SubjectCode="AP 3",     Description="ASP .NET",                                   StudentName="Melanie Dinglasa",    StudentCourse="BSIT-2A" },
                new ClearanceRequest { Id=4, MisCode="GT-54", SubjectCode="PC 223",   Description="Integrative Programming and Technologies 1", StudentName="Stephany Camoro",     StudentCourse="BSIT-2A" },
                new ClearanceRequest { Id=5, MisCode="GT-54", SubjectCode="P Elec 3", Description="Integrative Programming and Technologies 1", StudentName="Janice Angel Chua",   StudentCourse="BSIT-2A" },
                new ClearanceRequest { Id=6, MisCode="GT-58", SubjectCode="AP 3",     Description="Platform Technology",                        StudentName="Gabriel Tolomea",     StudentCourse="BSIT-2A" },
                new ClearanceRequest { Id=7, MisCode="GT-59", SubjectCode="AP 3",     Description="ASP .NET",                                   StudentName="Alex Belongilot",     StudentCourse="BSIT-2A" },
                new ClearanceRequest { Id=8, MisCode="GT-60", SubjectCode="AP 3",     Description="ASP .NET",                                   StudentName="Sheena Melgar",       StudentCourse="BSIT-2A" }
            };

            return View(requests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Approve(int id)
        {
            TempData["SuccessMessage"] = $"Clearance #{id} has been approved.";
            return RedirectToAction(nameof(SubjectClearance));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Decline(int id)
        {
            TempData["SuccessMessage"] = $"Clearance #{id} has been declined.";
            return RedirectToAction(nameof(SubjectClearance));
        }

        // ==========================================================
        // SIGNED CLEARANCE
        // ==========================================================
        public IActionResult SignedClearance(string filter = "all")
        {
            SetLayoutData("SignedClearance");  // ✅ added
            ViewData["Filter"] = filter;

            var all = new List<SignedClearance>
            {
                new SignedClearance { Id=1, MisCode="GT-58", SubjectCode="P Elec 3", Description="Platform Technology",                        StudentName="Althea Jean Barnes",  StudentCourse="BSIT-2A", Status="Approved" },
                new SignedClearance { Id=2, MisCode="GT-54", SubjectCode="AP 3",     Description="Integrative Programming and Technologies 1", StudentName="Mila Marie Villamor", StudentCourse="BSIT-2A", Status="Approved" },
                new SignedClearance { Id=3, MisCode="GT-55", SubjectCode="PC 223",   Description="ASP .NET",                                   StudentName="Melanie Dinglasa",    StudentCourse="BSIT-2A", Status="Approved" },
                new SignedClearance { Id=4, MisCode="GT-54", SubjectCode="PC 223",   Description="Integrative Programming and Technologies 1", StudentName="Stephany Camoro",     StudentCourse="BSIT-2A", Status="Declined" },
                new SignedClearance { Id=5, MisCode="GT-54", SubjectCode="P Elec 3", Description="Integrative Programming and Technologies 1", StudentName="Janice Angel Chua",   StudentCourse="BSIT-2A", Status="Approved" },
                new SignedClearance { Id=6, MisCode="GT-58", SubjectCode="AP 3",     Description="Platform Technology",                        StudentName="Gabriel Tolomea",     StudentCourse="BSIT-2A", Status="Approved" },
                new SignedClearance { Id=7, MisCode="GT-59", SubjectCode="AP 3",     Description="ASP .NET",                                   StudentName="Alex Belongilot",     StudentCourse="BSIT-2A", Status="Declined" },
                new SignedClearance { Id=8, MisCode="GT-60", SubjectCode="PC 223",   Description="ASP .NET",                                   StudentName="Sheena Melgar",       StudentCourse="BSIT-2A", Status="Approved" }
            };

            var filtered = filter.ToLower() switch
            {
                "approved" => all.Where(x => x.Status == "Approved").ToList(),
                "rejected" => all.Where(x => x.Status == "Declined").ToList(),
                _          => all
            };

            return View(filtered);
        }

        // ==========================================================
        // ORGANIZATION
        // ==========================================================
        public IActionResult Organization()
        {
           SetLayoutData("Organization");
           var model = new List<OrganizationRequest>(); // empty = shows sample data
           return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ApproveOrg(int id)
        {
        TempData["SuccessMessage"] = $"Organization request #{id} has been approved.";
        return RedirectToAction(nameof(Organization));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeclineOrg(int id)
        {
            TempData["SuccessMessage"] = $"Organization request #{id} has been declined.";
            return RedirectToAction(nameof(Organization));
        }

        // ==========================================================
        // PROFILE
        // ==========================================================
        public IActionResult Profile()
        {
            SetLayoutData("Profile");

            var model = new InstructorProfileViewModel
            {
                FullName      = "Dr. Glicerio A. Baguia",
                EmployeeId    = "7240424",
                FirstName     = "Glicerio",
                MiddleInitial = "A",
                LastName      = "Baguia",
                OrgPosition   = "Campus Director",
                ClassAdviser  = "BSIT - 2A",
                Password      = "",
                Positions     = new List<string> { "Campus Director", "BSIT – 2A Class Adviser" }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveInstructorProfile(InstructorProfileViewModel model)
        {
            SetLayoutData("Profile");
            if (!ModelState.IsValid) return View(model);  // ✅ removed "Profile" string

            TempData["ProfileSaved"] = "Profile saved successfully!";
            return RedirectToAction("Profile");
        }
    }
}
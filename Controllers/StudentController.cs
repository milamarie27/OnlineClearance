using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineClearance.Models;

namespace CTUGClearance.Controllers
{
    public class StudentController : Controller
    {
        // ─────────────────────────────────────────
        // SHARED: sets sidebar/layout data once
        // ─────────────────────────────────────────
        private void SetLayoutData(string activePage)
        {
            ViewData["UserName"]   = "Mila Marie";    // 🔁 replace with session/auth later
            ViewData["UserId"]     = "2023-00001";    // 🔁 replace with session/auth later
            ViewData["UserCourse"] = "BSIT";
            ViewData["UserYear"]   = "2nd Year";
            ViewData["ActivePage"] = activePage;
            ViewData["ShowOrg"]    = false;
        }

        // ─────────────────────────────────────────
        // DASHBOARD
        // ─────────────────────────────────────────
        [AllowAnonymous]
        public IActionResult Dashboard()
        {
            SetLayoutData("Dashboard");

            var model = new StudentDashboardViewModel
            {
                StudentName = ViewData["UserName"]?.ToString() ?? "Student"
            };
            return View(model);
        }

        // ─────────────────────────────────────────
        // SUBJECTS OFFERED
        // ─────────────────────────────────────────
        public IActionResult SubjectsOffered()
        {
            SetLayoutData("SubjectsOffered");

            var model = new SubjectOfferedViewModel
            {
                // Leave empty → view falls back to sample data
                // Replace with DB query later:
                // AvailableSubjects = _db.Subjects.Select(s => new SubjectItem { ... }).ToList()
                AvailableSubjects = new List<SubjectItem>()
            };

            return View(model);
        }

        // ─────────────────────────────────────────
        // SUBJECTS OFFERED — CONFIRM (POST)
        // ─────────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmSubjects(string selectedSubjects)
        {
            if (string.IsNullOrWhiteSpace(selectedSubjects))
                return RedirectToAction("SubjectsOffered");

            var codes = selectedSubjects
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.Trim())
                .ToList();

            // TODO: Save selected subjects to DB
            // Example:
            // foreach (var code in codes)
            //     _db.StudentSubjects.Add(new StudentSubject { MisCode = code, StudentId = currentUserId });
            // _db.SaveChanges();

            TempData["ConfirmedSubjects"] = string.Join(",", codes);
            return RedirectToAction("Clearance");
        }

        // ─────────────────────────────────────────
        // CLEARANCE
        // ─────────────────────────────────────────
        public IActionResult Clearance()
        {
            SetLayoutData("Clearance");

            // Replace with real DB data later:
            // var items = _db.StudentClearanceItems
            //     .Where(x => x.StudentId == currentUserId)
            //     .Select(x => new StudentClearanceItem { ... })
            //     .ToList();

            var items = new List<StudentClearanceItem>();
            return View(items);
        }

        // ─────────────────────────────────────────
        // PROFILE
        // ─────────────────────────────────────────
       public IActionResult Profile()
{
    SetLayoutData("Profile");

    var model = new StudentProfileViewModel
    {
        StudentId     = "7240427",
        FullName      = "Mila Marie F. Villamor",
        FirstName     = "Mila Marie",
        MiddleInitial = "F",
        LastName      = "Villamor",
        Suffix        = "",
        Course        = "BSIT",
        YearLevel     = "2nd Year",
        Section       = "2A",
        Username      = "emyat_27",
        Password      = ""
    };

    return View(model);
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult SaveProfile(StudentProfileViewModel model)
{
    SetLayoutData("Profile");

    if (!ModelState.IsValid)
        return View(model);  // ← FIXED: removed "Profile" string

    TempData["ProfileSaved"] = "Profile saved successfully!";
    return RedirectToAction("Profile");
}
        
        // ─────────────────────────────────────────
        // DOWNLOAD PDF
        // ─────────────────────────────────────────
        public IActionResult DownloadPdf()
{
    SetLayoutData("DownloadPdf");

    var model = new StudentClearancePdfViewModel
    {
        StudentName = "Mila Marie",
        StudentId   = "2023-00001",
        CourseYear  = "BSIT – 2nd Year",

        // Replace with real DB data later
        SubjectClearances = new List<PdfSubjectItem>(),
        OrganizationClearances = new List<PdfOrganizationItem>()
        // Empty → view uses hardcoded sample data
    };

    return View(model);
}
        // ─────────────────────────────────────────
        // ORGANIZATION (conditional in sidebar)
        // ─────────────────────────────────────────
        public IActionResult Organization()
        {
            SetLayoutData("Organization");
            ViewData["ShowOrg"] = true;  // show org link in sidebar

            var model = new List<OrganizationSignatory>();
    // Leave empty → view shows sample data
    // Replace with DB query later:
    // model = _db.OrganizationSignatories
    //     .Where(x => x.StudentId == currentUserId)
    //     .Select(x => new OrganizationSignatory { ... })
    //     .ToList();
    
            return View(model);
        }

        
    }
}
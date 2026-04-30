using Microsoft.AspNetCore.Mvc;
using OnlineClearance.Models;

namespace OnlineClearance.Controllers
{
    public class StaffController : Controller
    {
        // ───────── PRIVATE HELPER
        private void SetLayout(string activePage = "Dashboard", string staffName = "Dr. Glicerio A. Baguia", string staffId = "7240424")
        {
            ViewData["ActivePage"] = activePage;
            ViewData["StaffName"]  = staffName;
            ViewData["StaffId"]    = staffId;
        }

        public IActionResult Dashboard()
        {
            var vm = new StaffDashboardViewModel
            {
                StaffName = "Staff Juan",
                TotalRequests = 50,
                TotalStudents = 120,
                Approved = 80,
                Pending = 40
            };

            SetLayout("Dashboard", vm.StaffName);
            return View(vm);
        }

        public IActionResult Signatories()
        {
            SetLayout("Signatories");

            var requests = new List<SignatoryViewModel>
            {
                new SignatoryViewModel { StudentName = "Juan Dela Cruz", StudentId = "2023-001", Course = "IT101", Status = "Pending" },
                new SignatoryViewModel { StudentName = "Maria Santos", StudentId = "2023-002", Course = "CS202", Status = "Approved" }
            };

            return View(requests);
        }

        [HttpPost]
        public IActionResult Approve(string studentId)
        {
            return RedirectToAction("Signatories");
        }

        [HttpPost]
        public IActionResult Decline(string studentId)
        {
            return RedirectToAction("Signatories");
        }

        public IActionResult Profile()
        {
            SetLayout("Profile");

            var model = new StaffProfileViewModel
            {
                FullName = "Dr. Glicerio A. Baguia",
                StaffId = "7240424",
                FirstName = "Glicerio",
                MiddleInitial = "A",
                LastName = "Baguia",
                Department = "Librarian",
                Password = "",
                Positions = new List<string> { "Librarian" }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveStaffProfile(StaffProfileViewModel model)
        {
            SetLayout("Profile");

            if (!ModelState.IsValid)
                return View("Profile", model);

            TempData["ProfileSaved"] = "Profile saved successfully!";
            return RedirectToAction("Profile");
        }
    }
}
using MasterDetailsInCoreDataFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasterDetailsInCoreDataFirst.Controllers
{
    public class MasterController : Controller
    {
        public readonly MasterDetailsInCoreDbfirstContext myDbContext;
        public readonly IWebHostEnvironment webHost;

        public MasterController(MasterDetailsInCoreDbfirstContext myDbContext, IWebHostEnvironment webHost)
        {
            this.myDbContext = myDbContext;
            this.webHost = webHost;
        }

        public IActionResult Index()
        {
            List<Applicant> applicants;
            applicants = myDbContext.Applicants.ToList();
            return View(applicants);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.Experiences.Add(new Experience() { ExperienceId = 1 });
            return View(applicant);


        }

        [HttpPost]

        public IActionResult Create(Applicant applicant)
        {
            applicant.Experiences.RemoveAll(n => n.YearsWorked == 0);
            string uniqueFileName = GetUploadedFileName(applicant);
            applicant.PhotoUrl = uniqueFileName;
            myDbContext.Add(applicant);
            myDbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        private string GetUploadedFileName(Applicant applicant)
        {
            string uniqueFileName = null;
            if (applicant.ProfilePhoto != null)
            {
                string uploadFolder = Path.Combine(webHost.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + applicant.ProfilePhoto.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    applicant.ProfilePhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(myDbContext.Applicants.Find(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                myDbContext.Update(applicant);
                await myDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        public IActionResult Details(int id)
        {
            Applicant applicant = myDbContext.Applicants
                .Include(a => a.Experiences)
                .Where(e => e.ApplicantId == id).FirstOrDefault();
            return View(applicant);

        }
        public IActionResult Delete(int id)
        {
            Applicant applicant = myDbContext.Applicants
                .Include(a => a.Experiences)
                .Where(e => e.ApplicantId == id).FirstOrDefault();
            return View(applicant);
        }

        [HttpPost]
        public IActionResult Delete(Applicant applicant)
        {
            myDbContext.Attach(applicant);
            myDbContext.Entry(applicant).State = EntityState.Deleted;
            myDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }
}


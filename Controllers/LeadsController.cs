using Lead_Management_System.Data;
using Lead_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lead_Management_System.Controllers
{
    public class LeadsController : Controller
    {
        public IActionResult Index()
        {
            List<LeadsEntity> allleads = new List<LeadsEntity>();

            LeadRepository leadRepository = new LeadRepository();

            allleads = leadRepository.GetallLeads();

            return View(allleads);
        }

        [HttpGet]
        public IActionResult AddLead()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLead(LeadsEntity newlead)
        {
            LeadRepository newLeadRepository = new LeadRepository();
            newLeadRepository.AddLead(newlead);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateLead(int Id) 
        {
         LeadsEntity lead= new LeadsEntity();
            LeadRepository leadRepository= new LeadRepository();
            lead=leadRepository.GetaSingleLeadbyId(Id);

            return View(lead);
        }

        [HttpPost]
        public IActionResult UpdateLead(int Id, LeadsEntity Updatedlead)
        {
          LeadRepository leadRepository= new LeadRepository();
            leadRepository.UpdateLead(Id, Updatedlead);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteLead(int Id)
        {
            LeadsEntity singlelead= new LeadsEntity();
            LeadRepository leadRepository= new LeadRepository();
            singlelead=leadRepository.GetaSingleLeadbyId(Id);
            return View(singlelead);
        }


        [HttpPost]
        public IActionResult DeleteLead(int Id,LeadsEntity leadtobedeleted)
        {
        
            LeadRepository leadRepository= new LeadRepository();
            leadRepository.DeleteLead(leadtobedeleted.Id);

            return RedirectToAction("Index");
        }
    }
}

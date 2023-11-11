using Microsoft.AspNetCore.Mvc;
using testi.DBContext;
using System.Linq;
using testi.Models;

namespace testi.Controllers
{
    public class AdminController : Controller
    {
        private readonly CandidatContext _context;

        public AdminController(CandidatContext context)
        {
            _context = context;
        }

        public IActionResult Index(CandidatSearchModel searchModel)
        {
            var candidatures = _context.Candidat.ToList();

            if (!string.IsNullOrWhiteSpace(searchModel.Nom))
            {
                candidatures = candidatures.Where(c => c.Nom.Contains(searchModel.Nom)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Prenom))
            {
                candidatures = candidatures.Where(c => c.Prenom.Contains(searchModel.Prenom)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
            {
                candidatures = candidatures.Where(c => c.Email.Contains(searchModel.Email)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Telephone))
            {
                candidatures = candidatures.Where(c => c.Telephone.Contains(searchModel.Telephone)).ToList();
            }

            return View(candidatures);
        }

        public IActionResult AfficherCV(int id)
        {
            var candidat = _context.Candidat.FirstOrDefault(c => c.Id == id);
            return View(candidat);
        }

        public IActionResult SupprimerCandidature(int id)
        {
            var candidat = _context.Candidat.FirstOrDefault(c => c.Id == id);

            if (candidat != null)
            {
                _context.Candidat.Remove(candidat);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}

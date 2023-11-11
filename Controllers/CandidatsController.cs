using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using testi.DBContext;
using testi.Models;

namespace testi.Controllers
{
    public class CandidatsController : Controller
    {
        private readonly CandidatContext _context;
        private readonly IWebHostEnvironment _environment;

        public CandidatsController(CandidatContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCandidatViewModel candidatViewModel)
        {
            if (ModelState.IsValid)
            {
                 var candidat = new Candidat
                {
                    Nom = candidatViewModel.Nom,
                    Prenom = candidatViewModel.Prenom,
                    Email = candidatViewModel.Email,
                    Telephone = candidatViewModel.Telephone,
                    NiveauEtude = candidatViewModel.NiveauEtude,
                    AnneesExperience = candidatViewModel.AnneesExperience,
                    DernierEmployeur = candidatViewModel.DernierEmployeur,
                };

                 if (candidatViewModel.Cv != null)
                {
                    string cvFileName = $"{candidat.Nom}_{candidat.Prenom}_CV{Path.GetExtension(candidatViewModel.Cv.FileName)}";
                    string cvPath = Path.Combine(_environment.WebRootPath, "CvUploads", cvFileName);

                    using (var stream = new FileStream(cvPath, FileMode.Create))
                    {
                        candidatViewModel.Cv.CopyTo(stream);
                    }

                    candidat.CvPath = $"~/CvUploads/{cvFileName}";
                }

                 _context.Candidat.Add(candidat);
                _context.SaveChanges();

                 string smtpUsername = "alaoui@gmail.com";
                string smtpPassword = "4567GHV@ghuh";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;

                using (var messageEmail = new MailMessage())
                {
                    messageEmail.From = new MailAddress(smtpUsername); // Adresse e-mail de l'expéditeur
                    messageEmail.Subject = "Condidature"; // Sujet de l'e-mail
                    messageEmail.Body = "envoyer un e-mail au candidat (Bonjour, vous avez postulé avec succès pour l'offre xxxx)"; // Corps de l'e-mail
                    messageEmail.IsBodyHtml = true;
                    messageEmail.To.Add(new MailAddress(candidatViewModel.Email)); // Adresse e-mail du candidat

                    using (var clientSmtp = new SmtpClient(smtpHost))
                    {
                        clientSmtp.Port = smtpPort;
                        clientSmtp.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                        clientSmtp.EnableSsl = true;

                        try
                        {
                            clientSmtp.Send(messageEmail);
                        }
                        catch (Exception ex)
                        {
                          
                        }
                    }
                }

                // Rediriger vers une page de confirmation
                return RedirectToAction("Confirmation");
            }

            return View(candidatViewModel);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}

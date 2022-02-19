using Colore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Colore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contato(Contato sendEmailDto)
        {
            var cookieOptions = new CookieOptions
            {

                Secure = true,


                SameSite = SameSiteMode.None
            };

            Response.Cookies.Append("MyCookie", "cookieValue", cookieOptions);

            if (ModelState.IsValid) return View();

            try
            {

                MailMessage mail = new();

                mail.From = new MailAddress("coloreprojeto1@gmail.com");
                mail.To.Add("coloreprojeto1@gmail.com");
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.Subject = sendEmailDto.Assunto;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;

                string Content = "<br>Nome: " + sendEmailDto.Nome;
                Content += "<br>Email: " + sendEmailDto.Email;
                Content += "" + sendEmailDto.Telefone;
                Content += "<br>Mensagem: " + sendEmailDto.Mensagem;

                mail.Body = Content;


                SmtpClient smtpClient = new("smtp.gmail.com");
                {

                    NetworkCredential networkCredential = new NetworkCredential("coloreprojeto1@gmail.com", "Colore123");
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = networkCredential;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.Timeout = 20000;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    smtpClient.Send(mail);

                    ViewBag.Message = "Mensagem enviada com sucesso";
                    ModelState.Clear();


                }

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message.ToString();

            }

            return View();
        }

    }
}
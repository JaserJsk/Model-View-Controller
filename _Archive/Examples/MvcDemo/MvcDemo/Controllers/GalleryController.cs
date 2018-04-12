using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Data.Models;
using MvcDemo.Data.Repositories;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class GalleryController : Controller
    {
        public PhotoRepository PhotoRepository { get; set; }

        // Konstruktorn körs varje gång vi kallar på /Gallery
        // Det betyder att vi skapar upp en instans av PhotoRepository varje gång
        // Tittar vi på PhotoRepository dock, så har den en statisk lista just nu
        // Senare kommer vi titta på att byta ut detta mot EntityFramework
        public GalleryController()
        {
            PhotoRepository = new PhotoRepository();
        }

        /// <summary>
        /// Index kommer att returnera en vy, denna vyn heter Index.cshtml
        /// När vi kör View() kommer den hitta Index.cshtml i Views\Gallery
        /// Den kommer att kompilera filen "on the fly" och returnera HTML 
        /// till webbläsaren.
        /// </summary>
        /// <returns>
        /// Vi returnerar ett ViewResult, som ärver av ActionResult
        /// ASP.NET vet då att den ska konvertera detta till HTML
        /// och läsa igenom vår Razor-fil för att sedan skicka tillbaka HTML
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Vi vill hantera en fil-uppladdning
        /// Detta gör vi endast via en POST som vi definerar genom att använda
        /// oss av attributet HttpPost.
        /// 
        /// Vi förväntar oss att man skickar in en HttpPostedFileBase samt ett namn
        /// </summary>
        /// <param name="file">
        /// För att file ska sättas krävs det att vi 
        /// har ett <input type="file" name="file"></input> i vår HTML som POSTar hit
        /// 
        /// Tänk på att det är HTML-attributet name som mappar till in-parametern i en Action
        /// </param>
        /// <param name="model">
        /// När vi laddar upp en ny bild vill vi sätta ett fint namn, det skickar vi genom
        /// att sätta ett fält i HTML som ser ut såhär <input type="text" name="name"></input>
        /// 
        /// Men hur mappas det till "model"? Jo! Genom Model Binding i ASP.NET MVC så ser ASP.NET
        /// att vi POSTar in ett fält som heter name, och då vet den per automatik att den ska skapa en
        /// instans av PhotoViewModel och sätta dess värde.
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, PhotoViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                // Vi kan själva lägga till fel i "ModelState"
                // Detta kan vi sedan kontrollera i vår vy och skriva ut en summering av fel
                // Hur skulle man annars kunna göra detta, per automatik?
                // Jo! Man skulle kunna använda sig av attributet Required på Name i PhotoViewModel!
                ModelState.AddModelError("error", "Namnet får inte vara tomt!");

                // Nu returnerar Upload.cshtml, genom att kalla på View så vet ASP.NET
                // Att vi ska returnera ett ViewResult och kommer således att hitta
                // filen Upload.cshtml och sedan kompilera denna "on the fly"
                // Och returnera HTML till webbläsaren.
                // Vi skickar med model tillbaka så att vi kan få Name förifyllt!
                return View(model);
            }

            if (file == null || file.ContentLength == 0)
            {
                ModelState.AddModelError("error", "En fil vill jag gärna att du laddar upp!");

                // Vi skickar med model tillbaka så att vi kan få Name förifyllt!
                return View(model);
            }

            var destination = Server.MapPath("~/Uploads/");

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            file.SaveAs(Path.Combine(destination, file.FileName));

            // Nu skapar vi upp vår _data_ modell
            // Detta är den som vi ska spara
            // Längre fram kommer vi spara denna i en databas
            // Här mappar vi över de värden från våran ingående modell som vi tycker är viktiga
            var photo = new Photo
            {
                Id = Guid.NewGuid(),
                Filename = file.FileName,
                Name = model.Name
            };

            PhotoRepository.Add(photo);

            // Nu vill vi visa en lista med bilder som är uppladdade
            // Vi Redirectar därför till /Gallery/List
            return RedirectToAction("List");
        }

        // Skriver man INGET Attribute 
        // är det samma som att skriva HttpGet
        public ActionResult List()
        {
            return View(PhotoRepository.Photos);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCrud.Data;

namespace WebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisilerController : ControllerBase
    {
        private readonly UygulamaDbContext _context;

        public KisilerController(UygulamaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Kisi> GetKisiler()
        {
            return _context.Kisiler.ToList();
        }

        [HttpGet("{id}")] // Yukarıdaki HttpGet ile çakışmasın diye içerisine "id" yazdık.
        public ActionResult<Kisi> GetKisi(int id)// Eğer Kisi yazmasaydık return'de Ok metodu kullanırdık.
        {
            Kisi? kisi = _context.Kisiler.Find(id);

            if (kisi == null)// Kişi bulunamadıysa "Kişi bulunamadı"desin.
                return NotFound();

            return kisi; // public ActionResult GetKisi(int id) YAZSAYDIK, RETURN OK(kisi) yazmamız gerekecekti.
        }

        [HttpPost]
        public ActionResult<Kisi> PostKisi(Kisi kisi)
        {
            if (ModelState.IsValid) // Class'taki şartlara uygunluk sağlıyorsa deriz.
            {
                _context.Add(kisi);
                _context.SaveChanges();
                return kisi;
            }

            return BadRequest(ModelState);// Kullanıcıya uyarı vermiş oluruz.
        }

        [HttpDelete("{id}")] // Silinecek kişinin id sini belirttik.
        public ActionResult DeleteKisi(int id) // Yazdığımız id'yi parametre olarak yolladık. 
        {
            Kisi? kisi = _context.Kisiler.Find(id); // belirttiğimiz id'den kişinin kim olduğunu çektik.

            if (kisi == null)
                return NotFound();

            _context.Remove(kisi);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult PutKisi(int id, Kisi kisi)
        {
            if (id != kisi.Id)
                return BadRequest();

            if (!_context.Kisiler.Any(x => x.Id == id))// Veritabanında böyle bir kişi yoksa anlamına gelir.
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);// Belirtilen kriterlere uymuyorsa Kullanıcıya uyarı ver.

            _context.Update(kisi);
            _context.SaveChanges();
            return Ok();
        }
    }
}

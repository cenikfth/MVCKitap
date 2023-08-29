using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUygulamaProje1.Models;
using WebUygulamaProje1.Models.Utility;

namespace WebUygulamaProje1.Controllers
{
    public class KitapController : Controller
    {
        private readonly IKitapRepository _kitapRepository;
        private readonly IKitapTuruRepository _kitapTuruRepository;
        public KitapController(IKitapRepository kitapRepository, IKitapTuruRepository kitapTuruRepository)
        {
            _kitapRepository = kitapRepository;
            _kitapTuruRepository = kitapTuruRepository;
        }
        public IActionResult Index()
        {
            List<Kitap> objKitapList = _kitapRepository.GetAll().ToList();
  
            return View(objKitapList);
        }

        public IActionResult EkleGuncelle(int? id) 
        {
            IEnumerable<SelectListItem> KitapTuruList = _kitapTuruRepository.GetAll()
               .Select(f => new SelectListItem
               {
                   Text = f.Ad,
                   Value = f.Id.ToString(),
               });
            ViewBag.KitapTuruList = KitapTuruList;
            if (id == null || id == 0)
            {
                return View();
            }
            else
            {
                Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
                if (kitapVt == null)
                {
                    return NotFound();
                }
                return View(kitapVt);
            }

        }

        [HttpPost]
        public IActionResult EkleGuncelle(Kitap kitap,IFormFile? fi
            )
        {
            if(ModelState.IsValid) {
                _kitapRepository.Ekle(kitap);
                _kitapRepository.Kaydet();
                TempData["basarili"] = "Yeni Kitap  başarıyla oluşturuldu";
            return RedirectToAction("Index");
            }
            return View();
        }

        //public IActionResult Guncelle(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
        //    if (kitapVt == null) 
        //    { 
        //        return NotFound(); 
        //    }
        //    return View(kitapVt);
        //}

        //[HttpPost]
        //public IActionResult Guncelle(Kitap kitap)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _kitapRepository.Güncelle(kitap);
        //        _kitapRepository.Kaydet();
        //        TempData["basarili"] = "Yeni Kitap başarıyla güncellendi";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //public IActionResult Sil(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
        //    if (kitapVt == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(kitapVt);
        //}

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kitap? kitap = _kitapRepository.Get(u => u.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }
            _kitapRepository.Sil(kitap);
            _kitapRepository.Kaydet();
            TempData["basarili"] = "Kayıt Silme işlemi başarılı!";
            return RedirectToAction("Index","Kitap");
        }
    }
}

using ecommerceWebMvcUser.Models.Classes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerceWebMvcUser.Controllers
{
    public class SiparisController : Controller
    {
        // GET: Siparis
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SepetiOnayla()
        {
            // Sepeti onaylama işlemini burada gerçekleştirin.
            // Örneğin, sipariş oluşturun veya sepeti boşaltın.

            return RedirectToAction("SiparisDetay"); // Sepet detay sayfasına yönlendirin.
        }
        public ActionResult SiparisDetay()
        {
            // Sepet bilgilerini toplamak için kodlar buraya gelecek.

            // Sepet bilgilerini toplamak için kodlar buraya gelecek.
            Sepet sepet = Session["Sepet"] as Sepet;

            // Kullanıcı bilgilerini almak için giriş yapmış kullanıcının kimlik bilgilerini kullanabilirsiniz.
            if (User.Identity.IsAuthenticated)
            {
                // Kullanıcının adı ve soyadı (örneğin "John Doe") alınabilir.
                string kullaniciAdi = User.Identity.Name;
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityDataContext()));
                var kullanici = userManager.FindByName(User.Identity.Name);
                string eposta = kullanici.Email;


                // Kullanıcının e-posta adresini almak için, ASP.NET Identity veya kimlik sisteminiz tarafından
                // sağlanan bir yöntemi kullanabilirsiniz. Örneğin:


                // ViewBag veya ViewModel aracılığıyla bilgileri iletebilirsiniz.
                ViewBag.KullaniciAdi = kullaniciAdi;
                ViewBag.Kullanici = kullanici;
                ViewBag.eposta = eposta;
                // ViewBag.Eposta = eposta; // Eğer e-posta bilgisini almak için uygun bir yöntemi kullanıyorsanız.

                // Sipariş bilgilerini toplamak ve ViewBag aracılığıyla görünüme iletmek için aşağıdaki kodları kullanabilirsiniz.
                //decimal toplamsepet = sepet.ToplamSepet();
                int toplamAdet = sepet.ToplamAdet();
                decimal toplamTutar = sepet.ToplamTutar();

                ViewBag.ToplamAdet = toplamAdet;
                ViewBag.ToplamTutar = toplamTutar;
                //ViewBag.ToplamSepet = toplamsepet;
            }
            else
            {
                if (!User.Identity.IsAuthenticated)
                {
                    ViewBag.GirisHatirlatma = "Sipariş verebilmek için giriş yapmanız gerekmektedir.";
                    return RedirectToAction("Login", "Account");
                }

            }

            return View(sepet.SepetOgeleriniGetir());
        }




    }
}

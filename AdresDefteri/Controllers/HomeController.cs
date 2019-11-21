using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdresDefteri.Models.Entity;

namespace AdresDefteri.Controllers
{
	public class HomeController : Controller
	{
		DBAdresDefteriEntities db = new DBAdresDefteriEntities();

		// GET: Home
		public ActionResult Index(string searchitem)
		{
			var selectitem = from item in db.TBLAdresDefteri select item;
			if (!string.IsNullOrEmpty(searchitem))
			{
				selectitem = selectitem.Where(m => m.AdSoyad.Contains(searchitem));
			}
			return View(selectitem.ToList());
		}


		public ActionResult Delete(int id)
		{
			var deleteitem = db.TBLAdresDefteri.Find(id);
			db.TBLAdresDefteri.Remove(deleteitem);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Ekle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Ekle(TBLAdresDefteri item)
		{
			if (!ModelState.IsValid)
			{
				return View("Ekle");
			}
			db.TBLAdresDefteri.Add(item);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		public ActionResult Update(int id)
		{
			var updateitemm = db.TBLAdresDefteri.Find(id);

			return View("Update", updateitemm);
		}

		public ActionResult UpdateMethod(TBLAdresDefteri item)
		{
			var updateitem = db.TBLAdresDefteri.Find(item.id);
			updateitem.AdSoyad = item.AdSoyad;
			updateitem.TC = item.TC;
			updateitem.SabitTel = item.SabitTel;
			updateitem.CepTel = item.CepTel;
			updateitem.Adres = item.Adres;
			updateitem.İlce = item.İlce;
			updateitem.İl = item.İl;
			db.SaveChanges();

			return RedirectToAction("Index");
		}

	}
}
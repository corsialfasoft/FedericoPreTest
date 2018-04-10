using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FedericoPreTest.Models;



namespace FedericoPreTest.Controllers {
	public class HomeController : Controller {
		PRETESTEntities db = new PRETESTEntities();
		public ActionResult Index() {
			return View();
		}

		public ActionResult  Carrello() {
			return View();
		}
	
		 
		DomainModel dm = new DomainModel();
		
		public ActionResult OrderRequest() {			

			return View();
		}

		

		[HttpPost]

		public ActionResult OrderRequest(string codice,string descrizione){
		    if (!String.IsNullOrEmpty(codice) && int.TryParse(codice, out int intCod)) {
                ViewBag.prodotto = dm.RicercaPerCodice(intCod);
            } else if (!String.IsNullOrEmpty(descrizione)) {
                ViewBag.prodotti = dm.RicercaPerDescrizione(descrizione);
            }				

			if(ViewBag.prodotto!=null){				
				return View("ProductDetail");
			} else if (ViewBag.prodotti != null) {				
					return View("ProductList");
			}	else {
					ViewBag.Message = "Nessun prodotto è stato trovato";
					return View();
				}
			}			
	
		

			public ActionResult Product(int Id){
			ViewBag.prodotto = dm.RicercaPerCodice(Id);
			return View("ProductDetail");
			}
		
			
			public ActionResult ProductDetail() {

			return View();
		}

		public ActionResult ProductList() {
			return View();
		}
	}
}

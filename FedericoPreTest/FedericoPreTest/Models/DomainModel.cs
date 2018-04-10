using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FedericoPreTest.Models {
	public class DomainModel {
	 
		public class Prodotto {
        public int Codice {get; set;}
        public string Descrizione {get; set;}
        public int RequestQty {get; set;}
    }

	        PRETESTEntities Collegamento;
     		public Prodotto RicercaPerCodice(int cod) {
			Prodotto Unico = new Prodotto();
			using(Collegamento = new PRETESTEntities()) {
				var prodotto = Collegamento.ProdottiSet.Find(cod);
				Unico.Codice = prodotto.Id;
				Unico.Descrizione = prodotto.descrizione;
				Unico.RequestQty = prodotto.quantita;
			}			
			return Unico;
			}


			 public void AddToOrder(List<Prodotto> Listona) {
				using(Collegamento = new PRETESTEntities()) {
					OrdiniSet Ordinipronti = new OrdiniSet();
					Collegamento.OrdiniSet.Add();
				}
			 }


			public List<Prodotto> RicercaPerDescrizione(string desc) {
			List<Prodotto> Listona = new List<Prodotto>();
			using(Collegamento = new PRETESTEntities()) {
			var prodotti = from p in Collegamento.ProdottiSet
							where p.descrizione.Contains(desc)
							select p;
				foreach(var prodotto in prodotti) {  			
					Prodotto prod = new Prodotto();
					prod.Codice = prodotto.Id;
					prod.Descrizione = prodotto.descrizione;
					Listona.Add(prod);
				}
				return Listona;
			}	

		}
	}
}
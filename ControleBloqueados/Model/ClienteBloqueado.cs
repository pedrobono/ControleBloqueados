using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBloqueados.Model {
	internal class ClienteBloqueado {

		public int CodCliente { get; set; }
		public string NomeCliente { get; set; }
		public DateTime LiberadoAte { get; set; }

		public ClienteBloqueado(int codCliente = 0, string nomeCliente = "", DateTime liberadoAte = new DateTime()) {
			CodCliente = codCliente;
			NomeCliente = nomeCliente;
			LiberadoAte = liberadoAte;
		}
	}
}

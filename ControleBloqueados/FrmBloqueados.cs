using System.Diagnostics;
using System.Globalization;
using ControleBloqueados.Model;
using Npgsql;

namespace ControleBloqueados {
	public partial class frmBloqueados : Form {

		private NpgsqlConnection conexao = new NpgsqlConnection("Host=192.168.0.103;Username=btech;Password=btech2310;Database=supremo;port=5432");
		private bool inserindo = true;

		public frmBloqueados() {
			InitializeComponent();
		}

		private void ImgBTech_Click(object sender, EventArgs e) {
			DialogResult dialogResult = MessageBox.Show(this, "Aplicativo criado por Pedro Bono\nDeseja me conhecer?", "Oi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

			if (dialogResult == DialogResult.Yes)
				Process.Start(new ProcessStartInfo { FileName = @"https://www.linkedin.com/in/pedro-h-bono/", UseShellExecute = true });
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			//populaCampos(dtgCadastrosBloqueados.sele)
		}

		private void btnExcluir_Click(object sender, EventArgs e) {

		}

		private void btnIncluir_Click(object sender, EventArgs e) {
			txtCodCliente.Text = "";
			txtNomeCliente.Text = "";
			dtLiberadoAte.Value = DateTime.Now;
			inserindo = true;
		}

		private void btnGravar_Click(object sender, EventArgs e) {
			ClienteBloqueado cliente = new ClienteBloqueado();
			if (inserindo) {
				int codcli = 0;
				bool wasParsedCorrectly = int.TryParse(txtCodCliente.Text, out codcli);
				cliente = new ClienteBloqueado(codcli, txtNomeCliente.Text, dtLiberadoAte.Value.Date);
				insereCliente(cliente);
			}

			atualizaDataGrid();


		}

		private void txtCodCliente_Leave(object sender, EventArgs e) {
			conexao.Open();

			using var cmd = new NpgsqlCommand();
			cmd.Connection = conexao;
			cmd.CommandText = "select codcli, fantasia, dataclarion(dataatual() + 30) from cliente where codfilial = 1 and codcli = " + txtCodCliente.Text;

			NpgsqlDataReader resultados = cmd.ExecuteReader();
			List<ClienteBloqueado> clientesBloqueados = new List<ClienteBloqueado>();


			ClienteBloqueado cliente = new ClienteBloqueado();

			while (resultados.Read()) {
				cliente.CodCliente = (int)resultados.GetValue(0);
				cliente.NomeCliente = (string)resultados.GetValue(1);
				cliente.LiberadoAte = DateTime.ParseExact(resultados.GetValue(2).ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

				cliente.NomeCliente = cliente.NomeCliente.Trim();
			}

			populaCampos(cliente);

			conexao.Close();
		}

		private void populaCampos(ClienteBloqueado cliente) {
			txtCodCliente.Text = cliente.CodCliente.ToString();
			txtNomeCliente.Text = cliente.NomeCliente;
			dtLiberadoAte.Value = cliente.LiberadoAte;
		}

		private void dtgCadastrosBloqueados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {

		}

		private void frmBloqueados_Load(object sender, EventArgs e) {
			atualizaDataGrid();
		}

		private void atualizaDataGrid() {
			conexao.Open();

			using var cmd = new NpgsqlCommand();
			cmd.Connection = conexao;
			cmd.CommandText = "select ci.codcli, c.fantasia, dataclarion(ci.datavalidade) from cliignorar ci join cliente c on (c.codfilial, c.codcli) = (1, ci.codcli)";

			NpgsqlDataReader resultados = cmd.ExecuteReader();
			List<ClienteBloqueado> clientesBloqueados = new List<ClienteBloqueado>();


			while (resultados.Read()) {
				ClienteBloqueado cliente = new ClienteBloqueado();
				cliente.CodCliente = (int)resultados.GetValue(0);
				cliente.NomeCliente = (string)resultados.GetValue(1);
				cliente.LiberadoAte = DateTime.ParseExact(resultados.GetValue(2).ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

				cliente.NomeCliente = cliente.NomeCliente.Trim();

				clientesBloqueados.Add(cliente);
			}

			dtgCadastrosBloqueados.DataSource = clientesBloqueados;
			dtgCadastrosBloqueados.Refresh();
			conexao.Close();
		}

		private int insereCliente(ClienteBloqueado cliente) {
			conexao.Open();
			using var cmd = new NpgsqlCommand();
			cmd.Connection = conexao;


			cmd.CommandText = "INSERT INTO cliignorar VALUES( " + cliente.CodCliente.ToString() + ", formatar_data('" + cliente.LiberadoAte.Date.ToString() + "') )";
			int qtdeRegistros = cmd.ExecuteNonQuery();

			conexao.Close();

			return qtdeRegistros;
		}
	}
}
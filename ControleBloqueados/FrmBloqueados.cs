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
            dtgCadastrosBloqueados.AutoGenerateColumns = false;
            dtgCadastrosBloqueados.DataSource = new List<ClienteBloqueado>();

            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CodCliente";
            column.Name = "Codigo";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dtgCadastrosBloqueados.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "NomeCliente";
            column.Name = "Nome do Cliente";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgCadastrosBloqueados.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "LiberadoAte";
            column.Name = "Liberado até";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgCadastrosBloqueados.Columns.Add(column);
        }

        //metodos personalizados primeiro
        private int alteraCliente(ClienteBloqueado cliente) {
            conexao.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conexao;

            cmd.CommandText = "update cliignorar set datavalidade = formatar_data('" + cliente.LiberadoAte.Date.ToString() + "') where codcli = " + cliente.CodCliente.ToString();
            int qtdeRegistros = cmd.ExecuteNonQuery();

            conexao.Close();
            return qtdeRegistros;
        }

        private void populaCampos(ClienteBloqueado cliente) {
            txtCodCliente.Text = cliente.CodCliente.ToString();
            txtNomeCliente.Text = cliente.NomeCliente;
            dtLiberadoAte.Value = cliente.LiberadoAte;
        }

        private void atualizaDataGrid() {
            conexao.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conexao;
            cmd.CommandText = "" +
                "select ci.codcli, " +
                "   (case when trim(c.fantasia) = '' then c.razao else c.fantasia end) as nome, " +
                "   dataclarion(ci.datavalidade) " +
                "from cliignorar ci " +
                "   join cliente c on (c.codfilial, c.codcli) = (1, ci.codcli)" +
                "order by ci.codcli";

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

            dtgCadastrosBloqueados.Rows[dtgCadastrosBloqueados.RowCount - 1].Selected = true;
            conexao.Close();
        }

        private void insereCliente(ClienteBloqueado cliente) {
            conexao.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conexao;

            cmd.CommandText = "INSERT INTO cliignorar VALUES( " + cliente.CodCliente.ToString() + ", formatar_data('" + cliente.LiberadoAte.Date.ToString() + "') )";
            int qtdeRegistros = cmd.ExecuteNonQuery();

            conexao.Close();
        }
        //Fim dos Metodos personalizados
        //metodos criados pelo sistema

        private void ImgBTech_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show(this, "Aplicativo criado por Pedro Bono\nDeseja me conhecer?", "Oi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
                Process.Start(new ProcessStartInfo { FileName = @"https://www.linkedin.com/in/pedro-h-bono/", UseShellExecute = true });
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            ClienteBloqueado cliente = (ClienteBloqueado)dtgCadastrosBloqueados.SelectedRows[0].DataBoundItem;
            excluirCliente(cliente);
        }

        private void excluirCliente(ClienteBloqueado cliente) {
            int codcli = 0;

            if (!int.TryParse(txtCodCliente.Text, out codcli)) {
                MessageBox.Show(this, "Codigo do cliente invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            conexao.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conexao;

            cmd.CommandText = "delete from cliignorar where codcli = " + codcli.ToString();
            int qtdeRegistros = cmd.ExecuteNonQuery();

            conexao.Close();
            atualizaDataGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e) {
            txtCodCliente.Text = "";
            txtNomeCliente.Text = "";
            dtLiberadoAte.Value = DateTime.Now;
            inserindo = true;
        }

        private void btnGravar_Click(object sender, EventArgs e) {
            ClienteBloqueado cliente = new ClienteBloqueado();

            int codcli = 0;

            if (!int.TryParse(txtCodCliente.Text, out codcli)) {
                MessageBox.Show(this, "Codigo do cliente invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cliente = new ClienteBloqueado(codcli, txtNomeCliente.Text, dtLiberadoAte.Value.Date);

            if (inserindo)
                insereCliente(cliente);
            else
                alteraCliente(cliente);

            atualizaDataGrid();
        }

        private void txtCodCliente_Leave(object sender, EventArgs e) {
            conexao.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conexao;
            cmd.CommandText = "" +
                "select c.codcli, " +
                "	(case when trim(c.fantasia) ='' then c.razao else c.fantasia end) as nome,  " +
                "	dataclarion(case when ci.datavalidade is null then dataatual() + 30 else datavalidade end) as datavalidade," +
                "	(case when ci.datavalidade is null then true else false end) inserindo " +
                "from cliente c" +
                "	left join cliignorar ci on ci.codcli = c.codcli" +
                " where c.codfilial = 1 and c.codcli = " + txtCodCliente.Text;

            NpgsqlDataReader resultados = cmd.ExecuteReader();
            List<ClienteBloqueado> clientesBloqueados = new List<ClienteBloqueado>();


            ClienteBloqueado cliente = new ClienteBloqueado();

            while (resultados.Read()) {
                cliente.CodCliente = (int)resultados.GetValue(0);
                cliente.NomeCliente = (string)resultados.GetValue(1);
                cliente.LiberadoAte = DateTime.ParseExact(resultados.GetValue(2).ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                inserindo = (bool)resultados.GetValue(3);

                cliente.NomeCliente = cliente.NomeCliente.Trim();
            }

            populaCampos(cliente);
            conexao.Close();
        }

        private void frmBloqueados_Load(object sender, EventArgs e) {
            atualizaDataGrid();
        }

        private void dtgCadastrosBloqueados_CellContentDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            inserindo = false;
            ClienteBloqueado cliente = (ClienteBloqueado)dtgCadastrosBloqueados.SelectedRows[0].DataBoundItem;
            populaCampos(cliente);
        }

        private void frmBloqueados_FormClosing(object sender, FormClosingEventArgs e) {
            conexao.Close();
        }
    }
}
namespace ControleBloqueados
{
    partial class frmBloqueados
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBloqueados));
            this.ImgBTech = new System.Windows.Forms.PictureBox();
            this.dtgCadastrosBloqueados = new System.Windows.Forms.DataGridView();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtLiberadoAte = new System.Windows.Forms.DateTimePicker();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBTech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCadastrosBloqueados)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgBTech
            // 
            this.ImgBTech.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ImgBTech.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImgBTech.Image = global::ControleBloqueados.Properties.Resources.LOGO_CARTAO_pequeno;
            this.ImgBTech.Location = new System.Drawing.Point(518, 299);
            this.ImgBTech.Name = "ImgBTech";
            this.ImgBTech.Size = new System.Drawing.Size(280, 150);
            this.ImgBTech.TabIndex = 0;
            this.ImgBTech.TabStop = false;
            this.ImgBTech.Click += new System.EventHandler(this.ImgBTech_Click);
            // 
            // dtgCadastrosBloqueados
            // 
            this.dtgCadastrosBloqueados.AllowUserToAddRows = false;
            this.dtgCadastrosBloqueados.AllowUserToDeleteRows = false;
            this.dtgCadastrosBloqueados.AllowUserToOrderColumns = true;
            this.dtgCadastrosBloqueados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(104)))));
            this.dtgCadastrosBloqueados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgCadastrosBloqueados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCadastrosBloqueados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(198)))), ((int)(((byte)(75)))));
            this.dtgCadastrosBloqueados.Location = new System.Drawing.Point(3, 3);
            this.dtgCadastrosBloqueados.MultiSelect = false;
            this.dtgCadastrosBloqueados.Name = "dtgCadastrosBloqueados";
            this.dtgCadastrosBloqueados.ReadOnly = true;
            this.dtgCadastrosBloqueados.RowTemplate.Height = 25;
            this.dtgCadastrosBloqueados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCadastrosBloqueados.Size = new System.Drawing.Size(509, 446);
            this.dtgCadastrosBloqueados.TabIndex = 1;
            this.dtgCadastrosBloqueados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgCadastrosBloqueados_CellContentDoubleClick);
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Enabled = false;
            this.txtNomeCliente.Location = new System.Drawing.Point(518, 93);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(280, 23);
            this.txtNomeCliente.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome: ";
            // 
            // dtLiberadoAte
            // 
            this.dtLiberadoAte.Location = new System.Drawing.Point(518, 158);
            this.dtLiberadoAte.Name = "dtLiberadoAte";
            this.dtLiberadoAte.Size = new System.Drawing.Size(280, 23);
            this.dtLiberadoAte.TabIndex = 4;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(698, 35);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(100, 23);
            this.txtCodCliente.TabIndex = 5;
            this.txtCodCliente.Leave += new System.EventHandler(this.txtCodCliente_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(698, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cod Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Liberado até:";
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(540, 223);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(75, 23);
            this.btnIncluir.TabIndex = 8;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(695, 223);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 9;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(618, 273);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // frmBloqueados
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.dtLiberadoAte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.dtgCadastrosBloqueados);
            this.Controls.Add(this.ImgBTech);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBloqueados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de cadastros a Bloquear";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBloqueados_FormClosing);
            this.Load += new System.EventHandler(this.frmBloqueados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgBTech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCadastrosBloqueados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private PictureBox ImgBTech;
		private DataGridView dtgCadastrosBloqueados;
		private TextBox txtNomeCliente;
		private Label label1;
		private DateTimePicker dtLiberadoAte;
		private TextBox txtCodCliente;
		private Label label2;
		private Label label3;
		private Button btnIncluir;
		private Button btnGravar;
		private Button btnExcluir;
    }
}
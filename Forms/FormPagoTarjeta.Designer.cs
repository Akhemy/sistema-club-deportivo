namespace ClubDeportivoSystem.Forms
{
    partial class FormPagoTarjeta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbDatosTarjeta = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.txtVencimientoTarjeta1 = new System.Windows.Forms.TextBox();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.lblCVV = new System.Windows.Forms.Label();
            this.lblVencimientoTarjeta = new System.Windows.Forms.Label();
            this.lblTitular = new System.Windows.Forms.Label();
            this.lblNumeroTarjeta = new System.Windows.Forms.Label();
            this.lblTituloTarjeta = new System.Windows.Forms.Label();
            this.gbDatosTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosTarjeta
            // 
            this.gbDatosTarjeta.BackColor = System.Drawing.Color.White;
            this.gbDatosTarjeta.Controls.Add(this.btnCancelar);
            this.gbDatosTarjeta.Controls.Add(this.btnConfirmar);
            this.gbDatosTarjeta.Controls.Add(this.txtCVV);
            this.gbDatosTarjeta.Controls.Add(this.txtVencimientoTarjeta1);
            this.gbDatosTarjeta.Controls.Add(this.txtTitular);
            this.gbDatosTarjeta.Controls.Add(this.txtNumeroTarjeta);
            this.gbDatosTarjeta.Controls.Add(this.lblCVV);
            this.gbDatosTarjeta.Controls.Add(this.lblVencimientoTarjeta);
            this.gbDatosTarjeta.Controls.Add(this.lblTitular);
            this.gbDatosTarjeta.Controls.Add(this.lblNumeroTarjeta);
            this.gbDatosTarjeta.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gbDatosTarjeta.Location = new System.Drawing.Point(31, 88);
            this.gbDatosTarjeta.Name = "gbDatosTarjeta";
            this.gbDatosTarjeta.Size = new System.Drawing.Size(403, 359);
            this.gbDatosTarjeta.TabIndex = 0;
            this.gbDatosTarjeta.TabStop = false;
            this.gbDatosTarjeta.Text = "Datos de la Tarjeta";
            this.gbDatosTarjeta.Enter += new System.EventHandler(this.gbDatosTarjeta_Enter);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(276, 214);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Green;
            this.btnConfirmar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(28, 214);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 35);
            this.btnConfirmar.TabIndex = 12;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtCVV
            // 
            this.txtCVV.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCVV.Location = new System.Drawing.Point(210, 161);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(100, 21);
            this.txtCVV.TabIndex = 7;
            // 
            // txtVencimientoTarjeta1
            // 
            this.txtVencimientoTarjeta1.Font = new System.Drawing.Font("Arial", 9F);
            this.txtVencimientoTarjeta1.Location = new System.Drawing.Point(210, 119);
            this.txtVencimientoTarjeta1.Name = "txtVencimientoTarjeta1";
            this.txtVencimientoTarjeta1.Size = new System.Drawing.Size(100, 21);
            this.txtVencimientoTarjeta1.TabIndex = 6;
            this.txtVencimientoTarjeta1.TextChanged += new System.EventHandler(this.txtVencimientoTarjeta1_TextChanged);
            // 
            // txtTitular
            // 
            this.txtTitular.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTitular.Location = new System.Drawing.Point(210, 77);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(166, 21);
            this.txtTitular.TabIndex = 6;
            this.txtTitular.TextChanged += new System.EventHandler(this.txtTitular_TextChanged);
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(210, 36);
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(166, 21);
            this.txtNumeroTarjeta.TabIndex = 5;
            this.txtNumeroTarjeta.TextChanged += new System.EventHandler(this.txtNumeroTarjeta_TextChanged);
            // 
            // lblCVV
            // 
            this.lblCVV.AutoSize = true;
            this.lblCVV.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCVV.Location = new System.Drawing.Point(25, 165);
            this.lblCVV.Name = "lblCVV";
            this.lblCVV.Size = new System.Drawing.Size(33, 15);
            this.lblCVV.TabIndex = 2;
            this.lblCVV.Text = "CVV:";
            this.lblCVV.Click += new System.EventHandler(this.lblCVV_Click);
            // 
            // lblVencimientoTarjeta
            // 
            this.lblVencimientoTarjeta.AutoSize = true;
            this.lblVencimientoTarjeta.Font = new System.Drawing.Font("Arial", 9F);
            this.lblVencimientoTarjeta.Location = new System.Drawing.Point(25, 123);
            this.lblVencimientoTarjeta.Name = "lblVencimientoTarjeta";
            this.lblVencimientoTarjeta.Size = new System.Drawing.Size(180, 15);
            this.lblVencimientoTarjeta.TabIndex = 13;
            this.lblVencimientoTarjeta.Text = "Vencimiento de Tarjeta (MM/AA):";
            this.lblVencimientoTarjeta.Click += new System.EventHandler(this.lblVencimientoTarjeta_Click);
            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTitular.Location = new System.Drawing.Point(25, 81);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(44, 15);
            this.lblTitular.TabIndex = 1;
            this.lblTitular.Text = "Titular:";
            this.lblTitular.Click += new System.EventHandler(this.lblTitular_Click);
            // 
            // lblNumeroTarjeta
            // 
            this.lblNumeroTarjeta.AutoSize = true;
            this.lblNumeroTarjeta.Font = new System.Drawing.Font("Arial", 9F);
            this.lblNumeroTarjeta.Location = new System.Drawing.Point(25, 44);
            this.lblNumeroTarjeta.Name = "lblNumeroTarjeta";
            this.lblNumeroTarjeta.Size = new System.Drawing.Size(125, 15);
            this.lblNumeroTarjeta.TabIndex = 0;
            this.lblNumeroTarjeta.Text = "Numero de la Tarjeta:";
            // 
            // lblTituloTarjeta
            // 
            this.lblTituloTarjeta.AutoSize = true;
            this.lblTituloTarjeta.BackColor = System.Drawing.Color.LightGray;
            this.lblTituloTarjeta.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTituloTarjeta.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTituloTarjeta.Location = new System.Drawing.Point(210, 48);
            this.lblTituloTarjeta.Name = "lblTituloTarjeta";
            this.lblTituloTarjeta.Size = new System.Drawing.Size(185, 26);
            this.lblTituloTarjeta.TabIndex = 1;
            this.lblTituloTarjeta.Text = "Pago con Tarjeta";
            this.lblTituloTarjeta.Click += new System.EventHandler(this.lblTituloTarjeta_Click);
            // 
            // FormPagoTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 450);
            this.Controls.Add(this.lblTituloTarjeta);
            this.Controls.Add(this.gbDatosTarjeta);
            this.Name = "FormPagoTarjeta";
            this.Text = "FormPagoTarjeta";
            this.gbDatosTarjeta.ResumeLayout(false);
            this.gbDatosTarjeta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosTarjeta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.TextBox txtVencimientoTarjeta1;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.TextBox txtNumeroTarjeta;
        private System.Windows.Forms.Label lblCVV;
        private System.Windows.Forms.Label lblVencimientoTarjeta;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.Label lblNumeroTarjeta;
        private System.Windows.Forms.Label lblTituloTarjeta;
    }
}
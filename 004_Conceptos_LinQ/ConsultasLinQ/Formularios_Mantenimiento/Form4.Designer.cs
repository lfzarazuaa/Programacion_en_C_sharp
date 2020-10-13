namespace Formularios_Mantenimiento
{
    partial class Form4
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
            this.components = new System.ComponentModel.Container();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvTerritorios = new System.Windows.Forms.DataGridView();
            this.errorTerritorio = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerritorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTerritorio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(333, 19);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(109, 37);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvTerritorios
            // 
            this.dgvTerritorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerritorios.Location = new System.Drawing.Point(85, 74);
            this.dgvTerritorios.Name = "dgvTerritorios";
            this.dgvTerritorios.ReadOnly = true;
            this.dgvTerritorios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTerritorios.Size = new System.Drawing.Size(623, 245);
            this.dgvTerritorios.TabIndex = 2;
            this.dgvTerritorios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ObtenerDatos);
            // 
            // errorTerritorio
            // 
            this.errorTerritorio.ContainerControl = this;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 338);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvTerritorios);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerritorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTerritorio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvTerritorios;
        private System.Windows.Forms.ErrorProvider errorTerritorio;
    }
}
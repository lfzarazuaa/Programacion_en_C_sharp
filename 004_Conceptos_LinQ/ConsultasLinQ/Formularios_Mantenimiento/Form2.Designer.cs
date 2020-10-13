namespace Formularios_Mantenimiento
{
    partial class Form2
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
            this.dgvTerritorios = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.errorTerritorio = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerritorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTerritorio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTerritorios
            // 
            this.dgvTerritorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerritorios.Location = new System.Drawing.Point(82, 67);
            this.dgvTerritorios.Name = "dgvTerritorios";
            this.dgvTerritorios.ReadOnly = true;
            this.dgvTerritorios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTerritorios.Size = new System.Drawing.Size(623, 245);
            this.dgvTerritorios.TabIndex = 0;
            this.dgvTerritorios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ObtenerDatos);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(330, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(109, 37);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // errorTerritorio
            // 
            this.errorTerritorio.ContainerControl = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 324);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvTerritorios);
            this.Name = "Form2";
            this.Text = "Eliminación física de territorios.";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerritorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTerritorio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTerritorios;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ErrorProvider errorTerritorio;
    }
}
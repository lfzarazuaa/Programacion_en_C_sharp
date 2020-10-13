namespace Formularios_DB_simple.Tareas
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNivelAcadémico = new System.Windows.Forms.TextBox();
            this.dgvAlumno = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumno)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Grado Académico:";
            // 
            // txtNivelAcadémico
            // 
            this.txtNivelAcadémico.Location = new System.Drawing.Point(172, 13);
            this.txtNivelAcadémico.Name = "txtNivelAcadémico";
            this.txtNivelAcadémico.Size = new System.Drawing.Size(207, 20);
            this.txtNivelAcadémico.TabIndex = 6;
            this.txtNivelAcadémico.TextChanged += new System.EventHandler(this.FiltrarGradoAcadémico);
            // 
            // dgvAlumno
            // 
            this.dgvAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumno.Location = new System.Drawing.Point(67, 53);
            this.dgvAlumno.Name = "dgvAlumno";
            this.dgvAlumno.Size = new System.Drawing.Size(658, 218);
            this.dgvAlumno.TabIndex = 5;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 284);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNivelAcadémico);
            this.Controls.Add(this.dgvAlumno);
            this.Name = "Form4";
            this.Text = "Filtrar por Grado Académico";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNivelAcadémico;
        private System.Windows.Forms.DataGridView dgvAlumno;
    }
}
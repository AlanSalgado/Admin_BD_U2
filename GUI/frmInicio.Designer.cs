namespace GUI
{
    partial class frmInicio
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
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnAreas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(252)))), ((int)(((byte)(199)))));
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(188)))), ((int)(((byte)(41)))));
            this.btnProductos.Location = new System.Drawing.Point(61, 120);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(157, 44);
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnAreas
            // 
            this.btnAreas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(252)))), ((int)(((byte)(199)))));
            this.btnAreas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAreas.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAreas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(188)))), ((int)(((byte)(41)))));
            this.btnAreas.Location = new System.Drawing.Point(300, 120);
            this.btnAreas.Name = "btnAreas";
            this.btnAreas.Size = new System.Drawing.Size(157, 44);
            this.btnAreas.TabIndex = 1;
            this.btnAreas.Text = "Areas";
            this.btnAreas.UseVisualStyleBackColor = false;
            this.btnAreas.Click += new System.EventHandler(this.btnAreas_Click);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(523, 288);
            this.Controls.Add(this.btnAreas);
            this.Controls.Add(this.btnProductos);
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INICIO";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInicio_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnAreas;
    }
}
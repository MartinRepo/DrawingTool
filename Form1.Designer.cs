namespace comp282assignment2_datagridVersion
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FirstX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorButton = new System.Windows.Forms.Button();
            this.remove_button = new System.Windows.Forms.Button();
            this.findIntersections = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstX,
            this.FirstY,
            this.SecondX,
            this.SecondY,
            this.Color});
            this.dataGridView1.Location = new System.Drawing.Point(532, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(481, 239);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // FirstX
            // 
            this.FirstX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FirstX.HeaderText = "First X";
            this.FirstX.MinimumWidth = 6;
            this.FirstX.Name = "FirstX";
            this.FirstX.Width = 92;
            // 
            // FirstY
            // 
            this.FirstY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FirstY.HeaderText = "First Y";
            this.FirstY.MinimumWidth = 6;
            this.FirstY.Name = "FirstY";
            this.FirstY.Width = 92;
            // 
            // SecondX
            // 
            this.SecondX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SecondX.HeaderText = "Second X";
            this.SecondX.MinimumWidth = 6;
            this.SecondX.Name = "SecondX";
            // 
            // SecondY
            // 
            this.SecondY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SecondY.HeaderText = "Second Y";
            this.SecondY.MinimumWidth = 6;
            this.SecondY.Name = "SecondY";
            // 
            // Color
            // 
            this.Color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Color.HeaderText = "Color";
            this.Color.MinimumWidth = 92;
            this.Color.Name = "Color";
            this.Color.Width = 92;
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(532, 24);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(95, 42);
            this.colorButton.TabIndex = 1;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.color_button_Click);
            // 
            // remove_button
            // 
            this.remove_button.Location = new System.Drawing.Point(917, 24);
            this.remove_button.Name = "remove_button";
            this.remove_button.Size = new System.Drawing.Size(96, 42);
            this.remove_button.TabIndex = 2;
            this.remove_button.Text = "Remove";
            this.remove_button.UseVisualStyleBackColor = true;
            this.remove_button.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // findIntersections
            // 
            this.findIntersections.Location = new System.Drawing.Point(532, 372);
            this.findIntersections.Name = "findIntersections";
            this.findIntersections.Size = new System.Drawing.Size(194, 42);
            this.findIntersections.TabIndex = 3;
            this.findIntersections.Text = "Find Intersections";
            this.findIntersections.UseVisualStyleBackColor = true;
            this.findIntersections.Click += new System.EventHandler(this.findButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(13, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(513, 617);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 653);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.findIntersections);
            this.Controls.Add(this.remove_button);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button remove_button;
        private System.Windows.Forms.Button findIntersections;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstX;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondX;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


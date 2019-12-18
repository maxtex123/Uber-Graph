namespace cis300_Assignment_6_F19_Shuber
{
    partial class UserInterface
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
            this.uxOpen = new System.Windows.Forms.Button();
            this.uxAllNodesLbl = new System.Windows.Forms.Label();
            this.uxCustomerNodesLbl = new System.Windows.Forms.Label();
            this.uxPathLbl = new System.Windows.Forms.Label();
            this.uxCostLbl = new System.Windows.Forms.Label();
            this.uxPathWeightBox = new System.Windows.Forms.TextBox();
            this.uxAllNodesBox = new System.Windows.Forms.ListBox();
            this.uxCustomerNodesBox = new System.Windows.Forms.ListBox();
            this.uxPathBox = new System.Windows.Forms.ListBox();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxOpen
            // 
            this.uxOpen.Location = new System.Drawing.Point(25, 30);
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(96, 64);
            this.uxOpen.TabIndex = 0;
            this.uxOpen.Text = "Open File";
            this.uxOpen.UseVisualStyleBackColor = true;
            this.uxOpen.Click += new System.EventHandler(this.uxOpen_Click);
            // 
            // uxAllNodesLbl
            // 
            this.uxAllNodesLbl.AutoSize = true;
            this.uxAllNodesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxAllNodesLbl.Location = new System.Drawing.Point(20, 119);
            this.uxAllNodesLbl.Name = "uxAllNodesLbl";
            this.uxAllNodesLbl.Size = new System.Drawing.Size(102, 25);
            this.uxAllNodesLbl.TabIndex = 1;
            this.uxAllNodesLbl.Text = "All Nodes:";
            // 
            // uxCustomerNodesLbl
            // 
            this.uxCustomerNodesLbl.AutoSize = true;
            this.uxCustomerNodesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxCustomerNodesLbl.Location = new System.Drawing.Point(253, 119);
            this.uxCustomerNodesLbl.Name = "uxCustomerNodesLbl";
            this.uxCustomerNodesLbl.Size = new System.Drawing.Size(165, 25);
            this.uxCustomerNodesLbl.TabIndex = 2;
            this.uxCustomerNodesLbl.Text = "Customer Nodes:";
            // 
            // uxPathLbl
            // 
            this.uxPathLbl.AutoSize = true;
            this.uxPathLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxPathLbl.Location = new System.Drawing.Point(485, 119);
            this.uxPathLbl.Name = "uxPathLbl";
            this.uxPathLbl.Size = new System.Drawing.Size(58, 25);
            this.uxPathLbl.TabIndex = 3;
            this.uxPathLbl.Text = "Path:";
            // 
            // uxCostLbl
            // 
            this.uxCostLbl.AutoSize = true;
            this.uxCostLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxCostLbl.Location = new System.Drawing.Point(485, 433);
            this.uxCostLbl.Name = "uxCostLbl";
            this.uxCostLbl.Size = new System.Drawing.Size(119, 25);
            this.uxCostLbl.TabIndex = 4;
            this.uxCostLbl.Text = "Travel Cost:";
            // 
            // uxPathWeightBox
            // 
            this.uxPathWeightBox.Enabled = false;
            this.uxPathWeightBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.uxPathWeightBox.Location = new System.Drawing.Point(490, 461);
            this.uxPathWeightBox.Name = "uxPathWeightBox";
            this.uxPathWeightBox.Size = new System.Drawing.Size(203, 30);
            this.uxPathWeightBox.TabIndex = 8;
            // 
            // uxAllNodesBox
            // 
            this.uxAllNodesBox.Enabled = false;
            this.uxAllNodesBox.FormattingEnabled = true;
            this.uxAllNodesBox.ItemHeight = 20;
            this.uxAllNodesBox.Location = new System.Drawing.Point(25, 147);
            this.uxAllNodesBox.Name = "uxAllNodesBox";
            this.uxAllNodesBox.Size = new System.Drawing.Size(199, 344);
            this.uxAllNodesBox.TabIndex = 9;
            // 
            // uxCustomerNodesBox
            // 
            this.uxCustomerNodesBox.Enabled = false;
            this.uxCustomerNodesBox.FormattingEnabled = true;
            this.uxCustomerNodesBox.ItemHeight = 20;
            this.uxCustomerNodesBox.Location = new System.Drawing.Point(258, 147);
            this.uxCustomerNodesBox.Name = "uxCustomerNodesBox";
            this.uxCustomerNodesBox.Size = new System.Drawing.Size(199, 344);
            this.uxCustomerNodesBox.TabIndex = 10;
            // 
            // uxPathBox
            // 
            this.uxPathBox.Enabled = false;
            this.uxPathBox.FormattingEnabled = true;
            this.uxPathBox.ItemHeight = 20;
            this.uxPathBox.Location = new System.Drawing.Point(490, 147);
            this.uxPathBox.Name = "uxPathBox";
            this.uxPathBox.Size = new System.Drawing.Size(199, 284);
            this.uxPathBox.TabIndex = 11;
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.FileName = "openFileDialog1";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 518);
            this.Controls.Add(this.uxPathBox);
            this.Controls.Add(this.uxCustomerNodesBox);
            this.Controls.Add(this.uxAllNodesBox);
            this.Controls.Add(this.uxPathWeightBox);
            this.Controls.Add(this.uxCostLbl);
            this.Controls.Add(this.uxPathLbl);
            this.Controls.Add(this.uxCustomerNodesLbl);
            this.Controls.Add(this.uxAllNodesLbl);
            this.Controls.Add(this.uxOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "User Interface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxOpen;
        private System.Windows.Forms.Label uxAllNodesLbl;
        private System.Windows.Forms.Label uxCustomerNodesLbl;
        private System.Windows.Forms.Label uxPathLbl;
        private System.Windows.Forms.Label uxCostLbl;
        private System.Windows.Forms.TextBox uxPathWeightBox;
        private System.Windows.Forms.ListBox uxAllNodesBox;
        private System.Windows.Forms.ListBox uxCustomerNodesBox;
        private System.Windows.Forms.ListBox uxPathBox;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
    }
}


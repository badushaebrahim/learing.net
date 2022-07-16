
namespace Login
{
    partial class dash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dash));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMedecineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.Name_of_pharamasist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nameofmed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parmasisid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateandtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceperunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatreColumnButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteColumnButton = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name_of_pharamasist,
            this.Nameofmed,
            this.Parmasisid,
            this.dateandtime,
            this.priceperunit,
            this.UID,
            this.UpdatreColumnButton,
            this.DeleteColumnButton});
            this.dataGridView1.Location = new System.Drawing.Point(12, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(925, 340);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.addMedecineToolStripMenuItem,
            this.billToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(865, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // addMedecineToolStripMenuItem
            // 
            this.addMedecineToolStripMenuItem.Name = "addMedecineToolStripMenuItem";
            this.addMedecineToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.addMedecineToolStripMenuItem.Text = "Add Medecine";
            this.addMedecineToolStripMenuItem.Click += new System.EventHandler(this.addMedecineToolStripMenuItem_Click);
            // 
            // billToolStripMenuItem
            // 
            this.billToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBillToolStripMenuItem,
            this.billReportToolStripMenuItem});
            this.billToolStripMenuItem.Name = "billToolStripMenuItem";
            this.billToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.billToolStripMenuItem.Text = "Bill";
            // 
            // addBillToolStripMenuItem
            // 
            this.addBillToolStripMenuItem.Name = "addBillToolStripMenuItem";
            this.addBillToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.addBillToolStripMenuItem.Text = "Add Bill";
            // 
            // billReportToolStripMenuItem
            // 
            this.billReportToolStripMenuItem.Name = "billReportToolStripMenuItem";
            this.billReportToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.billReportToolStripMenuItem.Text = "Bill report";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(338, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Medicine";
            // 
            // Name_of_pharamasist
            // 
            this.Name_of_pharamasist.DataPropertyName = "Name_of_pharamasist";
            this.Name_of_pharamasist.HeaderText = "Name of pharamasist";
            this.Name_of_pharamasist.Name = "Name_of_pharamasist";
            this.Name_of_pharamasist.ReadOnly = true;
            // 
            // Nameofmed
            // 
            this.Nameofmed.DataPropertyName = "Nameofmed";
            this.Nameofmed.HeaderText = "Name of meds";
            this.Nameofmed.Name = "Nameofmed";
            this.Nameofmed.ReadOnly = true;
            // 
            // Parmasisid
            // 
            this.Parmasisid.DataPropertyName = "Parmasisid";
            this.Parmasisid.HeaderText = "pharamasist id";
            this.Parmasisid.Name = "Parmasisid";
            this.Parmasisid.ReadOnly = true;
            // 
            // dateandtime
            // 
            this.dateandtime.DataPropertyName = "dateandtime";
            this.dateandtime.HeaderText = "date & time of Medecine added";
            this.dateandtime.Name = "dateandtime";
            this.dateandtime.ReadOnly = true;
            // 
            // priceperunit
            // 
            this.priceperunit.DataPropertyName = "priceperunit";
            this.priceperunit.HeaderText = "priceperunit";
            this.priceperunit.Name = "priceperunit";
            this.priceperunit.ReadOnly = true;
            // 
            // UID
            // 
            this.UID.DataPropertyName = "UID";
            this.UID.HeaderText = "UID";
            this.UID.Name = "UID";
            this.UID.ReadOnly = true;
            // 
            // UpdatreColumnButton
            // 
            this.UpdatreColumnButton.HeaderText = "Update";
            this.UpdatreColumnButton.Name = "UpdatreColumnButton";
            this.UpdatreColumnButton.ReadOnly = true;
            this.UpdatreColumnButton.Text = "Update";
            this.UpdatreColumnButton.UseColumnTextForButtonValue = true;
            // 
            // DeleteColumnButton
            // 
            this.DeleteColumnButton.HeaderText = "Delete";
            this.DeleteColumnButton.Name = "DeleteColumnButton";
            this.DeleteColumnButton.ReadOnly = true;
            this.DeleteColumnButton.Text = "Delete";
            this.DeleteColumnButton.UseColumnTextForButtonValue = true;
            // 
            // dash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 456);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "dash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pharmacy";
            this.Load += new System.EventHandler(this.dashon_load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMedecineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem addBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billReportToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_of_pharamasist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nameofmed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parmasisid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateandtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceperunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn UID;
        private System.Windows.Forms.DataGridViewButtonColumn UpdatreColumnButton;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteColumnButton;
    }
}
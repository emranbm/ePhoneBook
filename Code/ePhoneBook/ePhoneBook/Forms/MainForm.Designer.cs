namespace ePhoneBook
{
    partial class MainForm
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
            System.Windows.Forms.Label label1;
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "First Name");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Last Name");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Phone Number");
            this.searchTB = new System.Windows.Forms.TextBox();
            this.contactsLV = new Telerik.WinControls.UI.RadListView();
            this.newContactBtn = new Telerik.WinControls.UI.RadButton();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.contactsLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newContactBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 13);
            label1.TabIndex = 2;
            label1.Text = "search:";
            // 
            // searchTB
            // 
            this.searchTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTB.Location = new System.Drawing.Point(61, 12);
            this.searchTB.Name = "searchTB";
            this.searchTB.Size = new System.Drawing.Size(283, 20);
            this.searchTB.TabIndex = 0;
            this.searchTB.TextChanged += new System.EventHandler(this.searchTB_TextChanged);
            // 
            // contactsLV
            // 
            listViewDetailColumn1.HeaderText = "First Name";
            listViewDetailColumn2.HeaderText = "Last Name";
            listViewDetailColumn3.HeaderText = "Phone Number";
            this.contactsLV.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2,
            listViewDetailColumn3});
            this.contactsLV.EnableFiltering = true;
            this.contactsLV.Location = new System.Drawing.Point(12, 38);
            this.contactsLV.Name = "contactsLV";
            this.contactsLV.SelectLastAddedItem = false;
            this.contactsLV.Size = new System.Drawing.Size(332, 251);
            this.contactsLV.TabIndex = 4;
            this.contactsLV.Text = "Some Texts";
            this.contactsLV.ItemMouseDoubleClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.contactsLV_ItemMouseDoubleClick);
            // 
            // newContactBtn
            // 
            this.newContactBtn.Location = new System.Drawing.Point(234, 294);
            this.newContactBtn.Name = "newContactBtn";
            this.newContactBtn.Size = new System.Drawing.Size(110, 24);
            this.newContactBtn.TabIndex = 1;
            this.newContactBtn.Text = "New Contact ...";
            this.newContactBtn.Click += new System.EventHandler(this.newContactBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 330);
            this.Controls.Add(this.newContactBtn);
            this.Controls.Add(this.contactsLV);
            this.Controls.Add(label1);
            this.Controls.Add(this.searchTB);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ePhoneBook";
            ((System.ComponentModel.ISupportInitialize)(this.contactsLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newContactBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox searchTB;
        private Telerik.WinControls.UI.RadListView contactsLV;
        private Telerik.WinControls.UI.RadButton newContactBtn;
    }
}


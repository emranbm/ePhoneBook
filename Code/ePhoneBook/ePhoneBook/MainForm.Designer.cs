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
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn4 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "First Name");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn5 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Last Name");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn6 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Phone Number");
            this.SearchTB = new System.Windows.Forms.TextBox();
            this.ContactsLV = new Telerik.WinControls.UI.RadListView();
            this.NewContactBtn = new Telerik.WinControls.UI.RadButton();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ContactsLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewContactBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 13);
            label1.TabIndex = 2;
            label1.Text = "search:";
            // 
            // SearchTB
            // 
            this.SearchTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTB.Location = new System.Drawing.Point(61, 12);
            this.SearchTB.Name = "SearchTB";
            this.SearchTB.Size = new System.Drawing.Size(283, 20);
            this.SearchTB.TabIndex = 1;
            // 
            // ContactsLV
            // 
            listViewDetailColumn4.HeaderText = "First Name";
            listViewDetailColumn5.HeaderText = "Last Name";
            listViewDetailColumn6.HeaderText = "Phone Number";
            this.ContactsLV.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn4,
            listViewDetailColumn5,
            listViewDetailColumn6});
            this.ContactsLV.Location = new System.Drawing.Point(12, 38);
            this.ContactsLV.Name = "ContactsLV";
            this.ContactsLV.Size = new System.Drawing.Size(332, 251);
            this.ContactsLV.TabIndex = 4;
            this.ContactsLV.Text = "Some Texts";
            this.ContactsLV.ItemMouseDoubleClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.contactsLV_ItemMouseDoubleClick);
            // 
            // NewContactBtn
            // 
            this.NewContactBtn.Location = new System.Drawing.Point(234, 294);
            this.NewContactBtn.Name = "NewContactBtn";
            this.NewContactBtn.Size = new System.Drawing.Size(110, 24);
            this.NewContactBtn.TabIndex = 5;
            this.NewContactBtn.Text = "New Contact ...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 330);
            this.Controls.Add(this.NewContactBtn);
            this.Controls.Add(this.ContactsLV);
            this.Controls.Add(label1);
            this.Controls.Add(this.SearchTB);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ContactsLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewContactBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox SearchTB;
        private Telerik.WinControls.UI.RadListView ContactsLV;
        private Telerik.WinControls.UI.RadButton NewContactBtn;
    }
}


namespace ePhoneBook
{
    partial class NewContactForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Title");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn4 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Number");
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            this.firstNameTB = new System.Windows.Forms.TextBox();
            this.lastNameTB = new System.Windows.Forms.TextBox();
            this.phoneNumbersLV = new Telerik.WinControls.UI.RadListView();
            this.titleDD = new Telerik.WinControls.UI.RadDropDownList();
            this.numberTB = new System.Windows.Forms.TextBox();
            this.addBtn = new Telerik.WinControls.UI.RadButton();
            this.saveBtn = new Telerik.WinControls.UI.RadButton();
            this.removeBtn = new Telerik.WinControls.UI.RadButton();
            this.cancelBtn = new Telerik.WinControls.UI.RadButton();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.phoneNumbersLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleDD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 13);
            label1.TabIndex = 0;
            label1.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 41);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 13);
            label2.TabIndex = 2;
            label2.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 75);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(87, 13);
            label3.TabIndex = 4;
            label3.Text = "Phone Number:";
            // 
            // firstNameTB
            // 
            this.firstNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameTB.Location = new System.Drawing.Point(82, 12);
            this.firstNameTB.Name = "firstNameTB";
            this.firstNameTB.Size = new System.Drawing.Size(216, 20);
            this.firstNameTB.TabIndex = 0;
            // 
            // lastNameTB
            // 
            this.lastNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastNameTB.Location = new System.Drawing.Point(82, 38);
            this.lastNameTB.Name = "lastNameTB";
            this.lastNameTB.Size = new System.Drawing.Size(216, 20);
            this.lastNameTB.TabIndex = 1;
            // 
            // phoneNumbersLV
            // 
            this.phoneNumbersLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            listViewDetailColumn3.HeaderText = "Title";
            listViewDetailColumn3.Width = 75F;
            listViewDetailColumn4.HeaderText = "Number";
            listViewDetailColumn4.MinWidth = 50F;
            this.phoneNumbersLV.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn3,
            listViewDetailColumn4});
            this.phoneNumbersLV.ItemSpacing = -1;
            this.phoneNumbersLV.Location = new System.Drawing.Point(12, 147);
            this.phoneNumbersLV.Name = "phoneNumbersLV";
            this.phoneNumbersLV.Size = new System.Drawing.Size(286, 115);
            this.phoneNumbersLV.TabIndex = 5;
            this.phoneNumbersLV.Text = "radListView1";
            this.phoneNumbersLV.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.phoneNumbersLV.SelectedItemChanged += new System.EventHandler(this.phoneNumbersLV_SelectedItemChanged);
            this.phoneNumbersLV.KeyUp += new System.Windows.Forms.KeyEventHandler(this.phoneNumbersLV_KeyUp);
            // 
            // titleDD
            // 
            radListDataItem4.Text = "Home";
            radListDataItem5.Text = "Mobile";
            radListDataItem6.Text = "Work";
            this.titleDD.Items.Add(radListDataItem4);
            this.titleDD.Items.Add(radListDataItem5);
            this.titleDD.Items.Add(radListDataItem6);
            this.titleDD.Location = new System.Drawing.Point(12, 91);
            this.titleDD.Name = "titleDD";
            this.titleDD.Size = new System.Drawing.Size(87, 20);
            this.titleDD.TabIndex = 2;
            this.titleDD.Text = "Mobile";
            // 
            // numberTB
            // 
            this.numberTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberTB.Location = new System.Drawing.Point(105, 91);
            this.numberTB.Name = "numberTB";
            this.numberTB.Size = new System.Drawing.Size(193, 20);
            this.numberTB.TabIndex = 3;
            this.numberTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numberTB_KeyUp);
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.Location = new System.Drawing.Point(211, 117);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(87, 24);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(188, 272);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(110, 24);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeBtn.Enabled = false;
            this.removeBtn.Location = new System.Drawing.Point(95, 117);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(110, 24);
            this.removeBtn.TabIndex = 5;
            this.removeBtn.Text = "Remove Selected";
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(72, 272);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(110, 24);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            // 
            // NewContactForm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(310, 308);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.numberTB);
            this.Controls.Add(this.titleDD);
            this.Controls.Add(this.phoneNumbersLV);
            this.Controls.Add(label3);
            this.Controls.Add(this.lastNameTB);
            this.Controls.Add(label2);
            this.Controls.Add(this.firstNameTB);
            this.Controls.Add(label1);
            this.Name = "NewContactForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Contact";
            ((System.ComponentModel.ISupportInitialize)(this.phoneNumbersLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleDD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNameTB;
        private System.Windows.Forms.TextBox lastNameTB;
        private Telerik.WinControls.UI.RadListView phoneNumbersLV;
        private Telerik.WinControls.UI.RadDropDownList titleDD;
        private System.Windows.Forms.TextBox numberTB;
        private Telerik.WinControls.UI.RadButton addBtn;
        private Telerik.WinControls.UI.RadButton saveBtn;
        private Telerik.WinControls.UI.RadButton removeBtn;
        private Telerik.WinControls.UI.RadButton cancelBtn;
    }
}
﻿namespace VisualZorgApp
{
    partial class ZorgApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZorgApp));
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.myProfilePrescribedDrugsGroupBox = new System.Windows.Forms.GroupBox();
            this.PrescribedDrugsGridView = new System.Windows.Forms.DataGridView();
            this.prescribedDrugName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prescribedDrugIntakeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prescribedDrugStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prescribedDrugEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.myProfileRoleNameLabel = new System.Windows.Forms.Label();
            this.myProfileIdLabel = new System.Windows.Forms.Label();
            this.myProfileRoleIdLabel = new System.Windows.Forms.Label();
            this.myProfileBmiLabel = new System.Windows.Forms.Label();
            this.myProfileLengthLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.myProfileWeightLabel = new System.Windows.Forms.Label();
            this.myProfileAgeLabel = new System.Windows.Forms.Label();
            this.myProfileSurnameLabel = new System.Windows.Forms.Label();
            this.myProfileNameLabel = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SaveProfileListButton = new System.Windows.Forms.Button();
            this.ProfileGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bmi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrugList = new System.Windows.Forms.TabPage();
            this.DrugGridView = new System.Windows.Forms.DataGridView();
            this.drugId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drugName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drugDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drugType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drugDosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myProfileWeightRegistrationGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.registeredWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registeredWeightDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabs.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.myProfilePrescribedDrugsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrescribedDrugsGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileGridView)).BeginInit();
            this.DrugList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrugGridView)).BeginInit();
            this.myProfileWeightRegistrationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.DrugList);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1119, 582);
            this.tabs.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.myProfileWeightRegistrationGroupBox);
            this.tabPage2.Controls.Add(this.myProfilePrescribedDrugsGroupBox);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(1111, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MyProfile";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // myProfilePrescribedDrugsGroupBox
            // 
            this.myProfilePrescribedDrugsGroupBox.Controls.Add(this.PrescribedDrugsGridView);
            this.myProfilePrescribedDrugsGroupBox.Location = new System.Drawing.Point(211, 6);
            this.myProfilePrescribedDrugsGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.myProfilePrescribedDrugsGroupBox.Name = "myProfilePrescribedDrugsGroupBox";
            this.myProfilePrescribedDrugsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.myProfilePrescribedDrugsGroupBox.Size = new System.Drawing.Size(517, 554);
            this.myProfilePrescribedDrugsGroupBox.TabIndex = 1;
            this.myProfilePrescribedDrugsGroupBox.TabStop = false;
            this.myProfilePrescribedDrugsGroupBox.Text = "Prescribed Drugs";
            // 
            // PrescribedDrugsGridView
            // 
            this.PrescribedDrugsGridView.AllowUserToAddRows = false;
            this.PrescribedDrugsGridView.AllowUserToDeleteRows = false;
            this.PrescribedDrugsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PrescribedDrugsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PrescribedDrugsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prescribedDrugName,
            this.prescribedDrugIntakeTime,
            this.prescribedDrugStartDate,
            this.prescribedDrugEndDate});
            this.PrescribedDrugsGridView.Location = new System.Drawing.Point(5, 18);
            this.PrescribedDrugsGridView.Name = "PrescribedDrugsGridView";
            this.PrescribedDrugsGridView.ReadOnly = true;
            this.PrescribedDrugsGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.PrescribedDrugsGridView.Size = new System.Drawing.Size(509, 526);
            this.PrescribedDrugsGridView.TabIndex = 0;
            this.PrescribedDrugsGridView.TabStop = false;
            // 
            // prescribedDrugName
            // 
            this.prescribedDrugName.HeaderText = "Drug Name";
            this.prescribedDrugName.Name = "prescribedDrugName";
            this.prescribedDrugName.ReadOnly = true;
            // 
            // prescribedDrugIntakeTime
            // 
            this.prescribedDrugIntakeTime.HeaderText = "Intake Time";
            this.prescribedDrugIntakeTime.Name = "prescribedDrugIntakeTime";
            this.prescribedDrugIntakeTime.ReadOnly = true;
            // 
            // prescribedDrugStartDate
            // 
            this.prescribedDrugStartDate.HeaderText = "Prescription Start";
            this.prescribedDrugStartDate.Name = "prescribedDrugStartDate";
            this.prescribedDrugStartDate.ReadOnly = true;
            // 
            // prescribedDrugEndDate
            // 
            this.prescribedDrugEndDate.HeaderText = "Prescription Ends";
            this.prescribedDrugEndDate.Name = "prescribedDrugEndDate";
            this.prescribedDrugEndDate.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myProfileRoleNameLabel);
            this.groupBox1.Controls.Add(this.myProfileIdLabel);
            this.groupBox1.Controls.Add(this.myProfileRoleIdLabel);
            this.groupBox1.Controls.Add(this.myProfileBmiLabel);
            this.groupBox1.Controls.Add(this.myProfileLengthLabel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.myProfileWeightLabel);
            this.groupBox1.Controls.Add(this.myProfileAgeLabel);
            this.groupBox1.Controls.Add(this.myProfileSurnameLabel);
            this.groupBox1.Controls.Add(this.myProfileNameLabel);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(202, 391);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your Details";
            // 
            // myProfileRoleNameLabel
            // 
            this.myProfileRoleNameLabel.AutoSize = true;
            this.myProfileRoleNameLabel.Location = new System.Drawing.Point(4, 249);
            this.myProfileRoleNameLabel.Name = "myProfileRoleNameLabel";
            this.myProfileRoleNameLabel.Size = new System.Drawing.Size(69, 13);
            this.myProfileRoleNameLabel.TabIndex = 20;
            this.myProfileRoleNameLabel.Text = "Role Name : ";
            // 
            // myProfileIdLabel
            // 
            this.myProfileIdLabel.AutoSize = true;
            this.myProfileIdLabel.Location = new System.Drawing.Point(4, 32);
            this.myProfileIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myProfileIdLabel.Name = "myProfileIdLabel";
            this.myProfileIdLabel.Size = new System.Drawing.Size(24, 13);
            this.myProfileIdLabel.TabIndex = 18;
            this.myProfileIdLabel.Text = "ID :";
            // 
            // myProfileRoleIdLabel
            // 
            this.myProfileRoleIdLabel.AutoSize = true;
            this.myProfileRoleIdLabel.Location = new System.Drawing.Point(4, 223);
            this.myProfileRoleIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myProfileRoleIdLabel.Name = "myProfileRoleIdLabel";
            this.myProfileRoleIdLabel.Size = new System.Drawing.Size(52, 13);
            this.myProfileRoleIdLabel.TabIndex = 14;
            this.myProfileRoleIdLabel.Text = "Role ID : ";
            // 
            // myProfileBmiLabel
            // 
            this.myProfileBmiLabel.AutoSize = true;
            this.myProfileBmiLabel.Location = new System.Drawing.Point(4, 196);
            this.myProfileBmiLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myProfileBmiLabel.Name = "myProfileBmiLabel";
            this.myProfileBmiLabel.Size = new System.Drawing.Size(35, 13);
            this.myProfileBmiLabel.TabIndex = 12;
            this.myProfileBmiLabel.Text = "BMI : ";
            // 
            // myProfileLengthLabel
            // 
            this.myProfileLengthLabel.AutoSize = true;
            this.myProfileLengthLabel.Location = new System.Drawing.Point(4, 169);
            this.myProfileLengthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myProfileLengthLabel.Name = "myProfileLengthLabel";
            this.myProfileLengthLabel.Size = new System.Drawing.Size(49, 13);
            this.myProfileLengthLabel.TabIndex = 10;
            this.myProfileLengthLabel.Text = "Length : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 169);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Name : ";
            // 
            // myProfileWeightLabel
            // 
            this.myProfileWeightLabel.AutoSize = true;
            this.myProfileWeightLabel.Location = new System.Drawing.Point(4, 141);
            this.myProfileWeightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myProfileWeightLabel.Name = "myProfileWeightLabel";
            this.myProfileWeightLabel.Size = new System.Drawing.Size(50, 13);
            this.myProfileWeightLabel.TabIndex = 7;
            this.myProfileWeightLabel.Text = "Weight : ";
            // 
            // myProfileAgeLabel
            // 
            this.myProfileAgeLabel.AutoSize = true;
            this.myProfileAgeLabel.Location = new System.Drawing.Point(4, 115);
            this.myProfileAgeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myProfileAgeLabel.Name = "myProfileAgeLabel";
            this.myProfileAgeLabel.Size = new System.Drawing.Size(35, 13);
            this.myProfileAgeLabel.TabIndex = 5;
            this.myProfileAgeLabel.Text = "Age : ";
            // 
            // myProfileSurnameLabel
            // 
            this.myProfileSurnameLabel.AutoSize = true;
            this.myProfileSurnameLabel.Location = new System.Drawing.Point(4, 87);
            this.myProfileSurnameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myProfileSurnameLabel.Name = "myProfileSurnameLabel";
            this.myProfileSurnameLabel.Size = new System.Drawing.Size(69, 13);
            this.myProfileSurnameLabel.TabIndex = 2;
            this.myProfileSurnameLabel.Text = "Surname(s) : ";
            // 
            // myProfileNameLabel
            // 
            this.myProfileNameLabel.AutoSize = true;
            this.myProfileNameLabel.Location = new System.Drawing.Point(4, 59);
            this.myProfileNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myProfileNameLabel.Name = "myProfileNameLabel";
            this.myProfileNameLabel.Size = new System.Drawing.Size(44, 13);
            this.myProfileNameLabel.TabIndex = 0;
            this.myProfileNameLabel.Text = "Name : ";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SaveProfileListButton);
            this.tabPage1.Controls.Add(this.ProfileGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(768, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ProfileList";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SaveProfileListButton
            // 
            this.SaveProfileListButton.Location = new System.Drawing.Point(6, 371);
            this.SaveProfileListButton.Name = "SaveProfileListButton";
            this.SaveProfileListButton.Size = new System.Drawing.Size(97, 23);
            this.SaveProfileListButton.TabIndex = 2;
            this.SaveProfileListButton.Text = "Save to JSON";
            this.SaveProfileListButton.UseVisualStyleBackColor = true;
            this.SaveProfileListButton.Click += new System.EventHandler(this.SaveProfileListButton_Click);
            // 
            // ProfileGridView
            // 
            this.ProfileGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProfileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProfileGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.surname,
            this.age,
            this.weight,
            this.length,
            this.bmi});
            this.ProfileGridView.Location = new System.Drawing.Point(3, 3);
            this.ProfileGridView.Name = "ProfileGridView";
            this.ProfileGridView.RowHeadersWidth = 51;
            this.ProfileGridView.Size = new System.Drawing.Size(758, 362);
            this.ProfileGridView.TabIndex = 1;
            this.ProfileGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProfileGridView_CellContentClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            // 
            // surname
            // 
            this.surname.DataPropertyName = "surname";
            this.surname.HeaderText = "Surname";
            this.surname.MinimumWidth = 6;
            this.surname.Name = "surname";
            // 
            // age
            // 
            this.age.DataPropertyName = "age";
            this.age.HeaderText = "Age";
            this.age.MinimumWidth = 6;
            this.age.Name = "age";
            // 
            // weight
            // 
            this.weight.DataPropertyName = "weight";
            this.weight.HeaderText = "Weight";
            this.weight.MinimumWidth = 6;
            this.weight.Name = "weight";
            // 
            // length
            // 
            this.length.DataPropertyName = "length";
            this.length.HeaderText = "Length";
            this.length.MinimumWidth = 6;
            this.length.Name = "length";
            // 
            // bmi
            // 
            this.bmi.DataPropertyName = "bmi";
            this.bmi.HeaderText = "BMI";
            this.bmi.MinimumWidth = 6;
            this.bmi.Name = "bmi";
            // 
            // DrugList
            // 
            this.DrugList.Controls.Add(this.DrugGridView);
            this.DrugList.Location = new System.Drawing.Point(4, 22);
            this.DrugList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DrugList.Name = "DrugList";
            this.DrugList.Size = new System.Drawing.Size(768, 400);
            this.DrugList.TabIndex = 2;
            this.DrugList.Text = "DrugList";
            this.DrugList.UseVisualStyleBackColor = true;
            // 
            // DrugGridView
            // 
            this.DrugGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DrugGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DrugGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.drugId,
            this.drugName,
            this.drugDescription,
            this.drugType,
            this.drugDosage});
            this.DrugGridView.Location = new System.Drawing.Point(3, 3);
            this.DrugGridView.Name = "DrugGridView";
            this.DrugGridView.RowHeadersWidth = 51;
            this.DrugGridView.RowTemplate.Height = 24;
            this.DrugGridView.Size = new System.Drawing.Size(758, 394);
            this.DrugGridView.TabIndex = 1;
            // 
            // drugId
            // 
            this.drugId.HeaderText = "Drug ID";
            this.drugId.MinimumWidth = 6;
            this.drugId.Name = "drugId";
            // 
            // drugName
            // 
            this.drugName.HeaderText = "Drug name";
            this.drugName.MinimumWidth = 6;
            this.drugName.Name = "drugName";
            // 
            // drugDescription
            // 
            this.drugDescription.HeaderText = "Drug Description";
            this.drugDescription.MinimumWidth = 6;
            this.drugDescription.Name = "drugDescription";
            // 
            // drugType
            // 
            this.drugType.HeaderText = "Drug type";
            this.drugType.MinimumWidth = 6;
            this.drugType.Name = "drugType";
            // 
            // drugDosage
            // 
            this.drugDosage.HeaderText = "Drug Dosage";
            this.drugDosage.MinimumWidth = 6;
            this.drugDosage.Name = "drugDosage";
            // 
            // myProfileWeightRegistrationGroupBox
            // 
            this.myProfileWeightRegistrationGroupBox.Controls.Add(this.dataGridView1);
            this.myProfileWeightRegistrationGroupBox.Location = new System.Drawing.Point(733, 6);
            this.myProfileWeightRegistrationGroupBox.Name = "myProfileWeightRegistrationGroupBox";
            this.myProfileWeightRegistrationGroupBox.Size = new System.Drawing.Size(372, 554);
            this.myProfileWeightRegistrationGroupBox.TabIndex = 2;
            this.myProfileWeightRegistrationGroupBox.TabStop = false;
            this.myProfileWeightRegistrationGroupBox.Text = "Weight history";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.registeredWeight,
            this.registeredWeightDate});
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(363, 528);
            this.dataGridView1.TabIndex = 0;
            // 
            // registeredWeight
            // 
            this.registeredWeight.HeaderText = "Weight (KG)";
            this.registeredWeight.Name = "registeredWeight";
            this.registeredWeight.ReadOnly = true;
            // 
            // registeredWeightDate
            // 
            this.registeredWeightDate.HeaderText = "Registered on:";
            this.registeredWeightDate.Name = "registeredWeightDate";
            this.registeredWeightDate.ReadOnly = true;
            // 
            // ZorgApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 606);
            this.Controls.Add(this.tabs);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ZorgApp";
            this.Text = "VisualZorgApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabs.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.myProfilePrescribedDrugsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrescribedDrugsGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProfileGridView)).EndInit();
            this.DrugList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DrugGridView)).EndInit();
            this.myProfileWeightRegistrationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView ProfileGridView;
        private System.Windows.Forms.Button SaveProfileListButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn age;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn bmi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label myProfileNameLabel;
        private System.Windows.Forms.Label myProfileAgeLabel;
        private System.Windows.Forms.Label myProfileSurnameLabel;
        private System.Windows.Forms.Label myProfileRoleIdLabel;
        private System.Windows.Forms.Label myProfileBmiLabel;
        private System.Windows.Forms.Label myProfileLengthLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label myProfileWeightLabel;
        private System.Windows.Forms.Label myProfileIdLabel;
        private System.Windows.Forms.TabPage DrugList;
        private System.Windows.Forms.GroupBox myProfilePrescribedDrugsGroupBox;
        private System.Windows.Forms.DataGridView DrugGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn drugId;
        private System.Windows.Forms.DataGridViewTextBoxColumn drugName;
        private System.Windows.Forms.DataGridViewTextBoxColumn drugDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn drugType;
        private System.Windows.Forms.DataGridViewTextBoxColumn drugDosage;
        private System.Windows.Forms.Label myProfileRoleNameLabel;
        private System.Windows.Forms.DataGridView PrescribedDrugsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn prescribedDrugName;
        private System.Windows.Forms.DataGridViewTextBoxColumn prescribedDrugIntakeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn prescribedDrugStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn prescribedDrugEndDate;
        private System.Windows.Forms.GroupBox myProfileWeightRegistrationGroupBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn registeredWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn registeredWeightDate;
    }
}


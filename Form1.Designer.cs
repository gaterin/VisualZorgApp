namespace VisualZorgApp
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SaveProfileListButton = new System.Windows.Forms.Button();
            this.ProfileGridView = new System.Windows.Forms.DataGridView();
            this.RenderAllButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bmi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(776, 426);
            this.tabs.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SaveProfileListButton);
            this.tabPage1.Controls.Add(this.ProfileGridView);
            this.tabPage1.Controls.Add(this.RenderAllButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ProfileList";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SaveProfileListButton
            // 
            this.SaveProfileListButton.Location = new System.Drawing.Point(115, 374);
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
            this.ProfileGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ProfileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProfileGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.surname,
            this.age,
            this.length,
            this.weight,
            this.bmi});
            this.ProfileGridView.Location = new System.Drawing.Point(6, 6);
            this.ProfileGridView.Name = "ProfileGridView";
            this.ProfileGridView.Size = new System.Drawing.Size(756, 362);
            this.ProfileGridView.TabIndex = 1;
            this.ProfileGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProfileGridView_CellContentClick);
            // 
            // RenderAllButton
            // 
            this.RenderAllButton.Location = new System.Drawing.Point(3, 374);
            this.RenderAllButton.Name = "RenderAllButton";
            this.RenderAllButton.Size = new System.Drawing.Size(106, 23);
            this.RenderAllButton.TabIndex = 0;
            this.RenderAllButton.Text = "Render All Profiles";
            this.RenderAllButton.UseVisualStyleBackColor = true;
            this.RenderAllButton.Click += new System.EventHandler(this.RenderAllButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MyProfile";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            // 
            // surname
            // 
            this.surname.DataPropertyName = "surname";
            this.surname.HeaderText = "Surname";
            this.surname.Name = "surname";
            // 
            // age
            // 
            this.age.DataPropertyName = "age";
            this.age.HeaderText = "Age";
            this.age.Name = "age";
            // 
            // length
            // 
            this.length.DataPropertyName = "length";
            this.length.HeaderText = "Length";
            this.length.Name = "length";
            // 
            // weight
            // 
            this.weight.DataPropertyName = "weight";
            this.weight.HeaderText = "Weight";
            this.weight.Name = "weight";
            // 
            // bmi
            // 
            this.bmi.DataPropertyName = "bmi";
            this.bmi.HeaderText = "BMI";
            this.bmi.Name = "bmi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabs);
            this.Name = "Form1";
            this.Text = "VisualZorgApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProfileGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button RenderAllButton;
        private System.Windows.Forms.DataGridView ProfileGridView;
        private System.Windows.Forms.Button SaveProfileListButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn age;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn bmi;
    }
}


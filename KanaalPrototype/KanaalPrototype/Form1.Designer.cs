
namespace KanaalPrototype
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
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.btnEditChannel = new System.Windows.Forms.Button();
            this.lbEditName = new System.Windows.Forms.Label();
            this.lbEditDescription = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUsersRemove = new System.Windows.Forms.ComboBox();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.cbAllUsers = new System.Windows.Forms.ComboBox();
            this.lbChannels = new System.Windows.Forms.ListBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.tbChannel = new System.Windows.Forms.TextBox();
            this.btnAddChannel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(623, 108);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(100, 22);
            this.tbDescription.TabIndex = 1;
            this.tbDescription.Visible = false;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(623, 50);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 22);
            this.tbName.TabIndex = 2;
            this.tbName.Visible = false;
            this.tbName.WordWrap = false;
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Location = new System.Drawing.Point(623, 323);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEdit.TabIndex = 3;
            this.btnSaveEdit.Text = "Save";
            this.btnSaveEdit.UseVisualStyleBackColor = true;
            this.btnSaveEdit.Visible = false;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(12, 9);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 17);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "General";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(12, 35);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(140, 17);
            this.lbDescription.TabIndex = 5;
            this.lbDescription.Text = "Welcome to General!";
            // 
            // btnEditChannel
            // 
            this.btnEditChannel.Location = new System.Drawing.Point(166, 6);
            this.btnEditChannel.Name = "btnEditChannel";
            this.btnEditChannel.Size = new System.Drawing.Size(75, 23);
            this.btnEditChannel.TabIndex = 6;
            this.btnEditChannel.Text = "Edit";
            this.btnEditChannel.UseVisualStyleBackColor = true;
            this.btnEditChannel.Click += new System.EventHandler(this.btnEditChannel_Click);
            // 
            // lbEditName
            // 
            this.lbEditName.AutoSize = true;
            this.lbEditName.Location = new System.Drawing.Point(620, 30);
            this.lbEditName.Name = "lbEditName";
            this.lbEditName.Size = new System.Drawing.Size(49, 17);
            this.lbEditName.TabIndex = 7;
            this.lbEditName.Text = "Name:";
            this.lbEditName.Visible = false;
            // 
            // lbEditDescription
            // 
            this.lbEditDescription.AutoSize = true;
            this.lbEditDescription.Location = new System.Drawing.Point(620, 88);
            this.lbEditDescription.Name = "lbEditDescription";
            this.lbEditDescription.Size = new System.Drawing.Size(83, 17);
            this.lbEditDescription.TabIndex = 8;
            this.lbEditDescription.Text = "Description:";
            this.lbEditDescription.Visible = false;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(623, 197);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 10;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Visible = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.ItemHeight = 16;
            this.lbUsers.Location = new System.Drawing.Point(15, 118);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(148, 228);
            this.lbUsers.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(620, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "User Name:";
            this.label1.Visible = false;
            // 
            // cbUsersRemove
            // 
            this.cbUsersRemove.FormattingEnabled = true;
            this.cbUsersRemove.Location = new System.Drawing.Point(623, 237);
            this.cbUsersRemove.Name = "cbUsersRemove";
            this.cbUsersRemove.Size = new System.Drawing.Size(121, 24);
            this.cbUsersRemove.TabIndex = 13;
            this.cbUsersRemove.Visible = false;
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Location = new System.Drawing.Point(623, 278);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveUser.TabIndex = 14;
            this.btnRemoveUser.Text = "Remove";
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Visible = false;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // cbAllUsers
            // 
            this.cbAllUsers.FormattingEnabled = true;
            this.cbAllUsers.Location = new System.Drawing.Point(623, 165);
            this.cbAllUsers.Name = "cbAllUsers";
            this.cbAllUsers.Size = new System.Drawing.Size(121, 24);
            this.cbAllUsers.TabIndex = 15;
            this.cbAllUsers.Visible = false;
            // 
            // lbChannels
            // 
            this.lbChannels.FormattingEnabled = true;
            this.lbChannels.ItemHeight = 16;
            this.lbChannels.Location = new System.Drawing.Point(263, 118);
            this.lbChannels.Name = "lbChannels";
            this.lbChannels.Size = new System.Drawing.Size(152, 228);
            this.lbChannels.TabIndex = 18;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(260, 87);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(152, 25);
            this.btnInsert.TabIndex = 19;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // tbChannel
            // 
            this.tbChannel.Location = new System.Drawing.Point(260, 59);
            this.tbChannel.Name = "tbChannel";
            this.tbChannel.Size = new System.Drawing.Size(152, 22);
            this.tbChannel.TabIndex = 20;
            // 
            // btnAddChannel
            // 
            this.btnAddChannel.Location = new System.Drawing.Point(263, 6);
            this.btnAddChannel.Name = "btnAddChannel";
            this.btnAddChannel.Size = new System.Drawing.Size(104, 23);
            this.btnAddChannel.TabIndex = 21;
            this.btnAddChannel.Text = "Add Channel";
            this.btnAddChannel.UseVisualStyleBackColor = true;
            this.btnAddChannel.Click += new System.EventHandler(this.btnAddChannel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(260, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddChannel);
            this.Controls.Add(this.tbChannel);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.lbChannels);
            this.Controls.Add(this.cbAllUsers);
            this.Controls.Add(this.btnRemoveUser);
            this.Controls.Add(this.cbUsersRemove);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.lbEditDescription);
            this.Controls.Add(this.lbEditName);
            this.Controls.Add(this.btnEditChannel);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btnSaveEdit);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbDescription);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Button btnEditChannel;
        private System.Windows.Forms.Label lbEditName;
        private System.Windows.Forms.Label lbEditDescription;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUsersRemove;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.ComboBox cbAllUsers;
        private System.Windows.Forms.ListBox lbChannels;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox tbChannel;
        private System.Windows.Forms.Button btnAddChannel;
        private System.Windows.Forms.Button btnSave;
    }
}


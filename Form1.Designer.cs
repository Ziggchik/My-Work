namespace WeaponStore
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
            this.cbDatabases = new System.Windows.Forms.ComboBox();
            this.cbServers = new System.Windows.Forms.ComboBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btChecked = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbDatabases
            // 
            this.cbDatabases.FormattingEnabled = true;
            this.cbDatabases.Location = new System.Drawing.Point(142, 211);
            this.cbDatabases.Name = "cbDatabases";
            this.cbDatabases.Size = new System.Drawing.Size(514, 21);
            this.cbDatabases.TabIndex = 28;
            // 
            // cbServers
            // 
            this.cbServers.FormattingEnabled = true;
            this.cbServers.Items.AddRange(new object[] {
            "DESKTOP-F28KLAR\\SQLEXPRESS"});
            this.cbServers.Location = new System.Drawing.Point(142, 146);
            this.cbServers.Name = "cbServers";
            this.cbServers.Size = new System.Drawing.Size(514, 21);
            this.cbServers.TabIndex = 27;
            this.cbServers.SelectedIndexChanged += new System.EventHandler(this.CbServers_SelectedIndexChanged);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(499, 255);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(159, 74);
            this.btCancel.TabIndex = 26;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // btChecked
            // 
            this.btChecked.Location = new System.Drawing.Point(144, 255);
            this.btChecked.Name = "btChecked";
            this.btChecked.Size = new System.Drawing.Size(178, 74);
            this.btChecked.TabIndex = 25;
            this.btChecked.Text = "Проверка подключения";
            this.btChecked.UseVisualStyleBackColor = true;
            this.btChecked.Click += new System.EventHandler(this.BtChecked_Click);
            // 
            // btConnect
            // 
            this.btConnect.Enabled = false;
            this.btConnect.Location = new System.Drawing.Point(323, 255);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(176, 74);
            this.btConnect.TabIndex = 24;
            this.btConnect.Text = "Подключиться";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.BtConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(334, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 22);
            this.label2.TabIndex = 23;
            this.label2.Text = "Название базы данных";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(334, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "Название сервера";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbDatabases);
            this.Controls.Add(this.cbServers);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btChecked);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Подключение";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDatabases;
        private System.Windows.Forms.ComboBox cbServers;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btChecked;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
namespace CLIM
{
    partial class AddLoader
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
            tbinputlhd = new TextBox();
            label1 = new Label();
            btnsavelhd = new Button();
            btnclose = new Button();
            SuspendLayout();
            // 
            // tbinputlhd
            // 
            tbinputlhd.BorderStyle = BorderStyle.FixedSingle;
            tbinputlhd.Location = new Point(144, 12);
            tbinputlhd.Name = "tbinputlhd";
            tbinputlhd.Size = new Size(215, 31);
            tbinputlhd.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 15);
            label1.Name = "label1";
            label1.Size = new Size(66, 25);
            label1.TabIndex = 21;
            label1.Text = "Loader";
            // 
            // btnsavelhd
            // 
            btnsavelhd.Location = new Point(103, 78);
            btnsavelhd.Name = "btnsavelhd";
            btnsavelhd.Size = new Size(112, 34);
            btnsavelhd.TabIndex = 23;
            btnsavelhd.Text = "Submit";
            btnsavelhd.UseVisualStyleBackColor = true;
            btnsavelhd.Click += btnsavelhd_Click;
            // 
            // btnclose
            // 
            btnclose.Location = new Point(221, 78);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(112, 34);
            btnclose.TabIndex = 24;
            btnclose.Text = "Close";
            btnclose.UseVisualStyleBackColor = true;
            btnclose.Click += btnclose_Click;
            // 
            // AddLoader
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 146);
            Controls.Add(btnclose);
            Controls.Add(btnsavelhd);
            Controls.Add(tbinputlhd);
            Controls.Add(label1);
            Name = "AddLoader";
            Text = "AddLoader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbinputlhd;
        private Label label1;
        private Button btnsavelhd;
        private Button btnclose;
    }
}
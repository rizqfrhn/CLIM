namespace CLIM
{
    partial class FormLoader
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
            btnping = new Button();
            btnsave = new Button();
            label2 = new Label();
            cbloader = new ComboBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            tbinputbsm = new TextBox();
            tbdatabsm = new TextBox();
            label6 = new Label();
            label7 = new Label();
            tbdatarsm = new TextBox();
            tbinputrsm = new TextBox();
            tbdatarouter = new TextBox();
            tbinputrouter = new TextBox();
            tbdataoru = new TextBox();
            tbinputoru = new TextBox();
            label8 = new Label();
            menuStrip1 = new MenuStrip();
            addLoaderToolStripMenuItem = new ToolStripMenuItem();
            scanIPLoaderToolStripMenuItem = new ToolStripMenuItem();
            scanningIPToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnping
            // 
            btnping.Location = new Point(328, 295);
            btnping.Margin = new Padding(2);
            btnping.Name = "btnping";
            btnping.Size = new Size(78, 25);
            btnping.TabIndex = 6;
            btnping.Text = "Ping";
            btnping.UseVisualStyleBackColor = true;
            btnping.Click += btnping_Click;
            // 
            // btnsave
            // 
            btnsave.Location = new Point(242, 295);
            btnsave.Margin = new Padding(2);
            btnsave.Name = "btnsave";
            btnsave.Size = new Size(78, 25);
            btnsave.TabIndex = 5;
            btnsave.Text = "Submit";
            btnsave.UseVisualStyleBackColor = true;
            btnsave.Click += btnsave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 104);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 9;
            label2.Text = "Loader";
            // 
            // cbloader
            // 
            cbloader.Location = new Point(181, 102);
            cbloader.Margin = new Padding(2);
            cbloader.Name = "cbloader";
            cbloader.Size = new Size(157, 23);
            cbloader.TabIndex = 7;
            cbloader.SelectedIndexChanged += cbloader_SelectedIndexChanged;
            cbloader.KeyDown += cbloader_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 189);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 16;
            label1.Text = "BSM";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 209);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 17;
            label3.Text = "RSM";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(88, 249);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 19;
            label4.Text = "Router";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(88, 229);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 18;
            label5.Text = "ORU";
            // 
            // tbinputbsm
            // 
            tbinputbsm.BorderStyle = BorderStyle.FixedSingle;
            tbinputbsm.Location = new Point(174, 187);
            tbinputbsm.Margin = new Padding(2);
            tbinputbsm.Name = "tbinputbsm";
            tbinputbsm.Size = new Size(151, 23);
            tbinputbsm.TabIndex = 1;
            // 
            // tbdatabsm
            // 
            tbdatabsm.BorderStyle = BorderStyle.FixedSingle;
            tbdatabsm.Location = new Point(324, 187);
            tbdatabsm.Margin = new Padding(2);
            tbdatabsm.Name = "tbdatabsm";
            tbdatabsm.ReadOnly = true;
            tbdatabsm.Size = new Size(151, 23);
            tbdatabsm.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(229, 157);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 22;
            label6.Text = "Input ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(361, 157);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 23;
            label7.Text = "Updated Data";
            // 
            // tbdatarsm
            // 
            tbdatarsm.BorderStyle = BorderStyle.FixedSingle;
            tbdatarsm.Location = new Point(324, 207);
            tbdatarsm.Margin = new Padding(2);
            tbdatarsm.Name = "tbdatarsm";
            tbdatarsm.ReadOnly = true;
            tbdatarsm.Size = new Size(151, 23);
            tbdatarsm.TabIndex = 25;
            // 
            // tbinputrsm
            // 
            tbinputrsm.BorderStyle = BorderStyle.FixedSingle;
            tbinputrsm.Location = new Point(174, 207);
            tbinputrsm.Margin = new Padding(2);
            tbinputrsm.Name = "tbinputrsm";
            tbinputrsm.Size = new Size(151, 23);
            tbinputrsm.TabIndex = 2;
            // 
            // tbdatarouter
            // 
            tbdatarouter.BorderStyle = BorderStyle.FixedSingle;
            tbdatarouter.Location = new Point(324, 247);
            tbdatarouter.Margin = new Padding(2);
            tbdatarouter.Name = "tbdatarouter";
            tbdatarouter.ReadOnly = true;
            tbdatarouter.Size = new Size(151, 23);
            tbdatarouter.TabIndex = 29;
            // 
            // tbinputrouter
            // 
            tbinputrouter.BorderStyle = BorderStyle.FixedSingle;
            tbinputrouter.Location = new Point(174, 247);
            tbinputrouter.Margin = new Padding(2);
            tbinputrouter.Name = "tbinputrouter";
            tbinputrouter.Size = new Size(151, 23);
            tbinputrouter.TabIndex = 4;
            // 
            // tbdataoru
            // 
            tbdataoru.BorderStyle = BorderStyle.FixedSingle;
            tbdataoru.Location = new Point(324, 227);
            tbdataoru.Margin = new Padding(2);
            tbdataoru.Name = "tbdataoru";
            tbdataoru.ReadOnly = true;
            tbdataoru.Size = new Size(151, 23);
            tbdataoru.TabIndex = 27;
            // 
            // tbinputoru
            // 
            tbinputoru.BorderStyle = BorderStyle.FixedSingle;
            tbinputoru.Location = new Point(174, 227);
            tbinputoru.Margin = new Padding(2);
            tbinputoru.Name = "tbinputoru";
            tbinputoru.Size = new Size(151, 23);
            tbinputoru.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(143, 32);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(273, 21);
            label8.TabIndex = 30;
            label8.Text = "COMMAND LHD IP MANAGEMENT";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { addLoaderToolStripMenuItem, scanIPLoaderToolStripMenuItem, scanningIPToolStripMenuItem, refreshToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(577, 24);
            menuStrip1.TabIndex = 31;
            menuStrip1.Text = "menuStrip1";
            // 
            // addLoaderToolStripMenuItem
            // 
            addLoaderToolStripMenuItem.Name = "addLoaderToolStripMenuItem";
            addLoaderToolStripMenuItem.Size = new Size(80, 22);
            addLoaderToolStripMenuItem.Text = "Add Loader";
            addLoaderToolStripMenuItem.Click += addLoaderToolStripMenuItem_Click;
            // 
            // scanIPLoaderToolStripMenuItem
            // 
            scanIPLoaderToolStripMenuItem.Name = "scanIPLoaderToolStripMenuItem";
            scanIPLoaderToolStripMenuItem.Size = new Size(96, 22);
            scanIPLoaderToolStripMenuItem.Text = "Scan IP Loader";
            scanIPLoaderToolStripMenuItem.Click += scanIPLoaderToolStripMenuItem_Click;
            // 
            // scanningIPToolStripMenuItem
            // 
            scanningIPToolStripMenuItem.Name = "scanningIPToolStripMenuItem";
            scanningIPToolStripMenuItem.Size = new Size(134, 22);
            scanningIPToolStripMenuItem.Text = "Scan IP BSM and RSM";
            scanningIPToolStripMenuItem.Click += scanningIPToolStripMenuItem_Click;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(58, 22);
            refreshToolStripMenuItem.Text = "Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // FormLoader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 359);
            Controls.Add(label8);
            Controls.Add(tbdatarouter);
            Controls.Add(tbinputrouter);
            Controls.Add(tbdataoru);
            Controls.Add(tbinputoru);
            Controls.Add(tbdatarsm);
            Controls.Add(tbinputrsm);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(tbdatabsm);
            Controls.Add(tbinputbsm);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(cbloader);
            Controls.Add(btnping);
            Controls.Add(btnsave);
            Controls.Add(label2);
            Controls.Add(menuStrip1);
            Margin = new Padding(2);
            Name = "FormLoader";
            Text = "FormLoader";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnping;
        private Button btnsave;
        private Label label2;
        private ComboBox cbloader;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox tbinputbsm;
        private TextBox tbdatabsm;
        private Label label6;
        private Label label7;
        private TextBox tbdatarsm;
        private TextBox tbinputrsm;
        private TextBox tbdatarouter;
        private TextBox tbinputrouter;
        private TextBox tbdataoru;
        private TextBox tbinputoru;
        private Label label8;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem addLoaderToolStripMenuItem;
        private ToolStripMenuItem scanningIPToolStripMenuItem;
        private ToolStripMenuItem scanIPLoaderToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
    }
}
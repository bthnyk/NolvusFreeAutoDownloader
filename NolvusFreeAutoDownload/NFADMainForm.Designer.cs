namespace NolvusFreeAutoDownloader
{
    partial class NfadMainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NfadMainForm));
            this.l_MTitle = new System.Windows.Forms.Label();
            this.l_Decs = new System.Windows.Forms.Label();
            this.l_Path = new System.Windows.Forms.Label();
            this.btn_ToggleTheme = new System.Windows.Forms.Button();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.p_Top = new System.Windows.Forms.Panel();
            this.btn_LangSwitch = new System.Windows.Forms.Button();
            this.p_Bot = new System.Windows.Forms.Panel();
            this.rtb_Output = new System.Windows.Forms.RichTextBox();
            this.tlp_SS = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.tlp_Mid = new System.Windows.Forms.TableLayoutPanel();
            this.p_Mid = new System.Windows.Forms.Panel();
            this.tlp_MidLeft = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.tlp_marger = new System.Windows.Forms.TableLayoutPanel();
            this.tb_Path = new System.Windows.Forms.TextBox();
            this.p_WaitSeconds = new System.Windows.Forms.Panel();
            this.l_Secs = new System.Windows.Forms.Label();
            this.l_Wait = new System.Windows.Forms.Label();
            this.nud_WaitSeconds = new System.Windows.Forms.NumericUpDown();
            this.tlp_Main.SuspendLayout();
            this.p_Top.SuspendLayout();
            this.p_Bot.SuspendLayout();
            this.tlp_SS.SuspendLayout();
            this.tlp_Mid.SuspendLayout();
            this.p_Mid.SuspendLayout();
            this.tlp_MidLeft.SuspendLayout();
            this.tlp_marger.SuspendLayout();
            this.p_WaitSeconds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_WaitSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // l_MTitle
            // 
            this.l_MTitle.AutoSize = true;
            this.l_MTitle.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.l_MTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_MTitle.Location = new System.Drawing.Point(4, 6);
            this.l_MTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_MTitle.Name = "l_MTitle";
            this.l_MTitle.Size = new System.Drawing.Size(280, 21);
            this.l_MTitle.TabIndex = 1;
            this.l_MTitle.Text = "HeX tarafından hazırlanmıştır!";
            // 
            // l_Decs
            // 
            this.l_Decs.AutoSize = true;
            this.l_Decs.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.l_Decs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_Decs.Location = new System.Drawing.Point(5, 27);
            this.l_Decs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_Decs.Name = "l_Decs";
            this.l_Decs.Size = new System.Drawing.Size(456, 17);
            this.l_Decs.TabIndex = 2;
            this.l_Decs.Text = "Nolvus Dashboard için oto-indirme tıklaması yapmaktadır.";
            // 
            // l_Path
            // 
            this.l_Path.AutoSize = true;
            this.l_Path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Path.Location = new System.Drawing.Point(4, 0);
            this.l_Path.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_Path.Name = "l_Path";
            this.l_Path.Size = new System.Drawing.Size(217, 46);
            this.l_Path.TabIndex = 3;
            this.l_Path.Text = "Nolvus Dashboard Yolu :";
            this.l_Path.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ToggleTheme
            // 
            this.btn_ToggleTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ToggleTheme.Location = new System.Drawing.Point(951, 6);
            this.btn_ToggleTheme.Name = "btn_ToggleTheme";
            this.btn_ToggleTheme.Size = new System.Drawing.Size(40, 40);
            this.btn_ToggleTheme.TabIndex = 4;
            this.btn_ToggleTheme.Text = ".";
            this.btn_ToggleTheme.UseVisualStyleBackColor = true;
            this.btn_ToggleTheme.Click += new System.EventHandler(this.btn_ToggleTheme_Click);
            // 
            // tlp_Main
            // 
            this.tlp_Main.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.p_Top, 0, 0);
            this.tlp_Main.Controls.Add(this.p_Bot, 0, 3);
            this.tlp_Main.Controls.Add(this.tlp_SS, 0, 2);
            this.tlp_Main.Controls.Add(this.tlp_Mid, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 4;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(1008, 729);
            this.tlp_Main.TabIndex = 5;
            // 
            // p_Top
            // 
            this.p_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Top.Controls.Add(this.btn_LangSwitch);
            this.p_Top.Controls.Add(this.l_Decs);
            this.p_Top.Controls.Add(this.btn_ToggleTheme);
            this.p_Top.Controls.Add(this.l_MTitle);
            this.p_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Top.Location = new System.Drawing.Point(4, 4);
            this.p_Top.Name = "p_Top";
            this.p_Top.Size = new System.Drawing.Size(1000, 54);
            this.p_Top.TabIndex = 0;
            // 
            // btn_LangSwitch
            // 
            this.btn_LangSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LangSwitch.Location = new System.Drawing.Point(905, 6);
            this.btn_LangSwitch.Name = "btn_LangSwitch";
            this.btn_LangSwitch.Size = new System.Drawing.Size(40, 40);
            this.btn_LangSwitch.TabIndex = 6;
            this.btn_LangSwitch.Text = ",";
            this.btn_LangSwitch.UseVisualStyleBackColor = true;
            this.btn_LangSwitch.Click += new System.EventHandler(this.btn_LangSwitch_Click);
            // 
            // p_Bot
            // 
            this.p_Bot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Bot.Controls.Add(this.rtb_Output);
            this.p_Bot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Bot.Location = new System.Drawing.Point(4, 182);
            this.p_Bot.Name = "p_Bot";
            this.p_Bot.Size = new System.Drawing.Size(1000, 543);
            this.p_Bot.TabIndex = 6;
            // 
            // rtb_Output
            // 
            this.rtb_Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Output.Location = new System.Drawing.Point(0, 0);
            this.rtb_Output.Name = "rtb_Output";
            this.rtb_Output.ReadOnly = true;
            this.rtb_Output.Size = new System.Drawing.Size(998, 541);
            this.rtb_Output.TabIndex = 0;
            this.rtb_Output.Text = "";
            // 
            // tlp_SS
            // 
            this.tlp_SS.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp_SS.ColumnCount = 2;
            this.tlp_SS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_SS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_SS.Controls.Add(this.btn_Start, 0, 0);
            this.tlp_SS.Controls.Add(this.btn_Stop, 1, 0);
            this.tlp_SS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_SS.Location = new System.Drawing.Point(4, 126);
            this.tlp_SS.Name = "tlp_SS";
            this.tlp_SS.RowCount = 1;
            this.tlp_SS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_SS.Size = new System.Drawing.Size(1000, 49);
            this.tlp_SS.TabIndex = 7;
            // 
            // btn_Start
            // 
            this.btn_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Start.Location = new System.Drawing.Point(4, 4);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(492, 41);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Başlat";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Stop.Location = new System.Drawing.Point(503, 4);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(493, 41);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "Durdur";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // tlp_Mid
            // 
            this.tlp_Mid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp_Mid.ColumnCount = 2;
            this.tlp_Mid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Mid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlp_Mid.Controls.Add(this.p_Mid, 0, 0);
            this.tlp_Mid.Controls.Add(this.p_WaitSeconds, 1, 0);
            this.tlp_Mid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Mid.Location = new System.Drawing.Point(4, 65);
            this.tlp_Mid.Name = "tlp_Mid";
            this.tlp_Mid.RowCount = 1;
            this.tlp_Mid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Mid.Size = new System.Drawing.Size(1000, 54);
            this.tlp_Mid.TabIndex = 8;
            // 
            // p_Mid
            // 
            this.p_Mid.Controls.Add(this.tlp_MidLeft);
            this.p_Mid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Mid.Location = new System.Drawing.Point(4, 4);
            this.p_Mid.Name = "p_Mid";
            this.p_Mid.Size = new System.Drawing.Size(831, 46);
            this.p_Mid.TabIndex = 4;
            // 
            // tlp_MidLeft
            // 
            this.tlp_MidLeft.ColumnCount = 3;
            this.tlp_MidLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tlp_MidLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_MidLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tlp_MidLeft.Controls.Add(this.l_Path, 0, 0);
            this.tlp_MidLeft.Controls.Add(this.btn_Browse, 2, 0);
            this.tlp_MidLeft.Controls.Add(this.tlp_marger, 1, 0);
            this.tlp_MidLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_MidLeft.Location = new System.Drawing.Point(0, 0);
            this.tlp_MidLeft.Name = "tlp_MidLeft";
            this.tlp_MidLeft.RowCount = 1;
            this.tlp_MidLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_MidLeft.Size = new System.Drawing.Size(831, 46);
            this.tlp_MidLeft.TabIndex = 6;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Browse.Location = new System.Drawing.Point(685, 3);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(143, 40);
            this.btn_Browse.TabIndex = 5;
            this.btn_Browse.Text = "Göz At";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // tlp_marger
            // 
            this.tlp_marger.ColumnCount = 1;
            this.tlp_marger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_marger.Controls.Add(this.tb_Path, 0, 1);
            this.tlp_marger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_marger.Location = new System.Drawing.Point(228, 3);
            this.tlp_marger.Name = "tlp_marger";
            this.tlp_marger.RowCount = 3;
            this.tlp_marger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_marger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_marger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_marger.Size = new System.Drawing.Size(451, 40);
            this.tlp_marger.TabIndex = 6;
            // 
            // tb_Path
            // 
            this.tb_Path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Path.Location = new System.Drawing.Point(3, 8);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.ReadOnly = true;
            this.tb_Path.Size = new System.Drawing.Size(445, 26);
            this.tb_Path.TabIndex = 0;
            this.tb_Path.WordWrap = false;
            // 
            // p_WaitSeconds
            // 
            this.p_WaitSeconds.Controls.Add(this.l_Secs);
            this.p_WaitSeconds.Controls.Add(this.l_Wait);
            this.p_WaitSeconds.Controls.Add(this.nud_WaitSeconds);
            this.p_WaitSeconds.Location = new System.Drawing.Point(842, 4);
            this.p_WaitSeconds.Name = "p_WaitSeconds";
            this.p_WaitSeconds.Size = new System.Drawing.Size(154, 46);
            this.p_WaitSeconds.TabIndex = 5;
            // 
            // l_Secs
            // 
            this.l_Secs.AutoSize = true;
            this.l_Secs.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.l_Secs.Location = new System.Drawing.Point(22, 23);
            this.l_Secs.Name = "l_Secs";
            this.l_Secs.Size = new System.Drawing.Size(56, 17);
            this.l_Secs.TabIndex = 2;
            this.l_Secs.Text = "saniye";
            // 
            // l_Wait
            // 
            this.l_Wait.AutoSize = true;
            this.l_Wait.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.l_Wait.Location = new System.Drawing.Point(6, 6);
            this.l_Wait.Name = "l_Wait";
            this.l_Wait.Size = new System.Drawing.Size(88, 17);
            this.l_Wait.TabIndex = 1;
            this.l_Wait.Text = "Beklenecek";
            // 
            // nud_WaitSeconds
            // 
            this.nud_WaitSeconds.Location = new System.Drawing.Point(100, 11);
            this.nud_WaitSeconds.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_WaitSeconds.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_WaitSeconds.Name = "nud_WaitSeconds";
            this.nud_WaitSeconds.Size = new System.Drawing.Size(46, 26);
            this.nud_WaitSeconds.TabIndex = 0;
            this.nud_WaitSeconds.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // NfadMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.tlp_Main);
            this.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "NfadMainForm";
            this.Text = "HeX | Nolvus Dashboard | Oto-indirici Sihirbazı";
            this.tlp_Main.ResumeLayout(false);
            this.p_Top.ResumeLayout(false);
            this.p_Top.PerformLayout();
            this.p_Bot.ResumeLayout(false);
            this.tlp_SS.ResumeLayout(false);
            this.tlp_Mid.ResumeLayout(false);
            this.p_Mid.ResumeLayout(false);
            this.tlp_MidLeft.ResumeLayout(false);
            this.tlp_MidLeft.PerformLayout();
            this.tlp_marger.ResumeLayout(false);
            this.tlp_marger.PerformLayout();
            this.p_WaitSeconds.ResumeLayout(false);
            this.p_WaitSeconds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_WaitSeconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label l_MTitle;
        private System.Windows.Forms.Label l_Decs;
        private System.Windows.Forms.Label l_Path;
        private System.Windows.Forms.Button btn_ToggleTheme;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.Panel p_Top;
        private System.Windows.Forms.Panel p_Mid;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.RichTextBox rtb_Output;
        private System.Windows.Forms.Panel p_Bot;
        private System.Windows.Forms.TableLayoutPanel tlp_SS;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.TableLayoutPanel tlp_Mid;
        private System.Windows.Forms.Panel p_WaitSeconds;
        private System.Windows.Forms.Label l_Wait;
        private System.Windows.Forms.NumericUpDown nud_WaitSeconds;
        private System.Windows.Forms.Label l_Secs;
        private System.Windows.Forms.TableLayoutPanel tlp_MidLeft;
        private System.Windows.Forms.TableLayoutPanel tlp_marger;
        private System.Windows.Forms.TextBox tb_Path;
        private System.Windows.Forms.Button btn_LangSwitch;
    }
}


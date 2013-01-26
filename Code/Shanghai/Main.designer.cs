namespace Shanghai
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.UORTButton = new System.Windows.Forms.Button();
            this.UserViewButton = new System.Windows.Forms.Button();
            this.RTButton = new System.Windows.Forms.Button();
            this.FavButton = new System.Windows.Forms.Button();
            this.ActiveStatusView = new System.Windows.Forms.ListView();
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tweet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PostCount = new System.Windows.Forms.Label();
            this.PostButton = new System.Windows.Forms.Button();
            this.PostText = new System.Windows.Forms.TextBox();
            this.AccountsList = new System.Windows.Forms.ListBox();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip.Location = new System.Drawing.Point(0, 389);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 23);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(44, 18);
            this.Status.Text = "Ready";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 26);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(51, 22);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem,
            this.columnToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(65, 22);
            this.accountsToolStripMenuItem.Text = "Manage";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(46, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.UORTButton);
            this.panel1.Controls.Add(this.UserViewButton);
            this.panel1.Controls.Add(this.RTButton);
            this.panel1.Controls.Add(this.FavButton);
            this.panel1.Controls.Add(this.ActiveStatusView);
            this.panel1.Controls.Add(this.PostCount);
            this.panel1.Controls.Add(this.PostButton);
            this.panel1.Controls.Add(this.PostText);
            this.panel1.Controls.Add(this.AccountsList);
            this.panel1.Location = new System.Drawing.Point(0, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 97);
            this.panel1.TabIndex = 5;
            // 
            // UORTButton
            // 
            this.UORTButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UORTButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UORTButton.BackgroundImage")));
            this.UORTButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UORTButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.UORTButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UORTButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UORTButton.ForeColor = System.Drawing.Color.Blue;
            this.UORTButton.Location = new System.Drawing.Point(599, 20);
            this.UORTButton.Name = "UORTButton";
            this.UORTButton.Size = new System.Drawing.Size(28, 24);
            this.UORTButton.TabIndex = 8;
            this.UORTButton.Text = "Q";
            this.UORTButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.UORTButton.UseVisualStyleBackColor = true;
            // 
            // UserViewButton
            // 
            this.UserViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserViewButton.BackColor = System.Drawing.Color.Transparent;
            this.UserViewButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UserViewButton.BackgroundImage")));
            this.UserViewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UserViewButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.UserViewButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.UserViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserViewButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UserViewButton.Location = new System.Drawing.Point(599, -1);
            this.UserViewButton.Name = "UserViewButton";
            this.UserViewButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UserViewButton.Size = new System.Drawing.Size(32, 25);
            this.UserViewButton.TabIndex = 7;
            this.UserViewButton.UseVisualStyleBackColor = false;
            // 
            // RTButton
            // 
            this.RTButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RTButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RTButton.BackgroundImage")));
            this.RTButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RTButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.RTButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RTButton.Location = new System.Drawing.Point(570, 20);
            this.RTButton.Name = "RTButton";
            this.RTButton.Size = new System.Drawing.Size(28, 24);
            this.RTButton.TabIndex = 6;
            this.RTButton.UseVisualStyleBackColor = true;
            // 
            // FavButton
            // 
            this.FavButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FavButton.BackColor = System.Drawing.Color.Transparent;
            this.FavButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FavButton.BackgroundImage")));
            this.FavButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FavButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.FavButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.FavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FavButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FavButton.Location = new System.Drawing.Point(570, -1);
            this.FavButton.Name = "FavButton";
            this.FavButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FavButton.Size = new System.Drawing.Size(32, 25);
            this.FavButton.TabIndex = 5;
            this.FavButton.UseVisualStyleBackColor = false;
            // 
            // ActiveStatusView
            // 
            this.ActiveStatusView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ActiveStatusView.BackgroundImageTiled = true;
            this.ActiveStatusView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.User,
            this.Tweet});
            this.ActiveStatusView.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ActiveStatusView.Location = new System.Drawing.Point(3, 3);
            this.ActiveStatusView.Name = "ActiveStatusView";
            this.ActiveStatusView.Scrollable = false;
            this.ActiveStatusView.Size = new System.Drawing.Size(561, 41);
            this.ActiveStatusView.TabIndex = 4;
            this.ActiveStatusView.UseCompatibleStateImageBehavior = false;
            this.ActiveStatusView.View = System.Windows.Forms.View.Details;
            // 
            // User
            // 
            this.User.Text = "User";
            this.User.Width = 74;
            // 
            // Tweet
            // 
            this.Tweet.Text = "Tweet";
            this.Tweet.Width = 519;
            // 
            // PostCount
            // 
            this.PostCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PostCount.AutoSize = true;
            this.PostCount.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PostCount.Location = new System.Drawing.Point(492, 60);
            this.PostCount.Name = "PostCount";
            this.PostCount.Size = new System.Drawing.Size(43, 21);
            this.PostCount.TabIndex = 3;
            this.PostCount.Text = "140";
            // 
            // PostButton
            // 
            this.PostButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PostButton.Location = new System.Drawing.Point(541, 50);
            this.PostButton.Name = "PostButton";
            this.PostButton.Size = new System.Drawing.Size(86, 38);
            this.PostButton.TabIndex = 2;
            this.PostButton.TabStop = false;
            this.PostButton.Text = "Post";
            this.PostButton.UseVisualStyleBackColor = true;
            // 
            // PostText
            // 
            this.PostText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PostText.Location = new System.Drawing.Point(174, 50);
            this.PostText.Multiline = true;
            this.PostText.Name = "PostText";
            this.PostText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.PostText.Size = new System.Drawing.Size(312, 38);
            this.PostText.TabIndex = 1;
            this.PostText.TabStop = false;
            // 
            // AccountsList
            // 
            this.AccountsList.FormattingEnabled = true;
            this.AccountsList.ItemHeight = 12;
            this.AccountsList.Location = new System.Drawing.Point(3, 48);
            this.AccountsList.Name = "AccountsList";
            this.AccountsList.ScrollAlwaysVisible = true;
            this.AccountsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.AccountsList.Size = new System.Drawing.Size(165, 40);
            this.AccountsList.TabIndex = 0;
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.manageToolStripMenuItem.Text = "Account";
            // 
            // columnToolStripMenuItem
            // 
            this.columnToolStripMenuItem.Name = "columnToolStripMenuItem";
            this.columnToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.columnToolStripMenuItem.Text = "Column";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 446);
            this.Name = "Main";
            this.Text = "Shanghai UI for Alicium 3.x";
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ColumnHeader Tweet;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.ListView ActiveStatusView;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PostCount;
        private System.Windows.Forms.Button PostButton;
        private System.Windows.Forms.TextBox PostText;
        private System.Windows.Forms.ListBox AccountsList;
        private System.Windows.Forms.Button RTButton;
        private System.Windows.Forms.Button FavButton;
        private System.Windows.Forms.Button UORTButton;
        private System.Windows.Forms.Button UserViewButton;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnToolStripMenuItem;
    }
}




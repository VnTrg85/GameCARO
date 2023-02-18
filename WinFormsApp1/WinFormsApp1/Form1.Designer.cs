namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelChessBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picBoxPlayer = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.progressTime = new System.Windows.Forms.ProgressBar();
            this.Time = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Player = new System.Windows.Forms.Label();
            this.txtLAN = new System.Windows.Forms.TextBox();
            this.txtPlayer = new System.Windows.Forms.TextBox();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timerProgess = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayer)).BeginInit();
            this.Menu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChessBoard
            // 
            this.panelChessBoard.Location = new System.Drawing.Point(12, 52);
            this.panelChessBoard.Name = "panelChessBoard";
            this.panelChessBoard.Size = new System.Drawing.Size(1313, 1200);
            this.panelChessBoard.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(1465, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 806);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::WinFormsApp1.Properties.Resources.Icon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 372);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.picBoxPlayer);
            this.panel3.Controls.Add(this.btnConnect);
            this.panel3.Controls.Add(this.progressTime);
            this.panel3.Controls.Add(this.Time);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.Player);
            this.panel3.Controls.Add(this.txtLAN);
            this.panel3.Controls.Add(this.txtPlayer);
            this.panel3.Location = new System.Drawing.Point(1465, 444);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 779);
            this.panel3.TabIndex = 2;
            // 
            // picBoxPlayer
            // 
            this.picBoxPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxPlayer.Location = new System.Drawing.Point(330, 5);
            this.picBoxPlayer.Name = "picBoxPlayer";
            this.picBoxPlayer.Size = new System.Drawing.Size(104, 100);
            this.picBoxPlayer.TabIndex = 7;
            this.picBoxPlayer.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(123, 290);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(265, 90);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // progressTime
            // 
            this.progressTime.Location = new System.Drawing.Point(168, 111);
            this.progressTime.Name = "progressTime";
            this.progressTime.Size = new System.Drawing.Size(266, 46);
            this.progressTime.TabIndex = 5;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(23, 111);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(67, 32);
            this.Time.TabIndex = 4;
            this.Time.Text = "Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "LAN";
            // 
            // Player
            // 
            this.Player.AutoSize = true;
            this.Player.Location = new System.Drawing.Point(23, 29);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(78, 32);
            this.Player.TabIndex = 2;
            this.Player.Text = "Player";
            // 
            // txtLAN
            // 
            this.txtLAN.Location = new System.Drawing.Point(168, 199);
            this.txtLAN.Name = "txtLAN";
            this.txtLAN.Size = new System.Drawing.Size(266, 39);
            this.txtLAN.TabIndex = 1;
            // 
            // txtPlayer
            // 
            this.txtPlayer.Location = new System.Drawing.Point(168, 29);
            this.txtPlayer.Name = "txtPlayer";
            this.txtPlayer.Size = new System.Drawing.Size(156, 39);
            this.txtPlayer.TabIndex = 0;
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(206, 118);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(205, 38);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(205, 38);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(205, 38);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1998, 42);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem1,
            this.undoToolStripMenuItem1,
            this.quitToolStripMenuItem1});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(97, 38);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem1
            // 
            this.newGameToolStripMenuItem1.Name = "newGameToolStripMenuItem1";
            this.newGameToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem1.Size = new System.Drawing.Size(359, 44);
            this.newGameToolStripMenuItem1.Text = "New Game";
            this.newGameToolStripMenuItem1.Click += new System.EventHandler(this.newGameToolStripMenuItem1_Click);
            // 
            // undoToolStripMenuItem1
            // 
            this.undoToolStripMenuItem1.Name = "undoToolStripMenuItem1";
            this.undoToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem1.Size = new System.Drawing.Size(359, 44);
            this.undoToolStripMenuItem1.Text = "Undo";
            this.undoToolStripMenuItem1.Click += new System.EventHandler(this.undoToolStripMenuItem1_Click);
            // 
            // quitToolStripMenuItem1
            // 
            this.quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
            this.quitToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem1.Size = new System.Drawing.Size(359, 44);
            this.quitToolStripMenuItem1.Text = "Quit";
            this.quitToolStripMenuItem1.Click += new System.EventHandler(this.quitToolStripMenuItem1_Click);
            // 
            // timerProgess
            // 
            this.timerProgess.Tick += new System.EventHandler(this.timerProgess_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1998, 1257);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelChessBoard);
            this.Name = "Form1";
            this.Text = "Game Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayer)).EndInit();
            this.Menu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelChessBoard;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Button btnConnect;
        private ProgressBar progressTime;
        private Label Time;
        private Label label2;
        private Label Player;
        private TextBox txtLAN;
        private TextBox txtPlayer;
        private ContextMenuStrip Menu;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem1;
        private ToolStripMenuItem undoToolStripMenuItem1;
        private ToolStripMenuItem quitToolStripMenuItem1;
        private PictureBox picBoxPlayer;
        private System.Windows.Forms.Timer timerProgess;
    }
}
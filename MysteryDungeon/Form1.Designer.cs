namespace MysteryDungeon
{
    partial class MysteryDungeonForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MysteryDungeonForm));
			this.gameTimer = new System.Windows.Forms.Timer(this.components);
			this.debugLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// gameTimer
			// 
			this.gameTimer.Enabled = true;
			this.gameTimer.Interval = 2;
			this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
			// 
			// debugLabel
			// 
			this.debugLabel.AutoSize = true;
			this.debugLabel.BackColor = System.Drawing.Color.Transparent;
			this.debugLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.debugLabel.Font = new System.Drawing.Font("PKMN Mystery Dungeon", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.debugLabel.Location = new System.Drawing.Point(12, 9);
			this.debugLabel.Name = "debugLabel";
			this.debugLabel.Size = new System.Drawing.Size(36, 12);
			this.debugLabel.TabIndex = 0;
			this.debugLabel.Text = "DEBUG";
			// 
			// MysteryDungeonForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(240, 161);
			this.Controls.Add(this.debugLabel);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MysteryDungeonForm";
			this.Text = "Pokémon Mystery Dungeon";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MysteryDungeon_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MysteryDungeon_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MysteryDungeon_KeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
		private System.Windows.Forms.Label debugLabel;
	}
}


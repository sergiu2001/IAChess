namespace IAChess
{
    partial class StartMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnVsPlayer = new System.Windows.Forms.Button();
            this.btnVsAi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zo Shogi(象將棋)";
            // 
            // btnVsPlayer
            // 
            this.btnVsPlayer.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnVsPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVsPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVsPlayer.Location = new System.Drawing.Point(222, 167);
            this.btnVsPlayer.Name = "btnVsPlayer";
            this.btnVsPlayer.Size = new System.Drawing.Size(119, 40);
            this.btnVsPlayer.TabIndex = 1;
            this.btnVsPlayer.Text = "vs Player";
            this.btnVsPlayer.UseVisualStyleBackColor = false;
            this.btnVsPlayer.Click += new System.EventHandler(this.btnVsPlayer_Click);
            // 
            // btnVsAi
            // 
            this.btnVsAi.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnVsAi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVsAi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVsAi.Location = new System.Drawing.Point(222, 268);
            this.btnVsAi.Name = "btnVsAi";
            this.btnVsAi.Size = new System.Drawing.Size(119, 40);
            this.btnVsAi.TabIndex = 2;
            this.btnVsAi.Text = "vs AI";
            this.btnVsAi.UseVisualStyleBackColor = false;
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.btnVsAi);
            this.Controls.Add(this.btnVsPlayer);
            this.Controls.Add(this.label1);
            this.Name = "StartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zo Shogi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVsPlayer;
        private System.Windows.Forms.Button btnVsAi;
    }
}
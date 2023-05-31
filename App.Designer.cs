namespace CzechPinVerifier
{
    partial class App
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.gBoxPin = new System.Windows.Forms.GroupBox();
            this.lblSlash = new System.Windows.Forms.Label();
            this.tboxPidSecond = new System.Windows.Forms.TextBox();
            this.tboxPidFirst = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.gBoxPin.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxPin
            // 
            this.gBoxPin.BackColor = System.Drawing.Color.Transparent;
            this.gBoxPin.Controls.Add(this.lblSlash);
            this.gBoxPin.Controls.Add(this.tboxPidSecond);
            this.gBoxPin.Controls.Add(this.tboxPidFirst);
            this.gBoxPin.Location = new System.Drawing.Point(12, 12);
            this.gBoxPin.Name = "gBoxPin";
            this.gBoxPin.Size = new System.Drawing.Size(200, 52);
            this.gBoxPin.TabIndex = 0;
            this.gBoxPin.TabStop = false;
            this.gBoxPin.Text = "Rodné číslo";
            // 
            // lblSlash
            // 
            this.lblSlash.AutoSize = true;
            this.lblSlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSlash.Location = new System.Drawing.Point(109, 22);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(12, 16);
            this.lblSlash.TabIndex = 2;
            this.lblSlash.Text = "/";
            // 
            // tboxPidSecond
            // 
            this.tboxPidSecond.Location = new System.Drawing.Point(122, 21);
            this.tboxPidSecond.MaxLength = 4;
            this.tboxPidSecond.Name = "tboxPidSecond";
            this.tboxPidSecond.Size = new System.Drawing.Size(72, 20);
            this.tboxPidSecond.TabIndex = 1;
            // 
            // tboxPidFirst
            // 
            this.tboxPidFirst.Location = new System.Drawing.Point(7, 20);
            this.tboxPidFirst.MaxLength = 6;
            this.tboxPidFirst.Name = "tboxPidFirst";
            this.tboxPidFirst.Size = new System.Drawing.Size(100, 20);
            this.tboxPidFirst.TabIndex = 0;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(218, 31);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 1;
            this.btnVerify.Text = "Ověř";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 80);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.gBoxPin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "App";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CzechPinVerifier";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.App_HelpButtonClicked);
            this.gBoxPin.ResumeLayout(false);
            this.gBoxPin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxPin;
        private System.Windows.Forms.TextBox tboxPidFirst;
        private System.Windows.Forms.TextBox tboxPidSecond;
        private System.Windows.Forms.Label lblSlash;
        private System.Windows.Forms.Button btnVerify;
    }
}


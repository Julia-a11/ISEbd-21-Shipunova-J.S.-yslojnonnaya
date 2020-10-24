namespace Laboratornaya
{
    partial class FormWaterTransport
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCreateAircraft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.pictureBoxShip = new System.Windows.Forms.PictureBox();
            this.comboBoxPlanesCount = new System.Windows.Forms.ComboBox();
            this.buttonCreateWarShip = new System.Windows.Forms.Button();
            this.comboBoxAdditions = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShip)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateAircraft
            // 
            this.buttonCreateAircraft.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonCreateAircraft.Location = new System.Drawing.Point(639, 12);
            this.buttonCreateAircraft.Name = "buttonCreateAircraft";
            this.buttonCreateAircraft.Size = new System.Drawing.Size(213, 27);
            this.buttonCreateAircraft.TabIndex = 1;
            this.buttonCreateAircraft.Text = "Создать Авианосец";
            this.buttonCreateAircraft.UseVisualStyleBackColor = false;
            this.buttonCreateAircraft.Click += new System.EventHandler(this.buttonCreateAirctaft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.blue_arrow_71_right_;
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRight.Location = new System.Drawing.Point(822, 383);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(30, 30);
            this.buttonRight.TabIndex = 5;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeft.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.blue_arrow_71_left_1;
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLeft.Location = new System.Drawing.Point(732, 383);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(30, 30);
            this.buttonLeft.TabIndex = 4;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.blue_arrow_71_down1_;
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDown.Location = new System.Drawing.Point(777, 383);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(30, 30);
            this.buttonDown.TabIndex = 3;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.blue_arrow_71_up_;
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUp.Location = new System.Drawing.Point(777, 336);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(30, 30);
            this.buttonUp.TabIndex = 2;
            this.buttonUp.Text = "\r\n";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // pictureBoxShip
            // 
            this.pictureBoxShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxShip.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxShip.Name = "pictureBoxShip";
            this.pictureBoxShip.Size = new System.Drawing.Size(884, 461);
            this.pictureBoxShip.TabIndex = 0;
            this.pictureBoxShip.TabStop = false;
            // 
            // comboBoxPlanesCount
            // 
            this.comboBoxPlanesCount.FormattingEnabled = true;
            this.comboBoxPlanesCount.Location = new System.Drawing.Point(639, 78);
            this.comboBoxPlanesCount.Name = "comboBoxPlanesCount";
            this.comboBoxPlanesCount.Size = new System.Drawing.Size(213, 21);
            this.comboBoxPlanesCount.TabIndex = 6;
            // 
            // buttonCreateWarShip
            // 
            this.buttonCreateWarShip.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonCreateWarShip.Location = new System.Drawing.Point(639, 45);
            this.buttonCreateWarShip.Name = "buttonCreateWarShip";
            this.buttonCreateWarShip.Size = new System.Drawing.Size(213, 27);
            this.buttonCreateWarShip.TabIndex = 7;
            this.buttonCreateWarShip.Text = "Создать военный корабль";
            this.buttonCreateWarShip.UseVisualStyleBackColor = false;
            this.buttonCreateWarShip.Click += new System.EventHandler(this.buttonCreateWarShip_Click);
            // 
            // comboBoxAdditions
            // 
            this.comboBoxAdditions.FormattingEnabled = true;
            this.comboBoxAdditions.Location = new System.Drawing.Point(639, 114);
            this.comboBoxAdditions.Name = "comboBoxAdditions";
            this.comboBoxAdditions.Size = new System.Drawing.Size(213, 21);
            this.comboBoxAdditions.TabIndex = 8;
            // 
            // FormWaterTransport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.comboBoxAdditions);
            this.Controls.Add(this.buttonCreateWarShip);
            this.Controls.Add(this.comboBoxPlanesCount);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonCreateAircraft);
            this.Controls.Add(this.pictureBoxShip);
            this.Name = "FormWaterTransport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Водный транспорт";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxShip;
        private System.Windows.Forms.Button buttonCreateAircraft;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.ComboBox comboBoxPlanesCount;
        private System.Windows.Forms.Button buttonCreateWarShip;
        private System.Windows.Forms.ComboBox comboBoxAdditions;
    }
}


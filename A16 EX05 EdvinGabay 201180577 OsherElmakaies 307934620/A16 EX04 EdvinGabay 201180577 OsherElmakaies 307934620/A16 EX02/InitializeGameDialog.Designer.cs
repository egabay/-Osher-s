namespace Ex05
{
    partial class InitializeGameDialog
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
            this.m_BoardSizeLabel = new System.Windows.Forms.Label();
            this.m_6x6RadioButton = new System.Windows.Forms.RadioButton();
            this.m_8x8RadioButton = new System.Windows.Forms.RadioButton();
            this.m_10x10RadioButton = new System.Windows.Forms.RadioButton();
            this.m_PlayersLabel = new System.Windows.Forms.Label();
            this.m_Player1Label = new System.Windows.Forms.Label();
            this.m_Player1NameTextBox = new System.Windows.Forms.TextBox();
            this.m_Player2NameTextBox = new System.Windows.Forms.TextBox();
            this.m_EnableSecondPlayerCheckBox = new System.Windows.Forms.CheckBox();
            this.m_DoneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_BoardSizeLabel
            // 
            this.m_BoardSizeLabel.AutoSize = true;
            this.m_BoardSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_BoardSizeLabel.Location = new System.Drawing.Point(12, 9);
            this.m_BoardSizeLabel.Name = "m_BoardSizeLabel";
            this.m_BoardSizeLabel.Size = new System.Drawing.Size(111, 24);
            this.m_BoardSizeLabel.TabIndex = 0;
            this.m_BoardSizeLabel.Text = "Board Size :";
            // 
            // m_6x6RadioButton
            // 
            this.m_6x6RadioButton.AutoSize = true;
            this.m_6x6RadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_6x6RadioButton.Location = new System.Drawing.Point(71, 36);
            this.m_6x6RadioButton.Name = "m_6x6RadioButton";
            this.m_6x6RadioButton.Size = new System.Drawing.Size(52, 24);
            this.m_6x6RadioButton.TabIndex = 1;
            this.m_6x6RadioButton.TabStop = true;
            this.m_6x6RadioButton.Text = "6x6";
            this.m_6x6RadioButton.UseVisualStyleBackColor = true;
            this.m_6x6RadioButton.CheckedChanged += new System.EventHandler(this.m_BoardSize_CheckedChanged);
            // 
            // m_8x8RadioButton
            // 
            this.m_8x8RadioButton.AutoSize = true;
            this.m_8x8RadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_8x8RadioButton.Location = new System.Drawing.Point(146, 36);
            this.m_8x8RadioButton.Name = "m_8x8RadioButton";
            this.m_8x8RadioButton.Size = new System.Drawing.Size(52, 24);
            this.m_8x8RadioButton.TabIndex = 2;
            this.m_8x8RadioButton.TabStop = true;
            this.m_8x8RadioButton.Text = "8x8";
            this.m_8x8RadioButton.UseVisualStyleBackColor = true;
            this.m_8x8RadioButton.CheckedChanged += new System.EventHandler(this.m_BoardSize_CheckedChanged);
            // 
            // m_10x10RadioButton
            // 
            this.m_10x10RadioButton.AutoSize = true;
            this.m_10x10RadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_10x10RadioButton.Location = new System.Drawing.Point(216, 36);
            this.m_10x10RadioButton.Name = "m_10x10RadioButton";
            this.m_10x10RadioButton.Size = new System.Drawing.Size(70, 24);
            this.m_10x10RadioButton.TabIndex = 3;
            this.m_10x10RadioButton.TabStop = true;
            this.m_10x10RadioButton.Text = "10x10";
            this.m_10x10RadioButton.UseVisualStyleBackColor = true;
            this.m_10x10RadioButton.CheckedChanged += new System.EventHandler(this.m_BoardSize_CheckedChanged);
            // 
            // m_PlayersLabel
            // 
            this.m_PlayersLabel.AutoSize = true;
            this.m_PlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_PlayersLabel.Location = new System.Drawing.Point(12, 63);
            this.m_PlayersLabel.Name = "m_PlayersLabel";
            this.m_PlayersLabel.Size = new System.Drawing.Size(76, 24);
            this.m_PlayersLabel.TabIndex = 4;
            this.m_PlayersLabel.Text = "Players:";
            // 
            // m_Player1Label
            // 
            this.m_Player1Label.AutoSize = true;
            this.m_Player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Player1Label.Location = new System.Drawing.Point(67, 108);
            this.m_Player1Label.Name = "m_Player1Label";
            this.m_Player1Label.Size = new System.Drawing.Size(73, 20);
            this.m_Player1Label.TabIndex = 5;
            this.m_Player1Label.Text = "Player 1 :";
            // 
            // m_Player1NameTextBox
            // 
            this.m_Player1NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Player1NameTextBox.Location = new System.Drawing.Point(149, 105);
            this.m_Player1NameTextBox.Name = "m_Player1NameTextBox";
            this.m_Player1NameTextBox.Size = new System.Drawing.Size(100, 26);
            this.m_Player1NameTextBox.TabIndex = 6;
            this.m_Player1NameTextBox.Text = "Player1";
            // 
            // m_Player2NameTextBox
            // 
            this.m_Player2NameTextBox.Enabled = false;
            this.m_Player2NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Player2NameTextBox.Location = new System.Drawing.Point(149, 143);
            this.m_Player2NameTextBox.Name = "m_Player2NameTextBox";
            this.m_Player2NameTextBox.Size = new System.Drawing.Size(100, 26);
            this.m_Player2NameTextBox.TabIndex = 8;
            this.m_Player2NameTextBox.Text = "[Computer]";
            // 
            // m_EnableSecondPlayerCheckBox
            // 
            this.m_EnableSecondPlayerCheckBox.AutoSize = true;
            this.m_EnableSecondPlayerCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_EnableSecondPlayerCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_EnableSecondPlayerCheckBox.Location = new System.Drawing.Point(53, 145);
            this.m_EnableSecondPlayerCheckBox.Name = "m_EnableSecondPlayerCheckBox";
            this.m_EnableSecondPlayerCheckBox.Size = new System.Drawing.Size(98, 25);
            this.m_EnableSecondPlayerCheckBox.TabIndex = 9;
            this.m_EnableSecondPlayerCheckBox.Text = "Player 2 :";
            this.m_EnableSecondPlayerCheckBox.UseVisualStyleBackColor = true;
            this.m_EnableSecondPlayerCheckBox.CheckedChanged += new System.EventHandler(this.m_EnableSecondPlayerCheckBox_CheckedChanged);
            // 
            // m_DoneButton
            // 
            this.m_DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_DoneButton.Location = new System.Drawing.Point(204, 186);
            this.m_DoneButton.Name = "m_DoneButton";
            this.m_DoneButton.Size = new System.Drawing.Size(91, 29);
            this.m_DoneButton.TabIndex = 10;
            this.m_DoneButton.Text = "Done";
            this.m_DoneButton.UseVisualStyleBackColor = true;
            this.m_DoneButton.Click += new System.EventHandler(this.m_DoneButton_Click);
            // 
            // InitializeGameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 227);
            this.Controls.Add(this.m_DoneButton);
            this.Controls.Add(this.m_EnableSecondPlayerCheckBox);
            this.Controls.Add(this.m_Player2NameTextBox);
            this.Controls.Add(this.m_Player1NameTextBox);
            this.Controls.Add(this.m_Player1Label);
            this.Controls.Add(this.m_PlayersLabel);
            this.Controls.Add(this.m_10x10RadioButton);
            this.Controls.Add(this.m_8x8RadioButton);
            this.Controls.Add(this.m_6x6RadioButton);
            this.Controls.Add(this.m_BoardSizeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InitializeGameDialog";
            this.Text = "Game Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InitializeGameDialog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_BoardSizeLabel;
        private System.Windows.Forms.RadioButton m_6x6RadioButton;
        private System.Windows.Forms.RadioButton m_8x8RadioButton;
        private System.Windows.Forms.RadioButton m_10x10RadioButton;
        private System.Windows.Forms.Label m_PlayersLabel;
        private System.Windows.Forms.Label m_Player1Label;
        private System.Windows.Forms.TextBox m_Player1NameTextBox;
        private System.Windows.Forms.TextBox m_Player2NameTextBox;
        private System.Windows.Forms.CheckBox m_EnableSecondPlayerCheckBox;
        private System.Windows.Forms.Button m_DoneButton;
    }
}
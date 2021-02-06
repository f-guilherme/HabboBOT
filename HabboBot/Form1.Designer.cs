namespace HabboBot
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonIntercept = new System.Windows.Forms.Button();
            this.buttonRoom = new System.Windows.Forms.Button();
            this.textBoxRoomId = new System.Windows.Forms.TextBox();
            this.buttonShout = new System.Windows.Forms.Button();
            this.textBoxShout = new System.Windows.Forms.TextBox();
            this.buttonRespect = new System.Windows.Forms.Button();
            this.textBoxRespect = new System.Windows.Forms.TextBox();
            this.buttonFriendRequest = new System.Windows.Forms.Button();
            this.textBoxFriendRequest = new System.Windows.Forms.TextBox();
            this.labelBots = new System.Windows.Forms.Label();
            this.labelBotCount = new System.Windows.Forms.Label();
            this.walkRandomButton = new System.Windows.Forms.Button();
            this.danceButton = new System.Windows.Forms.Button();
            this.checkBoxTopMost = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(11, 155);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(419, 197);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // buttonIntercept
            // 
            this.buttonIntercept.Location = new System.Drawing.Point(13, 126);
            this.buttonIntercept.Name = "buttonIntercept";
            this.buttonIntercept.Size = new System.Drawing.Size(419, 23);
            this.buttonIntercept.TabIndex = 1;
            this.buttonIntercept.Text = "Interceptar";
            this.buttonIntercept.UseVisualStyleBackColor = true;
            this.buttonIntercept.Click += new System.EventHandler(this.buttonIntercept_Click);
            // 
            // buttonRoom
            // 
            this.buttonRoom.Location = new System.Drawing.Point(12, 68);
            this.buttonRoom.Name = "buttonRoom";
            this.buttonRoom.Size = new System.Drawing.Size(99, 23);
            this.buttonRoom.TabIndex = 2;
            this.buttonRoom.Text = "Quarto";
            this.buttonRoom.UseVisualStyleBackColor = true;
            this.buttonRoom.Click += new System.EventHandler(this.buttonRoom_Click);
            // 
            // textBoxRoomId
            // 
            this.textBoxRoomId.Location = new System.Drawing.Point(11, 42);
            this.textBoxRoomId.Name = "textBoxRoomId";
            this.textBoxRoomId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxRoomId.Size = new System.Drawing.Size(100, 20);
            this.textBoxRoomId.TabIndex = 3;
            // 
            // buttonShout
            // 
            this.buttonShout.Location = new System.Drawing.Point(117, 68);
            this.buttonShout.Name = "buttonShout";
            this.buttonShout.Size = new System.Drawing.Size(100, 23);
            this.buttonShout.TabIndex = 5;
            this.buttonShout.Text = "Falar";
            this.buttonShout.UseVisualStyleBackColor = true;
            this.buttonShout.Click += new System.EventHandler(this.buttonShout_Click);
            // 
            // textBoxShout
            // 
            this.textBoxShout.Location = new System.Drawing.Point(117, 42);
            this.textBoxShout.Name = "textBoxShout";
            this.textBoxShout.Size = new System.Drawing.Size(100, 20);
            this.textBoxShout.TabIndex = 6;
            // 
            // buttonRespect
            // 
            this.buttonRespect.Location = new System.Drawing.Point(223, 68);
            this.buttonRespect.Name = "buttonRespect";
            this.buttonRespect.Size = new System.Drawing.Size(100, 23);
            this.buttonRespect.TabIndex = 7;
            this.buttonRespect.Text = "Respeitar";
            this.buttonRespect.UseVisualStyleBackColor = true;
            this.buttonRespect.Click += new System.EventHandler(this.buttonRespect_Click);
            // 
            // textBoxRespect
            // 
            this.textBoxRespect.Location = new System.Drawing.Point(225, 42);
            this.textBoxRespect.Name = "textBoxRespect";
            this.textBoxRespect.Size = new System.Drawing.Size(100, 20);
            this.textBoxRespect.TabIndex = 8;
            // 
            // buttonFriendRequest
            // 
            this.buttonFriendRequest.Location = new System.Drawing.Point(331, 68);
            this.buttonFriendRequest.Name = "buttonFriendRequest";
            this.buttonFriendRequest.Size = new System.Drawing.Size(100, 23);
            this.buttonFriendRequest.TabIndex = 9;
            this.buttonFriendRequest.Text = "Adicionar";
            this.buttonFriendRequest.UseVisualStyleBackColor = true;
            this.buttonFriendRequest.Click += new System.EventHandler(this.buttonFriendRequest_Click);
            // 
            // textBoxFriendRequest
            // 
            this.textBoxFriendRequest.Location = new System.Drawing.Point(331, 42);
            this.textBoxFriendRequest.Name = "textBoxFriendRequest";
            this.textBoxFriendRequest.Size = new System.Drawing.Size(100, 20);
            this.textBoxFriendRequest.TabIndex = 10;
            // 
            // labelBots
            // 
            this.labelBots.AutoSize = true;
            this.labelBots.Location = new System.Drawing.Point(13, 13);
            this.labelBots.Name = "labelBots";
            this.labelBots.Size = new System.Drawing.Size(39, 13);
            this.labelBots.TabIndex = 11;
            this.labelBots.Text = "BOTS:";
            // 
            // labelBotCount
            // 
            this.labelBotCount.AutoSize = true;
            this.labelBotCount.Location = new System.Drawing.Point(47, 13);
            this.labelBotCount.Name = "labelBotCount";
            this.labelBotCount.Size = new System.Drawing.Size(16, 13);
            this.labelBotCount.TabIndex = 12;
            this.labelBotCount.Text = " 0";
            // 
            // walkRandomButton
            // 
            this.walkRandomButton.Location = new System.Drawing.Point(119, 97);
            this.walkRandomButton.Name = "walkRandomButton";
            this.walkRandomButton.Size = new System.Drawing.Size(98, 23);
            this.walkRandomButton.TabIndex = 13;
            this.walkRandomButton.Text = "Andar aleatório";
            this.walkRandomButton.UseVisualStyleBackColor = true;
            this.walkRandomButton.Click += new System.EventHandler(this.walkRandomButton_Click);
            // 
            // danceButton
            // 
            this.danceButton.Location = new System.Drawing.Point(13, 97);
            this.danceButton.Name = "danceButton";
            this.danceButton.Size = new System.Drawing.Size(98, 23);
            this.danceButton.TabIndex = 15;
            this.danceButton.Text = "Dance";
            this.danceButton.UseVisualStyleBackColor = true;
            this.danceButton.Click += new System.EventHandler(this.danceButton_Click);
            // 
            // checkBoxTopMost
            // 
            this.checkBoxTopMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxTopMost.AutoSize = true;
            this.checkBoxTopMost.Location = new System.Drawing.Point(11, 358);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(71, 17);
            this.checkBoxTopMost.TabIndex = 4;
            this.checkBoxTopMost.Text = "Top Most";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            this.checkBoxTopMost.CheckedChanged += new System.EventHandler(this.checkBoxTopMost_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(446, 387);
            this.Controls.Add(this.danceButton);
            this.Controls.Add(this.walkRandomButton);
            this.Controls.Add(this.labelBotCount);
            this.Controls.Add(this.labelBots);
            this.Controls.Add(this.textBoxFriendRequest);
            this.Controls.Add(this.buttonFriendRequest);
            this.Controls.Add(this.textBoxRespect);
            this.Controls.Add(this.buttonRespect);
            this.Controls.Add(this.textBoxShout);
            this.Controls.Add(this.buttonShout);
            this.Controls.Add(this.checkBoxTopMost);
            this.Controls.Add(this.textBoxRoomId);
            this.Controls.Add(this.buttonRoom);
            this.Controls.Add(this.buttonIntercept);
            this.Controls.Add(this.richTextBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "HabboBOT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonIntercept;
        private System.Windows.Forms.Button buttonRoom;
        private System.Windows.Forms.TextBox textBoxRoomId;
        private System.Windows.Forms.Button buttonShout;
        private System.Windows.Forms.TextBox textBoxShout;
        private System.Windows.Forms.Button buttonRespect;
        private System.Windows.Forms.TextBox textBoxRespect;
        private System.Windows.Forms.Button buttonFriendRequest;
        private System.Windows.Forms.TextBox textBoxFriendRequest;
        private System.Windows.Forms.Label labelBots;
        private System.Windows.Forms.Label labelBotCount;
        private System.Windows.Forms.Button walkRandomButton;
        private System.Windows.Forms.Button danceButton;
        private System.Windows.Forms.CheckBox checkBoxTopMost;
    }
}
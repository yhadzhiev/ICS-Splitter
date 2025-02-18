namespace iCal_Splitter
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            progBox = new RichTextBox();
            openFileDial = new OpenFileDialog();
            status = new Label();
            newNameBox = new TextBox();
            toolTip1 = new ToolTip(components);
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(302, 23);
            button1.Name = "button1";
            button1.Size = new Size(158, 42);
            button1.TabIndex = 0;
            button1.Text = "Select .ics and go";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progBox
            // 
            progBox.BackColor = SystemColors.InactiveCaption;
            progBox.Location = new Point(19, 101);
            progBox.Name = "progBox";
            progBox.Size = new Size(441, 167);
            progBox.TabIndex = 3;
            progBox.Text = "";
            // 
            // openFileDial
            // 
            openFileDial.InitialDirectory = "C:\\";
            openFileDial.Title = "Select ICS file to split.";
            // 
            // status
            // 
            status.AutoSize = true;
            status.BackColor = Color.LemonChiffon;
            status.Location = new Point(24, 63);
            status.Name = "status";
            status.Size = new Size(0, 25);
            status.TabIndex = 4;
            // 
            // newNameBox
            // 
            newNameBox.Location = new Point(19, 23);
            newNameBox.Name = "newNameBox";
            newNameBox.PlaceholderText = "Name for resulting files";
            newNameBox.Size = new Size(204, 31);
            newNameBox.TabIndex = 5;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.question;
            pictureBox1.Location = new Point(19, 276);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(23, 21);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 305);
            Controls.Add(pictureBox1);
            Controls.Add(newNameBox);
            Controls.Add(status);
            Controls.Add(progBox);
            Controls.Add(button1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "ICS Splitter 25";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private RichTextBox progBox;
        private OpenFileDialog openFileDial;
        private Label status;
        private TextBox newNameBox;
        private ToolTip toolTip1;
        private PictureBox pictureBox1;
    }
}

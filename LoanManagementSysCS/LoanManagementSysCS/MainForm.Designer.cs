namespace LoanManagementSys
{
    partial class MainForm
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
            btnOK = new Button();
            lstOutput = new ListBox();
            btnStop = new Button();
            lstItems = new ListBox();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Location = new Point(161, 810);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(254, 65);
            btnOK.TabIndex = 0;
            btnOK.Text = "Start";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // lstOutput
            // 
            lstOutput.Font = new Font("Courier New", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lstOutput.FormattingEnabled = true;
            lstOutput.ItemHeight = 22;
            lstOutput.Location = new Point(28, 14);
            lstOutput.Margin = new Padding(4, 5, 4, 5);
            lstOutput.Name = "lstOutput";
            lstOutput.Size = new Size(676, 774);
            lstOutput.TabIndex = 1;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(450, 810);
            btnStop.Margin = new Padding(4, 5, 4, 5);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(254, 65);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lstItems
            // 
            lstItems.Font = new Font("Courier New", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lstItems.FormattingEnabled = true;
            lstItems.ItemHeight = 22;
            lstItems.Location = new Point(733, 14);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(516, 774);
            lstItems.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 893);
            Controls.Add(lstItems);
            Controls.Add(btnStop);
            Controls.Add(lstOutput);
            Controls.Add(btnOK);
            Name = "MainForm";
            Text = "Equipment Loaning System";
            FormClosing += MainForm_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button btnOK;
        private ListBox lstOutput;
        private Button btnStop;
        private ListBox lstItems;
    }
}

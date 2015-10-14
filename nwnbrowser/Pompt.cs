using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NWNBrowser
{
    public static class Pompt
    {
        public static string AskForPassword()
        {
            Form dialog = new Form();
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;

            System.Windows.Forms.Label label1;
            MarkJohansen.Forms.MSJTextBox msjTextBox1;
            MarkJohansen.Forms.MSJButton msjButton1;

            label1 = new System.Windows.Forms.Label();
            msjTextBox1 = new MarkJohansen.Forms.MSJTextBox();
            msjButton1 = new MarkJohansen.Forms.MSJButton();
            dialog.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(2, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(160, 13);
            label1.TabIndex = 0;
            label1.Text = "Please enter your DM password.";
            // 
            // msjTextBox1
            // 
            msjTextBox1.Location = new System.Drawing.Point(5, 25);
            msjTextBox1.Name = "msjTextBox1";
            msjTextBox1.Size = new System.Drawing.Size(285, 20);
            msjTextBox1.TabIndex = 1;
            // 
            // msjButton1
            // 
            msjButton1.Location = new System.Drawing.Point(5, 51);
            msjButton1.Name = "msjButton1";
            msjButton1.Size = new System.Drawing.Size(285, 28);
            msjButton1.TabIndex = 2;
            msjButton1.Text = "OK";
            msjButton1.Click += (sender, e) => { dialog.Close(); };
            msjButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            dialog.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            dialog.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            dialog.ClientSize = new System.Drawing.Size(292, 84);
            dialog.Controls.Add(msjButton1);
            dialog.Controls.Add(msjTextBox1);
            dialog.Controls.Add(label1);
            dialog.Name = "Form1";
            dialog.Text = "Form1";
            dialog.ResumeLayout(false);
            dialog.PerformLayout();

            dialog.ShowDialog();

            return msjTextBox1.Text;
        }
    }
}

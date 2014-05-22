﻿namespace WebMConverter
{
    partial class MultipleTrimForm
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
            this.listViewTrims = new System.Windows.Forms.ListView();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddTrim = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewTrims
            // 
            this.listViewTrims.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTrims.Location = new System.Drawing.Point(3, 3);
            this.listViewTrims.MultiSelect = false;
            this.listViewTrims.Name = "listViewTrims";
            this.tableLayoutPanel1.SetRowSpan(this.listViewTrims, 7);
            this.listViewTrims.Size = new System.Drawing.Size(160, 248);
            this.listViewTrims.TabIndex = 0;
            this.listViewTrims.UseCompatibleStateImageBehavior = false;
            this.listViewTrims.View = System.Windows.Forms.View.List;
            this.listViewTrims.ItemActivate += new System.EventHandler(this.listViewTrims_ItemActivate);
            this.listViewTrims.SelectedIndexChanged += new System.EventHandler(this.listViewTrims_SelectedIndexChanged);
            this.listViewTrims.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewTrims_KeyUp);
            this.listViewTrims.Leave += new System.EventHandler(this.listViewTrims_Leave);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConfirm.Location = new System.Drawing.Point(169, 228);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(125, 23);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(169, 200);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(125, 22);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAddTrim
            // 
            this.buttonAddTrim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddTrim.Location = new System.Drawing.Point(169, 107);
            this.buttonAddTrim.Name = "buttonAddTrim";
            this.buttonAddTrim.Size = new System.Drawing.Size(125, 22);
            this.buttonAddTrim.TabIndex = 3;
            this.buttonAddTrim.Text = "Add";
            this.buttonAddTrim.UseVisualStyleBackColor = true;
            this.buttonAddTrim.Click += new System.EventHandler(this.buttonAddTrim_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.89226F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.10774F));
            this.tableLayoutPanel1.Controls.Add(this.listViewTrims, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonConfirm, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddTrim, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonMoveUp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonMoveDown, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.01847F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.98153F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(297, 254);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonMoveUp.AutoSize = true;
            this.buttonMoveUp.Enabled = false;
            this.buttonMoveUp.Location = new System.Drawing.Point(211, 79);
            this.buttonMoveUp.MaximumSize = new System.Drawing.Size(40, 0);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(40, 22);
            this.buttonMoveUp.TabIndex = 4;
            this.buttonMoveUp.Text = "^";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonMoveDown.AutoSize = true;
            this.buttonMoveDown.Enabled = false;
            this.buttonMoveDown.Location = new System.Drawing.Point(211, 135);
            this.buttonMoveDown.MaximumSize = new System.Drawing.Size(40, 0);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(40, 22);
            this.buttonMoveDown.TabIndex = 5;
            this.buttonMoveDown.Text = "v";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // MultipleTrimForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(297, 254);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MultipleTrimForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Multiple Trim";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewTrims;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddTrim;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
    }
}
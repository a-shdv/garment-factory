﻿namespace GarmentFactoryView
{
    partial class FormWarehouseTextile
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
            this.labelWarehouse = new System.Windows.Forms.Label();
            this.labelTextile = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxTextile = new System.Windows.Forms.ComboBox();
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWarehouse
            // 
            this.labelWarehouse.AutoSize = true;
            this.labelWarehouse.Location = new System.Drawing.Point(10, 9);
            this.labelWarehouse.Name = "labelWarehouse";
            this.labelWarehouse.Size = new System.Drawing.Size(43, 15);
            this.labelWarehouse.TabIndex = 2;
            this.labelWarehouse.Text = "Склад:";
            // 
            // labelTextile
            // 
            this.labelTextile.AutoSize = true;
            this.labelTextile.Location = new System.Drawing.Point(10, 38);
            this.labelTextile.Name = "labelTextile";
            this.labelTextile.Size = new System.Drawing.Size(41, 15);
            this.labelTextile.TabIndex = 3;
            this.labelTextile.Text = "Ткань:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(10, 67);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(75, 15);
            this.labelCount.TabIndex = 4;
            this.labelCount.Text = "Количество:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(93, 64);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(207, 23);
            this.textBoxCount.TabIndex = 5;
            // 
            // comboBoxTextile
            // 
            this.comboBoxTextile.FormattingEnabled = true;
            this.comboBoxTextile.Location = new System.Drawing.Point(93, 35);
            this.comboBoxTextile.Name = "comboBoxTextile";
            this.comboBoxTextile.Size = new System.Drawing.Size(207, 23);
            this.comboBoxTextile.TabIndex = 6;
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(93, 6);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(207, 23);
            this.comboBoxWarehouse.TabIndex = 7;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(143, 93);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(224, 93);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormWarehouseTextile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 128);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxWarehouse);
            this.Controls.Add(this.comboBoxTextile);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelTextile);
            this.Controls.Add(this.labelWarehouse);
            this.Name = "FormWarehouseTextile";
            this.Text = "Ткань склада";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelWarehouse;
        private System.Windows.Forms.Label labelTextile;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxTextile;
        private System.Windows.Forms.ComboBox comboBoxWarehouse;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}
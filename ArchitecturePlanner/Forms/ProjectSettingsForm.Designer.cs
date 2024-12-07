using System.ComponentModel;

namespace ArchitecturePlanner.Forms
{
	partial class ProjectSettingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;
		private System.Windows.Forms.Label lengthLabel;
		private System.Windows.Forms.TextBox lengthInput;
		private System.Windows.Forms.Label widthLabel;
		private System.Windows.Forms.TextBox widthInput;
		private System.Windows.Forms.Button createButton;
		private System.Windows.Forms.Button backButton;

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
			this.lengthLabel = new System.Windows.Forms.Label();
			this.lengthInput = new System.Windows.Forms.TextBox();
			this.widthLabel = new System.Windows.Forms.Label();
			this.widthInput = new System.Windows.Forms.TextBox();
			this.createButton = new System.Windows.Forms.Button();
			this.backButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// lengthLabel
			//
			this.lengthLabel.Location = new System.Drawing.Point(12, 15);
			this.lengthLabel.Name = "lengthLabel";
			this.lengthLabel.Size = new System.Drawing.Size(62, 23);
			this.lengthLabel.TabIndex = 0;
			this.lengthLabel.Text = "Длина:";
			//
			// lengthInput
			//
			this.lengthInput.Location = new System.Drawing.Point(80, 12);
			this.lengthInput.Name = "lengthInput";
			this.lengthInput.Size = new System.Drawing.Size(100, 22);
			this.lengthInput.TabIndex = 1;
			//
			// widthLabel
			//
			this.widthLabel.Location = new System.Drawing.Point(12, 45);
			this.widthLabel.Name = "widthLabel";
			this.widthLabel.Size = new System.Drawing.Size(62, 23);
			this.widthLabel.TabIndex = 2;
			this.widthLabel.Text = "Ширина:";
			//
			// widthInput
			//
			this.widthInput.Location = new System.Drawing.Point(80, 42);
			this.widthInput.Name = "widthInput";
			this.widthInput.Size = new System.Drawing.Size(100, 22);
			this.widthInput.TabIndex = 3;
			//
			// createButton
			//
			this.createButton.Location = new System.Drawing.Point(15, 80);
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(75, 23);
			this.createButton.TabIndex = 4;
			this.createButton.Text = "Создать";
			this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
			//
			// backButton
			//
			this.backButton.Location = new System.Drawing.Point(100, 80);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(75, 23);
			this.backButton.TabIndex = 5;
			this.backButton.Text = "Назад";
			this.backButton.Click += new System.EventHandler(this.BackButton_Click);
			//
			// ProjectSettingsForm
			//
			this.ClientSize = new System.Drawing.Size(200, 120);
			this.Controls.Add(this.lengthLabel);
			this.Controls.Add(this.lengthInput);
			this.Controls.Add(this.widthLabel);
			this.Controls.Add(this.widthInput);
			this.Controls.Add(this.createButton);
			this.Controls.Add(this.backButton);
			this.Name = "ProjectSettingsForm";
			this.Text = "Настройки проекта";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion
	}
}
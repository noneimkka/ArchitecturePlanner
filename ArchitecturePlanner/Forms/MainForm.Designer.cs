using System.ComponentModel;

namespace ArchitecturePlanner.Forms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton createProjectButton;
		private System.Windows.Forms.ToolStripButton createWallButton;
		private System.Windows.Forms.ToolStripButton moveWallButton;
		private System.Windows.Forms.ToolStripButton deleteWallButton ;
		private System.Windows.Forms.PictureBox planPanel;
		private System.Windows.Forms.Label infoLabel;

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
			this.components = new System.ComponentModel.Container();

			this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.createProjectButton = new System.Windows.Forms.ToolStripButton();
			this.createWallButton = new System.Windows.Forms.ToolStripButton();
			this.moveWallButton = new System.Windows.Forms.ToolStripButton();
			this.deleteWallButton = new System.Windows.Forms.ToolStripButton();
            this.planPanel = new System.Windows.Forms.PictureBox();
            this.infoLabel = new System.Windows.Forms.Label();

            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planPanel)).BeginInit();
            this.SuspendLayout();

            // toolStrip
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.createProjectButton,
				this.createWallButton,
				this.moveWallButton,
				this.deleteWallButton,
            });

            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 27);
            this.toolStrip.TabIndex = 0;

            // createProjectButton
            this.createProjectButton.Text = "Создать проект";
            this.createProjectButton.Click += new System.EventHandler(this.CreateProjectButton_Click);

			// createWallButton
			this.createWallButton.Text = "Создать стену";
			this.createWallButton.Click += new System.EventHandler(this.CreateWallButton_Click);

			// moveWallButton
			this.moveWallButton.Text = "Переместить стену";
			this.moveWallButton.Click += new System.EventHandler(this.MoveWallButton_Click);

			// deleteWallButton
			this.deleteWallButton.Text = "Удалить стену";
			this.deleteWallButton.CheckOnClick = true;
			this.deleteWallButton.Click += new System.EventHandler(this.DeleteWallButton_Click);

            // planPanel
            this.planPanel.BackColor = System.Drawing.Color.White;
            this.planPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.planPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.planPanel.Location = new System.Drawing.Point(0, 27);
            this.planPanel.Name = "planPanel";
            this.planPanel.Size = new System.Drawing.Size(800, 423);
            this.planPanel.TabIndex = 1;
            this.planPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PlanPanel_MouseWheel);

            // infoLabel
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoLabel.Location = new System.Drawing.Point(0, 450);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(800, 23);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "";

            // MainForm
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.planPanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.infoLabel);
            this.Name = "MainForm";
            this.Text = "Architectural Planner";

            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
		}

		#endregion
	}
}
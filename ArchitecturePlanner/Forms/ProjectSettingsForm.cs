using System;
using System.Windows.Forms;

namespace ArchitecturePlanner.Forms
{
	public partial class ProjectSettingsForm : Form
	{
		public int PlanLength { get; private set; }
		public int PlanWidth { get; private set; }

		public ProjectSettingsForm()
		{
			InitializeComponent();
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			if (int.TryParse(lengthInput.Text, out int length) && int.TryParse(widthInput.Text, out int width))
			{
				PlanLength = length;
				PlanWidth = width;
				DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show("Введите корректные размеры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
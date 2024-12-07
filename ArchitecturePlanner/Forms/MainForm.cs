using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ArchitecturePlanner.Models;

namespace ArchitecturePlanner.Forms
{
	public partial class MainForm : Form
	{
		private const int maxWallThickness = 4;
		private const int scrollMargin = 10; // Зона, при которой начинается перемещение
		private const int scrollSpeed = 10; // Скорость перемещения

		private int currentScale = 5; // Текущий масштаб
		private int planLength; // Длина квартиры
		private int planWidth; // Ширина квартиры
		private List<Wall> walls = new List<Wall>();
		private bool isCreatingWall;
		private bool isMovingWall;
		private bool isDeletingWall;
		private Wall selectedWall;
		private Point initialMousePosition;

		private int offsetX; // Смещение по горизонтали
		private int offsetY; // Смещение по вертикали

		public MainForm()
		{
			InitializeComponent();
			planPanel.MouseDown += PlanPanel_MouseDown;
			planPanel.MouseMove += PlanPanel_MouseMove;
			planPanel.MouseUp += PlanPanel_MouseUp;
		}

		private void CreateProjectButton_Click(object sender, EventArgs e)
		{
			using (var settingsForm = new ProjectSettingsForm())
			{
				if (settingsForm.ShowDialog() == DialogResult.OK)
				{
					planLength = settingsForm.PlanLength;
					planWidth = settingsForm.PlanWidth;
					DrawPlan();
				}
			}
		}

		private void PlanPanel_MouseWheel(object sender, MouseEventArgs e)
		{
			int deltaScale = e.Delta > 0 ? 1 : -1;
			int newScale = Math.Max(1, currentScale + deltaScale);
			UpdateScale(newScale);
		}

		private void DrawPlan()
		{
			int panelWidth = planPanel.Width;
			int panelHeight = planPanel.Height;

			Bitmap bitmap = new Bitmap(panelWidth, panelHeight);
			using (Graphics g = Graphics.FromImage(bitmap))
			{
				g.Clear(Color.White);

				// Границы квартиры (несущие стены)
				var rect = GetPlanRectangle();
				rect.Offset(offsetX, offsetY);
				using (Pen thickPen = new Pen(Color.Black, 4)) // Толщина несущих стен
				{
					g.DrawRectangle(thickPen, rect);
				}

				// Рисуем стены
				foreach (var wall in walls)
				{
					Rectangle wallRect = wall.Bounds;
					wallRect.Offset(offsetX, offsetY);

					Brush brush = wall.IsSelected ? Brushes.Red : Brushes.Gray;
					g.FillRectangle(brush, wallRect);

					// Подписываем размеры стены
					string dimension = wall.Bounds.Width > wall.Bounds.Height
						? $"{wall.Bounds.Width / currentScale * 100} см"
						: $"{wall.Bounds.Height / currentScale * 100} см";

					var textPosition = new Point(wallRect.X + 5, wallRect.Y + 5);
					g.DrawString(dimension, DefaultFont, Brushes.Black, textPosition);
				}
			}

			planPanel.Image = bitmap;
			infoLabel.Text = $"Размеры: {planLength * 100} см x {planWidth * 100} см, Площадь: {planLength * planWidth} м², Масштаб: {currentScale}";
		}

		private void UpdateScale(int newScale)
		{
			if (newScale == currentScale) return;

			// Масштабируем стены
			foreach (var wall in walls)
			{
				wall.UpdateBounds(newScale);
			}

			currentScale = newScale;
			DrawPlan();
		}

		private Rectangle GetPlanRectangle()
		{
			int rectWidth = planWidth * currentScale;
			int rectHeight = planLength * currentScale;

			int x = (planPanel.Width - rectWidth) / 2;
			int y = (planPanel.Height - rectHeight) / 2;

			return new Rectangle(x, y, rectWidth, rectHeight);
		}

        private void CreateWallButton_Click(object sender, EventArgs e)
        {
			if (isCreatingWall)
			{
				ResetToolButtons();
				return;
			}

			ResetToolButtons();

            isCreatingWall = true;
			createWallButton.Checked = true;
        }

        private void MoveWallButton_Click(object sender, EventArgs e)
        {
			if (isMovingWall)
			{
				ResetToolButtons();
				return;
			}

			ResetToolButtons();

            isMovingWall = true;
			moveWallButton.Checked = true;
        }

		private void DeleteWallButton_Click(object sender, EventArgs e)
		{
			if (isDeletingWall)
			{
				ResetToolButtons();
				return;
			}

			ResetToolButtons();

			isDeletingWall = true;
			deleteWallButton.Checked = true;
		}

		private void ResetToolButtons()
		{
			isCreatingWall = false;
			isMovingWall = false;
			isDeletingWall = false;

			createWallButton.Checked = false;
			moveWallButton.Checked = false;
			deleteWallButton.Checked = false;
			selectedWall = null;
		}

		private void PlanPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (isCreatingWall)
			{
				// Начало создания стены
				selectedWall = new Wall(e.X, e.Y, 1, 1, currentScale);
				walls.Add(selectedWall);
			}
			else if (isMovingWall)
			{
				// Выбор стены для перемещения
				selectedWall = walls.FirstOrDefault(w => w.Bounds.Contains(e.Location));
				if (selectedWall != null)
				{
					selectedWall.IsSelected = true;
					initialMousePosition = e.Location;
				}
			}
			else if (isDeletingWall)
			{
				// Удаление стены
				var wallToDelete = walls.FirstOrDefault(w => w.Bounds.Contains(e.Location));
				if (wallToDelete != null)
				{
					walls.Remove(wallToDelete);
				}
			}

			DrawPlan();
		}

		private void PlanPanel_MouseMove(object sender, MouseEventArgs e)
		{
			// Перемещение по области плана
			if (e.X < scrollMargin)
				offsetX = Math.Min(0, offsetX + scrollSpeed);
			else if (e.X > planPanel.Width - scrollMargin)
				offsetX -= scrollSpeed;

			if (e.Y < scrollMargin)
				offsetY = Math.Min(0, offsetY + scrollSpeed);
			else if (e.Y > planPanel.Height - scrollMargin)
				offsetY -= scrollSpeed;

			// Проверка на создание или перемещение стены
			if (isCreatingWall && selectedWall != null)
			{
				int width = e.X - selectedWall.Bounds.X - offsetX;

				int height = e.Y - selectedWall.Bounds.Y - offsetY;

				if (width > height && height > maxWallThickness)
					height = maxWallThickness;

				if (height > width && width > maxWallThickness)
					width = maxWallThickness;

				var rect = GetPlanRectangle();

				if (selectedWall.Bounds.X + width > rect.Right)
					width = rect.Right - selectedWall.Bounds.X;

				if (selectedWall.Bounds.Y + height > rect.Bottom)
					height = rect.Bottom - selectedWall.Bounds.Y;

				selectedWall.Bounds = new Rectangle(selectedWall.Bounds.X, selectedWall.Bounds.Y, width, height);
			}
			else if (isMovingWall && selectedWall != null)
			{
				int deltaX = e.X - initialMousePosition.X - offsetX;
				int deltaY = e.Y - initialMousePosition.Y - offsetY;

				var rect = GetPlanRectangle();
				var newX = Math.Max(rect.Left, Math.Min(selectedWall.Bounds.X + deltaX, rect.Right - selectedWall.Bounds.Width));
				var newY = Math.Max(rect.Top, Math.Min(selectedWall.Bounds.Y + deltaY, rect.Bottom - selectedWall.Bounds.Height));

				selectedWall.Bounds = new Rectangle(newX, newY, selectedWall.Bounds.Width, selectedWall.Bounds.Height);
				initialMousePosition = e.Location;
			}

			DrawPlan();
		}

		private void PlanPanel_MouseUp(object sender, MouseEventArgs e)
		{
			if (isCreatingWall && selectedWall != null)
			{
				selectedWall = new Wall(
					selectedWall.Bounds.X,
					selectedWall.Bounds.Y,
					selectedWall.Bounds.Width,
					selectedWall.Bounds.Height,
					currentScale
				);

				walls[walls.Count - 1] = selectedWall; // Обновляем последний добавленный элемент
				selectedWall = null;
			}
			else if (isMovingWall)
			{
				if (selectedWall != null)
				{
					selectedWall.IsSelected = false;
					selectedWall = null;
				}
			}

			DrawPlan();
		}
	}
}
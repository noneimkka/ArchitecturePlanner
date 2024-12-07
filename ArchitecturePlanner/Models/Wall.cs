using System.Drawing;

namespace ArchitecturePlanner.Models
{
	public class Wall
	{
		public Rectangle Bounds { get; set; }
		public bool IsSelected { get; set; } = false;

		// Исходные координаты и размеры
		public int OriginalX { get; private set; }
		public int OriginalY { get; private set; }
		public int OriginalWidth { get; private set; }
		public int OriginalHeight { get; private set; }

		public Wall(int x, int y, int width, int height, int currentScale)
		{
			Bounds = new Rectangle(x, y, width, height);

			// Сохраняем оригинальные размеры
			OriginalX = x / currentScale;
			OriginalY = y / currentScale;
			OriginalWidth = width / currentScale;
			OriginalHeight = height / currentScale;
		}

		// Метод обновления размеров при масштабировании
		public void UpdateBounds(int currentScale)
		{
			Bounds = new Rectangle(
				OriginalX * currentScale,
				OriginalY * currentScale,
				OriginalWidth * currentScale,
				OriginalHeight * currentScale
			);
		}
	}
}
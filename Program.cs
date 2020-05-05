using System;
using System.Threading;
using Snake_game;
using System.Diagnostics;
using System.Reflection;

namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetWindowSize(102, 30);

			string name;
			while (true)
			{
				Console.Write("Введите свое имя: ");
				name = Console.ReadLine();
				if (name.Length < 3)
				{
					Console.Clear();
					Console.WriteLine("Имя должно быть больше 3 символа.");
					continue;
				}
				else if(name.Length > 8)
				{
					Console.Clear();
					Console.WriteLine("Имя не должно быть больше 8 символов.");
					continue;
				}
				else
				{
					Console.Clear();
					break;
				}
			}

			Music music = new Music();
			music.MainMusic();

			Walls walls = new Walls(100, 25);
			walls.Draw();

			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(100, 24);
			Point food = foodCreator.CreateFood();
			food.Draw();

			Text text = new Text();

			int xOffsetO4ki = 40;
			int yOffsetO4ki = 26;

			int size = 4;
			text.WriteText("Длина змеи:" + size, xOffsetO4ki-35, yOffsetO4ki);

			int o4ki = 0;
			text.WriteText("Баллы:"+o4ki, xOffsetO4ki, yOffsetO4ki);

			Stopwatch stopWatch = new Stopwatch(); // секундомер
			stopWatch.Start(); // запустить секундомер

			while (true)
			{
				Console.SetCursorPosition(xOffsetO4ki, 27);
				TimeSpan ts = stopWatch.Elapsed; // структура для работы с временем
				Console.WriteLine($"{ts.Minutes:00}:{ts.Seconds:00}:{ts.Milliseconds:00}"); // вывод секунд и милисекунд

				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{

					music.EatSound();
					FoodCreator food1 = new FoodCreator(100, 24);
					food = food1.CreateFood();
					food.FoodDraw();
					o4ki++;
					Console.SetCursorPosition(xOffsetO4ki, yOffsetO4ki);
					text.WriteText("Баллы:" + o4ki, xOffsetO4ki, yOffsetO4ki);
					size ++;
					Console.SetCursorPosition(xOffsetO4ki, yOffsetO4ki);
					text.WriteText("Длина змеи:" + size, xOffsetO4ki - 35, yOffsetO4ki);
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			music.GameOver();

			GameOver game = new GameOver();
			game.WriteGameOver(o4ki);

			SaveFiles saveFiles = new SaveFiles();
			saveFiles.to_file(name,o4ki,size);

			ConsoleKeyInfo btn = Console.ReadKey();
			if (btn.Key == ConsoleKey.Enter)
			{
				var fileName = Assembly.GetExecutingAssembly().Location;
				System.Diagnostics.Process.Start(fileName);
				Environment.Exit(0);
			}
		}

	}
}

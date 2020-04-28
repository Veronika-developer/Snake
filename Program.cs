using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using Snake_game;
using System.IO;

namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
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
				else
				{
					Console.Clear();
					break;
				}
			}

			Console.SetWindowSize(100, 30);

			Music music = new Music();
			music.MainMusic();

			Walls walls = new Walls(100, 25);
			walls.Draw();
		
			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(100, 25, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			Text text = new Text();

			int xOffsetO4ki = 40;
			int yOffsetO4ki = 26;

			int o4ki = 0;
			text.WriteText("Баллы:"+o4ki, xOffsetO4ki, yOffsetO4ki);

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					music.EatSound();
					food = foodCreator.CreateFood();
					food.Draw();
					o4ki++;
					Console.SetCursorPosition(xOffsetO4ki, yOffsetO4ki);
					text.WriteText("Баллы:" + o4ki, xOffsetO4ki, yOffsetO4ki);

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
			saveFiles.to_file(name,o4ki);

			Console.ReadLine();
		}

	}
}

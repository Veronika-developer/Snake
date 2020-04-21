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

			int xOffsetO4ki = 40;
			int yOffsetO4ki = 26;

			int o4ki = 0;
			WriteText("Баллы:"+o4ki, xOffsetO4ki, yOffsetO4ki);

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
					WriteText("Баллы:" + o4ki, xOffsetO4ki, yOffsetO4ki);

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
			WriteGameOver();
			Console.ReadLine();
		}

		static void WriteGameOver()
		{
			int xOffset = 40;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			yOffset++;
			WriteText("Введите свое имя:", xOffset + 2, yOffset++);
			yOffset++;
			WriteText("Автор: Veronika Jefimova", xOffset + 2, yOffset++);
			WriteText("Группа: TARpv19", xOffset + 2, yOffset++);
			WriteText("============================", xOffset, yOffset++);

			Console.SetCursorPosition(xOffset + 2, yOffset - 4);
			string NameU = Console.ReadLine();

			SaveFiles saveFiles = new SaveFiles();
			saveFiles.to_file(NameU);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}

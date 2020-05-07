using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Snake
{
    class FoodCreator
    {
        int mapWidht;
        int mapHeight;
        char sym;

        static string symbols = "#¤%&@£$";
        static Random random = new Random();
        static char GetRandomChar()
        {
            var index = random.Next(symbols.Length);
            return symbols[index];
        }
        public FoodCreator(int mapWidht, int mapHeight)
        {
            this.mapWidht = mapWidht;
            this.mapHeight = mapHeight;
            this.sym = GetRandomChar();
        }

        public Point CreateFood()
        {
            int x = random.Next(2, mapWidht - 2);
            int y = random.Next(2, mapHeight - 2);
            return new Point(x, y, sym);
        }
    }
}
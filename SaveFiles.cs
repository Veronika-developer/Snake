using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game
{
    class SaveFiles
    {
        public SaveFiles()
        {
        }

        public void to_file(string x, int y, int s)
        {
            StreamWriter to_file = new StreamWriter(@"C:\Users\morgo\source\repos\Snake-game\Users.txt", true);
            to_file.WriteLine("Имя:" + x + " ¦Очки:"+ y + " ¦Длина:"+s);
            to_file.Close();
        }

        public void from_file()
        {
            StreamReader from_file = new StreamReader(@"C:\Users\morgo\source\repos\Snake-game\Users.txt", true);
            string text = from_file.ReadToEnd();
            Console.WriteLine(text);
            from_file.Close();
        }
    }
}

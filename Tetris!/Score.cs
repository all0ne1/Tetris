using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_
{
    internal static class Score
    {
        public static int bestscore = 0;
        public static int score = 0;
        public static string ReadScore()
        {
            string readedtext = "";
            using (StreamReader sr = new StreamReader("score.txt", System.Text.Encoding.Default))
            {
                readedtext = sr.ReadToEnd();
            }
            return readedtext;
        }
        public static void WriteScore()
        {
            using (StreamWriter sr = new StreamWriter("score.txt", false, System.Text.Encoding.Default))
            {
                sr.WriteLine(bestscore);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MadJunior
{
    public class Data
    {
        // number Of Questins per Level
        public static int taskSize = 10;

        public List<Board.Question> tasksEasy() {
            List<Board.Question> list = new List<Board.Question>();

            list.Add(new Board.Question("3 + 7 + 3", "17", "16", "13", "12", "13", "1"));
            list.Add(new Board.Question("3 + 7 - 3", "13", "7", "3", "16", "7", "1"));
            list.Add(new Board.Question("7 - 88", "95", "-81", "-18", "-1", "-81", "1"));
            list.Add(new Board.Question("10 - 10 - 55", "-5", "-55", "45", "10", "-55", "1"));
            list.Add(new Board.Question("10 + 10 - 55", "-35", "-55", "45", "10", "-35", "1"));
            list.Add(new Board.Question("10 + 10 + 55", "-5", "-55", "75", "10", "75", "1"));
            list.Add(new Board.Question("9 + 11 + 70", "90", "109", "111", "10", "90", "1"));
            list.Add(new Board.Question("5 - 10 + 55", "50", "-55", "45", "10", "50", "1"));
            list.Add(new Board.Question("10 * 85", "85", "850", "45", "10", "850", "1"));
            list.Add(new Board.Question("7 * 7", "-5", "49", "45", "10", "49", "1"));
            list.Add(new Board.Question("2 + 3 + 21", "26", "25", "15", "10", "26", "1"));
            list.Add(new Board.Question("2 * 2 * 4", "12", "8", "16", "32", "16", "1"));
            list.Add(new Board.Question("3 * 10 * 10", "30", "330", "45", "300", "300", "1"));
            list.Add(new Board.Question("10 - 10 - 10", "0", "10", "-20", "-10", "-10", "1"));
            list.Add(new Board.Question("100 + 99 + 1", "204", "299", "399", "200", "200", "1"));

            list = randomize(list);

            return list.GetRange(0, taskSize);
        }

        public List<Board.Question> tasksMedium() {
            List<Board.Question> list = new List<Board.Question>();

            list.Add(new Board.Question("3 * 15", "50", "30 + 16", "39 + 6", "45 + 5", "39 + 6", "2"));
            list.Add(new Board.Question("1 * 7 + 30", "38", "37", "7", "30", "37", "2"));
            list.Add(new Board.Question("5 * 5 * 20", "500", "100", "525", "255", "500", "2"));
            list.Add(new Board.Question("10 * 3 / 6 * 2", "20", "2", "3", "10", "10", "2"));
            list.Add(new Board.Question("(100 * 99) + 1", "1999", "991", "1000", "199", "991", "2"));
            list.Add(new Board.Question("5 * 2 * 20", "500", "100", "200", "255", "200", "2"));
            list.Add(new Board.Question("5 * 5 * 5", "550", "100", "125", "255", "125", "2"));
            list.Add(new Board.Question("5 * 3 * 3", "45", "150", "525", "145", "45", "2"));
            list.Add(new Board.Question("2 * 2 * 60", "605", "100", "240", "460", "240", "2"));
            list.Add(new Board.Question("3 * 10 * 7", "370", "210", "125", "255", "210", "2"));
            list.Add(new Board.Question("13 * 1 * 10", "133", "100", "130", "301", "130", "2"));
            list.Add(new Board.Question("5 + 55 * 1", "61", "65", "60", "255", "60", "2"));
            list.Add(new Board.Question("7 * 7 / 7 * 2", "14", "1", "7", "0", "14", "2"));
            list.Add(new Board.Question("8 * 5 / 20", "5", "20", "2", "6", "2", "2"));
            list.Add(new Board.Question("60 / 5 * 12", "360", "30", "12", "144", "144", "2"));

            list = randomize(list);

            return list.GetRange(0, taskSize);
        }

        public List<Board.Question> tasksHard() {
            List<Board.Question> list = new List<Board.Question>();

            list.Add(new Board.Question("15 * 15", "225", "525", "250", "255", "255", "3"));
            list.Add(new Board.Question("3 * 12 * 4", "120", "144", "360", "166", "144", "3"));
            list.Add(new Board.Question("8 * 7 * 2", "120", "144", "110", "112", "112", "3"));
            list.Add(new Board.Question("(3*3) + (3*9)", "36", "27", "81", "3", "36", "3"));
            list.Add(new Board.Question("(3*2) + (3*9)", "36", "27", "33", "3", "33", "3"));
            list.Add(new Board.Question("(3*3) + (5*5)", "34", "27", "31", "3", "34", "3"));
            list.Add(new Board.Question("12 + (4*9)", "36", "27", "81", "48", "48", "3"));
            list.Add(new Board.Question("60 + (4*9)", "85", "69", "81", "96", "96", "3"));
            list.Add(new Board.Question("(15+1) * (1*3)", "48", "27", "65", "36", "48", "3"));
            list.Add(new Board.Question("(3+3) + (3+9)", "36", "18", "81", "33", "18", "3"));
            list.Add(new Board.Question("155 + 99", "360", "270", "181", "254", "254", "3"));
            list.Add(new Board.Question("155 + 99", "360", "270", "181", "254", "254", "3"));
            list.Add(new Board.Question("145 + 99", "360", "244", "181", "254", "244", "3"));
            list.Add(new Board.Question("(7*12) + 99", "112", "183", "181", "240", "183", "3"));
            list.Add(new Board.Question("313 + 999", "300", "1312", "1081", "254", "1312", "3"));
            list.Add(new Board.Question("85 + (5 * 3) + 100 ", "260", "300", "180", "200", "200", "3"));

            list = randomize(list);

            return list.GetRange(0, taskSize);
        }

        // Resort any list Randomly
        private List<Board.Question> randomize(List<Board.Question> list)
        {
            Random rand = new Random();
            int n = list.Count;
            int size = n - 1;
            while (n > 0)
            {
                n--;
                int i = rand.Next(0, size);
                Board.Question temp = list[i];
                list[i] = list[n];
                list[n] = temp;
            }
            return list;
        }
    }
}
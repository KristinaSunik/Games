﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot
{
    class FileProvider
    {
        public static void Add(string path, User user)
        {
            var results = new StreamWriter(path, true);
            results.WriteLine(user.Name + " " + user.Surname + " " +
                user.CountRightAnswers.ToString() + " " + user.Diagnose);
            results.Close();
        }

        public static void Get(string path)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(path, true))
                {
                    var line = streamReader.ReadToEnd().Split('\n');
                    Console.WriteLine("{0,-25} {1,-25} {2,-35} {3, 20}\n",
                        "Имя:", "Фамилия:", "Количество правильных ответов:", "Диагноз:");
                    for (int i = 0; i < line.Length - 1; i++)
                    {
                        var world = line[i].Split(' ');
                        Console.WriteLine("{0,-25} {1,-25} {2,-35} {3, 20}\n", world[0], world[1], world[2], world[3]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

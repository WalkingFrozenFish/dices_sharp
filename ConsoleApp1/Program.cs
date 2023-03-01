﻿using System;

namespace MyProgram
{
    class Dice
    {
        static void Main()
        {
            Console.WriteLine("---          Start game          ---");
            
            Console.WriteLine("Загадайте число от 2 до 12");
            int userChoice = int.Parse(Console.ReadLine());

            Console.WriteLine("Загаданное число (2..12): {0}", userChoice);
            Console.WriteLine("Пользователь кинул кости:");
            
            RollTheDice(userChoice, "Пользователь");

            Console.WriteLine("Компьютер загадывает число от 2 до 12");
            Random random = new Random();
            int computerChoice = random.Next(2, 13);
            Console.WriteLine("Загаданное число (2..12): {0}", computerChoice);
            Console.WriteLine("Компьютер кинул кости:");
            
            RollTheDice(computerChoice, "Компьютер");
        }

        static string PrintDice(int number)
        {
            switch (number)
            {
                case 1:
                    return "\n---------\n|       |\n|   #   |\n|       |\n---------\n";
                    break;
                case 2:
                    return "\n---------\n| #     |\n|       |\n|     # |\n---------\n";
                    break;
                case 3:
                    return "\n---------\n| #     |\n|   #   |\n|     # |\n---------\n";
                    break;
                case 4:
                    return "\n---------\n| #   # |\n|       |\n| #   # |\n---------\n";
                    break;
                case 5:
                    return "\n---------\n| #   # |\n|   #   |\n| #   # |\n---------\n";
                    break;
                case 6:
                    return "\n---------\n| # # # |\n|       |\n| # # # |\n---------\n";
                    break;
                default:
                    return "Отсутствует вариант";
            }
        }

        static int RollTheDice(int userChoice, string who)
        {
            Random random = new Random();
            int firstDice = random.Next(1, 7);
            int secondDice = random.Next(1, 7);

            int formula = (firstDice + secondDice) - Math.Abs((firstDice + secondDice) - userChoice) * 2;

            Console.WriteLine("{0} {1}", PrintDice(firstDice), PrintDice(secondDice));
            Console.WriteLine("На костях выпало {0} очков", firstDice + secondDice);
            Console.WriteLine("Результат {0} - ABS({0} - {1}) * 2: {2}", firstDice + secondDice, userChoice, formula);

            if (formula > 0)
            {
                Console.WriteLine("{0} победил", who);
                return formula;
            }
            else
            {
                Console.WriteLine("{0} проиграл", who);
                return formula;
            }
        }
    }
}
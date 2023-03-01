using System;

namespace MyProgram
{
    class GameRound
    {
        public int userGues;
        public int userDice;
        public int userResult;
        
        public int computerGues;
        public int computerDice;
        public int computerResult;

        public int roundNum;

        public GameRound(int roundNum)
        {
            this.roundNum = roundNum;
        }

        public string GetMessage()
        {
            string resultMessage = string.Format(
                "-------+----------------+--------------- \n" +
                "       | Predicted:  {1}  | Predicted:  {4} \n" +
                " - {0} - | Dice:       {2}  | Dice:       {5} \n" +
                "       | Result:     {3}  | Result:     {6} \n",
                this.roundNum, userGues, userDice, userResult, computerGues, computerDice, computerResult
            );

            return resultMessage;
        }
    }
    class Dice
    {
        static void Main()
        {
            GameRound[] gameRounds = new GameRound[3] { new GameRound(1), new GameRound(2), new GameRound(3) };

            Console.WriteLine("---          Start game          ---");

            for (int i = 0; i < gameRounds.Length; i++)
            {
                // User
                Console.WriteLine("Загадайте число от 2 до 12");
                gameRounds[i].userGues = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Загаданное число (2..12): {0}", gameRounds[i].userGues);
                Console.WriteLine("Пользователь кинул кости:");
                
                gameRounds[i].userResult = RollTheDice(gameRounds[i].userGues, "Пользователь", gameRounds[i]);
                
                
                // Computer
                Console.WriteLine("Компьютер загадывает число от 2 до 12");
                Random random = new Random();
                gameRounds[i].computerGues = random.Next(2, 13);
                
                Console.WriteLine("Загаданное число (2..12): {0}", gameRounds[i].computerGues);
                Console.WriteLine("Компьютер кинул кости:");
                
                gameRounds[i].computerResult = RollTheDice(gameRounds[i].computerGues, "Компьютер", gameRounds[i]);
                
                
                // Round result
                Console.WriteLine("---------- Current score ---------");
                Console.WriteLine(" User:       {0} points", gameRounds[i].userResult);
                Console.WriteLine(" Computer:   {0} points", gameRounds[i].computerResult);
                Console.WriteLine("\n");
                
                if (gameRounds[i].userResult > gameRounds[i].computerResult)
                {
                    Console.WriteLine("Результат раунда: Результат пользователя больше на {0} единиц", gameRounds[i].userResult - gameRounds[i].computerResult);
                }
                else
                {
                    Console.WriteLine("Результат раунда: Результат компьютера больше на {0} единиц", gameRounds[i].computerResult - gameRounds[i].userResult);
                }
            }
            
            string gameResultMessage = string.Format(
                "-------------- Finish game ------------- \n" +
                " Round |           User |      Computer  \n" +
                gameRounds[0].GetMessage() + gameRounds[1].GetMessage() + gameRounds[2].GetMessage() +
                "-------+----------------+--------------- \n" +
                "Total  | Points:     {0} | Points:     {1} \n", (gameRounds[0].userResult + gameRounds[1].userResult + gameRounds[2].userResult), (gameRounds[0].computerResult + gameRounds[1].computerResult + gameRounds[2].computerResult));

            Console.WriteLine(gameResultMessage);
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

        static int RollTheDice(int userChoice, string who, GameRound round)
        {
            Random random = new Random();
            int firstDice = random.Next(1, 7);
            int secondDice = random.Next(1, 7);

            int formula = (firstDice + secondDice) - Math.Abs((firstDice + secondDice) - userChoice) * 2;

            Console.WriteLine("{0} {1}", PrintDice(firstDice), PrintDice(secondDice));
            Console.WriteLine("На костях выпало {0} очков", firstDice + secondDice);
            Console.WriteLine("Результат {0} - ABS({0} - {1}) * 2: {2}", firstDice + secondDice, userChoice, formula);

            if (who == "Пользователь")
            {
                round.userDice = firstDice + secondDice;
            } else if (who == "Компьютер")
            {
                round.computerDice = firstDice + secondDice;
            }

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
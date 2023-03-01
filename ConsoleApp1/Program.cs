using System;

namespace MyProgram
{
    
    class Dice
    {
        static int gameAttempt = 0;
        
        static int firstRoundUserGues;
        static int firstRoundUserDice;
        static int firstRoundUserResult;
            
        static int firstRoundComputerGues;
        static int firstRoundComputerDice;
        static int firstRoundComputerResult;
        
        
        static int secondRoundUserGues;
        static int secondRoundUserDice;
        static int secondRoundUserResult;
            
        static int secondRoundComputerGues;
        static int secondRoundComputerDice;
        static int secondRoundComputerResult;
        
        
        static int thirdRoundUserGues;
        static int thirdRoundUserDice;
        static int thirdRoundUserResult;
            
        static int thirdRoundComputerGues;
        static int thirdRoundComputerDice;
        static int thirdRoundComputerResult;

        static int userResult = firstRoundUserResult + secondRoundUserResult + thirdRoundUserResult;
        static int computerResult =
            firstRoundComputerResult + secondRoundComputerResult + thirdRoundComputerResult;

        public static string firstRoundResult;
        public static string secondRoundResult;
        public static string thirdRoundResult;
        static void Main()
        {
            // string firstRoundResult = string.Format(
            //     "-------+----------------+--------------- \n" +
            //     "       | Predicted:  {0}  | Predicted:  {3} \n" +
            //     " - 1 - | Dice:       {1}  | Dice:       {4} \n" +
            //     "       | Result:     {2}  | Result:     {5} \n",
            //     firstRoundUserGues, firstRoundUserDice, firstRoundUserResult, firstRoundComputerGues, firstRoundComputerDice, firstRoundComputerResult
            //     );
            //
            // string secondRoundResult = string.Format(
            //     "-------+----------------+--------------- \n" +
            //     "       | Predicted:  {0}  | Predicted:  {3} \n" +
            //     " - 2 - | Dice:       {1}  | Dice:       {4} \n" +
            //     "       | Result:     {2}  | Result:     {5} \n",
            //     secondRoundUserGues, secondRoundUserDice, secondRoundUserResult, secondRoundComputerGues, secondRoundComputerDice, secondRoundComputerResult
            // );
            //
            // string thirdRoundResult = string.Format(
            //     "-------+----------------+--------------- \n" +
            //     "       | Predicted:  {0}  | Predicted:  {3} \n" +
            //     " - 2 - | Dice:       {1}  | Dice:       {4} \n" +
            //     "       | Result:     {2}  | Result:     {5} \n",
            //     thirdRoundUserGues, thirdRoundUserDice, thirdRoundUserResult, thirdRoundComputerGues, thirdRoundComputerDice, thirdRoundComputerResult
            // );

            

            Console.WriteLine("---          Start game          ---");
            
            while (gameAttempt < 3)
            {
                Console.WriteLine("Загадайте число от 2 до 12");
                int userChoice = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Загаданное число (2..12): {0}", userChoice);
                Console.WriteLine("Пользователь кинул кости:");
                
                int userResult = RollTheDice(userChoice, "Пользователь");
                
                
                Console.WriteLine("Компьютер загадывает число от 2 до 12");
                Random random = new Random();
                int computerChoice = random.Next(2, 13);
                Console.WriteLine("Загаданное число (2..12): {0}", computerChoice);
                Console.WriteLine("Компьютер кинул кости:");
            
                int computerResult = RollTheDice(computerChoice, "Компьютер");
                
                Console.WriteLine("---------- Current score ---------");
                Console.WriteLine(" User:       {0} points", userResult);
                Console.WriteLine(" Computer:   {0} points", computerResult);
                Console.WriteLine("\n");
            
                if (userResult > computerResult)
                {
                    Console.WriteLine("Результат раунда: Результат пользователя больше на {0} единиц", userResult - computerResult);
                }
                else
                {
                    Console.WriteLine("Результат раунда: Результат компьютера больше на {0} единиц", computerResult - userResult);
                }

                if (gameAttempt == 0)
                {
                    firstRoundUserGues = userChoice;
                    firstRoundUserDice = userResult;
            
                    firstRoundComputerGues = computerChoice;
                    firstRoundComputerDice = computerResult;
                    
                    firstRoundResult = string.Format(
                        "-------+----------------+--------------- \n" +
                        "       | Predicted:  {0}  | Predicted:  {3} \n" +
                        " - 1 - | Dice:       {1}  | Dice:       {4} \n" +
                        "       | Result:     {2}  | Result:     {5} \n",
                        firstRoundUserGues, firstRoundUserDice, firstRoundUserResult, firstRoundComputerGues, firstRoundComputerDice, firstRoundComputerResult
                    );
                } else if (gameAttempt == 1)
                {
                    secondRoundUserGues = userChoice;
                    secondRoundUserDice = userResult;
                    
                    secondRoundComputerGues = computerChoice;
                    secondRoundComputerDice = computerResult;
                    
                    secondRoundResult = string.Format(
                        "-------+----------------+--------------- \n" +
                        "       | Predicted:  {0}  | Predicted:  {3} \n" +
                        " - 2 - | Dice:       {1}  | Dice:       {4} \n" +
                        "       | Result:     {2}  | Result:     {5} \n",
                        secondRoundUserGues, secondRoundUserDice, secondRoundUserResult, secondRoundComputerGues, secondRoundComputerDice, secondRoundComputerResult
                    );
                } else if (gameAttempt == 2)
                {
                    thirdRoundUserGues = userChoice;
                    thirdRoundUserDice = userResult;
                    
                    thirdRoundComputerGues = computerChoice;
                    thirdRoundComputerDice = computerResult;
                    
                    thirdRoundResult = string.Format(
                        "-------+----------------+--------------- \n" +
                        "       | Predicted:  {0}  | Predicted:  {3} \n" +
                        " - 2 - | Dice:       {1}  | Dice:       {4} \n" +
                        "       | Result:     {2}  | Result:     {5} \n",
                        thirdRoundUserGues, thirdRoundUserDice, thirdRoundUserResult, thirdRoundComputerGues, thirdRoundComputerDice, thirdRoundComputerResult
                    );
                }
                
                gameAttempt++;
            }
            
            string gameResult = string.Format(
                "-------------- Finish game ------------- \n" +
                " Round |           User |      Computer  \n" +
                firstRoundResult + secondRoundResult + thirdRoundResult +
                "-------+----------------+--------------- \n" +
                "Total  | Points:     {0} | Points:     {1} \n", userResult, computerResult);

            Console.WriteLine(gameResult);
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
            
            if (gameAttempt == 0)
            {
                firstRoundUserResult = firstDice + secondDice;
                firstRoundComputerResult = firstDice + secondDice;
            } else if (gameAttempt == 1)
            {
                secondRoundUserResult = firstDice + secondDice;
                secondRoundComputerResult = firstDice + secondDice;
            } else if (gameAttempt == 2)
            {
                thirdRoundUserResult = firstDice + secondDice;
                thirdRoundComputerResult = firstDice + secondDice;
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
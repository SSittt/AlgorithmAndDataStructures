using System.Diagnostics.Metrics;

namespace GAmeFindingNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = 0;                // мин кол-во попыток 
            int max = 0;                // макс кол-вщ попыток
            int count = 0;              // всего попыток всей игры
            int countGame = 0;          // кол-во сыгранных игр
            Random rnd = new Random();  //генератор случайных чисел
            char answer = 'Y';          // ответ пользователь Y - играем еще 

                do
            {
                int rndnum = rnd.Next(0, 101);      // генератор случайных чисел 
                int counter = 0;                    // счетчик попыток

                while (true)
                {
                    Console.WriteLine("Input number from [0;101]"); // Просим вести число пользователя
                    int attempt = GetNumberFromUser();              // Получаем этого число от пользователя

                    if (CompareNumbers(rndnum, attempt, ref counter))     // проверяем выграли ли пользователь
                    {
                        UpdateStatistics(counter, ref min, ref max, ref count, ref countGame); // обновление  статистики
                        break;
                    }
                }

                Console.WriteLine("Do you want play again"); // Спрашиваем пользователя о продолжении игры
                answer = Convert.ToChar(Console.Read());     // Получаем ответ от пользователя
            } 
            
            while (answer == 'Y');                  // если ответ Y  - продолжаем
            ShowStats(min, max, count, countGame);  // Показываем после завершение игры статистику
        }

        static int GetNumberFromUser()                                  // Мпетод получение от пользователя число 
        {
            int attempt = 0;                                            // число, которое ввел пользователь
            for (int i = 0; i < 3; i++)                                 // дается 3 попытки на правильные ответ 
            {
                if (!int.TryParse(Console.ReadLine(), out attempt)
                    || attempt > 100 || attempt < 0)                    // проверяем число 
                {
                    Console.WriteLine("Input number from [0;101]");     // если ошибка вывод сообщение
                }
                else
                {
                    return attempt;
                }
                if (i == 2)                                             // если 3 попытки не верны выводит сообщение
                {
                    Console.WriteLine("You are stupid");
                }
            }
            return attempt;
        }
        static bool CompareNumbers(int rndnum, int attempt, ref int counter)    //  Метод для сравнение введеное число с загаданным 
        {
            counter++;                                          // Считаем попытки 

            if (rndnum < attempt)                               // если число пользователя больше выводит сообщение 
            {
                Console.WriteLine("You number is greater");
                return false;                                   // если пользователь не угадал 
            }
            else if (rndnum > attempt)                          // если число пользователя меньше выводит сообщение
            {
                Console.WriteLine("Your number is less");
                return false;
            }
            else
            {
                Console.WriteLine("Your are win!");
                return true;                                    // если пользователь угадал
            }
        }


        static void UpdateStatistics(int counter, ref int min, ref int max, ref int count, ref int countGame) // метод для отслеживании статистики 
        {
            if (min == 0 || min > counter) min = counter;   // мининмум
            max = max < counter ? counter : max;            // максимум
            count += counter;                               // общая сумма попыток
            countGame++;                                    // кол-во игр
        }

        static void ShowStats(int min, int max, int count, int countGame) // метод для вывода статистики
        {
            Console.WriteLine($"min = {min} max = {max} avg = {(double)count / countGame}"); // показывает статистику после завершения игры
        }


    }

}
 

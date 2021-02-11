using System;
using System.Linq;

namespace ElaboTek
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] chips_array = {1, 5, 9, 10, 5};                // Массив фишек ( Тест 1)
            //int[] chips_array = {1, 2, 3};                       // Массив фишек ( Тест 2)
            //int[] chips_array = {0, 1, 1, 1, 1, 1, 1, 1, 1, 2};  // Массив фишек ( Тест 3)
            int number_players = chips_array.Length;  // Количество игроков
            int total_chips = chips_array.Sum();      // Суммарное количество фишек
            int chips_one_player = total_chips / number_players;  //  Исходное количество фишек у каждого игрока
            int number_steps;       // Количество ходов на каждой итерации 
            int number_moves = 0;  // Искомое минимальное количество ходов для равномерного распределения фишек

            int max_chips = chips_array.Max();  // Максимальное количество фишек на игровом месте
            int min_chips = chips_array.Min();  // Минимальное количество фишек на игровом месте
            int index_max_chips = -1;           // Номер игрового места с максимальным количеством фишек
            int index_min_chips = -1;           // Номер игрового места с минимальным количеством фишек

            while (max_chips > chips_one_player)
            {
                index_max_chips = Array.FindIndex(chips_array, i => i == max_chips);
                index_min_chips = Array.FindIndex(chips_array, i => i == min_chips);
                number_steps = Math.Abs(index_max_chips - index_min_chips);
                if (number_steps > (number_players / 2))          // Определяем наименьший путь (направление) перемещения фишек
                    number_steps = number_players - number_steps;
                number_moves += number_steps;
                chips_array[index_max_chips] -= 1;
                chips_array[index_min_chips] += 1;

                max_chips = chips_array.Max();
                min_chips = chips_array.Min();
            }

            Console.WriteLine("Минимальное количество ходов для равномерного рапределения фишек = " + number_moves);
        }
    }
}

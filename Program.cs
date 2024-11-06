using System;

namespace kazino_ruletka;
public class Program
{

  public static void Main(string[] args)
  {

    var ListOfRoulette = new ListOfRoulette();

    string bet = "четное";
    Console.WriteLine($"четное {ListOfRoulette.getNumberByKey("1").getByAttribute(bet)}");
    Random random = new Random();
    string start = default, choice = default;
    int money;

    string[] options = { "число", "красное/чёрное", "старшинство", "ряд", "совокупность чисел", "столбец", "последовательность", "чётное/нечётное" };

    while (true)
    {
      Console.Write("Готов ли ты попытать свою удачу? (Выбери да/нет): ");
      start = Console.ReadLine().ToLower();

      // Проверка выбора пользователя
      if (start == "нет")
      {
        Console.WriteLine("\nПечально :(\nНо ты заходи если что. До следующего раза :)");
        break;
      }
      else if (start == "да")
      {
        Console.WriteLine("\nСупер! Давай поскорее начнём играть)");

        Console.Write($"Cколько ты хочешь поставить?:");
        if (!int.TryParse(Console.ReadLine(), out money))
        {
          Console.WriteLine("Введите число.");
          continue;
        }

        Console.Write($"Выбери из переченя:'число','красное/чёрное','старшинство','ряд,'совокупность чисел','столбец','последовательность ',чётное/нечётное':");
        bet = Console.ReadLine();

        if (Array.IndexOf(options, bet) == -1)
        {
          Console.WriteLine("Такой ставки нет в списке. Попробуй ещё раз");
          continue;
        }

        if (bet == "число")
        {
          Console.Write("Какое именно число от 0 до 36 ты хочешь выбрать?: ");
          choice = Console.ReadLine();

          string[] validChoices = new string[37];
          for (int i = 0; i <= 36; i++)
          {
            validChoices[i] = i.ToString();
          }

          if (Array.IndexOf(validChoices, choice) == -1)
          {
            Console.WriteLine("Введена неправильная информация. Попробуй ещё раз.");
            continue;
          }
        }

        if (bet == "красное/чёрное")
        {
          Console.Write("Какой именно цвет ты хочешь выбрать?: ");
          choice = Console.ReadLine();

          string[] validChoices = { "красное", "чёрное" };

          if (Array.IndexOf(validChoices, choice) == -1)
          {
            Console.WriteLine("Введена неправильная информация. Попробуй ещё раз.");
            continue;
          }
        }

        int rand = random.Next(ListOfRoulette.Numbers.Count());

        Console.WriteLine($"На рулетке выпало: {rand}");

        if (ListOfRoulette.getNumberByKey("1").getByAttribute(bet).ToString() == choice.ToString())
        {
          money *= 2;
          Console.WriteLine($"Поздравляю! Ты выиграл {money} долларов");
        }
        else
        {
          Console.WriteLine($"К сожалению, ты проиграл {money} долларов");
        }
      }

      else
      {
        Console.WriteLine("Такого варианта нет");
        continue;
      }
    }

  }
}


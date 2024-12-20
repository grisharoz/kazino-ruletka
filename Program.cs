using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Dynamic;

namespace kazino_ruletka;
public class Program
{

  public static void Main(string[] args)
  {
    var roulette = new ListOfRoulette();


    List<Bet> bets = new List<Bet>();

    Random random = new Random();
    string start = default;
    int stakeAmount = 0;
    int balance = 300;

    string[] options = { "число", "цвет", "старшинство", "ряд", "совокупность чисел", "столбец", "последовательность", "чётность" };


    while (true)
    {

      Console.Write("Готов ли ты попытать свою удачу? (Выбери да/нет): ");
      start = Console.ReadLine().ToLower().Trim();

      if (start != "нет" && start != "да")
      {
        System.Console.WriteLine("Введена неправильная информация. Попробуй ещё раз.");
        continue;
      }

      // Проверка выбора пользователя
      if (start == "нет")
      {
        Console.WriteLine("Печально :(\nНо ты заходи если что. До следующего раза :)");
        break;
      }
      else if (start == "да")
      {

        Console.WriteLine("\nСупер! Давай поскорее начнём играть)\n");

        System.Console.WriteLine($"Твой баланс: {balance}$");
        while (true)
        {

          Console.Write($"Cколько ты хочешь поставить?:");
          

          if (!int.TryParse(Console.ReadLine().Trim(), out stakeAmount))
          {
            Console.WriteLine("Введите число.");

            continue;
          }
          if(stakeAmount>balance){
            
            Console.WriteLine("У тебя нет сколько денег.Попробуй ещё раз");
            continue;
         

          }
          

          Console.Write($"Выбери из перечня:'число','цвет','старшинство','ряд','совокупность чисел','столбец','последовательность','чётность':");


          string betType = Console.ReadLine().ToLower().Trim();

          if (Array.IndexOf(options, betType) == -1)
          {
            Console.WriteLine("Такой ставки нет в списке. Попробуй eщё раз");
            continue;
          }

          if (betType == "число")
          {
            Console.Write("Какое именно число от 0 до 36 ты хочешь выбрать?: ");
            string input = Console.ReadLine().Trim();
            List<string> validChoices = Enumerable.Range(0, 37).Select(i => i.ToString()).ToList();

            if (!validChoices.Contains(input))
            {
              System.Console.WriteLine("Введена неправильная информация. Попробуй ещё раз.");
              continue;
            }
            else
            {
              bets.Add(new Bet(stakeAmount, betType, input));
              balance -= stakeAmount;

            }

          }



          if (betType == "цвет")
          {
            Console.Write("Какой именно цвет ты хочешь выбрать?(красный/чёрный или зелёный): ");
            string input = Console.ReadLine().ToLower().Trim();

            List<string> validChoices = new List<string>() { "красный", "чёрный", "зелёный" };
            if (!validChoices.Contains(input))
            {
              Console.WriteLine("Введена неправильная информация. Попробуй ещё раз.");
              continue;
            }
            else
            {
              bets.Add(new Bet(stakeAmount, betType, input));
              balance -= stakeAmount;
              
            }
          }


          if (betType == "старшинство")
          {

            Console.Write("Какую именно последовательность ты хочешь выбрать?(1-18/19-36):");
            string input = Console.ReadLine().Trim();



            List<string> validChoices = ["1-18", "19-36"];

            if (!validChoices.Contains(input))
            {
              Console.WriteLine("Введена неправильная информация. Попробуй ещё раз.");
              continue;
            }
            else
            {
              bets.Add(new Bet(stakeAmount, betType, input));
              balance -= stakeAmount;
            }
          }


          if (betType == "ряд")
          {

            Console.Write("Какой именно ряд ты хочешь выбрать(1,2,3)?:");
            string input = Console.ReadLine().Trim();
            List<string> validChoices = Enumerable.Range(1, 3).Select(i => i.ToString()).ToList();

            if (!validChoices.Contains(input))
            {
              System.Console.WriteLine("Введена неправильная информация. Попробуй ещё раз.");
              continue;
            }
            else
            {
              bets.Add(new Bet(stakeAmount, betType, input));
              balance -= stakeAmount;
            }
          }

          if (betType == "столбец")
          {
            Console.Write("Какой именно столбец ты хочешь выбрать?(1-12):");
            string input = Console.ReadLine().Trim();
            List<string> validChoices = Enumerable.Range(1, 12).Select(i => i.ToString()).ToList();

            if (!validChoices.Contains(input))
            {
              System.Console.WriteLine("Введена неправильная информация. Попробуй ещё раз.");
              continue;
            }
            else
            {
              bets.Add(new Bet(stakeAmount, betType, input));
              balance -= stakeAmount;
            }
          };


          if (betType == "последовательность")
          {
            Console.Write("Какую именно последовательность ты хочешь выбрать?(1-12/13-24/25-36):");
            string input = Console.ReadLine().Trim();

            List<string> validChoices = ["1-12", "13-24", "25-36"];

            if (!validChoices.Contains(input))
            {
              Console.WriteLine("Введена неправильная информация. Попробуй ещё раз.");
              continue;
            }
            else
            {
              bets.Add(new Bet(stakeAmount, betType, input));
              balance -= stakeAmount;
            }

          }

          if (betType == "чётность")
          {
            Console.Write("Ты выберишь чётное или нечётное?:");
            string input = Console.ReadLine().ToLower().Trim();

            List<string> validChoices = ["чётное", "нечётное"];

            if (!validChoices.Contains(input))
            {
              Console.WriteLine("Введена неправильная информация. Попробуй ещё раз.");
              continue;
            }
            {
              bets.Add(new Bet(stakeAmount, betType, input));
              balance -= stakeAmount;
            }

          }

          if (betType == "совокупность чисел")
          {

            Console.Write("Какую именно совокупность чисел ты хочешь выбрать?(напиши её через слэш):");
            string input = Console.ReadLine().Trim();


            string[] validCollectionChoices=["1/2","1/4","1/2/4/5","1/2/3/4/5/6","2/3","2/5","2/3/5/6","3/6","4/5","5/6","5/8","4/5/7/8","5/6/8/9","4/5/6/7/8/9","6/9","4/7","7/8","7/10","7/8/10/11","7/8/9/10/11/12","8/9","8/11","8/9/11/12","9/12","10/11","10/13","10/11/13/14","10/11/12/13/14/15","11/12","11/14","11/12/14/15","12/15","13/14","13/16","13/14/16/17","13/14/15/16/17/18","14/15","15/18","14/15/17/18","16/17","16/19","16/17/19/20","16/17/18/19/20/21","14/17","17/18","17/20","17/18/20/21","18/21","19/20","19/22","19/20/22/23","19/20/21/22/23/24","20/21","20/23","20/21/23/24","21/24","22/23","22/25","22/23/25/26","22/23/24/25/26","23/24","23/26","23/24/26/27","22/23/24/25/26/27","24/27","25/26","25/28","25/26/28/29","25/26/27/28/29/30","26/27","26/29","26/27/29/30","27/30","28/29","28/31","28/29/31/32","28/29/30/31/32/33","29/30","29/32","29/30/32/33","30/33","31/32","31/34","31/32/34/35","31/32/33/34/35/36","32/33","32/35","32/33/35/36","33/36","34/35","35/36"];

            if (!validCollectionChoices.Contains(input))
            {
              Console.WriteLine("Введена неправильная информация. Попробуй ещё раз.");
              continue;
            }
            else
            {
              bets.Add(new Bet(stakeAmount, betType, input));
              balance -= stakeAmount;
            }

          };
          System.Console.WriteLine($"\nТвой актуальный баланс: {balance}");
          System.Console.Write("\nТы хочешь ещё поставить?(да/нет):");
        
          
          string manystakes = Console.ReadLine().ToLower().Trim();
          if (manystakes == "да")
          {
            continue;
          }

          else if (manystakes == "нет")
          {
            string rand = random.Next(roulette.Numbers.Count()).ToString();

            Console.WriteLine($"На рулетке выпало: {rand}");
     
            bets.ForEach(delegate(Bet bet)
            {
              string type = bet.getByAttribute("Type").ToString();
              string value = bet.getByAttribute("Value").ToString();
              stakeAmount = (int) bet.getByAttribute("Stake");
             

              if(type=="совокупность чисел"){

                if (roulette.getNumberByKey(rand).getByAttribute(type) is List<string> collectionOfNumbers)
                {

                    if(collectionOfNumbers.Contains(value)){
                        string collectionOfNumbersCount=value.Split("/").Length.ToString();
                        Dictionary<string, int> coefficients = new Dictionary<string, int>(){
                          {"2",18},
                          {"3",12},
                          {"4",9},
                          {"6",6},
                          
                        };

                        balance += stakeAmount * coefficients[collectionOfNumbersCount];
                        Console.WriteLine($"Поздравляю! Ты выиграл {stakeAmount * coefficients[collectionOfNumbersCount]} долларов, поставив на {value}");
                    }else{
                        Console.WriteLine($"К сожалению, ты проиграл {stakeAmount} долларов, поставив на {value}");
                    }

                }

              }else{
                if (roulette.getNumberByKey(rand).getByAttribute(type).ToString() == value)
                {
                  balance += stakeAmount * roulette.coefficients[type];
                  Console.WriteLine($"Поздравляю! Ты выиграл {stakeAmount * roulette.coefficients[type]} долларов, поставив на {value}");
                  System.Console.WriteLine($"Твой баланс: {balance}$");
                } else {
                  
                  Console.WriteLine($"К сожалению, ты проиграл {stakeAmount} долларов, поставив на {value}");
                  
                  
                  System.Console.WriteLine($"Твой баланс: {balance}$");
                
                }
              }
              

            });
            bets.Clear();
            break;
          }
        }
      }
    }
  }

}

using System;

namespace kazino_ruletka;

public class Program
{
    public static void Main(string[] args)
    {
        string start,bet;
        int money;
        
        

        Console.Write($"Приветствую! Рады видеть тебя в одной из увлекательной и фартовой игре в мире :)\nГотов ли ты попытать свою удачу?(Выбери да/нет):");
        start=Console.ReadLine();

        if(start=="да")
        Console.WriteLine($"\nСупер! Давай поскорее начнём играть");
        
        Console.Write($"Cколько ты хочешь поставить?:");
        money=Convert.ToInt32(Console.ReadLine());

        Console.Write($"Выбери из переченя:'число','красное/чёрное','старшинство','ряд,'совокупность чисел','столбец','последовательность ',чётное/нечётное':");
        bet=Console.ReadLine();

        List<string> options= new List<string>();
        {
          new string("число");
          new string("красное/чёрное");
          new string("старшинство");
          new string("ряд");
          new string("совокупность чисел");
          new string("столбец");
          new string("последовательность");
          new string("чётное/нечётное");     

        };



        if(start=="нет")
        Console.WriteLine($"\nПечально :(\nНо ты заходи если что. До следующего раза :)");

    }
}
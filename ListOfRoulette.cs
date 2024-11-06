public class ListOfRoulette
{
    public Dictionary<string, RouletteNumber> Numbers { get; private set; }

    public ListOfRoulette()
    {
        Numbers = new Dictionary<string, RouletteNumber>();
        GenerateRouletteNumbers();
    }

    private void GenerateRouletteNumbers()
    {
        Numbers.Add("0", new RouletteNumber(0, true));
        Numbers.Add("1", new RouletteNumber(1, false, "красный", "1", "1", "1/18", "1/12", new List<string> { "1/2", "1/4", "1/2/4/5", "1/2/3/4/5/6" }));
        Numbers.Add("2", new RouletteNumber(2, true, "чёрный", "2", "1", "1/18", "1/12", new List<string> { "1/2", "2/3", "2/5", "1/2/4/5", "2/3/5/6", "1/2/3/4/5/6" }));
    }

    public void PrintRouletteNumbers()
    {
        foreach (var number in Numbers)
        {
            Console.WriteLine($"Число: {number.Value.Число}, Четное: {number.Value.Четное}, Цвет: {number.Value.Цвет}, Ряд: {number.Value.Ряд}, Столбец: {number.Value.Столбец}, Старшинство: {number.Value.Старшинство}, Послед: {number.Value.Послед}, Совокупность чисел: {string.Join(", ", number.Value.СовокупностьЧисел)}");
        }
    }

    public RouletteNumber getNumberByKey(string key)
    {
        return Numbers[key];
    }
}

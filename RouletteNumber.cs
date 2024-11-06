public class RouletteNumber
{
    public int Число { get; set; }
    public bool Четное { get; set; }
    public string Цвет { get; set; }
    public string Ряд { get; set; }
    public string Столбец { get; set; }
    public string Старшинство { get; set; }
    public string Послед { get; set; }
    public List<string> СовокупностьЧисел { get; set; }

    public int Коэффициент { get; set; }

    // Конструктор для инициализации свойств
    public RouletteNumber(int число, bool четное, string цвет = null, string ряд = null,
                        string столбец = null, string старшинство = null,
                        string послед = null, List<string> совокупностьЧисел = null)
    {
        Число = число;
        Четное = четное;
        Цвет = цвет;
        Ряд = ряд;
        Столбец = столбец;
        Старшинство = старшинство;
        Послед = послед;
        СовокупностьЧисел = совокупностьЧисел ?? new List<string>();
    }

    public object getByAttribute(string attribute)
    {
        switch (attribute)
        {
            case "число":
                return Число;
            case "четное":
                return Четное;
            case "цвет":
                return Цвет;
            case "ряд":
                return Ряд;
            case "столбец":
                return Столбец;
            case "старшинство":
                return Старшинство;
            case "послед":
                return Послед;
            case "совокупность чисел":
                return СовокупностьЧисел;
            default:
                return "Такого атрибута нет";
        }
    }
}

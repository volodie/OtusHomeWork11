using OtusHomeWork11;

internal class Program
{
    private static void Main(string[] args)
    {
        var dict = new OtusDictionary();

        dict.Add(3, "3");
        dict.Add(10, "10");
        //dict.Add(10, "10"); //ключ уже занят
        dict.Add(132, "132");
        dict.Add(70, "70");
        dict.Add(54, "54");
        dict.Add(0, "0");
        dict.Add(1, "1");
        var s = dict.Get(132);
        Console.WriteLine(s);
    }
}
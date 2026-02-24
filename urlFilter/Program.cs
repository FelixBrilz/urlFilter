using System;

public class Programm
{
    //-------------------------------------------------------------------------That’s just to create a demonstration file------------------------------------------------------------

    int docLines = 21;
    string docName = "outPut.txt";
    string[] ending = { "com", "net" };
    List<string> net = new List<string>();
    List<string> com = new List<string>();

    Random rnd = new Random();

    static void Main()
    {
        Programm programm = new Programm();
        programm.start();
    }

    public void createEntry()
    {

        using (TextWriter writer = new StreamWriter(docName, append: false))
        {
            for (int i = 0; i < docLines; i++)
            {
                string line = createTxt();
                Console.WriteLine(line);
                writer.WriteLine(line);
            }
        }


    }

    public String createTxt()
    {
        string res = "";
        if ((rnd.Next(100) + 1) <= 25)
        {
            for (int i = 0; i < 6; i++)
            {
                res += rnd.Next(7);
            }
        }
        else
        {
            string tld = ending[rnd.Next(ending.Length)];
            string url = $"https://www.bing.{tld}/";
            for (int i = 0; i < 6; i++)
            {
                url += rnd.Next(7);
            }
            res = url;
        }
        return res;
    }

    //------------------------------------------------------------------There is the important part of the program-----------------------------------------------------------------

    public void readEntry()
    {
        using (TextReader reader = new StreamReader(docName))
        {
            Console.WriteLine("\nWurde ausgelesen:");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length == 6)
                {
                    net.Add(line);
                }
                else
                {
                    addToList(line);
                }
            }
        }
    }

    public void addToList(string input)
    {
        string[] link = input.Split('/', '.');
        if (link[4] == "net")
        {
            net.Add(link[5]);
        }
        else
        {
            com.Add(link[5]);
        }
    }

    public void showList()
    {
        Console.WriteLine("\n\nNet(" + net.Count + "): ");
        foreach (string e in net)
        {
            Console.WriteLine(e);
        }
        Console.WriteLine("\nCom(" + com.Count + "): ");
        foreach (string e in com)
        {
            Console.WriteLine(e);
        }
    }

    public void start()
    {
        createEntry();
        readEntry();
        showList();
    }
}
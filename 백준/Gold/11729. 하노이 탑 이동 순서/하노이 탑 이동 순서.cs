using System.Numerics;
using System.Text;
StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
StringBuilder stringBuilder = new StringBuilder();
BigInteger b;
int a = int.Parse(sr.ReadLine());//입력
b = BigInteger.Pow(2, a) - 1;
stringBuilder.Append(b);
if (a > 21)
    Console.WriteLine(b);
else
{
    Console.WriteLine(b);
    Hanoi(a, '1', '3', '2');
    sr.Close();
    sw.Close();
}
void Hanoi(int a, char from, char to, char by)
{

    if (a == 1)
    {
        sw.WriteLine("{0} {1}", from, to);
        return;
    }
    else
    {
        Hanoi(a - 1, from, by, to);
        sw.WriteLine("{0} {1}", from, to);
        Hanoi(a - 1, by, to, from);
    }


}
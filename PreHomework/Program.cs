using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start:
            Console.WriteLine($"請選擇要執行的部分\n a:九九乘法表\n b:股市營業時間判斷\n c:質數判斷\n d:轉換大寫字母\n e:生成星號三角形");
            string option = Console.ReadLine();
            ProgramChoose(option);
            
            goto Start;
        }

        public static void ProgramChoose(string choose)
        {
            switch (choose)
            {
                case "a":
                    string resultA = MultiplicationTableUtility.MultiplicationTable();
                    Console.WriteLine(resultA);
                    break;
                case "b":
                    Console.WriteLine("請輸入一個時間：");
                    try 
                    { 
                        DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
                        bool result = IsTradingHours(dateTime);

                        if (result) Console.WriteLine("符合台灣股市開市時間");
                        else Console.WriteLine("非台灣股市開市時間");
                        Console.WriteLine();
                    }
                    catch(FormatException) { Console.WriteLine("輸入格式錯誤"); }
                    break;
                case "c":
                    Console.WriteLine("請輸入一個數字：");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int n))
                    {
                        if (IsPrime(int.Parse(input))) Console.WriteLine($"{input}是質數");
                        else Console.WriteLine($"{input}不是質數");
                    }
                    else Console.WriteLine("請輸入正整數");
                    Console.WriteLine();
                    break;
                case "d":
                    Console.WriteLine("請輸入一個字串：");
                    string ForConvert = Console.ReadLine();
                    Console.WriteLine($"=> {UppercaseTrans(ForConvert)}");
                    Console.WriteLine();
                    break;
                case "e":
                    Console.WriteLine("請輸入一個數字：");
                    string input2 = Console.ReadLine();
                    if (int.TryParse(input2, out int m))
                    {
                        Console.WriteLine(StarTree(int.Parse(input2)));
                    }
                    else Console.WriteLine("請輸入正整數");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("請輸入包含的內容");
                    Console.WriteLine();
                    break;
            }
        }

        //開市時間判斷
        public static bool IsTradingHours(DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday) return false;

            TimeSpan begin = new TimeSpan(9, 0, 0);
            TimeSpan end = new TimeSpan(13, 30, 0);
            TimeSpan Nowdt = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            if (Nowdt > begin && Nowdt < end) return true;
            return true;
        }

        //質數判斷
        public static bool IsPrime(int num)
        {
            if (num < 2) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;
            for (int divisor = 3; divisor < Math.Sqrt(num); divisor += 2)
            {
                if (num % divisor == 0) return false;
            }
            return true;
        }

        //大小寫轉換
        public static string UppercaseTrans(string word)
        {
            char[] upper = word.ToCharArray();
            int length = upper.Length;
            string lower = "";

            for (int index = 0; index < length; index++)
            {
                if (char.IsUpper(upper[index]))
                {
                    if (index + 1 < length && char.IsUpper(upper[index + 1])) lower += $"{char.ToLower(upper[index])}_";
                    else lower += $"{char.ToLower(upper[index])}";
                }
                else lower += $"{upper[index]}";
            }
            return lower;
        }

        //顯示星星樹
        public static string StarTree(int layer)
        {
            if (layer < 1) return string.Empty;
            string result = string.Empty;

            for (int i = 1; i <= layer; i++) result += new string('*', i) + "\n";
            result += "\n\n";

            for (int i = 1; i <= layer; i++) result += new string(' ', layer - i) + new string('*', i) + "\n";
            result += "\n\n";

            for (int i = 1; i <= layer; i++) result += new string(' ', layer - i) + new string('*', 2 * i - 1) + "\n";

            return result;
        }
    }

    class MultiplicationTableUtility
    {
        //九九乘法表
        public static string MultiplicationTable()
        {
            string result = string.Empty;

            for (int multiplicand = 2; multiplicand < 9; multiplicand++)
            {
                for (int multiplier = 1; multiplier < 9; multiplier++)
                {
                    result += $"{multiplicand} * {multiplier} = {multiplicand * multiplier}\n";
                }
                result += "\n";
            }

            return result;
        }
    }
}

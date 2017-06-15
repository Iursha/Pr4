using System;
using System.Linq;
namespace Example
{
    internal static class Program
    {
        private static void Main()
        {
            var payments = Create(10, 4);
            Print(ref payments);
            Console.WriteLine($"Общее число покупателей: {CountAll(ref payments)}");
            Console.WriteLine($"Расплатились наличными: {CountCash(ref payments)}");
            Console.WriteLine($"Расплатились картами: {CountCard(ref payments)}");
            Info(ref payments);
            Console.ReadKey();
        }
        private struct Payment
        {
            public int Cash;
            public int Card;
            public override string ToString() { return Cash.ToString() + " : " + Card.ToString(); }
        }
        private static void Print(ref Payment[] payments) { foreach (var payment in payments) Console.Write(payment + " | "); }
        private static void Print(ref Payment[][] payments)
        {
            var line = new string('-', 55);
            for (var i = 0; i != payments.Length; ++i)
            {
                Print(ref payments[i]);
                Console.WriteLine("\n" + line);
            }
        }
        private static Payment[][] Create(int week, int day, int min = 4, int max = 9)
        {
            var payments = new Payment[week][];
            var rand = new Random();
            const int n = 7;
            for (var i = 0; i != week; ++i)
            {
                var limit = rand.Next(day, n + 1);
                payments[i] = new Payment[n];
                var j = 0;
                Payment payment;
                while (j < limit)
                {
                    payment.Cash = rand.Next(min, max);
                    payment.Card = rand.Next(min, max);
                    payments[i][j] = payment;
                    ++j;
                }
                while (j < n)
                {
                    payment.Cash = payment.Card = 0;
                    payments[i][j] = payment;
                    ++j;
                }
            }
            return payments;
        }
        private static int CountCash(ref Payment[] payments) { return payments.Sum(n => n.Cash); }
        private static int CountCash(ref Payment[][] payments) { return payments.Sum(n => CountCash(ref n)); }
        private static int CountCard(ref Payment[] payments) { return payments.Sum(n => n.Card); }
        private static int CountCard(ref Payment[][] payments) { return payments.Sum(n => CountCard(ref n)); }
        private static int CountAll(ref Payment[] payments) { return CountCash(ref payments) + CountCard(ref payments); }
        private static int CountAll(ref Payment[][] payments) { return payments.Sum(n => CountAll(ref n)); }
        private static bool MainlyInCash(ref Payment[] payments) { return CountCash(ref payments) > CountCard(ref payments); }
        private static void Info(ref Payment[][] payments)
        {
            for (var i = 0; i != payments.Length; ++i)
            {
                var result = MainlyInCash(ref payments[i]) ? "Наличными" : "Картой";
                Console.WriteLine($"{i + 1}. {result}");
            }
        }
    }
}

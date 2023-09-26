using System;

namespace OOP_Lab2._2
{
    public class Ar
    {
        int n;        // Кількість елементів у масиві
        int[] a;      // Одновимірний цілочисельний масив
        int s;//сума елементів масиву, які більше 10 та менше 40

        public Ar(int a, int b)
        {
            n = b - a + 1;
            this.a = new int[n];

            for (int i = 0; i < n; i++)
                this.a[i] = (a + i) * (a + i);
        }

        public Ar(string s)
        {
            string[] chisla = s.Split('.');//розділяє рядок
            n = chisla.Length;
            a = new int[n];//створення масиву з тією кількістю чисел, скільки було записано в рядок

            for (int i = 0; i < n; i++)
            {
                if (int.TryParse(chisla[i], out int c))//перетворення з рядку в число та записування в масив
                {
                    a[i] = c;
                }
                else
                {
                    Console.WriteLine("Виникла помилка. В рядку повинні бути лише числа");
                }
            }
        }

        public int S//обчислює суму чисел більших 10, та менших 40
        {
            get
            {
                s = 0;
                for (int i = 0; i < n; i++)
                {
                    if (a[i] >= 10 && a[i] <= 40)//перевірка, щоб 10 <= a[i] <= 40
                    {
                        s += a[i];
                    }
                }
                return s;
            }
        }

        public int N//властивість для читання n
        {
            get { return n; }
        }

        public void Print()//виводить масив на екран
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
                Console.Write(" {0}", a[i]);
            Console.WriteLine();
        }

        public int P()
        {
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 != 0) return a[i];
            }
            return -1;
        }

        public int Pr(int i1, int i2)//добуток елементів масиву починаючи з першого непарного
        {
            if (i1 >= 0 && i2 >= 0 && i1 < n && i2 < n && i2 >= i1)
            {
                int c = 1;
                for (int i = i1; i <= i2; i++)
                {
                    c = c * a[i];//добуток елементів масиву
                }
                return c;
            }
            else
            {
                Console.WriteLine("Індекси виходять за межі діапазону або мають не коректне значення");
                return -1;
            }
        }

        public int FindIndex(int f)//Знаходить індекс числа, що знаходиться в масиві
        {
            int index = -1;
            for (int i = 0; i < n; i++)
            {
                if (a[i] == f)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;//так треба
            try
            {
                Ar mas = null; // Ініціалізація змінної

                Console.WriteLine("Оберіть конструктор 1 або 2: ");
                int r = Convert.ToInt32(Console.ReadLine());

                if (r == 1)
                {
                    Console.WriteLine("Ви обрали конструктор 1");
                    Console.Write("a = ");
                    int k = Convert.ToInt32(Console.ReadLine());
                    Console.Write("b = ");
                    int l = Convert.ToInt32(Console.ReadLine());
                    mas = new Ar(k, l);
                }
                else if (r == 2)
                {
                    Console.WriteLine("Ви обрали конструктор 2");
                    Console.Write("Введіть рядок чисел, розділених крапкою: ");
                    string i = Console.ReadLine();
                    mas = new Ar(i);
                }
                else
                {
                    Console.WriteLine("Невірний вибір конструктора.");
                    return;
                }

                mas.Print();

                int t = mas.S;
                Console.WriteLine("Сума чисел більше 10 та менше 40 = {0}", t);

                int p = mas.P();
                if (p == -1) Console.WriteLine("В цьому масиві немає непарних чисел");
                else
                {
                    Console.WriteLine("Перше непарне число: {0}", p);
                    int index = mas.FindIndex(p);
                    int pr = mas.Pr(index, mas.N - 1);
                    Console.WriteLine("Твір елементів масиву від першого непарного числа до кінця: {0}", pr);
                }
            }
            catch { Console.WriteLine("Помилка"); }
            Console.ReadKey();
        }
    }
}
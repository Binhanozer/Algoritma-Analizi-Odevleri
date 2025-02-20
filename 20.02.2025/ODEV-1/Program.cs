using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Farklı dizi boyutları
        int[] diziBoyutlari = { 100, 1000, 5000, 10000 };

        foreach (int boyut in diziBoyutlari)
        {
            // Rastgele dizi oluşturma
            int[] diziBubble = RastgeleDiziOlustur(boyut);
            int[] diziInsertion = (int[])diziBubble.Clone(); // Aynı dizinin kopyası

            Console.WriteLine($"{boyut} Elemanlı Dizi İçin:");

            // Bubble Sort Süresi
            Stopwatch stopwatchBubble = new Stopwatch();
            stopwatchBubble.Start();
            BubbleSort(diziBubble);
            stopwatchBubble.Stop();
            Console.WriteLine($"  Bubble Sort Süresi: {stopwatchBubble.ElapsedMilliseconds} ms");

            // Insertion Sort Süresi
            Stopwatch stopwatchInsertion = new Stopwatch();
            stopwatchInsertion.Start();
            InsertionSort(diziInsertion);
            stopwatchInsertion.Stop();
            Console.WriteLine($"  Insertion Sort Süresi: {stopwatchInsertion.ElapsedMilliseconds} ms");

            Console.WriteLine();
        }
    }

    static int[] RastgeleDiziOlustur(int boyut)
    {
        int[] dizi = new int[boyut];
        Random random = new Random();
        for (int i = 0; i < boyut; i++)
        {
            dizi[i] = random.Next(1, 10001); // 1 ile 10000 arasında rastgele sayılar
        }
        return dizi;
    }

    static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Elemanları yer değiştir
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    static void InsertionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;

            // Anahtar elemanı doğru konumuna yerleştir
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
}

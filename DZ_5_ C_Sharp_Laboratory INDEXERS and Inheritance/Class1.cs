using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5__C_Sharp_Laboratory_INDEXERS_and_Inheritance
{
    class RangeOfArray
    {
        private int lowerIndex;
        private int upperIndex;
        private int[] arr;

        public RangeOfArray(int lowerIndex, int upperIndex)
        {
            if (lowerIndex > upperIndex)
            {
                throw new ArgumentException("Нижний индекс должен быть меньше или равен верхнему индексу");
            }

            this.lowerIndex = lowerIndex;
            this.upperIndex = upperIndex;
            int length = upperIndex - lowerIndex + 1;
            arr = new int[length];
        }

        public void FillRandom()
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next();
            }
        }

        public void PrintArray()
        {
            Console.WriteLine("Массив:");
            for (int i = lowerIndex; i <= upperIndex; i++)
            {
                Console.WriteLine($"Элемент с индексом {i}: {arr[i - lowerIndex]}");
            }
        }

        /*
         Функция добавляет значение value в конец массива arr. 
        Для этого она увеличивает размер массива на одну позицию с помощью метода Array.Resize,
        а затем записывает значение в новую ячейку.
        После этого функция увеличивает переменную upperIndex, которая, вероятно,
        хранит индекс последнего элемента массива.

        Когда вы передаете аргумент в метод с ключевым словом ref, вы можете изменить значение этого аргумента внутри метода.
        Это позволяет вам изменять параметры метода непосредственно, а не возвращать новые значения.

        Метод ToLower() переводит все буквы в нижний регистр. Например, 
        если мы передадим в этот метод строку “Hello, world!”, то на выходе получим “hello, world!”.

         */
        public void AddElement(int value)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = value;
            upperIndex++;
        }


        public int this[int index]
        {
            get
            {
                if (index < lowerIndex || index > upperIndex)
                {
                    throw new IndexOutOfRangeException($"Индекс {index} находится вне диапазона массива");
                }

                return arr[index - lowerIndex];
            }
            set
            {
                if (index < lowerIndex || index > upperIndex)
                {
                    throw new IndexOutOfRangeException($"Индекс {index} находится вне диапазона массива");
                }

                arr[index - lowerIndex] = value;
            }
        }
    }   
}

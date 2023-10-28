﻿
/*
* Сайт Метанит !!! по С++ сайт рависли. Дум 3 много исходного кода С++
* 
ТЕМА: ИНДЕКСАТОРЫ
Цель: Совершенствование навыков применения объектно-ориентированного подхода в программировании с использованием средств C#, создания пользовательских типов, использования средств обработки исключительных ситуаций. 
Необходимые инструменты: MS Visual Studio 2016.
Документация: Конспект, Литература.
Ориентировочное время исполнения: 1 час.
Задание 1.
В С # индексация начинается с нуля, но в некоторых 
языках программирования это не так. Например, в Turbo 
Pascal индексация массиве начинается с 1. Напишите класс 
RangeOfArray, который позволяет работать с массивом 
такого типа, в котором индексный диапазон устанавливается пользователем. Например, в диапазоне от 6 до 10, 
или от –9 до 15.
Подсказка: В классе можно объявить две переменных, 
которые будут содержать верхний и нижний индекс допустимого диапазона. 


Пользоватеолем вводится диапазон индекса массива от –9 до 15
Тоесть первый элемент начинается с первого индекса введенного пользователем.
и последний элемент заканчивается со второго введенного пользователем индекса.
После вывода результата пользователь может добавить элемент в массив.
Напишите класс 
RangeOfArray, который позволяет работать с этим массивом. 
Продемонстрировать в main()
Написать решение в C# и объяснить по ход действий


///////////////////////////////////////
В данном решении используется предыдущий класс RangeOfArray.
В методе FillRandom создается массив и заполняется случайными значениями при помощи класса Random.

Затем, в Main создается объект класса RangeOfArray с указанными пользователем нижним и верхним индексами диапазона.
Метод FillRandom вызывается для заполнения массива случайными значениями.
Затем, метод PrintArray вызывается для вывода элементов массива с их значениями. 
//////////////////////////////


ТЕМА: НАСЛЕДОВАНИЕ
Цель: Закрепить у слушателей практические навыки и теоретические знания для работы классами и объектами, свойствами. 
Научиться создавать иерархии классов. 
Необходимые инструменты: MS Visual Studio 2016.
Документация: Конспект, Литература.
Ориентировочное время исполнения: 2 часа.
Требования к отчету: Отчет должен быть оформлен в виде 
электронного документа: программный код с комментариями, 
выводы о результатах выполняемых действий и копии экрана. 
Размер файла отчета до 2 МБ со скриншотами.

Задание 1. 
Разработать приложение «Резервная копия»
Цель: произвести расчет необходимого количества внешних носителей информации при переносе за один раз 
важной информации (565 Гб,файлыпо 780 Мб) с рабочего 
компьютера на домашний компьютер и затрачиваемое 
на данный процесс время. Вы имеете в распоряжении 
следующие типы носителей информации: 
■ Flash-память, 
■ DVD-диск, 
■ съемный HDD. 
Каждый носитель информации является объектом соответствующего класса:

ТЕМА: НАСЛЕДОВАНИЕ
Цель: Закрепить у слушателей практические навыки и теоретические знания для работы классами и объектами, свойствами. 
Научиться создавать иерархии классов. 
Необходимые инструменты: MS Visual Studio 2016.
Документация: Конспект, Литература.
Ориентировочное время исполнения: 2 часа.
Требования к отчету: Отчет должен быть оформлен в виде 
электронного документа: программный код с комментариями, 
выводы о результатах выполняемых действий и копии экрана. 
Размер файла отчета до 2 МБ со скриншотами.

Задание 2.
Разработать приложение «Резервная копия»
Цель: произвести расчет необходимого количества внешних носителей информации при переносе за один раз 
важной информации (565 Гб,файлыпо 780 Мб) с рабочего 
компьютера на домашний компьютер и затрачиваемое 
на данный процесс время. Вы имеете в распоряжении 
следующие типы носителей информации: 
■ Flash-память, 
■ DVD-диск, 
■ съемный HDD. 
Каждый носитель информации является объектом соответствующего класса:

Приложение должно предоставлять следующие возможности:
■ расчет общего количества памяти всех устройств;
■ копирование информации на устройства;
■ расчет времени необходимого для копирования;
■ расчет необходимого количества носителей информации представленных типов для переноса 
информации.
*/


using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace DZ_5__C_Sharp_Laboratory_INDEXERS_and_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task_1_Hello, World!");
            Console.WriteLine("Введите нижний индекс диапазона:");
            int lowerIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите верхний индекс диапазона:");
            int upperIndex = int.Parse(Console.ReadLine());

            RangeOfArray rangeArray = new RangeOfArray(lowerIndex, upperIndex);

            rangeArray.FillRandom();
            rangeArray.PrintArray();

            Console.WriteLine("Хотите добавить элемент в массив? (Y/N)");
            string answer = Console.ReadLine();

            while (answer.ToLower() == "y")
            {
                Console.WriteLine("Введите значение элемента:");
                int value = int.Parse(Console.ReadLine());

                rangeArray.AddElement(value);
                rangeArray.PrintArray();

                Console.WriteLine("Хотите добавить еще элемент в массив? (Y/N)");
                answer = Console.ReadLine();
            }
                // Task_2
                Console.WriteLine("\n\nЗадача 2: «Резервная копия»");
                double dataToCopy = 565; // размер данных для копирования в Гб
                double fileSize = 780; // размер одного файла для копирования в Мб

                double dataSize = dataToCopy * 1024 + fileSize / 1024; // общий объем данных для копирования в Мб

                Storage[] devices = new Storage[]
                {                    
                    new Flash(3,"Flash-память", "FlashModel1", 64, 50.52,"Высокоскоростная компактная Flash сделана а Китае", 100.40),
                    new Flash(3,"Flash-память", "FlashModel2", 64, 50.52,"Высокоскоростная компактная Flash сделана а Китае", 100.40),
                    new Flash(3,"Flash-память", "FlashModel3", 64, 50.52,"Высокоскоростная компактная Flash сделана а Китае", 100.40),
                    
                    new DVD(30,"DVD-диск", "DVDModel1", 250.7, 16,"Высокоскоростная компактная DVDModel сделана а Китае", 50.3, 48.2, "односторонний"),
                    new DVD(30,"DVD-диск", "DVDModel2", 250.7, 16,"Высокоскоростная компактная DVDModel сделана а Китае", 50.3, 48.2, "двусторонний"),
                    new DVD(30,"DVD-диск", "DVDModel3", 250.7, 16,"Высокоскоростная компактная DVDModel сделана а Китае", 50.3, 48.2, "односторонний"),
                    

                    new HDD(10, "съемный HDD", "HDDModel1", 500.80, 35.5, "Средняя модель по качеству компактная HDDModel сделана а Россия", 80.3, 3, 2.5),
                    new HDD(10, "съемный HDD", "HDDModel2", 500.80, 35.5, "Средняя модель по качеству компактная HDDModel сделана а Россия", 80.3, 3, 2.5),
                    new HDD(10, "съемный HDD", "HDDModel3", 500.80, 35.5, "Средняя модель по качеству компактная HDDModel сделана а Россия", 80.3, 3, 2.5)
                };
                double totalMemorySize = 0;
            BackupManager backupManager = new BackupManager(devices);
                foreach (var device in devices)
                {
                    totalMemorySize += device.GetMemorySize();
                    device.Print();
                }
          
            totalMemorySize = backupManager.CalculateMemory();
                Console.WriteLine($"Общий объем памяти всех устройств: {totalMemorySize} Гб");
                double dataSize1 = 565.0;
                double timeNeeded = 0;
            foreach (var device in devices)
            {
                double freeMemory = device.GetMemorySize();
                if (freeMemory >= dataSize1)
                {
                    device.CopyDate(dataSize1);
                    timeNeeded = dataSize / device.GetMemorySize();
                    break;
                }
            }

                    double requiredDevices = backupManager.CalculateRequiredDevices(dataSize);
                Console.WriteLine($"Необходимое количество носителей информации: {requiredDevices}");

                double transferSpeed = 15; // скорость передачи данных в Мб/с
                double transferTime = backupManager.CalculateTransferTime(dataSize, transferSpeed);
                Console.WriteLine($"Время, необходимое для копирования данных: {transferTime} сек");

                foreach (Storage device1 in devices)
                {
                    backupManager.CopyDataToDevice(dataSize, device1);
                }

                Console.ReadLine();
        }        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

/*
 Задание 1. Разработать приложение «Резервная копия»
Цель: произвести расчет необходимого количества внешних носителей информации при переносе за один раз 
важной информации (565 Гб,файлыпо 780 Мб) с рабочего 
компьютера на домашний компьютер и затрачиваемое 
на данный процесс время. Вы имеете в распоряжении 
следующие типы носителей информации: 
■ Flash-память, 
■ DVD-диск, 
■ съемный HDD. 
Каждый носитель информации является объектом соответствующего класса:
■ Flash-память — класс «Flash»;
■ класс DVD-диск — класс «DVD»;
■ класс съемный HDD — класс «HDD».
Все три класса являются производными от абстрактного 
класса «Носитель информации» — класс «Storage». 
Базовый класс («Storage») содержит следующие закрытые 
поля:
■ наименование носителя;
■ модель.
Класс обладает всеми необходимыми свойствами для 
доступа к полям, а также абстрактными методами: 
■ получение объема памяти;
■ копирование данных (файлов/папок) на устройство, 
■ получение информации о свободном объеме памяти 
на устройстве;
■ получение общей/полной информации об устройстве. 
Кроме того, каждый из производных классов дополняется 
следующими полями:
■ класс Flash-память: скорость USB 3.0, объем памяти;
■ класс DVD-диск: скорость чтения / записи, тип 
(односторонний (4.7 Гб) /двусторонний (9 Гб));
■ класс съемный HDD: скорость USB 2.0, количество 
разделов, объем разделов.
Работа с объектами соответствующих классов производится через ссылки на базовый класс («Storage»), которые 
хранятся в массиве
 Приложение должно предоставлять следующие возможности:
■ расчет общего количества памяти всех устройств;
■ копирование информации на устройства;
■ расчет времени необходимого для копирования;
■ расчет необходимого количества носителей информации представленных типов для переноса 
информации.
 */

namespace DZ_5__C_Sharp_Laboratory_INDEXERS_and_Inheritance
{
   public abstract class Storage
   {
        protected int quantity = 0;
        protected string name;             
        protected string deviceInformation;
        protected string type;
        protected double memorySize;
        public double usedSpace = 0;

        protected Storage() { }
        protected Storage(int quantity, string name, string type, double memorySize, double usedSpace, string deviceInformation) 
        { 
            this.quantity = quantity;
            this.name = name;                    
            this.deviceInformation = deviceInformation;
            this.type = type;
            this.memorySize = memorySize;
            this.usedSpace = usedSpace;
        }
        
        public virtual void Print()
        {
            Console.WriteLine($"Количество носителей этого Типа: {this.quantity} Шт\n Наименование устройтва: {this.name}\n Модель:" +
                $" {this.type}\n Объем памяти:{this.memorySize} Гб\n Описание: {this.deviceInformation}");
        }
        public abstract double GetMemorySize();
        public abstract void CopyDate(double dataSize);
        public abstract double GetFreeSpace();

   }

    public class Flash : Storage
    {
        private double speedUSB_3;// и при переносе за один раз (565 Гб,файлы по 780 Мб)       

        public Flash(int quantity, string name, string type, double memorySize, double usedSpace, string deviceInformation, double speedUSB_3)
                        : base(quantity, name, type, memorySize, usedSpace, deviceInformation)
        {
            this.speedUSB_3 = speedUSB_3;            
        }
        public override double GetMemorySize() { return this.memorySize * quantity; }
        public override void CopyDate(double dataSize) {
            double time = dataSize / speedUSB_3;
            Console.WriteLine($"Копирование данных на Flash-память объемом {memorySize} Гб. Время копирования: {time} с.");
        }
        public override double GetFreeSpace() {
            return memorySize - usedSpace;
        }
        public override void Print() {
            base.Print();
            Console.WriteLine($"Скорость устройства USB 3.0: {speedUSB_3} Мб/с\n Объем использованной памяти: {usedSpace} Гб\n" +
                             $" Свободной памяти: {GetFreeSpace()} Гб\n\n");
        }        
    }
    public class DVD : Storage
    {
        private double readingSpeed;
        private double writeingSpeed;
        private string typeCarrier;//(односторонний (4.7 Гб) /двусторонний (9 Гб))
        public DVD(int quantity, string name, string type, double memorySize, double usedSpace, string deviceInformation, double readingSpeed, double writeingSpeed, string typeCarrier)
                        : base(quantity, name, type, memorySize, usedSpace, deviceInformation)
        {
            this.readingSpeed = readingSpeed;
            this.writeingSpeed = writeingSpeed;
            this.typeCarrier = typeCarrier;
        }

        public override void Print() {
            base.Print();
            Console.WriteLine($"Скорость чтения: {readingSpeed} Мб/с\n Скорость записи: {writeingSpeed}\n Тип памяти: {typeCarrier}\n " +
                                $"Объем использованной памяти: {usedSpace} Гб\n Свободной памяти: {GetFreeSpace()} Гб\n\n");
        }
        public override double GetMemorySize() { return memorySize; }
        public override void CopyDate(double dataSize) {
            double time = dataSize / writeingSpeed;
            Console.WriteLine($"Запись данных на DVD-диск объемом {memorySize} Гб. Время записи: {time} с.");
        }
        public override double GetFreeSpace() {
            return memorySize - usedSpace;
        }
    }
    public class HDD : Storage
    {
        private double speedUSB_2;
        private double quantitySections;
        private double volumeSections;

        public HDD(int quantity, string name, string type, double memorySize, double usedSpace, string deviceInformation, double speedUSB_2, double quantitySections, double volumeSections) 
                        : base(quantity, name, type, memorySize, usedSpace, deviceInformation)
        {
            this.speedUSB_2 = speedUSB_2;
            this.quantitySections = quantitySections;
            this.volumeSections = volumeSections;
        }
       
        public override void Print() {
            base.Print();
            Console.WriteLine($"Скорость устройства USB 2.0: {speedUSB_2}\n Количество разделов: {quantitySections} Шт\n " +
                                $"Объем разделов: {volumeSections} Гб\n Объем использованной памяти: {usedSpace}\n Свободной памяти: {GetFreeSpace()} Гб\n\n");
        }
        public override double GetMemorySize() { return memorySize ; }
        public override void CopyDate(double dataSize) {
            double time = dataSize / speedUSB_2;
            Console.WriteLine($"Перенос данных на съемный HDD объемом {memorySize} Гб. Время переноса: {time} с.");
        }
        public override double GetFreeSpace() {
            return memorySize - usedSpace;
        }
    }

    public class BackupManager
    {
        private Storage[] devices;
        public BackupManager(Storage[] devices)
        {
            this.devices = devices;
        }

        public double CalculateMemory()
        {
            double wholeMamorySize = 0;
            foreach(Storage device in devices)
            {
                wholeMamorySize += (device.GetMemorySize());                
            }
            return wholeMamorySize;
                        
        }

        public double CalculateRequiredDevices( double dataSize)
        {
            double wholeMamorySize = CalculateMemory();
            return (double)Math.Ceiling( dataSize/ wholeMamorySize);
        }

        public double CalculateTransferTime(double dataSize, double transferSpeed)
        {
            return dataSize / transferSpeed;
        }

        public void CopyDataToDevice(double dataSize, Storage device)
        {
            device.CopyDate(dataSize);
        }
    }
}
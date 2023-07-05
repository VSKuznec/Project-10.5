using Project_10._5._1;
using System;
using System.Runtime.CompilerServices;

namespace Task1
{
    class Program
    {
        static ILogger Logger { get; set; } 
        static void Main(string[] args)
        {
            Logger = new Logger();
            var worker1 = new Worker1(Logger);
            var worker2 = new Worker2(Logger);
            var worker3 = new Worker3(Logger);

            worker1.Work();
            worker2.Work();
            worker3.Work();

            Console.ReadKey();

            try
            {
                ICalculator calculator = new Calculator();
                Console.WriteLine("Введите первое число: ");
                double a = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите второе число: ");
                double b = double.Parse(Console.ReadLine());

                double result = calculator.Calculate(a, b);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка. Вы что-то сделали не так.");
            }
        }
    } 

    public interface ICalculator 
    {
        double Calculate(double numberOne, double numberTwo); 
    }

    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Calculator: ICalculator {        
        public double Calculate(double numberOne, double numberTwo) 
        {            
            return numberOne + numberTwo;
        }
    }

    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
    }

    public interface IWorker
    {
        void Work();
    }
}
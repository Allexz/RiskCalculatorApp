using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace RiskCalculatorApp
{

    public class Program
    {
        private static DateTime _dateInput;
        private static int _qtdeItens;
        private static List<ITrade> _tradeList;
        public static void Main(string[] args)
        {
            try
            {
                Start();
            }
            catch 
            {
                WorkingOnError();
            }
        }
        private static void Start()
        {
            Header();
            GetBaseDate();
            GetNumberOfInputs();
            AskForItens();
            PrintData();
            Calculate(_tradeList, _dateInput);
            Console.ReadKey();
        }

       

        private static void Header()
        {
            Console.WriteLine();
            Console.WriteLine("** Author:\t JOSÉ ALEXANDRE DE BARROS");
            Console.WriteLine("** E-mail:\t alexandre@microworkers.com.br / jallexz@msn.com");
            Console.WriteLine("** Telefone:\t (27)98804-5444");
            Console.WriteLine("** Problem:\t CATEGORIZE TRADES IN A BANK'S PORTFOLIO");
            Console.WriteLine("***************************************************");
            Console.WriteLine();
            System.Threading.Thread.Sleep(500);
        }
        private static void AskForItens()
        {
            _tradeList = new List<ITrade>();
            for (int i = 0; i < _qtdeItens; i++)
            {
                Console.WriteLine($"Item nº {_tradeList.Count + 1}");
                double amount = GetAmount(i+1);
                string sector = GetSector(i + 1);
                DateTime date = GetPortfolioDate(i + 1);
                _tradeList.Add(new Trade(amount, sector, date));
                Console.Clear();
                Header();
            }
        }
        private static void PrintData()
        {
            Console.WriteLine(_dateInput);
            Console.WriteLine(_qtdeItens);
            _tradeList.ForEach(element =>
            {
                Console.WriteLine($"{element.Value}\t\t{element.ClientSector}\t{element.NextPaymentDate}");
            });
        }
        private static void GetBaseDate()
        {
            try
            {
                Console.WriteLine("Input a base date for processing - \"format mm/dd/yyyy\": ");
                _dateInput = Convert.ToDateTime(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch 
            {
                WorkingOnError();
            }
        }
        private static void GetNumberOfInputs()
        {
            try
            {
                Console.WriteLine("Input total of portfolio's itens:");
                _qtdeItens = int.Parse(Console.ReadLine());
            }
            catch 
            {
                WorkingOnError();
            }
        }
        private static double GetAmount(int pos)
        {
            try
            {
                Console.WriteLine($"{pos}º - Input an amount of this portfolio item");
                return Convert.ToDouble(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch 
            {
                WorkingOnError();
                return 0;
            }
        }
        private static string GetSector(int pos)
        {
            try
            {
                Console.WriteLine($"{pos}º - Input a sector of this portfolio - Private or Public");
                return Console.ReadLine();
            }
            catch 
            {
                WorkingOnError();
                return string.Empty;
            }
        }
        private static DateTime GetPortfolioDate(int pos)
        {
            try
            {
                Console.WriteLine($"{pos}º Input a date for this portfolio item - \"format mm/dd/yyyy\": ");
                return Convert.ToDateTime(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch 
            {
                WorkingOnError();
                return DateTime.MinValue;

            }
        }
        private static void WorkingOnError()
        {
            if (_tradeList != null) 
                _tradeList.Clear();

            Console.WriteLine();
            Console.WriteLine("FOR BREVITY, INPUT'S ERRORS AREN'T HANDLED.");
            Console.WriteLine();
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            Start();
        }
        public static void Calculate(IEnumerable<ITrade> trades, DateTime inputDate)
        {
            foreach (ITrade trade in trades)
            {
                try
                {
                    RiskCategories calculator = new ExpiredTrade(trade, inputDate).CalcularRiscoTrade();
                    Console.WriteLine(calculator.ToString());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }

}

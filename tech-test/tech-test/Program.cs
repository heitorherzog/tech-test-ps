using System;
using System.Text;

namespace tech_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleContext = new ConsoleContext();
            consoleContext.Test();
        }
    }

    public class ConsoleContext
    {
        public void Test()
        {
            string srthoursworked;
            string srthourlyrate;
            string employeelocation;

            Console.WriteLine("Please enter the hours worked:");
            srthoursworked = Console.ReadLine();
            Console.WriteLine("Please enter the hourly rate: ");
            srthourlyrate = Console.ReadLine();
            Console.WriteLine("Please enter the employee’s location: ");
            employeelocation = Console.ReadLine();


            int.TryParse(srthoursworked, out int hoursworked);
            int.TryParse(srthourlyrate, out int hoursRate);

            if (employeelocation.ToString() == "ireland")
            {
                var d = new Deductions()
                {
                    Employeelocation = employeelocation,
                    GrossAmount = hoursworked * hoursRate,
                    IncomeTax = 0,
                    UniversalSocialCharge = 0,
                    Pension = 0,
                    NetAmount = 0
                };


                StringBuilder b = new StringBuilder();
                b.AppendFormat("Employee location: {0}{1}", d.Employeelocation, Environment.NewLine);
                b.AppendFormat("Gross Amount: {0:C}{1}", d.GrossAmount, Environment.NewLine);
                b.AppendLine("Less deductions");
                b.AppendFormat("Income Tax: {0:C}{1}", d.IncomeTax, Environment.NewLine);
                b.AppendFormat("Universal Social Charge: {0:C}{1}", d.UniversalSocialCharge, Environment.NewLine);
                b.AppendFormat("Pension: {0:C}{1}", d.Pension, Environment.NewLine);
                b.AppendFormat("Net Amount: {0:C}{1}", d.NetAmount, Environment.NewLine);


                Console.WriteLine(b.ToString());

            }
            else
            {
                Console.Clear();
                Console.WriteLine("not implemented");
            }
        }
    }
    class Deductions
    {
        public string Employeelocation { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal UniversalSocialCharge { get; set; }
        public decimal Pension { get; set; }
        public decimal NetAmount { get; set; }
    }
}

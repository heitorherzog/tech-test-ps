using System;
using System.Text;

namespace Application
{
    public class HandleOutputDeductions
    {
        public StringBuilder ResultBuilder { get; set; }
        public Deductions Deductions { get => _deductions; }
        private Deductions _deductions;

        public HandleOutputDeductions()
        {
            ResultBuilder = new StringBuilder();
        }
        public void GetDeductions(Deductions deductions)
        {
            _deductions = deductions;
        }

        public void FormatResult()
        {
            if (_deductions == null)
            {
                ResultBuilder.Append("Please insert valid values");
                return;
            }

            ResultBuilder.AppendLine();
            ResultBuilder.AppendFormat("Employee location: {0}{1}", Deductions.Employeelocation, Environment.NewLine);
            ResultBuilder.AppendFormat("Gross Amount: {0:C}{1}", Deductions.GrossAmount, Environment.NewLine);
            ResultBuilder.AppendLine("Less deductions");
            ResultBuilder.AppendFormat("Income Tax: {0:C}{1}", Deductions.IncomeTax, Environment.NewLine);
            ResultBuilder.AppendFormat("Universal Social Charge: {0:C}{1}", Deductions.UniversalSocialCharge, Environment.NewLine);
            ResultBuilder.AppendFormat("Pension: {0:C}{1}", Deductions.Pension, Environment.NewLine);
            ResultBuilder.AppendFormat("Net Amount: {0:C}{1}", Deductions.NetAmount, Environment.NewLine);
        }
    }
}

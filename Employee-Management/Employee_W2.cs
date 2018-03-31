using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management
{
    public class Employee_W2: Employee
    {
     
        private decimal monthlyTax { get; set; }
        private decimal annualTax { get; set; }

        //three-parameter constructor  Employee_W2 constructor
        public Employee_W2(string name, string address, decimal annualGross)
            : base(name, address, annualGross)
       {
         
       } 
        /// <summary>
        /// Monthly Tax = Monthly Gross Pay * Tax %
        /// </summary>
        public decimal MonthlyTax
        {
            get { return base.MonthlyPayGross * TaxPercent; }
            set { monthlyTax = value; }
        }

        /// <summary>
        /// Annual Tax = Annual Gross Pay * Tax %
        /// </summary>
        public decimal AnnualTax
        {
            get { return base.AnnualPayGross * TaxPercent; }
            set { annualTax = value; }
        }

        // property that gets and sets Employee Net pay
        public decimal AnnualNetPay
        {
            get { return base.AnnualPayGross - this.AnnualTax; }
            set { }
        }

        // return string representation of Employee_W2 object
        //Reference to format numeric data https://msdn.microsoft.com/en-us/library/syy068tk(v=vs.100).aspx
        public override string ToString()
        {
            return string.Format("W2 Employee:\n Name: {0} \n Address: {1} \n Employee Type: {2} \n Annual Gross Salary: {3:C}, \n Monthly Gross Salary: {4:C}" +
                "\n Monthly Tax: {5:C} \n Annual Tax: {6:C}, \n AnnualNetPay: {7:C}",
                Name, Address,"W2", AnnualPayGross, MonthlyPayGross, MonthlyTax, AnnualTax, AnnualNetPay);
        }

    }
}

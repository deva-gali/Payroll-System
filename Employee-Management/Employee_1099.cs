using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management
{
    public class Employee_1099 : Employee
    {
        //three-parameter constructor Employee_1099 constructor
        public Employee_1099(string name, string address, decimal annualGross)
            : base(name, address, annualGross)
       {
         
       }

        // property that gets and sets Employee Net pay
        public decimal AnnualNetPay
        {
            get { return base.AnnualPayGross; }
            set {  }
        }

        // return string representation of Employee_1099 object
        public override string ToString()
        {
            return string.Format("1099 Employee:\n Name: {0} \n Address: {1} \n Employee Type: {2} \n Annual Gross Salary: {3:C}, \n Monthly Gross Salary: {4:C} "+
            " \n AnnualNetPay: {5:C}",
                 Name, Address, "1099", AnnualPayGross, MonthlyPayGross, AnnualNetPay);
        }

    }
}

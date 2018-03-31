using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management
{
    //Employee Base class
   public abstract class Employee 
    {
       public string name { get; set; }
       public string address { get; set; }
        private decimal monthlyPayGross { get; set; }
        private decimal annualPayGross { get; set; }

        //three-parameter constructor Employee constructor
       public Employee(string name, string address, decimal annualGross)
       {
           Name = name;
           Address = address;
           AnnualPayGross = annualGross;
       }

       public string Name
       {
           get{return name;}
           set
           {
               if(!String.IsNullOrEmpty(value))
               {
                   name = value;
               }
               else
               {
                   throw new NullReferenceException("Employee Name cannot be empty");
               }
           }
       }
       public string Address 
       { 
           get { return address;}
           set {
                   if (!String.IsNullOrEmpty(value))
                   {
                       address = value;
                   }
                   else
                   {
                       throw new NullReferenceException("Employee Address cannot be empty");
                   }
                }

       }
       public const decimal TaxPercent = 0.1m;

       //property to get and set Monthly gross
       public decimal MonthlyPayGross
       {
           get { return this.AnnualPayGross/12 ; }
           set { ;}
       }

       //property to get and set Annual gross salary
       public decimal AnnualPayGross
       {
          
           set { 
               if(value <= 0 )
                 { throw new ArgumentOutOfRangeException("Annual Gross Salary",value, "Annual Gross shoud be greater than Zero "); //validate if annual gross salary is less than 0
                 }
                else { annualPayGross = value; }
               }
           get { return annualPayGross; }
       }

    }
}

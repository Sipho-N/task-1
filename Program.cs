using System;
using System.Collections;
using System.Collections.Generic;

namespace CommandLineApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Income_Expenses(); // to run the named method
        }

        public static void Income_Expenses() // method that prompts user to enter income and expenses
        {
            Console.WriteLine("Please enter your estimated gross monthly income (before deductions): ");
            int grossMonthlyIncome = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter estimated monthly tax deducted: ");
            int monthlyTaxDeductions = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter estimated monthly expenditures in each of the following categories: ");
            Console.WriteLine("i) Groceries: ");
            int groceries = Int32.Parse(Console.ReadLine());
            Console.WriteLine("ii) Water and Lights: ");
            int waterAndLights = Int32.Parse(Console.ReadLine());
            Console.WriteLine("iii) Travel costs (including petrol): ");
            int travelCosts = Int32.Parse(Console.ReadLine());
            Console.WriteLine("iv) Cell phone and telephone: ");
            int cellAndTele = Int32.Parse(Console.ReadLine());
            Console.WriteLine("v) Other expenses: ");
            int otherExpenses = Int32.Parse(Console.ReadLine());
            // above is the code that declares each prompted value as a variable

            // array that stores the expenses
            int[] expenses = { grossMonthlyIncome, monthlyTaxDeductions, groceries, waterAndLights, travelCosts, cellAndTele, otherExpenses };
            // formula to calculate the total expenses
            int totalExpenses = monthlyTaxDeductions + groceries + waterAndLights + travelCosts + cellAndTele + otherExpenses;
            // formula to calculate income after expenses deducted
            int netIncome = grossMonthlyIncome - totalExpenses;
            // display of the net income
            Console.WriteLine(" Net Income: R" + netIncome);
            // displays the option of whether the user is renting or buying accomodation
            Console.WriteLine("Options:");
            Console.WriteLine("(1) - renting accommodation");
            Console.WriteLine("(2) - buying accommodation");
            Console.WriteLine("Choose: ");
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                RentProperty(netIncome);
            }
            // above displays the method that will be executed if the user selects option 1
            else if (choice == 2)
            {
                BuyingProperty(totalExpenses, netIncome);
            }
            // above displays the method that will be executed if the user selects option 2
        }
        // method that prompts and displays monthly rent and income remaining after rent paid
        static void RentProperty(int netIncome)
        {
            
            Console.Write("Enter the monthly rental amount: ");
            int monthRent = Convert.ToInt32(Console.ReadLine());
            Console.Write("Total remaining after rent paid: R " + (netIncome - monthRent));
        }
        // method to prompt values neeeded to buy property
        static void BuyingProperty(int totalExpenses, int netIncome)
        {
            Console.WriteLine("Enter purchase price of the property: ");
            int purchasePrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter total deposit: ");
            int totalDeposit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter interest rate (percentage): ");
            int interest = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of months to repay: ");
            int numMonths = Convert.ToInt32(Console.ReadLine());
            if ((numMonths < 240) | (numMonths > 360)) // IF statement to display the range of months to pay 
            {
                Console.WriteLine("Input invalid: The number of months to repay must be between 240 and 360."); 
                Console.WriteLine("Please re-enter number of months to repay: ");
                // above is the error message to be displayed if the user enters a value below 240 and above 360 months
                numMonths = Convert.ToInt32(Console.ReadLine());
            }
            else // statement to execute accomodation calculation
            {
                Accomodation(totalExpenses, purchasePrice, totalDeposit, interest, numMonths, netIncome);
            }

            static void Accomodation(int totalExpenses, int purchasePrice, int totalDeposit, int interest, int numMonths, int netIncome)
            {
                // use of formula A=P(1 + in)

                double interestPercentage /*i*/ = interest / 100;
                double years /*n*/ = numMonths / 12;
                double a_Amount /*A*/ = 1 + years * interestPercentage;
                double total = a_Amount * purchasePrice; 
                double monthlyPayment = total / numMonths;

                // displays the monthly payment the user has to make to pay off the accomodation
                Console.WriteLine("Monthly Repayment: R" + monthlyPayment);
                double income = (int)((int)monthlyPayment * 0.33);
                if (income > monthlyPayment)
                {
                    Console.WriteLine("ALERT : Unfortunately, a home loan is unlikely");
                }
                // above is the statement to be executed if the monthly payment is above a third of the users income
                else if (income < monthlyPayment)
                {
                    Console.WriteLine("ALERT : congratulations, you can acquire a home loan");
                }
                // above is the statement to be executed if the monthly payment is below a third of the users income
                Console.WriteLine("Money available after deductions: R " + (netIncome - monthlyPayment));
            }
        }
        abstract class Expenses
        {
            double monthlyPayment;
            int totalExpenses;
        }           
    }
}
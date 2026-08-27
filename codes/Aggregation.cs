using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqProgramming
{
    class Aggregation
    {
        public string? name{get;set;}
        public int price{get;set;}
        public static void AggreMeth()
        {
            List<int> num1 = new List<int>{10,20,30,40};
            int TotalCount = num1.Count();
            int SumValue = num1.Sum();
            Console.WriteLine($"Total count is: {TotalCount} and sum value is: {SumValue}");

            var products = new List<Aggregation>
            {
                new Aggregation{name = "Laptop",price = 20000},
                new Aggregation{name = "computer",price = 50000},
                new Aggregation{name = "tab", price = 5000}
            };

            int minvalue = num1.Min();
            int maxvalue = num1.Max();
            var avgvalue = products.Average(m => m.price);
            Console.WriteLine($"MinValus is: {minvalue}, MaxValue is: {maxvalue} and AvgValue is: {avgvalue}");

            List<string> str = new List<string>{"Hello", "LinQ", "World"};
            string combinedString = str.Aggregate((current,next) => $"{current} {next}");  //Take the current result and the next item, combine them, and use that as the new current result.
            Console.WriteLine(combinedString);

            //Quantifier Methods
            List<int> eve = new List<int>{1,5,3,2};
            bool isEven = eve.Any(ev => ev % 2 == 0); //"Any" --> Checks if at least one element satisfies a condition and return in boolean(true or false) // "All" --> all the elements must satisfy the condition
            Console.WriteLine($"eve consist even number: {isEven}");

            bool containsvalue = eve.Contains(4);
            Console.WriteLine($"Does eve contains 3: {containsvalue}");

            Console.WriteLine();

            //sequence equals
            List<int> lit1 = new List<int>{1,2,3}; //it is used to check if both the list contains same elements at the same position, then it returns true
            List<int> lit2 = new List<int>{1,2,3};
            List<int> lit3 = new List<int>{2,4,1};

            bool IsSequence1 = lit1.SequenceEqual(lit2);
            Console.WriteLine($"Is lit1 and lit2 are same: {IsSequence1}");

            bool IsSequence2 = lit2.SequenceEqual(lit3);
            Console.WriteLine($"Is lit2 and lit3 are same: {IsSequence2}");

            Console.WriteLine();

            var ids = new List<int>{101,102,103,104};
            int b = ids.ElementAt(2); // checks the elements position
            Console.WriteLine($"In ids the Element at 2nd index is: {b}");


         }
    }
}
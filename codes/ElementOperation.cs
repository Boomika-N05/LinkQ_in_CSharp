using System;
namespace LinqProgramming
{
    public class ElementOperation
    {
        public int Id{get;set;}
        public string? Name{get;set;}

        public static void person()
        {
            IEnumerable<ElementOperation> nu = new List<ElementOperation>
            {
                new ElementOperation{Id = 101,Name = "Ram"},
                new ElementOperation{Id = 102, Name = "Bheem"},
                new ElementOperation{Id = 103, Name = "Som"}
            }; 
            var FirstEle = nu.First();
            Console.WriteLine(FirstEle.Id);

            var FirstOrDefault = nu.FirstOrDefault(n => n.Id == 1005); // it doesn't get crash if it didn't found the value that is assigned to the "n", while "First" get crash if it doesn't found the value
            Console.WriteLine($"First or default: {FirstOrDefault?.Id}");

            var lastEle = nu.Last();
            Console.WriteLine(lastEle.Id);

            List<int> singleValue = new List<int>{2};
            int singlenum = singleValue.Single();
            Console.WriteLine($"single: {singlenum}");

            List<int> singleValue2 = new List<int>{};
            int singleOrDefault = singleValue2.SingleOrDefault(h => h == 5);
            Console.WriteLine($"Single or default: {singleOrDefault}");

            List<string> str = new List<string>{"Hel", "low", "Wor", "Ld!"};
            string st = str.Aggregate((c,n) => $"{c} {n}");
            Console.WriteLine($"Combining the string: {st}");

        } 
    } 
}
using System;
namespace LinqProgramming
{
    public class PartisioningMeth
    {
        public static void PartMeth()
        {
            List<int> rate = new List<int>{100,200,300,400,500};

            //take,takeLast,takewhile,skip,skiplast,skipwhile,chunk
            var r1 = rate.Take(4); // we used "var" b/c int can store only one integer but "Take(3)" gives you a sequence of integers
            var r2 = rate.TakeLast(2);
            var r3 = rate.TakeWhile(n => n < 300);

            Console.WriteLine("Using Take, TakeLast, TakeWhile: ");
            Console.WriteLine(string.Join(", ",r1));
            Console.WriteLine(string.Join(", ",r2));
            Console.WriteLine(string.Join(", ",r3));

            Console.WriteLine("Using Skip, SkipLast, SkipWhile: ");
            var n1 = rate.Skip(2);
            var n2 = rate.SkipLast(3);
            var n3 = rate.SkipWhile(s => s < 300); //Starting from the beginning, keep skipping as long as the condition is true. Once it becomes false, stop skipping and keep everything after that.
            var n4 = rate.Chunk(2);

            Console.WriteLine(string.Join(", ",n1));
            Console.WriteLine(string.Join(", ",n2));
            Console.WriteLine(string.Join(", ",n3)); //The condition is already false at the first element(100 ISN'T GREATER THAN 300), so SkipWhile() immediately stops skipping, so it is returning the entire list

            foreach(var chunks in n4)
            {
                Console.WriteLine($"[ {string.Join(", ",chunks)} ]"); //Splits a sequence into chunks of a specified maximum size
            }

            //Generic methods
            IEnumerable<int> RangeValue = Enumerable.Range(1,10);

            IEnumerable<int> EmptyValues = Enumerable.Empty<int>();

            IEnumerable<string> RepeatValues = Enumerable.Repeat("Hello", 5);


            Console.WriteLine($"Range of values: {string.Join(", ",RangeValue)}");
            Console.WriteLine($"Creating Empty collection: [ {string.Join(", ",EmptyValues)} ]");
            Console.WriteLine($"Repeating value: {string.Join(", ",RepeatValues)}");

        }
    }
}
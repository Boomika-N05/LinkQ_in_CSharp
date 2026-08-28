using System;
namespace LinqProgramming
{
    public class ListVsIEnumarable
    {
        public static List<int> numbers = new List<int>{1,2,3};

        public static List<int> meal = numbers.Where(n => n > 1).ToList(); // if you want to access them inside the static method then you have to defined them(list & IEnumerable) as "public static"

        public static IEnumerable<int> resipe = numbers.Where(n => n > 1); //b/c static methods cant access non-static class members directly, if dont want to mention(List & IEnumerable as public static) then remove static from the method

        public static void Methods1() //static method
        {
            numbers.Add(100);

            Console.WriteLine();
            Console.Write("List resipe: ");
            foreach(var n in meal)  //Once created, List(Meal) has zero connection to numbers. Adding, removing, or modifying elements in numbers afterwards will never update List(Meal)
            {
                Console.WriteLine($" {n}");
            }
            Console.Write("IEnumerable res: ");
            foreach(var n in resipe)
            {
                Console.WriteLine($" {n}");
            }
        }
    }
}
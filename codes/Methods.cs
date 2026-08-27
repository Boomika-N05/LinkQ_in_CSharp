using System;
namespace LinqProgramming
{
    public class ReverseOperation
    {
        public static void RenMeth()
        {
            List<int> cal = new List<int>{1,5,3,2};

            IEnumerable<int> num = cal.AsEnumerable().Reverse(); //if we use "AsEnumerable().Reverse()" it Creates a new sequence without touching the original list // if we only use "Reverse()" it mutates the list and doesn't return anything to assign

            Console.WriteLine("By using reverse method: ");
            foreach(var ni in num)
            {
                Console.Write($" {ni}");
            }
            Console.WriteLine();
            
        }
    }

    public class StdMarks 
    {
        public string? Name{get;set;}
        public string? Grades{get;set;}
        public static void GroupByMeth() //It takes a flat list of data and categorizes it into organized groups based on a specific property (called the Key)
        {
            var students = new List<StdMarks>
            {
                new StdMarks{Name = "Mark" , Grades = "A"},
                new StdMarks{Name = "Zukini" , Grades = "B"},
                new StdMarks{Name = "Zuken" , Grades = "A"},
                new StdMarks{Name = "Burg" , Grades = "B"},
                new StdMarks{Name = "Wasabi", Grades = "c"}
            };

            var studentGrades = students.GroupBy(s => s.Grades); //When you call students.GroupBy(s => s.Grade), C# looks at each Student object, checks their Grade, and places them into matching buckets
            foreach(var Group in studentGrades)
            {
                Console.WriteLine($"Grades: {Group.Key}"); // Access the grouping key ("A", "B", etc.)
                foreach(var std in Group)
                {
                    Console.WriteLine($"  -Name: {std.Name}");  // Inner loop iterates through the STUDENTS inside that specific bucket
                }
            }
        }

        public static void ToLookMeth()
        {
            var words = new List<string>{"cat","dog","dolphin","camel","tiger","cheetah","deer"};

            var cwords = words.ToLookup(c => c[1]); // Group words by their starting letter immediately, b/c index is [0]----> we can change

            Console.WriteLine("From ToLookUp, The Cwords are: ");
            foreach(var v in cwords['o']) // Direct lookup using key 'c', we can change as we want the letter that we want
            {
                Console.Write($" {v}");
            }
            Console.WriteLine();
            
        }
    }
}
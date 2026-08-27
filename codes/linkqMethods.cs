using System.Linq;  //for linq this is main
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Versioning;
namespace LinqProgramming
{
    public class LinqFramework
    {
        public int Id{get;set;}
        public string? Name{get;set;}
        public string? Dept{get;set;}
        public double Salary{get;set;}

        public static List<LinqFramework> Employee = new List<LinqFramework> //List Runs immidiately when ".ToList()" is called
        {
            new LinqFramework
            {
                Id = 1001,Name = "Emp1", 
                Dept = "Developer", 
                Salary = 7000
            },
            new LinqFramework
            {
                Id = 1002,Name = "Emp2", Dept = "Marketing", Salary = 4000
            },
            new LinqFramework{Id = 1003,Name = "Emp3", Dept = "Business", Salary = 9000},
            new LinqFramework{Id = 1004,Name = "Emp4", Dept = "Testing", Salary = 3000},
            new LinqFramework{Id = 1005,Name = "Emp5", Dept = "Designing", Salary = 6000}
        };

        public static void Methods() // C# won't let you run LINQ directly on a class name unless it's a static list property.
        {   
            List<LinqFramework> HighPaid = Employee.Where(p => p.Salary > 5000).ToList(); // "p" is a lambda exp and p(just a temporary variable) represent a single item // ".ToList(), .ToArray() and .ToHashset()" Filters immediately and saves results into an actual List in memory  //it becomes as a list that consist all filtered persons who's salary is higher that 5000 and stored in "HighPaid"
        
            Console.WriteLine("The High Paid is: ");
            foreach(var p in HighPaid)
            {
                Console.WriteLine($"{p.Dept} | {p.Name} | {p.Dept} | {p.Salary}");  // p is an object. You need to print individual properties like p.Name and p.Salary 
            }

            var Mixedlist = new List<object>{"Maths",89,98,"English","Science",34};
            var stringOnly = Mixedlist.OfType<string>();

            Console.WriteLine("Mixed List string's are: ");
            foreach(var el in stringOnly)
            {
                Console.Write($"{el}, ");
            }
        }
    }

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

    public class SelectMethod : LinqFramework
    {
        public static void People()
        {
            foreach(LinqFramework linq in Employee) //without select method
            {
                linq.Salary = linq.Salary * 1.20; // 0.20, C# calculates 20% of the total amount, effectively cutting everyone's salary by 80%, bonus amounts alone, not the final salaries(if you multiply 0.20 then it shows how much amount get increased, not the total salary) //To increase a value by 20%, you need the original 100% plus the extra 20% (which equals 120%, or 1.20)

                Console.WriteLine($"Name : {linq.Name} and Salary : {linq.Salary}");
            }

            List<double> EmployeeSalary = Employee.Select(e => e.Salary * 0.20).ToList();

            List<string?> EmployeesNames = Employee.Select(e => e.Name).ToList(); // Extract just the names (IEnumerable<string>)
            
            
            IEnumerable<LinqFramework> result = Employee.Select(e => new LinqFramework()   // Transform into custom anonymous objects
            {
                Id = e.Id,
                Name = $"Mr.{e.Name}",
                Salary = e.Salary * 1.20
            });
            foreach (var it in result)
            {
                Console.WriteLine($"Respected: {it.Name}");
            }

            var indexProperty = Employee.Select((k, Index) => $"{Index + 1}. {k.Name} {k.Dept}");// {K.Name} --> From each employee, take the "Name" // here you are formetting how to print each employee like (1. Emp1 Developer)
            foreach(var i in indexProperty)
            {
                Console.WriteLine(i);
            }
        }

        public static void SelectManyMethod() //flattens nested or multiple inner collections into a single flat sequence
        {
            var students = new List<List<string>>
            {
                new List<string>{"Ram","Sam"},
                new List<string>{"Misty","Visty"}
            };
            var school = students.SelectMany(clas => clas);
            Console.WriteLine("by using SelectMany combined all std as: ");
            foreach(var c in school)
            {
                Console.Write($" {c}");
            }
            Console.WriteLine();
        }

        public static void ZipMethod() // pairs elements from two sequences index-by-index regardless of their types
        {
            List<int> marks = new List<int>{98, 95, 74}; 
            List<string> students = new List<string>{"John","Leo","Smith"};

            var stdDetails = marks.Zip(students, (mark,student) => $"{student}: {mark}");

            Console.WriteLine("From zip: " + string.Join("," , stdDetails));
        }
    }

    public class SortingMethod : LinqFramework
    {
        public static void EmpSalary()
        {
            var DescendingSalary = Employee.OrderByDescending(h => h.Salary);

            Console.WriteLine("Printing salary in descenting order: ");

            foreach(var o in DescendingSalary)
            {
                Console.Write($" {o.Salary}");
            }

             var AscendingSalary = Employee.OrderBy(q => q.Salary);

            Console.WriteLine();

            Console.WriteLine("Printing salary in Ascending order: ");
            foreach(var o1 in AscendingSalary)
            {
                Console.Write($" {o1.Salary}");
            }
        }
    }

    public class FirstOrDefault : LinqFramework
    {
        public static void CheckingDept()
        {
            //FirstOrDefault ---> Scans the collection until it finds the first item matching the condition.
            
            var FinanceDept = Employee.FirstOrDefault(mm => mm.Dept == "Finance"); // (List,IEnumarable,var) are used when you access the collections(multiple property(like: name,id,salary...)) and for accessing single property we use "var" // FirstOrDefault ----> return single employee object or null, doesn't crash if not found
            Console.WriteLine($"{FinanceDept?.Name} is in Finance department"); // directly print that variable

            var MarkDept = Employee.First(mn => mn.Dept == "Marketing"); // if value not found it get crash
            Console.WriteLine($"{MarkDept.Name} is in {MarkDept.Dept} department"); 
        }
    }

    public class ThenByMethod //Performs secondary sorting on elements that share the same primary sort value(id both have same FName)
    {
        public string? FName{get;set;}
        public string? LName{get;set;}

        public static void per()
        {
            var person = new List<ThenByMethod>
            {
                new ThenByMethod{FName = "Jhon",LName = "smith"},
                new ThenByMethod{FName = "Jhon",LName = "Doe"},
                new ThenByMethod{FName = "Alen",LName = "Walker"}
            };
            var cal = person.OrderBy(f => f.FName).ThenBy(fg => fg.LName);

            Console.WriteLine("From ThenBy method: ");
            foreach(var na in cal)
            {
                Console.WriteLine($"{na.FName}  {na.LName}");
            }
        }
    }
}
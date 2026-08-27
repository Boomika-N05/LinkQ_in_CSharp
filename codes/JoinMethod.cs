using System;
namespace LinqProgramming
{
    public class Company
    {
        class Departments
        {
            public int Id{set;get;}
            public string? DeptName{set;get;}
        }
        class Employees
        {
            public string? Names{get;set;}
            public int DeptId{get;set;}
        }
        public static void JoinMeth()  // gives matching individual pairs at a time //Joining methods combine elements from two different collections, based on matching keys(eg: Department's => Id and Employee's => DeptId)
        {
            var Dep = new List<Departments>
            {
                new Departments{Id = 1001 , DeptName = "IT"},
                new Departments{Id = 1002 , DeptName = "HR"},
                new Departments{Id = 1003 , DeptName = "Marketing"}
            };
            var Emp = new List<Employees>
            {
                new Employees{Names = "Ram" , DeptId = 1002},
                new Employees{Names = "Sam" , DeptId = 1001},
                new Employees{Names = "Jam" , DeptId = 1001}
            };

            var departmentDetails = Emp.Join( // "Emp" is the first collection.
                Dep, // This is the collection that we want to group under each Employees
                e => e.DeptId, // matching each of the "employee's =>  DeptId" and 
                d => d.Id, // matching each of the "Department's => Id", if it matched then it will combines them
                (e,d) => $"{e.Names} works in {d.DeptName}" //formatting the output
                );

            foreach(var i in departmentDetails)
            {
                Console.WriteLine(i); // here you dont need to give {i.Name} and {i.DeptName}, b/c already in "departmentDetails" you have formatted the output 
            }

            var deptWithEmp = Dep.GroupJoin(
                Emp,
                de => de.Id,
                em => em.DeptId,
                (de,GrpDept) => new //this line says "For each department, give me the department and its group of matching employees."
                {
                    DeptNames = de.DeptName, //The current department
                    Emps = GrpDept //the collection of employees that belong to that department
                }
                );

            foreach(var de in deptWithEmp)
            {
                Console.WriteLine($"Department: {de.DeptNames}");
                foreach(var em in de.Emps)
                {
                    Console.WriteLine($"{em.Names}");
                }
            }

            //set operation
            var val = Emp.DistinctBy(pal => pal.DeptId); // allows you to target a specific value remove the duplicate value in collection
            Console.WriteLine("From DistinctBy value: ");
            foreach(var va in val)
            {
                Console.WriteLine($" {va.DeptId}");
            }
        }

        public static void DistinctMeth()
        {
            var n = new List<int>{1,2,2,3,3,3,4,5,5}; //Removes duplicate elements from a collection
            var number = n.Distinct();
            Console.WriteLine("Distinct");
            Console.WriteLine(string.Join(", " , number)); //instead of forLoop you can use "join" operation

            List<int> list1 = new List<int>{1,2,3};
            List<int> list2 = new List<int>{3,4,5};

            var nu1 = list1.Union(list2);
            Console.WriteLine("Union");
            Console.WriteLine(string.Join(", ", nu1));

            var nu2 = list1.Intersect(list2);
            Console.WriteLine("Intersection");
            Console.WriteLine(string.Join("," ,nu2));

            var nu3 = list1.Except(list2);
            Console.WriteLine("Except");
            Console.WriteLine(string.Join(", ",nu3));

            

        }
    } 
}
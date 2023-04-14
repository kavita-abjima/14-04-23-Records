using Deconstructor;
using System;
using System.Reflection.Emit;
using static ClassesAndRecords.Course;

namespace ClassesAndRecords
{
    class Program
    {
    
             
    }
    public class Course
    {
        static void Main(string[] args)
        {    
            //Record pbject
            Record1 r1a = new(FirstName: "Kavita", LastName: "Jangir");
            Record1 r1b = new(FirstName: "Kavita", LastName: "Jangir");
            Record1 r1c = new(FirstName: "Divya", LastName: "Jangir");

            //Class object
            Class1 c1a= new(firstName: "Kavita", lastName: "Jangir");
            Class1 c1b = new(firstName: "Kavita", lastName: "Jangir");
            Class1 c1c= new(firstName: "Divya", lastName: "Jangir");

            Console.WriteLine(value:"Record Type:");
            Console.WriteLine($"To String: {r1a}");
            Console.WriteLine($"Are the two objects are Equal {Equals(r1a,r1b)}");
            Console.WriteLine($"Are the two objects reference are Equal {ReferenceEquals(r1a, r1b)}");
            Console.WriteLine($"Are the two objects are r1a==r1b {(r1a== r1b)}");
            Console.WriteLine($"HashCode of object A{r1a.GetHashCode()}");
            Console.WriteLine($"HashCode of object B{r1b.GetHashCode()}");
            Console.WriteLine($"HashCode of object C{r1c.GetHashCode()}");

            
            Console.WriteLine();
            Console.WriteLine(value:"***************************");
            Console.WriteLine();

            Console.WriteLine(value: "Class Type:");
            Console.WriteLine($"To String: {c1a}");
            Console.WriteLine($"Are the two objects are Equal {Equals(c1a, c1b)}");
            Console.WriteLine($"Are the two objects are Equal {ReferenceEquals(c1a, c1b)}");
            Console.WriteLine($"Are the two objects c1a==c1b {Equals(c1a, c1b)}");
            Console.WriteLine($"HashCode of object A{c1a.GetHashCode()}");
            Console.WriteLine($"HashCode of object B{c1b.GetHashCode()}");
            Console.WriteLine($"HashCode of object C{c1c.GetHashCode()}");

            //Deconstructor
            var (fn, ln) = r1a;
            Console.WriteLine($"The value of fn is {fn} and the value of ln is {ln}");

            Record1 r1d = r1a with
            {
                FirstName = "Johan"

            };
            Console.WriteLine(value: $"Johan's Record is : {r1d}");

            Console.WriteLine();
            Record2 r2a = new(FirstName: "Kavita", LastName: "Jangir");
            Console.WriteLine(value:$"r2a value is {r2a}");

            Console.WriteLine(r2a.SayHello());

            //Deconstructors
            Person obj = new Person("Sona", 20, 120, "Scala", 40000.0);

            // Deconstruct the instance of 
            // the Person class named as obj
            (string AuthorName, int Age, int TotalArticals,
                     string Language, double Salary) = obj;

            // Displayin the values
            Console.WriteLine("Details of the Author:");
            Console.WriteLine("Author age:{0}", Age);
            Console.WriteLine("Author Name:{0}", AuthorName);
            Console.WriteLine("Total number of articles:{0}", TotalArticals);
            Console.WriteLine("Language:{0}", Language);
            Console.WriteLine("Salary :{0}", Salary);
            Console.ReadLine();
        }
    }   
        //Record is just a fancy class
        //Immutable
        public record Record1(string FirstName, string LastName);
        //inheritance
        public record User1(int id, string FirstName, string LastName):Record1(FirstName,LastName);

        public class DiscoveryModel
        {
        public User1 LookUpUser{get; set;}
        public int IncidentsFound { get; set; }
        public List<string> Incidents { get; set; }

        }
        public record Record2(string FirstName, string LastName)
        {
        private string _fullName = FirstName;

        public string FirstNames
        {
            get { return _fullName.Substring(0, 1); }
            init { }
        }

           internal string FirstName { get; init; } = FirstName;
           public string FullName { get => $"{LastName} {FirstName}";}

        //Methods
           public string SayHello () {
            return $"Hello {FirstName}";
           }
        }

    public class Class1
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Class1(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        
        public void Deconstruct(out string FirstName, out string LastName)
        {
            FirstName = this.FirstName;
            LastName = this.LastName;
        }
    }
    //Do not do any of the below
    public record Record3
    {
        public string FirstName { get; set; } //here set makes this racord immutable
        public string LastName { get; set; }
    }

}
namespace Deconstructor
{
    // Geeks class
    public class Person
    {
        // Creating variables
        string Aname;
        int age;
        int Tarticals;
        string language;
        double salary;

        // Method
        public Person(string _AuthorName, int _Age, int _TotalArticals,
                                      string _Language, double _Salary)
        {
            age = _Age;
            Aname = _AuthorName;
            Tarticals = _TotalArticals;
            language = _Language;
            salary = _Salary;
        }

        // Deconstructor 
        public void Deconstruct(out string _AuthorName, out int _Age,
                         out int _TotalArticals, out string _Language,
                                                   out double _Salary)
        {

            _AuthorName = Aname;
            _Age = age;
            _TotalArticals = Tarticals;
            _Language = language;
            _Salary = salary;
        }
    }
}
      
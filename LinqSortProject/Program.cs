using System;
using System.Collections;

namespace LinqSortProject
{
    class Person
    {
        public string? Name { get; set; }
        public DateTime BirthDay { set; get; }
    }

    class PersonMonthComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.BirthDay.Month - y.BirthDay.Month;
        }

        //public int Compare(object? x, object? y)
        //{
        //    return ((DateTime)x).Month - ((DateTime)y).Month;
        //}
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strs = { "hello", "people", "book", "boy", "economics" };

            var strResOne = from s in strs
                            orderby s.Length
                            select s;

            foreach (var s in strResOne)
                Console.WriteLine(s);
            Console.WriteLine(new String('-', 10));

            var strResTwo = strs.OrderBy(s => s.Length);
            foreach (var s in strResTwo)
                Console.WriteLine(s);
            Console.WriteLine(new String('-', 10));

            var persons = new List<Person>
            {
                new Person(){Name = "Bob",
                            BirthDay = new DateTime(1999, 5, 25)},
                new Person(){Name = "Tom",
                            BirthDay = new DateTime(2002, 6, 3)},
                new Person(){Name = "Sam",
                            BirthDay = new DateTime(2005, 11, 16)},
                new Person(){Name = "Jim",
                            BirthDay = new DateTime(2001, 3, 8)},
                new Person(){Name = "Tim",
                            BirthDay = new DateTime(2003, 7, 10)},
                new Person(){Name = "Bob",
                            BirthDay = new DateTime(2004, 3, 4)},
                new Person(){Name = "Tom",
                            BirthDay = new DateTime(1997, 2, 3)},
                new Person(){Name = "Sam",
                            BirthDay = new DateTime(2001, 11, 16)},
                new Person(){Name = "Jim",
                            BirthDay = new DateTime(2006, 3, 8)},
                new Person(){Name = "Tim",
                            BirthDay = new DateTime(1996, 7, 10)},
            };

            var personsSortOne = from p in persons
                                 orderby p.BirthDay descending
                                 select p;

            foreach (var s in personsSortOne)
                Console.WriteLine($"{s.Name} {DateTime.Now.Year - s.BirthDay.Year}");
            Console.WriteLine(new String('-', 10));

            var personsSortTwo = persons.OrderByDescending(p => p.BirthDay);
            foreach (var s in personsSortTwo)
                Console.WriteLine($"{s.Name} {DateTime.Now.Year - s.BirthDay.Year}");
            Console.WriteLine(new String('-', 10));

            var personsSortMultOne = from p in persons
                                     orderby p.Name, p.BirthDay descending
                                     select p;
            foreach (var s in personsSortMultOne)
                Console.WriteLine($"{s.Name} {DateTime.Now.Year - s.BirthDay.Year}");
            Console.WriteLine(new String('-', 10));

            var personsSortMultTwo = persons.OrderBy(p => p.Name)
                                            .ThenByDescending(p => p.BirthDay);
            foreach (var s in personsSortMultTwo)
                Console.WriteLine($"{s.Name} {DateTime.Now.Year - s.BirthDay.Year}");
            Console.WriteLine(new String('-', 10));

            var personsSortMonth = persons.OrderBy(p => p, new PersonMonthComparer());
                                            
            foreach (var s in personsSortMonth)
                Console.WriteLine($"{s.Name} {s.BirthDay}");
            Console.WriteLine(new String('-', 10));

        }
    }
}
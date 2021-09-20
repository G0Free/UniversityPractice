using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityPractice
{
    class Program
    {
        static void Process<T>(IEnumerable<T> x)
        {
            Console.WriteLine("\n\t~~~~~~~~~~\n");

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Ez a második heti feladatok gyakorlása!");

            List<int> list = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                list.Add(r.Next(99));
            }

            IEnumerable<int> filteredList = list.FindAll(x => x % 2 == 0);
            int maxItem = filteredList.Max(x => x);


            //páros számok kinyerése LINQ-val:
            var evens = list.Where(x => x % 2 == 0);
            Process(evens);
            //-----
            var orderedNumbers = list.OrderBy(x => x);
            Process(orderedNumbers);
            //-----


            #region DataGeneraling

            List<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Tim Tom" });
            students.Add(new Student() { Name = "Even Edward" });
            students.Add(new Student() { Name = "Lorem Lora" });
            students.Add(new Student() { Name = "Killer Karol" });
            students.Add(new Student() { Name = "King kARol" });

            #endregion

            #region IntroExamples

            //bevezető példák

            var orderedStuds = students.OrderBy(x => x.Name);
            Process(orderedStuds);

            //Tom
            var NameIs = students.Where(x => x.Name.Contains("Tom"));
            Process(NameIs);

            #endregion

            #region TASK1

            // 1. feladat:
            // adott egy adatbázis List-ként, kérdezzük le a Karol-ok számát
            // ekkora mérettel hozzunk létre tömböt
            // és másoljuk át a tömbbe a Karol-okat
            //
            // figyeljünk arra, hogy az adatbázisban lehet, hogy kis és nagybetűvel egyaránt lesz név

            int count = students.Count(x => x.Name.ToLower().Contains("karol".ToLower()));
            var karols = students.Where(x => x.Name.ToLower().Contains("karol".ToLower()));
            Student[] selectedOnes = new Student[count];
            int index = 0;
            foreach (Student item in karols)
            {
                selectedOnes[index] = item;
                index++;
            }
            Process(selectedOnes);

            #endregion

            //--------------------------

            #region TASK2

            // 2. feladat:
            // hallgatók lekérése, akiknek életkoruk 20-50 között van
            // és még nincsenek párkapcsolatban
            // (ehhez egészítsük ki a hallgató osztályt)
            //
            // hallgatók adatainak kiegészítése (életkor + kapcs. státusz)

            //kiegészítés
            Predicate<int> statusRandomizer = x => { return x == 0; };
            for (int i = 0; i < students.Count; i++)
            {
                students[i].Status = (bool)statusRandomizer?.Invoke(r.Next(2));
                students[i].Age = r.Next(0, 60);
            }
            Process(students);

            //lekérés megvalósítása:
            var studentsTaskTwo = students.Where(x => !x.Status && (x.Age <= 50 && x.Age >= 20));
            Process(studentsTaskTwo);
            #endregion

            //--------------------------

            #region TASK3

            // 3. feladat:
            // kérjük le azokat, akik kapcsolatban vannak
            // a kapott eredményt rendezzük sorrendbe név alapján
            // és alakítsuk nagybetűssé a neveket

            var taken = students
                .Where(x => x.Status == true)
                .OrderBy(x => x.Name)
                .Select(x => x.Name.ToUpper());

            Process(taken);

            #endregion
            //--------------------------

            #region TASK4

            // 4. feladat:
            // kérjük le a kapcsolatban / nem kapcs. lévő hallgatókat
            // csoportsítva és számoljuk meg, hogy hány entitás van egyik/másik csoportban



            #endregion
            //--------------------------
        }

    }
}

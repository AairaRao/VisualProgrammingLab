using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //                                          Activity 1


            List<int>numbers = new List<int>();

            numbers.Add(6);
            numbers.Add(5);
            numbers.Add(8);
            numbers.Add(1);

            Console.WriteLine("Original List ");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
            numbers.Sort();
            Console.WriteLine("\nSorted List ");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
            numbers.Remove(8);
            Console.WriteLine("\n List after removal ");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
             }



            //                                        Activity 02


            Dictionary<string, string> countries = new Dictionary<string, string>();

            countries["USA"] = "Washington D.C.";
            countries["France"] = "Paris ";
            countries["Japan"] = "Tokyo";
            countries["India"] = "New Dehli";

            Console.WriteLine("Countries and Capitals.");
            foreach (var pair in countries)
            {
                Console.WriteLine($"{pair.Key}:{pair.Value}");

            }
            Console.WriteLine($"\nCapital of Japan : {countries["Japan"]}");

            countries.Remove("France");

            Console.WriteLine("\nUpdated Countries and Capitals : ");
            foreach (var pair in countries)
            {
                Console.WriteLine($"{pair.Key}:{pair.Value}");
            }



            //                                        Activity_3

            ArrayList arraylist = new ArrayList();

            arraylist.Add(10);
            arraylist.Add("Hello");
            arraylist.Add(20.5);
            arraylist.Add("World");

            Console.WriteLine("Array List Items: ");
            foreach (var item in arraylist)
            {
                Console.WriteLine(item);
            }

            arraylist.Remove("Hello");
            Console.WriteLine("\nArrayList after Removal: ");
            foreach (var item in arraylist)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nContains 'World': {arraylist.Contains("World")}");




            //                                   Activity 4



            Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();

            students["Alice"] = new List<int> { 85, 90, 88 };
            students["Bob"] = new List<int> { 70, 60, 75 };
            students["Charlie"] = new List<int> { 95, 92, 94 };
            students["Daisy"] = new List<int> { 55, 60, 58 };

            Console.WriteLine("\nStudents Average: ");
            foreach (var student in students)
            {
                double average = student.Value.Average();
                Console.WriteLine($"{student.Key}:{average:F2}");
            }

            var topStudent = students.OrderByDescending(s => s.Value.Average()).First();
            var lowStudent = students.OrderBy(s => s.Value.Average()).First();

            Console.WriteLine($"\nTop performing Student: {topStudent.Key} with an average of {topStudent.Value.Average():F2}");
            Console.WriteLine($"\nLow performing Student: {lowStudent.Key} with an average of {lowStudent.Value.Average():F2}");

            var fallingStudents = students.Where(s => s.Value.Average() < 60).Select(s => s.Key).ToList();

            foreach (var student in fallingStudents)
            {
                students.Remove(student);
            }

            Console.WriteLine("\nList of Students:");
            foreach (var student in students)
            {
                Console.WriteLine(student.Key);
            }
        }
    }
}

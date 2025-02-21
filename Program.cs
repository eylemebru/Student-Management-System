using System;
using System.Linq;
using StudentDatabase.Data;
using StudentDatabase.Models;

namespace StudentDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentContext())
            {
                context.Database.EnsureCreated();
                bool continueRunning = true;

                while (continueRunning)
                {
                    Console.WriteLine("\n=== Student Management System ===");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. List All Students");
                    Console.WriteLine("3. Search Student");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nYour choice (1-4): ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddStudent(context);
                            break;
                        case "2":
                            ListStudents(context);
                            break;
                        case "3":
                            SearchStudent(context);
                            break;
                        case "4":
                            continueRunning = false;
                            Console.WriteLine("Exiting program...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice! Please try again.");
                            break;
                    }
                }
            }
        }

        static void AddStudent(StudentContext context)
        {
            Console.WriteLine("\n=== Add Student ===");
            
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            
            Console.Write("Date of Birth (DD.MM.YYYY): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
            {
                Console.Write("Email: ");
                string email = Console.ReadLine();

                var student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    Email = email
                };

                context.Students.Add(student);
                context.SaveChanges();
                Console.WriteLine("\nStudent added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid date format!");
            }
        }

        static void ListStudents(StudentContext context)
        {
            Console.WriteLine("\n=== Student List ===");
            var students = context.Students.ToList();
            
            if (students.Any())
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.StudentId}");
                    Console.WriteLine($"First Name: {student.FirstName}");
                    Console.WriteLine($"Last Name: {student.LastName}");
                    Console.WriteLine($"Date of Birth: {student.DateOfBirth.ToShortDateString()}");
                    Console.WriteLine($"Email: {student.Email}");
                    Console.WriteLine("------------------------");
                }
            }
            else
            {
                Console.WriteLine("No students found in the database.");
            }
        }

        static void SearchStudent(StudentContext context)
        {
            Console.WriteLine("\n=== Search Student ===");
            Console.Write("Enter student's first name or last name to search: ");
            string searchTerm = Console.ReadLine().ToLower();

            var results = context.Students
                .Where(s => s.FirstName.ToLower().Contains(searchTerm) || 
                           s.LastName.ToLower().Contains(searchTerm))
                .ToList();

            if (results.Any())
            {
                Console.WriteLine("\nFound students:");
                foreach (var student in results)
                {
                    Console.WriteLine($"ID: {student.StudentId}");
                    Console.WriteLine($"First Name: {student.FirstName}");
                    Console.WriteLine($"Last Name: {student.LastName}");
                    Console.WriteLine($"Date of Birth: {student.DateOfBirth.ToShortDateString()}");
                    Console.WriteLine($"Email: {student.Email}");
                    Console.WriteLine("------------------------");
                }
            }
            else
            {
                Console.WriteLine("No students found matching the search criteria.");
            }
        }
    }
}

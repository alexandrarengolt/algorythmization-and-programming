using System;
using System.Runtime.ExceptionServices;
using System.Xml.Linq;

namespace lab
{
    unsafe struct Student
    {
        public int studentId;
        public string name;
        public Student* leftStudent;
        public Student* rightStudent;

        public Student(int studentId, string name, Student* leftStudent = null, Student* rightStudent = null)
        {
            this.studentId = studentId;
            this.name = name;
            this.leftStudent = leftStudent;
            this.rightStudent = rightStudent;
        }
    }

    unsafe class Program
    {
        unsafe static void Main()
        {
            Student rootStudent = new Student(22, "Inna");
            Student* rootPtr = &rootStudent;

            Student student2 = new Student(13, "Anna");
            Student student3 = new Student(18, "Ksunya");
            Student student4 = new Student(34, "Olya");
            Student student5 = new Student(1, "Sanya");
            Student student6 = new Student(8, "Manya");

            InsertStudent(rootPtr, &student2);
            InsertStudent(rootPtr, &student3);
            InsertStudent(rootPtr, &student4);
            InsertStudent(rootPtr, &student5);
            InsertStudent(rootPtr, &student6);

            Console.WriteLine("Левая ветка:");
            PrintLeftStudents(rootPtr->leftStudent);

            Console.WriteLine("Корень:");
            Console.WriteLine($"ID: {rootPtr->studentId}, Имя: {rootPtr->name}");

            Console.WriteLine("Правая ветка:");
            PrintRightStudents(rootPtr->rightStudent);
        }

        public static void InsertStudent(Student* current, Student* newStudent)
        {
            if (current == null || newStudent == null) return;

            if (current->studentId < newStudent->studentId)
            {
                if (current->rightStudent == null)
                {
                    current->rightStudent = newStudent;
                }
                else
                {
                    InsertStudent(current->rightStudent, newStudent);
                }
            }
            else if (current->studentId > newStudent->studentId)
            {
                if (current->leftStudent == null)
                {
                    current->leftStudent = newStudent;
                }
                else
                {
                    InsertStudent(current->leftStudent, newStudent);
                }
            }
        }

        public static void PrintLeftStudents(Student* student)
        {
            if (student != null)
            {
                PrintLeftStudents(student->leftStudent);
                Console.WriteLine($"ID: {student->studentId}, Имя: {student->name}");
                PrintLeftStudents(student->rightStudent);
            }
        }

        public static void PrintRightStudents(Student* student)
        {
            if (student != null)
            {
                PrintRightStudents(student->leftStudent);
                Console.WriteLine($"ID: {student->studentId}, Имя: {student->name}");
                PrintRightStudents(student->rightStudent);
            }
        }
    }
}

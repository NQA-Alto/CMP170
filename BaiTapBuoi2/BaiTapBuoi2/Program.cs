using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public void Show()
    {
        Console.WriteLine($"Mã: {Id}, Tên: {Name}, Tuổi: {Age}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        List<Student> studentList = new List<Student>
        {
            new Student(1, "An", 15),
            new Student(2, "Bình", 16),
            new Student(3, "Anh", 18),
            new Student(4, "Chi", 19),
            new Student(5, "Dũng", 17)
        };

        Console.WriteLine("a. Danh sách toàn bộ học sinh");
        DisplayList(studentList);

        Console.WriteLine("\nb. Danh sách học sinh có tuổi từ 15 đến 18");
        var studentsFrom15To18 = studentList
            .Where(s => s.Age >= 15 && s.Age <= 18)
            .ToList();
        DisplayList(studentsFrom15To18);

        Console.WriteLine("\nc. Danh sách học sinh có tên bắt đầu bằng chữ A");
        var studentsStartWithA = studentList
            .Where(s => s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase))
            .ToList();
        DisplayList(studentsStartWithA);

        int totalAge = studentList.Sum(s => s.Age);
        Console.WriteLine($"\nd. Tổng tuổi của tất cả học sinh: {totalAge}");

        Student oldestStudent = studentList
            .OrderByDescending(s => s.Age)
            .First();

        Console.WriteLine("\ne. Học sinh có tuổi lớn nhất");
        oldestStudent.Show();

        Console.WriteLine("\nf. Danh sách học sinh được sắp xếp theo tuổi tăng dần");
        var sortedStudents = studentList
            .OrderBy(s => s.Age)
            .ToList();
        DisplayList(sortedStudents);

        Console.ReadKey();
    }

    static void DisplayList(List<Student> studentList)
    {
        foreach (Student student in studentList)
        {
            student.Show();
        }
    }
}
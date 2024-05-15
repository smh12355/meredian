using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace meredian;

internal class Program
{
    static void Main(string[] args)
    {
        var teachers = new List<Teacher>();
        using (StreamReader reader = new StreamReader("Учителя.txt"))
        {
            reader.ReadLine();
            string? line;
            long counter = 0;
            while ((line = reader.ReadLine()) != null)
            {
                LessonType lesson;
                var data = line.Split("\t\t").ToList<string>();
                if (data.Count != 4)
                {
                    for (int i = 0; i < 3 || data.Count != 4; i++)
                    {
                        if (data[i].Split("\t").GetUpperBound(0) != 0)
                        {
                            var storage = data[i].Split("\t");
                            data.Insert(i + 1, storage[1]);
                            data.RemoveAt(i);
                            data.Insert(i, storage[0]);
                        }
                    }
                }
                if (data[3] is "Физика")
                {
                    lesson = LessonType.Physics;
                }
                else
                {
                    lesson = LessonType.Mathematics;
                }
                teachers.Add(new Teacher() { ID = counter, Name = data[0], LastName = data[1], Age = Convert.ToInt32(data[2]), Lesson = lesson });
                counter++;
            }
        }
        var students = new List<Student>();
        using (StreamReader reader = new StreamReader("Ученики.txt"))
        {
            reader.ReadLine();
            string? line;
            long counter = 0;
            while ((line = reader.ReadLine()) != null)
            {
                var data = line.Split("\t\t").ToList<string>();
                if (data.Count != 3)
                {
                    for (int i = 0; i < 3 || data.Count != 3; i++)
                    {
                        if (data[i].Split("\t").GetUpperBound(0) != 0)
                        {
                            var storage = data[i].Split("\t");
                            data.Insert(i + 1, storage[1]);
                            data.RemoveAt(i);
                            data.Insert(i, storage[0]);
                        }
                    }
                }
                students.Add(new Student() { ID = counter, Name = data[0], LastName = data[1], Age = Convert.ToInt32(data[2])});
                counter++;
            }
        }
        var exams = new List<Exams>();
        //exams.Add(new Exams { Student = students[0], Teacher = teachers[1], Score = 95, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[1], Teacher = teachers[1], Score = 80, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[0], Teacher = teachers[0], Score = 85, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[1], Teacher = teachers[0], Score = 90, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[2], Teacher = teachers[0], Score = 78, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[0], Teacher = teachers[2], Score = 95, ExamDate = DateTime.Now });
        var secondTask = exams
            .GroupBy(x => x.Teacher.ID)
            .OrderBy(x => x.Count())
            .FirstOrDefault()
            .FirstOrDefault()
            .Teacher;
        //Console.WriteLine($"{secondTask.Name} {secondTask.LastName}");
        //exams.Add(new Exams { Student = students[0], Teacher = teachers[1], Score = 95, ExamDate = new DateTime(2023, 5, 15, 21, 45, 33) });
        //exams.Add(new Exams { Student = students[1], Teacher = teachers[1], Score = 80, ExamDate = new DateTime(2023, 5, 15, 21, 46, 33) });
        //exams.Add(new Exams { Student = students[0], Teacher = teachers[0], Score = 85, ExamDate = new DateTime(2023, 5, 15, 21, 47, 33) });
        //exams.Add(new Exams { Student = students[1], Teacher = teachers[0], Score = 90, ExamDate = new DateTime(2023, 5, 15, 21, 42, 33) });
        //exams.Add(new Exams { Student = students[2], Teacher = teachers[0], Score = 78, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[0], Teacher = teachers[2], Score = 95, ExamDate = DateTime.Now });
        var thirdTask = exams
            .Where(x => Regex.IsMatch(x.ExamDate.ToString(), @".*2023.*"))
            .Select(x => x.Score)
            .Average();
        //exams.Add(new Exams { Student = students[0], Teacher = new Teacher() { ID = 1, Name = "Alex", LastName = "Petrov", Age = 5, Lesson = LessonType.Mathematics }, Score = 95, ExamDate = new DateTime(2023, 5, 15, 21, 45, 33) });
        //exams.Add(new Exams { Student = students[1], Teacher = new Teacher() { ID = 1, Name = "Alex", LastName = "Petrov", Age = 5, Lesson = LessonType.Mathematics }, Score = 80, ExamDate = new DateTime(2023, 5, 15, 21, 46, 33) });
        //exams.Add(new Exams { Student = students[0], Teacher = new Teacher() { ID = 1, Name = "Alex", LastName = "Petrov", Age = 5, Lesson = LessonType.Mathematics }, Score = 85, ExamDate = new DateTime(2023, 5, 15, 21, 47, 33) });
        //exams.Add(new Exams { Student = students[1], Teacher = new Teacher() { ID = 1, Name = "Alex", LastName = "Petrov", Age = 5, Lesson = LessonType.Mathematics }, Score = 91, ExamDate = new DateTime(2023, 5, 15, 21, 42, 33) });
        //exams.Add(new Exams { Student = students[2], Teacher = teachers[0], Score = 78, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[0], Teacher = teachers[2], Score = 95, ExamDate = DateTime.Now });
        var fourthTask = exams
            .Where(x => x.Teacher.Lesson == LessonType.Mathematics && x.Teacher.Name == "Alex" && x.Score > 90)
            .Count();

        //exams.Add(new Exams { Student = students[0], Teacher = teachers[1], Score = 95, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[1], Teacher = teachers[1], Score = 80, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[0], Teacher = teachers[0], Score = 85, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[1], Teacher = teachers[0], Score = 90, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[2], Teacher = teachers[0], Score = 78, ExamDate = DateTime.Now });
        //exams.Add(new Exams { Student = students[0], Teacher = teachers[2], Score = 95, ExamDate = DateTime.Now });
        var fifthTask = exams
            .GroupBy(x => x.Teacher.ID)
            .OrderByDescending(x => x.Count())
            .Skip(1)
            .FirstOrDefault()
            .FirstOrDefault()
            .Teacher
            .Name
;
    }

}
public class Person
{
    public long ID { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}
public class Teacher : Person
{
    public LessonType Lesson { get; set; }
}
public class Student : Person
{

}
public class Exams
{
    public decimal Score { get; set; }
    public DateTime ExamDate { get; set; }
    public Student Student { get; set; }
    public Teacher Teacher { get; set; }
}

public enum LessonType
{
    Mathematics = 0,
    Physics = 1
}

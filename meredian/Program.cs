using System.Linq.Expressions;

namespace meredian;

internal class Program
{
    static void Main(string[] args)
    {
        //var initial_path = Environment.CurrentDirectory;
        //var another = Path.Combine(initial_path, "Учителя.txt");
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
        //List<>
        //Person oleg = new Person();
        //Teacher teacher = new Teacher();
        //Console.WriteLine(teacher.Lesson);
        //LessonType hey = LessonType.Mathematics;
        //Console.WriteLine(hey);
    }

}
internal class Person
{
    public long ID { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}
internal class Teacher : Person
{
    public LessonType Lesson { get; set; }
}
public enum LessonType
{
    Mathematics = 1,
    Physics = 1
}

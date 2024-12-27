namespace Otus_Lesson_19;

// 1
// Создайте метод, который принимает список имен и возвращает кортеж с самым длинным и самым коротким именем.
// Если есть несколько имен одинаковой длины, выберите первое из них.

// 2
// Создайте список студентов с полями Name, Age и Grade.
// Затем создайте анонимный тип, который будет содержать только имена и оценки студентов, старше 18 лет, и выведите этот список.

internal class Program
{
    private static void Main(string[] args)
    {
        var testTuple = GetInput(new List<string> { "Иван", "Пётр", "Аркадий", "Анна" });
        Console.WriteLine($"Самое длинное: {testTuple.Item1}, Самое короткое: {testTuple.Item2}");

        PrintAdultStudentsInfo(new List<Student>
            {
                new() { Name = "Алексей", Age = 17, Grade = 4.0 },
                new() { Name = "Мария", Age = 19, Grade = 5.0 },
                new() { Name = "Иван", Age = 22, Grade = 3.0 },
                new() { Name = "Анна", Age = 16, Grade = 5.0 }
            }
        );
    }

    private static (string, string) GetInput(List<string> names)
    {
        if (names.Count == 0) throw new Exception("Пустой список имён");

        var longest = string.Empty;
        var shortest = string.Empty;

        foreach (var name in names)
        {
            if (shortest == string.Empty) shortest = name;
            if (name.Length > longest.Length) longest = name;
            if (name.Length < shortest.Length) shortest = name;
        }

        return (longest, shortest);
    }

    private static void PrintAdultStudentsInfo(List<Student> students)
    {
        var adultStudents = students.Where(s => s.Age >= 18)
            .Select(s => new
                {
                    Name = s.Name, 
                    Grade = s.Grade
                })
            .ToList();
        
        Console.WriteLine("Список студентов: ");
        
        foreach (var student in adultStudents)
        {
            Console.WriteLine($"Имя : {student.Name}, оценка: {student.Grade}");
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
    }
}
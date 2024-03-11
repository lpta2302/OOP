using System.Runtime.InteropServices;
using System.Text.Json;
using day9;

class Program
{
    public static string path = "file.dat";
    public static List<StudentList>? lists = new List<StudentList>();
    public static void DoTask(Task task)
    {
        StudentList studentList = new StudentList();
        studentList.Add(new Student { Id = 1, Name = "Nam", Age = 20 });
        studentList.Add(new Student { Id = 2, Name = "Binh", Age = 21 });
        studentList.Add(new Student { Id = 3, Name = "Minh", Age = 22 });
        task.SaveToFile(studentList);

        Console.WriteLine("Old");
        task.Display();
        Console.WriteLine("".PadLeft(40, '-'));

        studentList = new StudentList();
        studentList.Add(new Student { Id = 4, Name = "An", Age = 20 });
        studentList.Add(new Student { Id = 5, Name = "Nhien", Age = 18 });
        task.SaveToFile(studentList);

        studentList = new StudentList();
        studentList.Add(new Student { Id = 6, Name = "Ngoc", Age = 21 });
        studentList.Add(new Student { Id = 7, Name = "Dat", Age = 20 });
        task.SaveToFile(studentList);

        Console.WriteLine("New");
        task.Display();
    }
    public static void Main(string[] args)
    {
        using (FileStream fs = new FileStream(path, FileMode.Create)) { }
        DoTask(new Cau2(path, lists));
    }
}
using System.Text.Json;

public abstract class Task
{
    protected string path = "file.json";
    protected List<StudentList>? lists = new List<StudentList>();
    public Task(string _path, List<StudentList> _lists)
    {
        path = _path;
        lists = _lists;
    }
    public abstract void SaveToFile(StudentList list);
    public abstract void GetFromFile();
    public void Display()
    {
        GetFromFile();
        if (lists == null) throw new Exception();
        foreach (StudentList item in lists)
        {
            foreach (Student st in item.Students)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine("".PadLeft(40, '-'));
        }
    }
}

using System.Runtime.Serialization;

public class StudentList : ISerializable
{
    private List<Student> students = new List<Student>();
    public List<Student> Students
    {
        get => students; set => students = value;
    }
    public StudentList() { }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Students", Students);
    }
    public StudentList(SerializationInfo info, StreamContent content)
    {
        Students = (List<Student>)info.GetValue("Students", typeof(List<Student>));
    }
    public void Add(Student item){
        Students.Add(item);
    }
}

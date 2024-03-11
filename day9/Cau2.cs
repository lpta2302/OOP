using System.Text.Json;
using System.Xml.Serialization;

public class Cau2 : Task
{
    public Cau2(string _path, List<StudentList> _lists) :
    base(_path, _lists)
    { }
    public override void SaveToFile(StudentList list)
    {
        lists.Add(list);
        XmlSerializer serializer = new XmlSerializer(typeof(List<StudentList>));
        using (StreamWriter writer = new StreamWriter(path))
        {
            serializer.Serialize(writer, lists);
        }
    }
    public override void GetFromFile()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<StudentList>));
        using (StreamReader reader = new StreamReader(path))
        {
            lists = serializer.Deserialize(reader) as List<StudentList>;
        }
    }
}

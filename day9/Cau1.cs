using System.Text.Json;

namespace day9;

public class Cau1 : Task
{
    public Cau1(string _path, List<StudentList> _lists) :
    base(_path, _lists){
        
    }
    public override void SaveToFile(StudentList list)
    {
        string json = JsonSerializer.Serialize(list,
            new JsonSerializerOptions { WriteIndented = true });

        string data = File.ReadAllText(path);
        bool haveData = data.Length > 0;

        if (haveData)
        {
            data = data.Substring(0, data.Length - 1) + "," + json + "]";
        }
        else
        {
            data = "[" + json + "]";
        }

        File.WriteAllText(path, data);
    }
    public override void GetFromFile()
    {
        string newjson = File.ReadAllText(path);
        lists = JsonSerializer.Deserialize<List<StudentList>>(newjson);
    }
}

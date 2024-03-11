﻿using System.Runtime.Serialization;

public class Student : ISerializable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Student() { }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Id", Id);
        info.AddValue("Name", Name);
        info.AddValue("Age", Age);
    }

    public Student(SerializationInfo info, StreamingContext context){
        Id = info.GetInt32("Id");
        Name = info.GetString("Name");
        Age = info.GetInt32("Age");
    }
    public override string ToString()
    {
        return $"Student: Id: {Id}, Name: {Name}, Age: {Age}";
    }
}

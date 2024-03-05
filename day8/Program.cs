// Bổ sung tính module vào  Ivector và triển khai pt này trong v2 và v3
// Bổ sung ~ để chuyển đổi v 2 thành v3 và ngược lại
// Triển khai main qua list 2v toạ độ ngẫu nhiên có v2 và v3 qua create vector

class Program
{
    private static int n = 5;
    private static int max = 21;

    static List<IVector> CreateVector()
    {
        List<IVector> res = new List<IVector>(n);
        Random r = new Random();
        for (int i = 0; i < n; i++)
        {
            int type = r.Next(2);
            Console.WriteLine(type);
            int x = r.Next(max);
            int y = r.Next(max);
            if (type == 0)
                res.Add(new Vector2D(x, y));
            else
                res.Add(new Vector3D(x, y, r.Next(max)));
        }
        return res;
    }
    static void Start(List<IVector> vectors)
    {
        for (int i = 0; i < vectors.Count; i++)
        {
            if (vectors[i] is Vector2D)
            {
                Vector2D v1 = (Vector2D)vectors[i];

                Console.WriteLine("Current Vector: " + v1);
                for (int j = i + 1; j < vectors.Count; j++)
                {
                    if (vectors[j].GetType() != vectors[i].GetType())
                        continue;
                    Vector2D v2 = (Vector2D)vectors[j];

                    Console.WriteLine($"{v1} + {v2} = {v1 + v2}");
                    Console.WriteLine($"{v1} * {v2} = {v1 * v2}");
                }
                Console.WriteLine($"Convert ~ : {~v1}");
                Console.WriteLine($"Module: {v1.Module()}");
                Console.WriteLine();
            }
            else
            {
                Vector3D v1 = (Vector3D)vectors[i];
                Console.WriteLine("Current Vector: " + v1);
                
                for (int j = i + 1; j < vectors.Count; j++)
                {
                    if (vectors[j].GetType() != vectors[i].GetType())
                        continue;
                    Vector3D v2 = (Vector3D)vectors[j];

                    Console.WriteLine($"{v1} + {v2} = {v1 + v2}");
                    Console.WriteLine($"{v1} * {v2} = {v1 * v2}");
                }
                    Console.WriteLine($"Convert ~ : {~v1}");
                    Console.WriteLine($"Module: {v1.Module()}");
                    Console.WriteLine();
            }
        }
    }
    static void Main()
    {
        List<IVector> vectors = CreateVector();
        Start(vectors);
    }
}
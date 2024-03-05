abstract class Numeric
{
    public abstract object Calculate();
}

class ComplexNum : Numeric
{
    public int RealNum { get; set; }
    public int ImaginaryNum { get; set; }
    private float calculate(int x, int y)
    {
        return (float)Math.Round(
            Math.Sqrt(x * x + y * y)
            , 2);
    }
    public ComplexNum(int RealNum = 0, int ImaginaryNum = 0)
    {
        this.RealNum = RealNum;
        this.ImaginaryNum = ImaginaryNum;
    }
    public override object Calculate()
    {
        return calculate(RealNum, ImaginaryNum);
    }
}
class Vector2D : Numeric
{
    public float x { get; set; }
    public float y { get; set; }
    public Vector2D(float x = 0, float y = 0)
    {
        this.x = (float)Math.Round(x,2);
        this.y = (float)Math.Round(y,2);
    }
    private Vector2D calculate(){
        if(y == 0 || x == 0)
            return new Vector2D(0,0);
        else{
            float calculatedY = -x*x/y;
            return new Vector2D(x,calculatedY);
        }
            
    }
    public override object Calculate()
    {
        return calculate();
    }
}
class Program
{
    static Vector2D createVector(float x, float y)
    {
        return new Vector2D(x, y);
    }
    static ComplexNum createSoPhuc(int x, int y)
    {
        return new ComplexNum(x, y);
    }
    static void Main()
    {
        Numeric[] numbers = new Numeric[20];

        Random random = new Random();

        for (int i = 0; i < numbers.Length; i++)
        {
            int x = random.Next(-10, 10);
            int y = random.Next(-10, 10);

            if(random.Next(0, 2) == 1){
                numbers[i] = createSoPhuc(x, y);
                ComplexNum tmp = (ComplexNum)numbers[i];
                Console.WriteLine($"Type: {"ComplexNum",10} | {"RealNum:",-15} {tmp.ImaginaryNum,4} | {"ImaginaryNum:",-15} {tmp.RealNum,4} | {tmp.Calculate()}");
            }
            else{
                numbers[i] = createVector(x, y);
                Vector2D tmp = (Vector2D)numbers[i];
                Vector2D result = (Vector2D)tmp.Calculate();
                Console.WriteLine($"Type: {"Vector2D",10} | {"X:",-15} {tmp.x,4} | {"Y:",-15} {tmp.y,4} | ({result.x,2}, {result.y,2})");
            }
        }
    }
}
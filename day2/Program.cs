using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualBasic;


class Program
{
    static void Main()
    {
        Flow flow = new Flow();
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();
        Console.WriteLine("Create DB");
        Console.Write("Number of product in DB: ");
        int n = int.Parse(Console.ReadLine());
        List<Product> db = new List<Product>(n);
        List<Product> cart = new List<Product>(n);
        flow.initDB(db);

        Console.WriteLine("Create Coupon");
        Console.Write("Number of coupon in CouponDB: ");
        n = int.Parse(Console.ReadLine());
        List<Coupon> coupons = new List<Coupon>(n);
        flow.initCoupon(coupons);

        flow.Buying(db, cart, coupons);
    }
}
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Text;
using System.Text.Unicode;
public class Status
{
    public int Quantity{get;set;}
    public float Price{get;set;}
}
public class Product
{
    public string Name{get; set;}
    public Status Stat{get; set;}
}

public class Program
{
    /*
    Tên hàng	                Gạo	Ngô	Khoai
    Số lượng (tấn)	            100	90	20
    Đơn giá (nghìn đồng/1kg)	30	15	12
    */
    public static void InitProduct(Product current)
    {
        Console.Write("\tProduct: ");
        current.Name = Console.ReadLine();
        Console.Write("\tQuantity: ");
        current.Stat.Quantity = int.Parse(Console.ReadLine());
        Console.Write("\tPrice: ");
        current.Stat.Price = float.Parse(Console.ReadLine());
    }
    public static void InitDataBase(Product[] db)
    {
        for (int i = 0; i < db.Length; i++)
        {
            Console.Write(">> Init product No.{0}\n", i+1);
            db[i] = new Product();
            Status status = new Status();
            db[i].Stat = status;
            InitProduct(db[i]);
        }
        Display(db);
    }
    public static void Display(Product[] db){
        Console.Clear();
        Console.WriteLine("Stock");
        foreach (Product product in db)
        {
            Console.WriteLine($"{product.Name,-20}|{product.Stat.Quantity,-4}|{product.Stat.Price,-10}");
        }
    }
    public static void Display(Product[] db,Status[] cart){
        for(int i=0;i<cart.Length;i++){
            Console.WriteLine($"{db[i].Name,-20}|{cart[i].Quantity,-4}|{cart[i].Price,-10}");
        }
    }
    public static void ask(Product[] db){
        Display(db);
        Console.WriteLine("Cart");
        Console.WriteLine("Buy ?\n0 - Exit");
            for (int i = 0; i < db.Length; i++)
            {
                Console.WriteLine($"{i+1} - {db[i].Name}");
            }
    }
    public static void Buy(Status[] cart, Product[] db)
    {
        while (true)
        {
            ask(db);

            int index = int.Parse(Console.ReadLine())-1;
            string productName = db[index].Name;

            Console.Write($"Buy {productName}\nQuantity: {db[index].Stat.Quantity}\nBuy: ");
            int x = int.Parse(Console.ReadLine());

            if(x > db[index].Stat.Quantity){
                x=db[index].Stat.Quantity;
            }

            db[index].Stat.Quantity -= x;
            cart[index].Quantity += x;

            Display(db);
            Console.WriteLine("".PadLeft(20,'-'));
            Display(db,cart);

            Console.WriteLine("Press E to exit\nPress C to Checkout\nPress Any to continue");
            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.E:
                    return;
                case ConsoleKey.C:
                    Checkout(db,cart);
                    return;
            }
        }
    }
    public static void Checkout(Product[] db,Status[] cart)
    {
        float sum = 0;
        for (int i = 0; i < cart.Length; i++)
            if (cart[i].Quantity != 0)
                sum += cart[i].Quantity * cart[i].Price;
        Console.Clear();
        Display(db,cart);
        Console.WriteLine("".PadRight(20,'-'));
        Console.WriteLine("Tong tien: " + sum);
    }
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();
        Console.WriteLine("-----Create Database-----");
        Console.Write("Number of db in DB: ");
        int n = int.Parse(Console.ReadLine());

        Product[] db = new Product[n];
        InitDataBase(db);

        Status[] cart = new Status[n];
        for(int i=0;i<cart.Length;i++){
            cart[i]= new Status();
            cart[i].Price = db[i].Stat.Price;
        }

        Buy(cart,db);

        Console.ReadLine();
    }
}
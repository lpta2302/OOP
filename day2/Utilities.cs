public class Display{
    public void DisplayCoupons(List<Coupon> coupons)
    {
        Console.Clear();
        Console.WriteLine("".PadLeft(50, '-'));
        Console.WriteLine("Coupons");
        Console.WriteLine($"{"No",-3}|{"ID",-20}|{"Price Off",-10}");
        for (int i = 0; i < coupons.Count(); i++)
        {
            Console.WriteLine($"{i + 1,-3}|{coupons[i].getID(),-20}|{coupons[i].getOff(),-10}");
        }
        Console.WriteLine("".PadLeft(50, '-'));
    }
    public void DisplayProducts(List<Product> products)
    {
        Console.Clear();
        Console.WriteLine("".PadLeft(50, '-'));
        Console.WriteLine("Products");

        Console.WriteLine($"{"ID",-10}|{"Name",-20}|{"Price",-10}");

        foreach (Product item in products)
        {
            Console.WriteLine($"{item.getID(),-10}|{item.getName(),-20}|{item.getPrice(),-10}");
        }
        Console.WriteLine("".PadLeft(50, '-'));
    }
    public void DisplayCart(List<Product> products,List<Product> cart)
    {
        Console.Clear();
        Console.WriteLine("".PadLeft(50, '-'));
        Console.WriteLine("Products");

        Console.WriteLine($"{"ID",-10}|{"Name",-20}|{"Price",-10}|{"Init Price",-10}");

        foreach (Product item in cart)
        {
            Buy buy = new Buy();
            float initPrice = products[buy.FindProduct(item.getName(),products)].getPrice();
            Console.WriteLine($"{item.getID(),-10}|{item.getName(),-20}|{item.getPrice(),-10}|{initPrice,-10}");
        }
        Console.WriteLine("".PadLeft(50, '-'));
    }
}
public class Buy
{
    public int FindProduct(string key, List<Product> list)
    {
        int res = -1;
        for (int i = 0; i < list.Count(); i++)
        {
            if (list[i].getName().Equals(key))
                return i;
            else if (list[i].getName().Contains(key))
                res = i;
        }
        return res;
    }
    public void AddCart(Product item, List<Product> cart)
    {
        int index = FindProduct(item.getName(), cart);
        if (index == -1)
            cart.Add(new Product(item));
    }
    public void AddCoupon(List<Product> db, List<Product> cart, List<Coupon> coupons)
    {
        Display display = new Display();
        while (true)
        {
            display.DisplayCoupons(coupons);
            Console.Write("Add Coupon No: ");
            int indexCoupon = int.Parse(Console.ReadLine()) - 1;
            display.DisplayProducts(cart);
            Console.Write("Add Coupon for: ");
            int index = FindProduct(Console.ReadLine(), cart);
            float initPrice = db[FindProduct(cart[index].getName(),db)].getPrice();
            cart[index].setPrice(cart[index].getPrice() - (coupons[indexCoupon].getOff() * initPrice));
            coupons.RemoveAt(indexCoupon);
            Console.WriteLine("Press C to Checkout\nPress any to continue...");
            if (Console.ReadKey().Key == ConsoleKey.C)
                break;
        }

        Console.Clear();
    }
}
class Flow
{
    public void Checkout(List<Product> cart, List<Product> db)
    {
        Buy buy = new Buy();
        float sum =0;
        Console.WriteLine("".PadLeft(50, '-'));
        Console.WriteLine("Bill");
        Console.WriteLine($"{"Name",-20}|{"Price",-10}|{"Init Price",-20}");
        foreach (Product item in cart)
        {
            sum += item.getPrice();
            float initPrice = db[buy.FindProduct(item.getName(), db)].getPrice();
            Console.WriteLine($"{item.getName(),-20}|{item.getPrice(),-10}|{initPrice,-20}");
        }
        Console.WriteLine("Total: "+sum);
        Console.WriteLine("".PadLeft(50, '-'));
    }
    public void initDB(List<Product> db)
    {
        for (int i = 0; i < db.Capacity; i++)
        {
            Console.WriteLine($"Input Product No.{i + 1}");
            Console.Write("ID: ");
            string id = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            float price = float.Parse(Console.ReadLine());
            db.Add(new Product(id, name, price));
        }
        Console.Clear();
    }
    public void initCoupon(List<Coupon> coupons)
    {
        for (int i = 0; i < coupons.Capacity; i++)
        {
            Console.WriteLine($"Input Coupon No.{i + 1}");
            Console.Write("ID: ");
            string id = Console.ReadLine();
            Console.Write("Decrease: ");
            string input = Console.ReadLine();
            float off;
            switch (input)
            {
                case "10%":
                    off=0.1f;
                    break;
                case "20%":
                    off=0.2f;
                    break;
                case "25%":
                    off=0.25f;
                    break;
                default:
                    off = float.Parse(input);
                    break;
            }
            coupons.Add(new Coupon(id, off));
        }
        Console.Clear();
    }
    public void Buying(List<Product> db, List<Product> cart, List<Coupon> coupons)
    {
        Buy buy = new Buy();
        Display display = new Display();
        while (true)
        {
            display.DisplayProducts(db);
            Console.Write("Wanna Buy: ");
            int index = buy.FindProduct(Console.ReadLine(), db);

            if (index == -1)
                continue;
            else
                buy.AddCart(db[index], cart);
            Console.WriteLine("Press A to Add Coupon\nPress any to continue...");
            if (Console.ReadKey().Key == ConsoleKey.A)
                break;
        }

        buy.AddCoupon(db, cart, coupons);

        Checkout(cart,db);
    }
}
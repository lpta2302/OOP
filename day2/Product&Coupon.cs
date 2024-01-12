public class Product
{
    private string id;
    private string name;
    private float price;
    public Product(string _id = null, string _name = null, float _price = 0)
    {
        id = _id;
        name = _name;
        price = _price;
    }
    public Product(Product product)
    {
        id = product.id;
        name = product.name;
        price = product.price;
    }
    public string getID()
    {
        return id;
    }
    public void setID(string _id)
    {
        id = _id;
    }
    public string getName()
    {
        return name;
    }
    public void setName(string _name)
    {
        name = _name;
    }
    public float getPrice()
    {
        return price;
    }
    public void setPrice(float _price)
    {
        price = _price;
    }
}
public class Coupon
{
    private string id;
    private float off;
    public Coupon(string _id = null, float _off = 0)
    {
        id = _id;
        off = validateOff(_off);
    }

    public string getID()
    {
        return id;
    }
    public void setID(string _id)
    {
        id = _id;
    }
    private float validateOff(float _off)
    {
        return (_off == 0.1f || _off == 0.2f || _off == 0.25f) ? _off : 0.1f;
    }
    public float getOff()
    {
        return off;
    }
    public void setOff(float _off)
    {
        off = validateOff(_off);
    }
}

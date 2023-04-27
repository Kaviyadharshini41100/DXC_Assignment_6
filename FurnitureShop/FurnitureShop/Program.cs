class Furniture
{
    public double Height { get; set; }
    public double Width { get; set; }
    public string Colour { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public Furniture() { }
 
      public virtual void Accept()
     {
        Console.WriteLine("Enter furniture details:");
        Console.WriteLine("Height:");
        Height =double.Parse(Console.ReadLine());
        Console.WriteLine("Width:");
        Width = Convert.ToDouble(Console.ReadLine());
        while(true)
        {
            Console.WriteLine("Colour");
            Colour = Console.ReadLine();
            if(!int.TryParse(Colour, out int result))
            {
                break;
            }
            Console.WriteLine("Invalid Data.Enter Correct Colour..!");
        }
        Console.WriteLine("Quantity");
        Quantity = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Price");
        Price = Convert.ToDouble(Console.ReadLine());
     }
    public virtual void Display()
    {
        Console.WriteLine($"Type of furniture:{this.GetType().Name}");
        Console.WriteLine($"Width:{Width}");
        Console.WriteLine($"Colour:{Colour}");
        Console.WriteLine($"Quantity:{Quantity}");
        Console.WriteLine($"Price:{Price}");
    }
}
class BookShelf : Furniture
{
    public int numofShelves { get; set; }
    public override void Accept()
    {
        base.Accept();
        Console.WriteLine("Number of shelves:");
        numofShelves = int.Parse(Console.ReadLine());
    }
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Number of shelves:{numofShelves}");
    }
}
class DinningTable : Furniture
{
    public int numofLegs { get; set; }
    public override void Accept()
    {
        base.Accept();
        Console.WriteLine("Number of Legs:");
        numofLegs = int.Parse(Console.ReadLine());
    }
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Number of Legs:{numofLegs}");
    }
}
class program
{
    static int AddToStock(Furniture[]stock)
    {
        Console.WriteLine("Adding furniture to stock:");
        int nItem = 0;
        while(nItem<stock.Length)
        {
            Console.WriteLine($"Enter item{nItem + 1}(A for BookShelf,B for Dinning table):");
            string choice = Console.ReadLine();
            switch(choice.ToUpper())
            {
                case "A":
                    stock[nItem] = new BookShelf();
                    break;

                case "B":
                    stock[nItem] = new DinningTable();
                    break;
                default:
                    Console.WriteLine("Invalid choice..Try again");
                    continue;
            }
            stock[nItem].Accept();
            nItem++;

        }
        Console.WriteLine("Stock added successfully");
        return nItem;
    }
    static double TotalStaockvalue(Furniture[]stock)
    {
        double totalvalue = 0;
        foreach(Furniture item in stock)
        {
            totalvalue += item.Quantity * item.Price;
        }
        return totalvalue;
    }
    static void ShowStockdetails(Furniture[]stock)
    {
        Console.WriteLine("Show stock details:");
        foreach(Furniture item in stock)
        {
            item.Display();
        }
    }
    static void Main(string[] args)
    {
        Furniture[] stock = new Furniture[5];
        int nItem = AddToStock(stock);
        ShowStockdetails(stock);
        double totalvalue = TotalStaockvalue(stock);
        Console.WriteLine($"Toatal stock value:INR{totalvalue}");
    }
}


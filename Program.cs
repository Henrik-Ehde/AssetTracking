using AssetTracking;

List<Asset> assets = new List<Asset>()
{
    new Laptop("Asus", "2024-01-15", 500, "Skövde"),
    new Laptop("Macintosh", "2022-05-17", 1000, "Skövde"),
    new Laptop("HP", "01/26/2023", 800, "Brussels"),

    new Phone("Nokia", "23-08-27", 200, "New York"),
    new Laptop("Lenovo", "03/19/2021", 900, "New York")
};

PrintList();

void PrintList()
{
    List<Asset> assetsSorted = assets.OrderBy(a => a.Office).ThenBy(a => a.PurchaseDate).ToList();
    Console.WriteLine("Type".PadRight(16) + "Brand".PadRight(16) + "Office".PadRight(16) + "Purchase Date".PadRight(16) + "Price");
    Console.WriteLine("----".PadRight(16) + "-----".PadRight(16) + "------".PadRight(16) + "-------------".PadRight(16) + "-----");

    foreach (Asset a in assetsSorted)
    {
        string type = a.GetType().Name;
        string pDate = a.PurchaseDate.ToString();
        Console.WriteLine(type.PadRight(16) + a.Brand.PadRight(16) + a.Office.PadRight(16) + pDate.PadRight(16) + a.Price);
    }
}




Console.ReadLine();



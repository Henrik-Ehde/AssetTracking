using AssetTracking;

//Create some offices with their local currency's code and the exchange rate from USD to local currency
Office skövde = new Office("Skövde", "SEK", 10.49);
Office london = new Office("London", "GDP", 0.8);
Office newYork = new Office("New York", "USD", 1.00);


//Create a populated list of assets
List<Asset> assets =
[
    new Laptop("Asus", "2024-01-15", 500, skövde),
    new Laptop("Macintosh", "2022-05-17", 1000, skövde),
    new Laptop("HP", "01/26/2023", 800, london),

    new Phone("Nokia", "23-08-27", 200, newYork),
    new Laptop("Lenovo", "03/19/2021", 900, newYork)
];

//Display the list of assets
PrintList();




void PrintList()
{
    //Prints information about each asset.
    //The assets are sorted by which office they belong to, then by their purchase date

    List<Asset> assetsSorted = assets.OrderBy(a => a.Office.Name).ThenBy(a => a.PurchaseDate).ToList();

    Console.WriteLine("Type".PadRight(16) + "Brand".PadRight(16) + "Office".PadRight(16) + "Purchase Date".PadRight(16)
                        + "Price in USD".PadRight(16) + "Local Currency".PadRight(16) + "Local Price");
    Console.WriteLine("----".PadRight(16) + "-----".PadRight(16) + "------".PadRight(16) + "-------------".PadRight(16)
                        + "------------".PadRight(16) + "--------------".PadRight(16) + "-----------");

    foreach (Asset a in assetsSorted)
    {
        //Get the name of the asset's class in order to display what type of an asset it is
        string type = a.GetType().Name;
        // Calculate the assets price in the local currency of the office it belongs to
        int localPrice = (int)(a.Price * a.Office.ExchangeRate);
        //Calculate the time remaining until the expiration date of the asset.
        TimeSpan timeLeft = DateOnly.FromDateTime(DateTime.Now) - a.ExpirationDate;

        Console.WriteLine(type.PadRight(16) + a.Brand.PadRight(16) + a.Office.Name.PadRight(16) + a.PurchaseDate.ToString().PadRight(16)
                            + a.Price.ToString().PadRight(16) + a.Office.currencyCode.PadRight(16) + localPrice);
    }
}




Console.ReadLine();



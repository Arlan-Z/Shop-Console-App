namespace OnlineStore
{
    interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; }
    }
}

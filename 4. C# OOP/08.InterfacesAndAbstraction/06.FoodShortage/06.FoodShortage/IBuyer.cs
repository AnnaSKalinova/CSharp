namespace FoodShortage
{
    interface IBuyer
    {
        int Food { get; }
        string Name { get; }

        int BuyFood();
    }
}

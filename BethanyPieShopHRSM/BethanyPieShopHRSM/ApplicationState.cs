namespace BethanyPieShopHRSM
{
    public class ApplicationState
    {
        public int NumberOfMessages { get; set; } = new Random().Next(0, 10);
    }
}

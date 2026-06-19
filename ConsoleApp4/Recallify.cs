namespace Recallify
{
    public enum Rating { Easy, Medium, Hard }
    internal class Recallify
    {
        static void Main(string[] args)
        {
            FlashcardManager manager = new FlashcardManager();
            manager.Run();

        }
    }
}

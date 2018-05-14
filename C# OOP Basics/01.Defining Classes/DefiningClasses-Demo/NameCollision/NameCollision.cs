namespace NameCollision
{
    class NameCollision
    {
        static void Main()
        {
            var t = new Transaction();
            t.Initilize(7, 8.52m);
            t.InitilizeFixed(10, 8.2m);
        }
    }
}

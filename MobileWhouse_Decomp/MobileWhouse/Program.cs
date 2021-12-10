namespace MobileWhouse
{
    using System;

    internal static class Program
    {
        [MTAThread]
        private static void Main()
        {
            new ClientApplication().Run();
        }
    }
}


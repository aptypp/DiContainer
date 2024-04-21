namespace DiContainer
{
    internal static class Program
    {
        private static readonly Builder Builder = new Builder();

        private static void Main(
            string[] args)
        {
            Builder.RegisterDependencies(RegisterServices).Build();
        }

        private static void RegisterServices(
            Container container)
        {
            container.Register<A>();
            container.Register<B>();
            container.Register<C>();
        }
    }
}
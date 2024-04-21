namespace DiContainer
{
    public class B
    {
        private readonly A _a;

        public B(
            A a)
        {
            _a = a;
        }

        public void Hello()
        {
            Console.WriteLine("HEllo B");
        }
    }
}
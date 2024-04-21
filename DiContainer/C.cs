namespace DiContainer
{
    public class C : IEntryPoint
    {
        private readonly B _b;
        private readonly A _a;

        public C(
            B b,
            A a)
        {
            _b = b;
            _a = a;
        }

        public void Start()
        {
            _b.Hello();
            _a.Hi();
        }
    }
}
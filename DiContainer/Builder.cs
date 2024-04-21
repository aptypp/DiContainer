namespace DiContainer
{
    public class Builder
    {
        private readonly Container _container = new();

        public Builder RegisterDependencies(
            Action<Container> action)
        {
            action(_container);

            return this;
        }

        public void Build()
        {
            _container.Build();
        }
    }
}
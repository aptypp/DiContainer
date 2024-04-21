namespace DiContainer
{
    public class Container
    {
        private readonly List<Type> _types = [];
        private readonly Dictionary<Type, object> _instances = new();

        public void Register<T>() where T : class
        {
            _types.Add(typeof(T));
        }

        public void Build()
        {
            foreach (var type in _types)
            {
                _instances.Add(
                    type,
                    Resolve(type));
            }

            foreach (var instance in _instances)
            {
                if (instance.Value is IEntryPoint entryPoint)
                {
                    entryPoint.Start();
                    return;
                }
            }
        }

        public object Resolve(
            Type type)
        {
            var typeConstructor = type.GetConstructors()[0];

            var parameters = typeConstructor.GetParameters();

            var dependencies = new object[parameters.Length];

            for (var argumentIndex = 0; argumentIndex < parameters.Length; argumentIndex++)
            {
                var argumentType = parameters[argumentIndex];

                if (!_instances.TryGetValue(
                        argumentType.ParameterType,
                        out var instance))
                {
                    throw new Exception("NO DEPENDENCY FOUND");
                }

                dependencies[argumentIndex] = instance;
            }

            return typeConstructor.Invoke(dependencies);
        }

        public T Resolve<T>() where T : class => (Resolve(typeof(T)) as T)!;
    }
}
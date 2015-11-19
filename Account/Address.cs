namespace Blog.ReactiveReadModels.Account
{
    public class Address
    {
        public Address(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}

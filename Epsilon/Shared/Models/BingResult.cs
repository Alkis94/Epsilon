namespace Epsilon.Shared.Models
{
    public class BingResult
    {
        public string? __Type { get; set; }

        public BingAddress? Address { get; set; }
        public string? Name { get; set; }
    }

    public class Resource
    {
        public List<BingResult>? Value { get; set; }
    }

    public class ResourceSet
    {
        public List<Resource>? Resources { get; set; }
    }

    public class RootObject
    {
        public List<ResourceSet>? ResourceSets { get; set; }
    }
}

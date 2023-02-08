namespace FlightPlanR.Domain.Common.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class MongoCollectionAttribute : Attribute
{
    public string CollectionName { get; set; }

    public MongoCollectionAttribute(string collectionName)
    {
        CollectionName = collectionName;
    }
}
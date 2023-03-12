namespace FlightPlanR.Infrastructure.Common;

public static class AttributeExtensions
{
	public static TCustomAttribute GetAttributeFromClass<TCustomAttribute>(this Type type) where TCustomAttribute : Attribute
	{
		var attribute = (TCustomAttribute) Attribute.GetCustomAttribute(type, typeof(TCustomAttribute));
		if (attribute is null)
			throw new Exception("Attribute not found");

		return attribute;
	}
}
using FlightPlanApi.Common.Exceptions;

namespace FlightPlanApi.Common.Extensions;

public static class AttributeExtensions
{
	public static TCustomAttribute GetAttributeFromClass<TCustomAttribute>(this Type type) where TCustomAttribute : Attribute
	{
		var attribute = (TCustomAttribute) Attribute.GetCustomAttribute(type, typeof(TCustomAttribute));
		if (attribute is null)
			throw new NotFoundException("Attribute not found");

		return attribute;
	}
}
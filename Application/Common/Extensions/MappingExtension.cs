using System.Linq.Expressions;
using AutoMapper;

namespace FlightPlanR.Application.Common.Extensions;

public static class MappingExtension
{
	public static IMappingExpression<TSource, TDestination> IgnoreDestinationMember<TSource, TDestination>(
		this IMappingExpression<TSource, TDestination> mappingExpression,
		Expression<Func<TDestination, object>> selectedMemberExpression)
	{
		mappingExpression.ForMember(selectedMemberExpression, opt => opt.Ignore());
		return mappingExpression;
	}
}
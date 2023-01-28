using FlightPlanApi.Common.Exceptions;
using MongoDB.Driver;

namespace FlightPlanApi.Common.Extensions;

public static class MongoOperationsExceptionExtensions
{
	public static async Task<List<TEntity>> ThrowIfOperationFailed<TEntity>(this Task<List<TEntity>> results)
	{
		var result = await results;
		if (!result.Any())
			throw new NoContentException("No elements.");

		return result;
	} 
	
	public static async Task ThrowIfOperationFailed(this Task<bool> resultTask)
	{
		var result = await resultTask;
		if (!result)
		{
			throw new BadRequestException("Operation failed.");
		}
	} 
	
	public static async Task ThrowIfOperationFailed(this Task<UpdateResult> updateResultTask)
	{
		var result = await updateResultTask;
		if (result is null && result?.MatchedCount == 0 || result?.ModifiedCount == 0)
		{
			throw new NotUpdatedException("No updates or element not found.");
		}
	}
	
	public static async Task ThrowIfOperationFailed(this Task<DeleteResult> deleteResultTask)
	{
		var result = await deleteResultTask;
		if (result.DeletedCount == 0)
		{
			throw new NotFoundException("No document removed.");
		}
	}

	public static async Task<TResult> ThrowIfOperationFailed<TResult>(this Task<TResult> resultTask)
	{
		var result = await resultTask;
		if (result is null)
		{
			throw new NotFoundException("Document not found.");
		}

		return result;
	}
}
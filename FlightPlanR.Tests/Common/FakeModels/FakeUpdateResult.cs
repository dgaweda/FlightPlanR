using MongoDB.Bson;
using MongoDB.Driver;

namespace FlightPlanR.Tests.Common.FakeModels;

public class FakeUpdateResult : UpdateResult
{
	public override bool IsAcknowledged { get; }
	public override bool IsModifiedCountAvailable { get; }
	public override long MatchedCount { get; }
	public override long ModifiedCount { get; }
	public override BsonValue UpsertedId { get; }

	public FakeUpdateResult(long matchedCount, long modifiedCount)
	{
		MatchedCount = matchedCount;
		ModifiedCount = modifiedCount;
	}
}
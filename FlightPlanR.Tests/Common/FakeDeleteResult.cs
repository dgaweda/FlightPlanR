namespace FlightPlanR.Tests.Common;

public class FakeDeleteResult : MongoDB.Driver.DeleteResult
{
	public override long DeletedCount { get; }
	public override bool IsAcknowledged { get; }

	public FakeDeleteResult(long deletedCount, bool isAcknowledged)
	{
		DeletedCount = deletedCount;
		IsAcknowledged = isAcknowledged;
	}
}
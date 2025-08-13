namespace Persistence.Entities;

public class MonthlyFee : IEntity
{
	public int Id { get; set; }
	public string PlateNumber { get; set; }
	public decimal AccumulatedFee { get; set; }
	public DateTime Date { get; set; }
}

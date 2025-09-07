using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts;

public class MonthlyFeeConfiguration : IEntityTypeConfiguration<MonthlyFee>
{
	public void Configure(EntityTypeBuilder<MonthlyFee> builder)
	{
		builder.ToTable("MonthlyFees", t =>
		{
			t.HasCheckConstraint("CK_MonthlyFee_Month", "[Month] >= 1 AND [Month] <= 12");
		});

		builder.HasKey(m => m.Id);

		// Optional: enforce uniqueness
		builder.HasIndex(m => new { m.PlateNumber, m.Year, m.Month }).IsUnique();
	}
}


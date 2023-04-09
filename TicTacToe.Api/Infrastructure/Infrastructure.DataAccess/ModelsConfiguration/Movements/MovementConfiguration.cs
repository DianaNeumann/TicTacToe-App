using Domain.Movements;
using Domain.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.ModelsConfiguration.Movements;

public class MovementConfiguration  : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> builder)
    {
        builder.Property(o => o.Id).ValueGeneratedOnAdd();
    }
}
using Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.ModelsConfiguration.Games;

public class GameStatsConfiguration: IEntityTypeConfiguration<GameStats>
{
    public void Configure(EntityTypeBuilder<GameStats> builder)
    {
        builder.Property(o => o.Id).ValueGeneratedOnAdd();
    }
}
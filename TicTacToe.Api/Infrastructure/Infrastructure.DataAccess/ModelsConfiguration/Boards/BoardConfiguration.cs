using Domain.Boards;
using Domain.Movements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.ModelsConfiguration.Boards;

public class BoardConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.Property(o => o.Id).ValueGeneratedOnAdd();
    }
}
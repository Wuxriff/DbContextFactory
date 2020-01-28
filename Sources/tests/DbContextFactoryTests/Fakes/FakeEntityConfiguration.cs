using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbContextFactoryTests.Fakes
{
    public class FakeEntityConfiguration : IEntityTypeConfiguration<FakeEntity>
    {
        public void Configure(EntityTypeBuilder<FakeEntity> builder)
        {
            builder.ToTable("FakeEntities");
            builder.HasKey(x => x.Id);
        }
    }
}

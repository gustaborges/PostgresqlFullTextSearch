using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreFullTextSearch.Models;

namespace PostgreFullTextSearch.Data.Mapping
{
    public class DocumentMap : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(d => d.DocumentId);
            builder.Property(d => d.DocumentId).HasColumnType("uuid").IsRequired(true);
            builder.Property(d => d.IssueDate).IsRequired(true);

            builder.HasGeneratedTsVectorColumn(
                    tsVectorPropertyExpression: d => d.SearchVector, 
                    config: "portuguese",
                    includeExpression: d => d.Content)
                .HasIndex(d => d.SearchVector)
                .HasMethod("GIN");
        }
    }
}
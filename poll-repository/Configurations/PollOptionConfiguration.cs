using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poll_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_repository.Configurations
{
    internal class PollOptionConfiguration : IEntityTypeConfiguration<PollOption>
    {
        public void Configure(EntityTypeBuilder<PollOption> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Answer).IsRequired().HasMaxLength(50);
            builder.ToTable("PollOptions");
            builder.HasOne(x => x.Poll).WithMany(x => x.Options).HasForeignKey(x => x.PollId);
        }
    }
}

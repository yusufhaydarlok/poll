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
    internal class PollVoteConfiguration : IEntityTypeConfiguration<PollVote>
    {
        public void Configure(EntityTypeBuilder<PollVote> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OptionId).IsRequired().HasMaxLength(50);
            builder.ToTable("PollVotes");
            builder.HasOne(x => x.Poll).WithMany(x => x.Votes).HasForeignKey(x => x.PollId);
            builder.HasOne(x => x.User).WithMany(x => x.PollVotes).HasForeignKey(x => x.UserId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Friends.Domain.Members;

namespace Friends.Persistence.Members
{
    public static class MemberMapper
    {

        public static void Map(ModelBuilder builder)
        {
            #region Members
            builder.Entity<Member>(entity =>
            {
                entity.ToTable("Members");
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Id).IsUnicode(false);
                entity.Property(m => m.Name).IsRequired();
                entity.Property(m => m.Website).IsRequired();
                entity
                    .HasMany(f => f.Friends)
                            .WithOne(m => m.Friend!)
                            .HasForeignKey("FriendId")
                            .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion

            #region MemberFriends

            builder.Entity<MemberFriend>(entity =>
            {
                entity.ToTable("MemberFriends");
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Id).IsUnicode(false);
            });
            #endregion


            #region MemberFriends

            builder.Entity<Heading>(entity =>
            {
                entity.ToTable("Headings");
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Id).IsUnicode(false);
                entity.Property(f => f.Key).IsUnicode(false).HasMaxLength(5);
            });
            #endregion
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BotCommon.Repository;

public sealed class ActiveUsersManager : DefaultDbContext<BotUser>
{
  private DbSet<BotUser> BotUsers { get; set; }

  public override BotUser Get(BotUser user)
  {
    return this.BotUsers.SingleOrDefault(u => u.BotUserId == user.BotUserId);
  }

  public override IEnumerable<BotUser> GetAll()
  {
    return this.BotUsers;
  }

  public override void Add(BotUser user)
  {
    if (this.Get(user) != null)
      return;
    this.BotUsers.Add(user);
    base.Add(user);
  }

  public override void Delete(BotUser user)
  {
    this.BotUsers.Remove(user);
    base.Delete(user);
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite(this._connectionString, builder => builder.MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName,schema: "BotUsers"));
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("BotUsers");
  }

  public ActiveUsersManager(string connectionString) : base(connectionString)
  {
  }
}

public class BotUser
{
  public long BotUserId { get; set; }

  public BotUser()
  {
  }

  public BotUser(long id)
  {
    this.BotUserId = id;
  }
}
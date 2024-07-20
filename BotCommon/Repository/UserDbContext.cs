using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BotCommon.Repository;

/// <summary>
/// 
/// </summary>
public class UserDbContext 
  : DefaultDbContext<BotUser>
{
  public DbSet<BotUser> BotUsers { get; set; }

  public override BotUser Get(BotUser user)
  {
    return this.BotUsers.SingleOrDefault(u => u.Id == user.Id);
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
    optionsBuilder.UseSqlite(this._connectionString);
  }

  public UserDbContext() : this("Filename=app.db")
  {
    
  }
  
  public UserDbContext(string connectionString) : base(connectionString)
  {
  }
}


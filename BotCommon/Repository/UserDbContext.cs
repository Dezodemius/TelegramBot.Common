﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BotCommon.Repository;

/// <summary>
/// DB context for users.
/// </summary>
public class UserDbContext 
  : DefaultDbContext<BotUser>
{
  #region Fields & props

  /// <summary>
  /// Bot users.
  /// </summary>
  public DbSet<BotUser> BotUsers { get; set; }

  #endregion

  #region DefaultDbContext

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

  #endregion

  #region DbContext

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite(this._connectionString);
  }  

  #endregion

  #region Constructors

  /// <summary>
  /// Constructor.
  /// </summary>
  public UserDbContext() 
    : this("Filename=app.db")
  {
    
  }
  
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="connectionString">DB connection string.</param>
  public UserDbContext(string connectionString) 
    : base(connectionString)
  {
  }

  #endregion
}


using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace BotCommon.Broadcast;

/// <summary>
/// Broadcasting message DB context.
/// </summary>
public class BroadcastMessageDbContext 
  : DbContext
{
  #region Fields & props

  /// <summary>
  /// Lock object.
  /// </summary>
  private static readonly object _padlock = new object();
  
  /// <summary>
  /// Lazy object.
  /// </summary>
  private static readonly Lazy<BroadcastMessageDbContext> _lazy = new(() => new BroadcastMessageDbContext());

  private static volatile BroadcastMessageDbContext _instance;

  /// <summary>
  /// Singleton instance.
  /// </summary>
  public static BroadcastMessageDbContext Instance
  {
    get
    {
      if (_instance != null) 
        return _instance;
      lock (_padlock)
      {
        _instance = _instance ?? _lazy.Value;
      }
      return _instance;
    }
  } 

  public DbSet<BroadcastMessageUser> BroadcastMessageUsers { get; set; }

  #endregion

  #region Base

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite("Filename=broadcast.db");
  }

  #endregion

  #region Constructors
  
  public BroadcastMessageDbContext()
  {
    Database.EnsureCreated();

    var creator = this.GetService<IRelationalDatabaseCreator>();
    if (!creator.Exists())
      creator.CreateTables();
  }

  #endregion
}
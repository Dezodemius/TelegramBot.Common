using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace BotCommon.Repository;

/// <summary>
/// Default DB context.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class DefaultDbContext<T> 
  : DbContext
{
  #region Fields & props

  /// <summary>
  /// DB connection string.
  /// </summary>
  protected readonly string _connectionString;

  #endregion

  #region Methods

  /// <summary>
  /// Get entity.
  /// </summary>
  /// <param name="entity">Entity to get.</param>
  /// <returns>Found entity.</returns>
  public abstract T Get(T entity);
  
  /// <summary>
  /// Get all entities.
  /// </summary>
  /// <returns>List of all entities.</returns>
  public abstract IEnumerable<T> GetAll();

  /// <summary>
  /// Add entity.
  /// </summary>
  /// <param name="entity">Entity to add.</param>
  public virtual void Add(T entity)
  {
    this.SaveChangesAsync();
  }

  /// <summary>
  /// Delete entity.
  /// </summary>
  /// <param name="entity">Entity to delete.</param>
  public virtual void Delete(T entity)
  {
    this.SaveChangesAsync();
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
  /// <param name="connectionString">DB connection string.</param>
  public DefaultDbContext(string connectionString)
  {
    this._connectionString = connectionString;
    Database.EnsureCreated();

    var creator = this.GetService<IRelationalDatabaseCreator>();
    if (!creator.Exists())
      creator.CreateTables();
  }

  #endregion
}
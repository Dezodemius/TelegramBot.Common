using System;
using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Types;

namespace BotCommon.Repository;

/// <summary>
/// Telegram bot user.
/// </summary>
public class BotUser
{
    #region Fields & props

    /// <summary>
    /// Telegram user ID.
    /// </summary>
    [Key]
    public long Id { get; set; }
    
    /// <summary>
    /// Telegram username.
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Telegram user first name.
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Telegram user last name.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Telegram user app language.
    /// </summary>
    public string UserLanguage { get; set; }
    
    /// <summary>
    /// Telegram user first meet in bot.
    /// </summary>
    public DateTime FirstMeet { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor.
    /// </summary>
    public BotUser()
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="user">Telegram user.</param>
    public BotUser(User user)
    {
        this.Id = user.Id;
        this.LastName = user.LastName;
        this.FirstName = user.FirstName;
        this.Username= user.Username;
        this.FirstMeet = DateTime.Now;
    }
  
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id">Telegram bot user ID.</param>
    /// <param name="username">Telegram username.</param>
    /// <param name="firstName">Telegram user first name.</param>
    /// <param name="lastName">Telegram user last name.</param>
    /// <param name="userLanguage">Telegram user app language.</param>
    public BotUser(
        long id, 
        string username, 
        string firstName, 
        string lastName, 
        string userLanguage)
    {
        this.Id = id;
        this.Username = username;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.UserLanguage = userLanguage;
        this.FirstMeet = DateTime.Now;
    }

    #endregion
}
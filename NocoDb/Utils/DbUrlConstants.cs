using System;
using JetBrains.Annotations;

namespace NocoDb.Utils;

public class DbUrlConstants
{
    /// <summary>
    /// Template url for getting info from certain database.
    /// </summary>
    /// <param name="baseId"></param>
    /// <returns>Url like: /api/v2/meta/bases/{baseId}/info</returns>
    /// <exception cref="ArgumentNullException">Occurs when the value of baseId is Null or Empty.</exception>
    public static string GetDbInfoUrl([NotNull]string baseId)
    {
        if(string.IsNullOrEmpty(baseId))
            throw new ArgumentNullException(nameof(baseId));
        return $"/api/v2/meta/bases/{baseId}/info";
    }
    
    /// <summary>
    /// Template url for getting list of all databases.
    /// </summary>
    public const string ListBasesUrl = "/api/v2/meta/bases/";
    
    /// <summary>
    /// Template url for creating new database.
    /// </summary>
    public const string CreateBaseUrl = "/api/v2/meta/bases/";
    
    /// <summary>
    /// Template url for getting certain database.
    /// </summary>
    /// <param name="baseId"></param>
    /// <returns>Url like: /api/v2/meta/bases/{baseId}</returns>
    /// <exception cref="ArgumentNullException">Occurs when the value of baseId is Null or Empty.</exception>
    public static string GetSingleDbUrl([NotNull]string baseId)
    {
        if(string.IsNullOrEmpty(baseId))
            throw new ArgumentNullException(nameof(baseId));
        return $"/api/v2/meta/bases/{baseId}";
    }
    
    
    /// <summary>
    /// Template url for delete certain database.
    /// </summary>
    /// <param name="baseId"></param>
    /// <returns>Url like: /api/v2/meta/bases/{baseId}</returns>
    /// <exception cref="ArgumentNullException">Occurs when the value of baseId is Null or Empty.</exception>
    public static string DeleteSingleDbUrl([NotNull]string baseId)
    {
        if(string.IsNullOrEmpty(baseId))
            throw new ArgumentNullException(nameof(baseId));
        return $"/api/v2/meta/bases/{baseId}";
    }
    
    
    /// <summary>
    /// Template url for updating certain database.
    /// </summary>
    /// <param name="baseId"></param>
    /// <returns>Url like: /api/v2/meta/bases/{baseId}</returns>
    /// <exception cref="ArgumentNullException">Occurs when the value of baseId is Null or Empty.</exception>
    public static string UpdateSingleDbUrl([NotNull]string baseId)
    {
        if(string.IsNullOrEmpty(baseId))
            throw new ArgumentNullException(nameof(baseId));
        return $"/api/v2/meta/bases/{baseId}";
    }
    
    /// <summary>
    /// Template url for duplicating certain database.
    /// </summary>
    /// <param name="baseId"></param>
    /// <returns>Url like: /api/v2/meta/duplicate/{baseId}</returns>
    /// <exception cref="ArgumentNullException">Occurs when the value of baseId is Null or Empty.</exception>
    public static string DuplicateSingleDbUrl([NotNull]string baseId)
    {
        if(string.IsNullOrEmpty(baseId))
            throw new ArgumentNullException(nameof(baseId));
        return $"/api/v2/meta/duplicate/{baseId}";
    }
}
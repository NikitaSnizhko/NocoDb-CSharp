using System;
using JetBrains.Annotations;

namespace NocoDb.Utils;

public class TableUrlConstants
{
    /// <summary>
    /// Template url for getting all tables in certain database.
    /// </summary>
    /// <param name="baseId"></param>
    /// <returns>Return Url like: /api/v2/meta/bases/{baseId}/tables</returns>
    /// <exception cref="ArgumentNullException">Occurs when the value of baseId is Null or Empty.</exception>
    public static string GetAllTablesUrl([NotNull]string baseId)
    {
        if (string.IsNullOrEmpty(baseId))
            throw new ArgumentNullException(nameof(baseId));
        return $"/api/v2/meta/bases/{baseId}/tables";
    }
    
    /// <summary>
    /// Template url for creating a table in certain database.
    /// </summary>
    /// <param name="baseId">Return Url like: /api/v2/meta/bases/{baseId}/tables</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Occurs when the value of baseId is Null or Empty.</exception>
    public static string CreateTableUrl([NotNull]string baseId)
    {
        if (string.IsNullOrEmpty(baseId))
            throw new ArgumentNullException(nameof(baseId));
        return $"/api/v2/meta/bases/{baseId}/tables";
    }
}
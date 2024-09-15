namespace NocoDb.Models.Bases;

public enum VisualDbType
{
    Database,
    Documentation,
    Dashboard
}

public class VisualDbTypeHelper
{
    public static string GetVisualDbTypeString(VisualDbType visualDbType)
    {
        switch (visualDbType)
        {
            case VisualDbType.Database:
                return "database";
            case VisualDbType.Documentation:
                return "documentation";
            case VisualDbType.Dashboard:
                return "dashboard";
            default:
                return "dashboard";
        }
    }
}
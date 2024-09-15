namespace NocoDb.Services
{
    public class NocoClientOptions
    {
        public string NocoBaseUrl { get; }
        public string NocoApiKey { get; }

        public NocoClientOptions(string nocoApiKey, string nocoBaseUrl)
        {
            NocoApiKey = ValidateProperty(nocoApiKey);
            NocoBaseUrl = ValidateProperty(nocoBaseUrl);
        }
        
        private static string ValidateProperty(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new System.ArgumentNullException(value);
            return value;
        }
    }
}
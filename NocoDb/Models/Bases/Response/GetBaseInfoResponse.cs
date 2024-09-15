namespace NocoDb.Models.Bases.Response
{
    public class GetBaseInfoResponse
    {
        public string Node { get; set; }
        public string Arch { get; set; }
        public string Platform { get; set; }
        public bool Docker { get; set; }
        public string Database { get; set; }
        public bool ProjectOnRootDB { get; set; }
        public string RootDB { get; set; }
        public string PackageVersion { get; set; }
    }
}
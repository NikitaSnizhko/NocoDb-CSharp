namespace NocoDb.Models.GeneralNocoUtils.Response
{
    public class GetAppInfoResponse
    {
        public string AuthType { get; set; }
        public bool BaseHasAdmin { get; set; }
        public bool FirstUser { get; set; }
        public string Type { get; set; }
        public bool GoogleAuthEnabled { get; set; }
        public bool GithubAuthEnabled { get; set; }
        public bool OneClick { get; set; }
        public bool ConnectToExternalDB { get; set; }
        public string Version { get; set; }
        public int DefaultLimit { get; set; }
        public bool NcMin { get; set; }
        public bool TeleEnabled { get; set; }
        public bool ErrorReportingEnabled { get; set; }
        public bool AuditEnabled { get; set; }
        public string NcSiteUrl { get; set; }
        public bool Ee { get; set; }
        public long NcAttachmentFieldSize { get; set; }
        public int NcMaxAttachmentsAllowed { get; set; }
        public bool IsCloud { get; set; }
        public string AutomationLogLevel { get; set; }
    }
}
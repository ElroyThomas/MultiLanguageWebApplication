using System;

namespace MultiLanguageWebApplication.Model
{
    public class LanguageDetailsModel
    {
        public long languageID { get; set; }
        public string language { get; set; }
        public string ISOCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class LanguageResourceModel
    {
        public string ResourceID { get; set; }
        public string LanguageID { get; set; }
        public string ResourceKey { get; set; }
        public string ResourceValue { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
using System;

namespace MultiLanguageWebApplication.DTO
{
    public class LanguageDetailsDTO
    {
        public long LanguageID { get; set; }
        public string Language { get; set; }
        public string ISOCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class LanguageResourceDTO
    {
        public string ResourceID { get; set; }
        public string LanguageID { get; set; }
        public string ResourceKey { get; set; }
        public string ResourceValue { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
using System;

namespace PostgreFullTextSearch.Models
{
    public class Document
    {
        public Guid DocumentId { get;set; }
        public string Content { get; set; }
        public DateTime IssueDate { get; set; }
        public NpgsqlTypes.NpgsqlTsVector SearchVector { get; set; }

    }
}
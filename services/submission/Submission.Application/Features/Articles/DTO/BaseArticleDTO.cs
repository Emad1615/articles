using Articles.Abstractions.Enums;

namespace Submission.Application.Features.Articles.DTO
{
    public class BaseArticleDTO
    {
        public required string Title { get; set; }
        public ArticleType Type { get; set; }
        public required string Scope { get; set; }
        public int JournalId { get; set; }
        public int Stage { get; set; }  
    }
}

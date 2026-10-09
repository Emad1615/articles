using Submission.Application.Features.Articles.Commands;
using Submission.Application.Features.Articles.DTO;

namespace Submission.Application.Features.Articles.Validators
{
    public class CreateArticleValidator:BaseArticleValidator<CreateArticle.Command, CreateArticleDTO>
    {
        public CreateArticleValidator():base(x=>x.createArticleDTO)
        {
            
        }
    }
}

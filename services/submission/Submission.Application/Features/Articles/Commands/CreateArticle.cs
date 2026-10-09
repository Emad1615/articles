using Articles.Abstractions;
using Articles.Abstractions.Enums;
using MediatR;
using Submission.Application.Features.Articles.DTO;

namespace Submission.Application.Features.Articles.Commands
{
    public class CreateArticle
    {
        public record Command : IRequest<IdResponse>
        {
            public CreateArticleDTO createArticleDTO { get; set; }
        }

        public class Handler : IRequestHandler<Command, IdResponse>
        {
            public Task<IdResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
     
}

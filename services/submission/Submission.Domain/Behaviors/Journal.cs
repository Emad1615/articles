using Articles.Abstractions.Enums;

namespace Submission.Domain.Entities
{
    public partial class Journal
    {

        public Article CreateArticle(string title, string scope, ArticleType type)
        {

            var article = new Article
            {
                Title = title,
                Scope = scope,
                Type = type,
                Stage = ArticleStage.Created,
                Journal = this
            };

            _articles.Add(article);

            //todo -  add domain event later

            return article;
        }
    }
}

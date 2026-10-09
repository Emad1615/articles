namespace Submission.Domain.Entities
{
    public partial class Journal
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Abbreviation { get; set; }

        private readonly List<Article> _articles = new();

        public IReadOnlyList<Article> Articles => _articles.AsReadOnly();

    }
}

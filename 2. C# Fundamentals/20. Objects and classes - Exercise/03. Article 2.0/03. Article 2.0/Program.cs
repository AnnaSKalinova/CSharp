using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Article_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfArticles = int.Parse(Console.ReadLine());
            var articles = new List<Article>();

            for (int i = 0; i < numOfArticles; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string title = input[0];
                string content = input[1];
                string author = input[2];

                var currentArticle = new Article(title, content, author);

                articles.Add(currentArticle);
            }

            string orderCommand = Console.ReadLine();

            switch (orderCommand)
            {
                case "title":
                    articles = articles.OrderBy(x => x.Title).ToList();
                    break;
                case "content":
                    articles = articles.OrderBy(x => x.Content).ToList();
                    break;
                case "author":
                    articles = articles.OrderBy(x => x.Author).ToList();
                    break;
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}"; 
        }
    }
}

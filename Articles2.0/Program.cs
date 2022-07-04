using System;
using System.Collections.Generic;

namespace Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            CatalogArticles catalog = new CatalogArticles();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article article = new Article(input[0], input[1], input[2]);

                catalog.Articles.Add(article);
            }

            string title = Console.ReadLine();

            foreach (var article in catalog.Articles)
            {
                article.Print();
            }
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Title} - {Content}: {Author}");
        }
    }

    class CatalogArticles
    {
        public CatalogArticles()
        {
            this.Articles = new List<Article>();
        }

        public List<Article> Articles { get; set; }
    }
}

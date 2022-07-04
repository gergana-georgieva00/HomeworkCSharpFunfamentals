using System;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int n = int.Parse(Console.ReadLine());

            Article article = new Article(input[0], input[1], input[2]);

            string command;
            for (int i = 0; i < n; i++)
            {
                command = Console.ReadLine();
                string[] splitCom = command.Split(": ");

                if (command.Contains("Edit"))
                {
                    article.Edit(splitCom[1]);
                }
                else if (command.Contains("ChangeAuthor"))
                {
                    article.ChangeAutor(splitCom[1]);
                }
                else
                {
                    article.Rename(splitCom[1]);
                }
            }

            article.Print();
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

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAutor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public void Print()
        {
            Console.WriteLine($"{Title} - {Content}: {Author}");
        }
    }
}

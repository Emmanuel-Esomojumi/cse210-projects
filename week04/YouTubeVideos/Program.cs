using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C#", "Code Academy", 600);
        video1.AddComment(new Comment("Alice", "Very helpful video!"));
        video1.AddComment(new Comment("Bob", "Clear explanation."));
        video1.AddComment(new Comment("Charlie", "Thanks for this."));
        videos.Add(video1);

        Video video2 = new Video("OOP Basics", "Tech World", 450);
        video2.AddComment(new Comment("Daniel", "Nice examples."));
        video2.AddComment(new Comment("Ella", "I understand better now."));
        video2.AddComment(new Comment("Frank", "Well done."));
        videos.Add(video2);

        Video video3 = new Video("Abstraction in C#", "LearnFast", 520);
        video3.AddComment(new Comment("Grace", "Straight to the point."));
        video3.AddComment(new Comment("Henry", "Good teaching."));
        video3.AddComment(new Comment("Ivy", "Very informative."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
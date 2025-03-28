using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Wholesome Giggles: DIY Rainbow Slime Adventure", "Ella Grace", 3.45);
        video1.AddComment(new Comment("Ella", "I can't stop giggling! This is the happiest video ever!"));
        video1.AddComment(new Comment("Jack", "Woah, that was super cool! I wanna try it too!"));
        video1.AddComment(new Comment("Lily", "This is like magic! You're amazing!"));
        videos.Add(video1);

        Video video2 = new Video("Super Cool Trick Shots in the Backyard!", "Jack Mason", 5.12);
        video2.AddComment(new Comment("Henry", "Haha, that part made me laugh so hard! Awesome job!"));
        video2.AddComment(new Comment("Emily", "This video is so fun, I could watch it forever!"));
        video2.AddComment(new Comment("Owen", "You're a genius! How did you think of this?"));
        video2.AddComment(new Comment("Robert", "I can't wait to see your next video!"));
        videos.Add(video2);

        Video video3 = new Video("A Magical Mini Adventure with Sparkling Lights!", "Zoe Harper", 4.20);
        video3.AddComment(new Comment("Grace", "This made my day so much brighter! You're the best!"));
        video3.AddComment(new Comment("Sam", "I showed this to my friends, and they loved it too!"));
        video3.AddComment(new Comment("Zoe", "This is like a little adventure. So exciting!"));
        video3.AddComment(new Comment("Dianne", "I wasn't expecting the last part. It was fun!"));
        video3.AddComment(new Comment("Michael", "It was magical! I'm still in awe!"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine(video.GetInfo());
            Console.WriteLine($"The video has {video.GetNumberOfComments()} comments:");

            foreach (Comment comment in video.GetAllComments())
            {
                Console.WriteLine($" * {comment.GetInfo()}");
            }
        }

        Console.WriteLine();
    }
}

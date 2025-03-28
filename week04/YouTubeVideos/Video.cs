using System;

public class Video
{
    private string _title;
    private string _author;
    private double _length;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, double length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public string GetInfo()
    {
        return $"\nVideo Title: \"{_title}\"\nUploaded By: {_author}\nVideo Length: {_length} minutes";
    }

    public List<Comment> GetAllComments()
    {
        return _comments;
    }
}

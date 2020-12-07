namespace blogBack.DB
{
    public interface IPost
    {
        int PostId { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string TimeStamp { get; set; }
        int BlogId { get; set; }
    }
}
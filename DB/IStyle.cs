namespace blogBack.DB
{
    public interface IStyle
    {
        int StyleId { get; set; }
        string StyleBody { get; set; }
        int DataId { get; set; }
        int ImageId { get; set; }
        int TextId { get; set; }
        int PostId { get; set; }
    }
}
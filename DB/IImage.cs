namespace blogBack.DB
{
    public interface IImage
    {
        int ImageId { get; set; }
        string OriginalFormat { get; set; }
        byte[] ImageImage { get; set; }
    }
}
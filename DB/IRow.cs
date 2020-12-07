namespace blogBack.DB
{
    public interface IRow
    {
        int RowId { get; set; }
        int PostId { get; set; }
    }
}
using LinqToDB.Mapping;

namespace blogBack.DB
{
    public interface IData
    {
        int DataId { get; set; }
        int RowId { get; set; }
        int TextId { get; set; }
        int ImageId { get; set; }
    }
}
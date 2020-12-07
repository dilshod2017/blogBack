using System.Collections.Generic;
using blogBack.DB;

namespace blogBack.UIEntities
{
    public class RowUI : IRow
    {
        public int RowId { get; set; }
        public int PostId { get; set; }
        public IEnumerable<IData> DataList { get; set; }
    }

    public class DataUI : IData
    {
        public int DataId { get; set; }
        public int RowId { get; set; }
        public int TextId { get; set; }
        public int ImageId { get; set; }
        public IEnumerable<IText> TextList { get; set; }
        public IEnumerable<Image> ImageList { get; set; }
    }
}
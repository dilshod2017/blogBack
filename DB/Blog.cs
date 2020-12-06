using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace blogBack.DB
{
    public class Style
    {
        [PrimaryKey, Identity] 
        public int StyleId { get; set; }
        public string StyleBody { get; set; }
        public int DataId { get; set; }
        public int ImageId { get; set; }
        public int TextId { get; set; }
        public int PostId { get; set; }
    }    
    public class Text
    {
        [PrimaryKey, Identity] 
        public int TextId { get; set; }
        public string TextBody { get; set; }
    }
    public class Image
    {
        [PrimaryKey, Identity]
        public int ImageId { get; set; }
        public string OriginalFormat { get; set; }
        public byte[] ImageImage { get; set; }
    }
    public class Data
    {
        [PrimaryKey, Identity]
        public int DataId { get; set; }
        public int PostId { get; set; }
        public int TextId { get; set; }
        public int ImageId { get; set; }
 
    }
 
    public class Post
    {
        [PrimaryKey, Identity]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string TimeStamp { get; set; }
        public int BlogId { get; set; }
    }
    public class Blog
    {
        [PrimaryKey, Identity]
        public int BlogId { get; set; }
        public string BlogName { get; set; }
    }
}

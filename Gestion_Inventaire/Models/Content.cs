using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsVideo { get; set; }
        public string FilePath { get; set; }
        public List<Display>? Displays { get; set; }
        public Content() { }
        public Content(int id, string description, bool isVideo, string filePath)
        {
            Id = id;
            Description = description;
            IsVideo = isVideo;
            FilePath = filePath;
            Displays = new List<Display>();
        }
    }
}

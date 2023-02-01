using System.ComponentModel.DataAnnotations;

namespace Lab8_.Models {
    [Serializable]
    public class ClothesModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Cost { get; set; }
    }
}

using System.Xml.Serialization;

namespace Lab8_.Models {
    [Serializable]
    public class ClothesCollectionModel
    {
        [XmlArray("Collection"), XmlArrayItem("Item")]
        public List<ClothesModel> Collection { get; set; }
        public ClothesCollectionModel() {
            Collection = new List<ClothesModel>();
        }
        public ClothesCollectionModel(List<ClothesModel> collection) {
            Collection = collection;
        }
    }
}

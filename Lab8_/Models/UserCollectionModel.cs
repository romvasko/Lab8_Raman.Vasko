using System.Xml.Serialization;

namespace Lab8_.Models {
    [Serializable]
    public class UserCollectionModel {
        [XmlArray("Collection"), XmlArrayItem("Item")]
        public List<UserModel> Collection { get; set; }
        public UserCollectionModel() {
            Collection = new List<UserModel>();
        }
        public UserCollectionModel(List<UserModel> collection) {
            Collection = collection;
        }
    }
}

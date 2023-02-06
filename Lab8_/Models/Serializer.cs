using System.Xml.Serialization;

namespace Lab8_.Models {
    public class Serializer<T> {
        public static T GetCollection(T obj, string path) {

            XmlSerializer xmlser = new XmlSerializer(typeof(T));
            using (Stream serialStream = new FileStream(path, FileMode.Open)) {

                obj = (T)xmlser.Deserialize(serialStream);
            }
            return obj;
        }
        public static T WriteToFile(T obj, string path) {
            XmlSerializer xmlser = new XmlSerializer(typeof(T));

            using (Stream serialStream = new FileStream(path, FileMode.Create)) {
                xmlser.Serialize(serialStream, obj);
            }
            return obj;
        }
            
}
    }


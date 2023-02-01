using Lab8_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace Lab8_.Controllers {
    public class ShopController : Controller {

        public IActionResult AddForm() {
            return View();
        }
        public IActionResult Index() {
            ViewBag.result = "hi";
            return View();
        }
        public IActionResult AddClothes(string name, string type, string cost) {
            
            XmlSerializer xmlser = new XmlSerializer(typeof(ClothesCollectionModel));


            ClothesCollectionModel model = new ClothesCollectionModel();
            using (Stream serialStream = new FileStream("../Shop.xml", FileMode.Open))
            {

                model = (ClothesCollectionModel)xmlser.Deserialize(serialStream);
            }
            var item = new ClothesModel()
            {
                Name = name,
                Cost = cost,
                Type = type,
            };
            model.Collection.Add(item);
            using (Stream serialStream = new FileStream("../Shop.xml", FileMode.Create))
            {
                xmlser.Serialize(serialStream, model);
            }
            ViewBag.result = "added";
            return View("Index");
        }
        public IActionResult GetAllClothes() {

            XmlSerializer xmlser = new XmlSerializer(typeof(ClothesCollectionModel));
            ClothesCollectionModel model = new ClothesCollectionModel();
            using (Stream serialStream = new FileStream("../Shop.xml", FileMode.Open)) {

                model = (ClothesCollectionModel)xmlser.Deserialize(serialStream);
            }
           
            return View(model.Collection);
        }
    }
}

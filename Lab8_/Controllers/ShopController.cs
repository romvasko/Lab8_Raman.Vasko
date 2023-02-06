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
        public IActionResult AddClothes(int id ,string name, string type, string cost) {
            
            ClothesCollectionModel model = new ClothesCollectionModel();
            model = Serializer<ClothesCollectionModel>.GetCollection(model, "../Shop.xml");

            
            var item = new ClothesModel()
            {
                Id = id,
                Name = name,
                Cost = cost,
                Type = type,
            };
            model.Collection.Add(item);
            Serializer<ClothesCollectionModel>.WriteToFile(model, "../Shop.xml");
            ViewBag.result = "added";
            return View("Index");
        }
        public IActionResult GetAllClothes() {

            ClothesCollectionModel model = new ClothesCollectionModel();
            model = Serializer<ClothesCollectionModel>.GetCollection(model, "../Shop.xml");

            return View(model.Collection);
        }
        public IActionResult Show(int id) {

            ClothesCollectionModel model = new ClothesCollectionModel();
            model = Serializer<ClothesCollectionModel>.GetCollection(model, "../Shop.xml");
            try {
            return View(model.Collection.First(x => x.Id == id));
            }
            catch {
                ViewBag.result = "not found";
                return View("Index");
            }
        }
        public IActionResult Delete(int id) {
            
            ClothesCollectionModel model = new ClothesCollectionModel();
            model = Serializer<ClothesCollectionModel>.GetCollection(model, "../Shop.xml");
            bool temp = model.Collection.Remove(model.Collection.First(x => x.Id == id));
            Serializer<ClothesCollectionModel>.WriteToFile(model, "../Shop.xml");

            if (temp) {
                ViewBag.result = "deleted";
                return View("Index");
            }
            else {
                ViewBag.result = "not found";
                return View("Index");
            }

        }
    }
}

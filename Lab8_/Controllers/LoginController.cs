using Lab8_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace Lab8_.Controllers {
    public class LoginController : Controller {

        public IActionResult Registration() {
            return View();
        }
        public IActionResult Index() {
            ViewBag.result = "hi";
            return View();
        }
        public IActionResult Register(string name, int age, string mail, string pass, string confPass) {
            if (pass!=confPass) {
                ViewBag.result = "confirm password not equal";
                return View();
            }
            XmlSerializer xmlser = new XmlSerializer(typeof(UserCollectionModel));
            UserCollectionModel model = new UserCollectionModel();
            using (Stream serialStream = new FileStream("../UserS.xml", FileMode.Open)) {

                 model = (UserCollectionModel)xmlser.Deserialize(serialStream);
            }
            var user = new UserModel() {
                Name = name,
                Email = mail,
                Age = age,
                Password = pass,
                ConfirmPassword = confPass,
            };
            model.Collection.Add(user);
            using (Stream serialStream = new FileStream("../UserS.xml", FileMode.Create)) {
                xmlser.Serialize(serialStream, model);
            }
            ViewBag.result = "added";
            return View("Index");
        }
        public IActionResult GetAllUsers() {

            XmlSerializer xmlser = new XmlSerializer(typeof(UserCollectionModel));
            UserCollectionModel model = new UserCollectionModel();
            using (Stream serialStream = new FileStream("../UserS.xml", FileMode.Open)) {

                model = (UserCollectionModel)xmlser.Deserialize(serialStream);
            }
           
            return View(model.Collection);
        }
    }
}

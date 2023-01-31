using System.ComponentModel.DataAnnotations;

namespace Lab8_.Models {
    [Serializable]
    public class UserModel {
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}

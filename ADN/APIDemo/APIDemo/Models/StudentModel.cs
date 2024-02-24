namespace APIDemo.Models
{
    public class StudentModel
    {
       public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentStandred { get; set; }
        public string StudentFatherName { get; set; }




        public string ProductName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int Price { get; set; }

        public int Discount { get; set; }

        public int StockCount { get; set; }
    }
}

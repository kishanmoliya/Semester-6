namespace Task_Management_System.DAL
{
    public class DAL_Helper
    {
        public static string ConnString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("connString");
    }
}

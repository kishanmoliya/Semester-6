namespace Task_Management_System.BAL
{
    public static class CommonVariables 
    {
        public static IHttpContextAccessor _httpContextAccessor;

        static CommonVariables()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        public static int? UserID()
        {
            if (_httpContextAccessor.HttpContext.Session.GetInt32("UserID") != null)
            {
                return _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            }
            return null;
        }
        public static string? UserName()
        {
            if (_httpContextAccessor.HttpContext?.Session.GetString("UserName") != null)
            {
                return _httpContextAccessor.HttpContext.Session.GetString("UserName")?.ToString();
            }
            return null;
        }

        public static string? Email()
        {
            if (_httpContextAccessor.HttpContext?.Session.GetString("Email") != null)
            {
                return _httpContextAccessor.HttpContext.Session.GetString("Email")?.ToString();
            }
            return null;
        }

        public static bool IsAdmin()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("IsAdmin") != null)
            {
                return Convert.ToBoolean(_httpContextAccessor.HttpContext.Session.GetString("IsAdmin").ToString());
            }
            return false;
        }

        public static int ProjectID;
        public static int TaskID;
        public static string Error;
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Demo_project.Controllers
{
    public class PageController1 : Controller
    {
        private readonly IConfiguration configuration;
        public PageController1(IConfiguration config)
        {
            this.configuration=config;

        }
        public IActionResult Firstpage()
        {
            string connectionstring = configuration.GetConnectionString("DefaultConnectionString");
            SqlConnection connection=new(connectionstring);
            
            SqlCommand com=new SqlCommand("select count(*) from Tb_application");

            connection.Open();
            var count = (int)com.ExecuteScalar();
            ViewData["TotalData"] = count;



            connection.Close();


            return View();
        }
    }
}


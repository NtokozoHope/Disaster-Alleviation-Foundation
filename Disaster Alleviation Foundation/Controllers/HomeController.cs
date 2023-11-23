using Disaster_Alleviation_Foundation.Models;
using Disaster_Alleviation_Foundation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using NuGet.Packaging.Signing;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Alleviation_Foundation.Controllers
{
    public class HomeController : Controller
    {
        public string connectionString = "Server=tcp:mserver10.database.windows.net,1433;Initial Catalog=Disaster Alleviation;Persist Security Info=False;User ID=admin1;Password=Nopass87*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private readonly ILogger<HomeController> _logger;
        private readonly DAFContext _context;

        public HomeController(ILogger<HomeController> logger, DAFContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users users)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO Users (name, Password,Email) VALUES (@name, @Password, @Email)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", users.name);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Users Users)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE name = @name AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", Users.name);
                cmd.Parameters.AddWithValue("@Password", Users.Password);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    // Successful login, redirect to a dashboard or another page
                    return RedirectToAction("Index");
                }
                else
                {
                    // Invalid login, return to the login page with an error message
                    ModelState.AddModelError(string.Empty, "Invalid credentials");
                    return View("LogIn");
                }
            }
        }
        [HttpGet]
        public IActionResult GoodsDonation() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult GoodsDonation(GoodsDonation goodsDonation)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO GoodsDonation (Donor, Date, Number_Of_Items, Category, Description) VALUES (@Donor, @Date, @Number_Of_Items, @Category, @Description)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Donor", goodsDonation.Donor);
            cmd.Parameters.AddWithValue("@Date", goodsDonation.Date);
            cmd.Parameters.AddWithValue("@Number_Of_Items", goodsDonation.Number_Of_Items);
            cmd.Parameters.AddWithValue("@Category", goodsDonation.Category);
            cmd.Parameters.AddWithValue("@Description", goodsDonation.Description);
            cmd.ExecuteNonQuery();
            conn.Close();

            return View("Index");
        }

        [HttpGet]
        public IActionResult GoodsDonationList()
        {
            var goods = _context.GoodsDonation.ToList();

            return View(goods);
        }

        [HttpGet]
        public IActionResult MonetaryDonation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MonetaryDonation(MonetaryDonation monetaryDonation)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO MonetaryDonation (Donor, Date, Amount) VALUES (@Donor, @Date, @Amount)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Donor", monetaryDonation.Donor);
            cmd.Parameters.AddWithValue("@Date", monetaryDonation.Date);
            cmd.Parameters.AddWithValue("@Amount", monetaryDonation.Amount);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View("Index");
        }

        [HttpGet]
        public IActionResult MonetaryDonationList()
        {
            var monetary = _context.MonetaryDonation.ToList();

            return View(monetary);
        }

        [HttpGet]
        public IActionResult Disaster()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Disaster(Disaster disaster)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO Disaster (StartDate, EndDate, Location, Description, AidType, IsDisaster) VALUES (@StartDate, @EndDate, @Location, @Description, @AidType, @IsDisaster)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StartDate", disaster.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", disaster.EndDate);
            cmd.Parameters.AddWithValue("@Location", disaster.Location);
            cmd.Parameters.AddWithValue("@Description", disaster.Description);
            cmd.Parameters.AddWithValue("@AidType", disaster.AidType);
            cmd.Parameters.AddWithValue("@IsDisaster", disaster.IsDisaster);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View("Index");
        }

        [HttpGet]
        public IActionResult DisasterList()
        {
            var Disaster = _context.Disaster.ToList();
            return View(Disaster);
        }

        [HttpGet]
        public IActionResult Categories()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Categories(Categories category)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO Categories (Name) VALUES (@Name)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", category.Name);
            cmd.ExecuteNonQuery();
            conn.Close();


            return View();
        }

        [HttpGet]
        public IActionResult Allocation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Allocation(MoneyAllocations allocations)
        {

            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO MoneyAllocations (Amount ) VALUES (@Amount )";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Amount", allocations.Amount);

            cmd.ExecuteNonQuery();
            conn.Close();

            return View("Index");
        }

        [HttpGet]
        public IActionResult AllocateGoods()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllocationSuccess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AllocateGoods(GoodsAllocation goods)
            {
                if (ModelState.IsValid)
                {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();

                            string sql = "INSERT INTO GoodsAllocation (Description, Quantity) " +
                                         "VALUES (@Description, @Quantity)";

                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@Description", goods.Description);
                                cmd.Parameters.AddWithValue("@Quantity", goods.Quantity);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        
                        return RedirectToAction("AllocationSuccess");
                    
                }

                return View(goods);
            }

        [HttpGet]
        public IActionResult CapturePurchase()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CapturePurchase(capturePurchase capturePurchase)
        {
            decimal avaMoney = CulAvaMoney();

            if (capturePurchase.Amount > avaMoney)
            {
                return RedirectToAction("AllocationSuccess");
            }

            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO CapturePurchase (Category, Amount) VALUES (@Category, @Amount)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Category", capturePurchase.Category);
            cmd.Parameters.AddWithValue("@Amount", capturePurchase.Amount);
            cmd.ExecuteNonQuery();
            conn.Close();

            UpdateAvaMoney(avaMoney - capturePurchase.Amount);
            decimal update = avaMoney- capturePurchase.Amount;
            ViewBag.UpdateAvaMoney = update;

            return View("Index");

            decimal CulAvaMoney()
            {
                decimal AvaMoney = 10000;


                return AvaMoney;
            }

        }

        private void UpdateAvaMoney(decimal newMoney)
        {

        }

        public async Task<IActionResult> InfoView()
        {
            var model = new Information();

            decimal totalMonetaryDonations = await _context.MonetaryDonation.SumAsync(d => d.Amount);
            model.TotalMonetary = (int)totalMonetaryDonations; 

            
            model.TotalGoods = await _context.GoodsAllocation.SumAsync(d => d.Quantity);

            model.IsDisaster = await _context.Disaster
                    .Where(d => d.IsDisaster)
                    .ToListAsync();

            return View(model);
        }

    }
}
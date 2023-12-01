
using applicationTP1.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using System.Xml.Linq;

namespace applicationTP1.Controllers
{
	public class MovieController : Controller
	{
		private readonly Customermovieviewmodel viewModel;

		public MovieController()
		{
			viewModel = new Customermovieviewmodel();
			viewModel.movie = new Movie { Id = 1, Name = "Galaxy" };
			viewModel.customers = new List<Customer>
			{
				new Customer { Id = 1, Name = "Farah" },
				new Customer { Id = 2, Name = "Nour" }
			};
		}
		//routage par attribut
		[Route("Movie/Index")]
		public IActionResult Index()
		{
			Movie movie = new Movie()
			{
				Name = "movie 0"
			};
			List<Movie> movies = new List<Movie>()
			{
			  new Movie{Name="movie 1"},
			  new Movie{Name="movie 2"},
			 };
			return View(movies);
		}

		public IActionResult Edit(int id)
		{
			return Content("TestID" + id);
		}
		public IActionResult ByRelease(int annee,int mois)
		{
            return Content($"Année : {annee}, Mois : {mois}");
        }

		public IActionResult movieclient()
		{
			
			return View(viewModel);
		}
		public IActionResult CustomerDetails(int? id )
		{
			if(id==0 || id==null)
			{
				return NotFound();
			}
			var customer = viewModel.customers.FirstOrDefault(x => x.Id == id);
			if(customer== null)
			{
				return NotFound();
			}

			var customerViewModel = new Customermovieviewmodel
			{
				customers = new List<Customer> { customer }
			};

			return View(customerViewModel);
		}
	}
}

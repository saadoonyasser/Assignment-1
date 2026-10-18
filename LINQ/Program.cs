using LINQ.DataSources;
using static LINQ.DataSources.Source;
namespace LINQ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Q1
			var q1 = Source.ProductList.Where(p => p.Category == "Seafood");

			foreach (var p in q1)
				Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

			// Q2
			var q2 = Source.ProductList.Select(p => p.ProductName);
			foreach (var name in q2)
				Console.WriteLine(name);

			// Q3
			var q3 = Source.ProductList.OrderBy(p => p.UnitPrice);
			foreach (var p in q3)
				Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

			// q4
			var q4 = Source.ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
			foreach (var p in q4)
				Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

			// Q 5
			var q5 = Source.ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
			foreach (var p in q5)
				Console.WriteLine(p.ProductName);

			// q6
			var q6 = Source.ProductList.Select(p => new
			{
				Name = p.ProductName,
				Price = p.UnitPrice,
				StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
			});

			foreach (var p in q6)
			{
				Console.WriteLine($"{p.Name} | {p.Price} | {p.StockStatus}");
			}

			// Q7
			var q7 = Source.ProductList.Select((p, index) => new
			{
				Position = index + 1,
				Name = p.ProductName
			});

			foreach (var p in q7)
				Console.WriteLine($"{p.Position}. {p.Name}");

			// Q8
			var q8 = Source.ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

			foreach (var p in q8)
			{
				Console.WriteLine($"{p.Category} | {p.ProductName} | {p.UnitPrice}");
			}

			// Q9
			var q9 = Source.ProductList.Where(p => p.Category == "Beverages").OrderByDescending(p => p.UnitsInStock);

			foreach (var p in q9)
			{ Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}"); }

			// Q10
			var q10 =
				from c in Source.CustomerList
				from o in c.Orders
				where o.OrderDate.Year >= 1997
				select new
				{
					c.CustomerID,
					o.OrderDate
				};

			foreach (var order in q10)
			{
				Console.WriteLine($"{order.CustomerID} - {order.OrderDate:d}");
			}


		}
	}
}

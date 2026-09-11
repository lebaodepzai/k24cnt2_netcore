using lgblesson06Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace lgblesson06Lab.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var hotProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/noi-com-dien.svg", Price = 1200000 },
                new Product { Id = 2, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/noi-com-dien.svg", Price = 1200000 },
                new Product { Id = 3, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/noi-com-dien.svg", Price = 1200000 }
            };

            return View(hotProducts);
        }
    }
}

using HelloWorld.Models;
using System.Collections.Generic;
using System.Web.Caching;
using System.Web.UI;
using System.Web;

namespace HelloWorld
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }

    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products
        {
            get
            {
                // Check if the MyProducts is NOT cached
                if (HttpContext.Current.Cache["MyProducts"] == null)
                {
                    var items = new[]
                    {
                    new Product{ Name = "Baseball"},
                    new Product{ Name="Football"},
                    new Product{ Name="Tennis ball"} ,
                    new Product{ Name="Golf ball"},
                };

                    //HttpContext.Current.Cache.Insert("MyProducts",
                    //                         items,
                    //                         null,
                    //                         System.DateTime.Now.AddSeconds(30),
                    //                         Cache.NoSlidingExpiration);

                    HttpContext.Current.Cache.Insert("MyProducts",
                                             items,
                                             null,
                                             Cache.NoAbsoluteExpiration, new System.TimeSpan(0, 0, 5));

                }

                return (IEnumerable<Product>)HttpContext.Current.Cache["MyProducts"];
            }
        }
    }
}
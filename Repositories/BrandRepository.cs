using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Web_API_DB_First_Demo.Models;

namespace Web_API_DB_First_Demo.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly BikeStoresContext _context;
        public BrandRepository()
        {
            _context = new BikeStoresContext();
        }
        public Brand AddNewBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return brand;
        }

        public string DeleteBrand(int id)
        {
            Brand brand = _context.Brands.Where(b => b.BrandId == id).FirstOrDefault();
            string result = null;
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                _context.SaveChanges();
                result = "Brand Removed from DB";
            }
            else
                result = " Given Brand does not exist";
            return result;
        }

        public Brand FindBrandById(int id)
        {
           Brand brand= _context.Brands.Where(b => b.BrandId==id).FirstOrDefault();
            if(brand != null)
            {
                return
                    brand;  
            }
            else
            {
                return brand = null;
            }
        }

        public List<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }

        public Brand UpdateBrand(Brand brand)
        {
           Brand brandtoupdate=_context.Brands.Where(b => b.BrandId== brand.BrandId).FirstOrDefault();
            if (brandtoupdate != null)
            {
                brandtoupdate.BrandName = brand.BrandName;
            }
            _context.Entry(brandtoupdate).State = EntityState.Modified;
             _context.SaveChanges();
           
            return brand;
        }
    }
}

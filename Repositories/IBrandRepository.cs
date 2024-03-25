using Web_API_DB_First_Demo.Models;

namespace Web_API_DB_First_Demo.Repositories
{
    public interface IBrandRepository
    {
        List<Brand> GetAllBrands();
        Brand FindBrandById(int id);
        Brand AddNewBrand(Brand brand);
        Brand UpdateBrand(Brand brand);
        String DeleteBrand(int brandid);
    }
}

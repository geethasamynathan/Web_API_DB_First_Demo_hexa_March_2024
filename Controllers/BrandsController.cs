using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_DB_First_Demo.Models;
using Web_API_DB_First_Demo.Repositories;

namespace Web_API_DB_First_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _repository;

        public BrandsController(IBrandRepository repository)
        {
          _repository = repository;
        }

        // GET: api/Brands
        [HttpGet]
        public  ActionResult<IEnumerable<Brand>> GetBrands()
        {
            return  _repository.GetAllBrands();
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public ActionResult<Brand> GetBrand(int id)
        {
            Brand brand = _repository.FindBrandById(id);

            if (brand == null)
            {
                return NotFound();
            }

            //else
            //    brand = null;
            return brand;
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, Brand brand)
        {
            if (id != brand.BrandId)
            {
                return BadRequest();
            }
            _repository.UpdateBrand(brand);
           // _context.Entry(brand).State = EntityState.Modified;
            return NoContent();
        }

        // POST: api/Brands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            _repository.AddNewBrand(brand);
            return CreatedAtAction("GetBrand", new { id = brand.BrandId }, brand);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public ActionResult DeleteBrand(int id)
        {
            var brand =  _repository.DeleteBrand(id);
            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        //private bool BrandExists(int id)
        //{
        //    return _repository.FindBrandById(id);
        //}
    }
}

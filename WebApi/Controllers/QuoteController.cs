using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.dbcontext;
using WebApi.Migrations;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly AppDbContext apppDbContext;
        public QuoteController(AppDbContext appDbContext)
        { 
            this.apppDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetQuote()
        { 
            var Quotes = await apppDbContext.Quotes.ToListAsync();
            return Ok (Quotes);
        } 

        [HttpPost]
        public async Task<IActionResult> CreateQuote(Employee quo)
        {
            quo.Id = new Guid();
            await apppDbContext.Quotes.AddAsync(quo);
            await apppDbContext.SaveChangesAsync();
            return Ok(quo);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateQuote([FromRoute] Guid id,[FromBody] Employee quo)
        {
            var quote = await apppDbContext.Quotes.FirstOrDefaultAsync(a => a.Id == id);

            if (quote != null) 
            {
                quote.Author = quo.Author;
                quote.Tags = quo.Tags;
                quote.QuoteText = quo.QuoteText;
                await apppDbContext.SaveChangesAsync();

                return Ok(quo);
            }
            else
            {
                return NotFound("Quote not found");
                    
                    
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteQuote([FromRoute] Guid id)
        {
            var quote = await apppDbContext.Quotes.FirstOrDefaultAsync(a => a.Id == id);

            if (quote != null)
            {
                apppDbContext.Quotes.Remove(quote);
                await apppDbContext.SaveChangesAsync();

                return Ok(quote);
            }
            else
            {
                return NotFound("Quote not found");


            }
        }
    }
}

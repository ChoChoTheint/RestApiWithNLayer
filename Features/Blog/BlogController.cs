
namespace RestApiWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _bl_blog;

        public BlogController() 
            {
                 _bl_blog = new BL_Blog();
            }
        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogModel> list = _bl_blog.GetBlogs();
            return Ok(list);
        }
    
        [HttpGet("{id}")]
        public IActionResult GetBlogs(int id)
        {
            BlogModel? item = _bl_blog.GetBlog(id);
            if (item == null)
            {
                return NotFound("Data not found");
            }
            return Ok(item);
        }
    
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            int result = _bl_blog.CreateBlog(blog);
            string message = result > 0 ? "Saving success" : "Saving fail";
            return Ok(message);
        }
    
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog)
        {
            var item = _bl_blog.GetBlog(id);
            if (item == null)
            {
                Console.WriteLine("No data found");
                return NotFound();
            }
        
            var result = _bl_blog.UpdateBlog(id,blog);
            string message = result > 0 ? "Saving success" : "Saving fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = _bl_blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
       
            int result = _bl_blog.DeleteBlog(id);
            string message = result > 0 ? "Saving success" : "Saving fail";
            return Ok(message);


        }
    }
}

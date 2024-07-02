namespace RestApiWithNLayer.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _content;
        public DA_Blog()
        {
            _content = new AppDbContext();
        }
        public List<BlogModel> GetBlogs() 
        {
            var list = _content.Blogs.ToList();
            return list;
        }
        public BlogModel GetBlog(int id) 
        {
            var item = _content.Blogs.FirstOrDefault(x => x.BlogId == id);
            return item;
        }
        public int CreateBlog(BlogModel requestModel)
        {
            _content.Blogs.Add(requestModel);
            var result = _content.SaveChanges();
            return result;
        }
        public int UpdateBlog(int id, BlogModel requestModel) 
        { 
            var item = _content.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;

            var result = _content.SaveChanges();
            return result;

        }
        public int DeleteBlog(int id) 
        {
            var item = _content.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            _content.Blogs.Remove(item);
            var result = _content.SaveChanges();
            return result;
        }
    }
}

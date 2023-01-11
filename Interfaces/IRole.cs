namespace Blog.Interfaces
{
    public interface IRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}

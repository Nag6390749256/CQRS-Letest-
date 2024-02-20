using MediatR;

namespace Application.Services.Book
{
    public class BookCommand:IRequest<object>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class BookQuery : IRequest<IEnumerable<BookCommand>>
    {
        public int Id { get; set; }
    }
}

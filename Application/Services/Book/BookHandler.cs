using MediatR;
using Persistence.Context;
using System.Data;

namespace Application.Services.Book
{
    public class BookHandler : IRequestHandler<BookCommand, object>, IRequestHandler<BookQuery, IEnumerable<BookCommand>>
    {
        private readonly IDapperContext _dapperContext;
        public BookHandler(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<object> Handle(BookCommand request, CancellationToken cancellationToken)
        {
            var response = await _dapperContext.ExceProcAsync<object>("Proc_AddUpdateBook", request, CommandType.StoredProcedure);
            return response;
        }

        public async Task<IEnumerable<BookCommand>> Handle(BookQuery request, CancellationToken cancellationToken)
        {
            var response = await _dapperContext.GetListAsync<BookCommand>("Select * from Books WHERE Id = IIF(@Id = 0,Id,@Id)", request, CommandType.Text);
            return response;
        }
    }
}

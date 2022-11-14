using DTO;

namespace Blazor_Client.Services.IServices
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBookList();
        Task<BookDto> GetBookById(int id);
    }
}

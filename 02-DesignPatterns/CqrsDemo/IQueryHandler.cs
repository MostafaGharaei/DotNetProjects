using System.Threading.Tasks;

namespace CqrsDemo;

public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    Task<TResponse> Handle(TQuery query);
}
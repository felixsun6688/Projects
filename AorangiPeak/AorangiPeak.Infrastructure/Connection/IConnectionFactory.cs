using System.Data;

namespace AorangiPeak.Infrastructure.Connection
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}

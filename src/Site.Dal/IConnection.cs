using System;
using System.Data.SqlClient;
namespace Site.Dal
{
    public interface IConnection:IDisposable
    {
        SqlConnection Connect { get; }
        SqlConnection Open();
        void Close();
        SqlCommand CreateCommand();
    }
}

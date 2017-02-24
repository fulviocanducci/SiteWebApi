using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Site.Dal
{
    public class DalBrand : IDalBrand
    {
        private IConnection _connection;
        public DalBrand(IConnection connection)
        {
            _connection = connection;            
        }
        public Brand Insert(Brand value)
        {
            using (SqlCommand _command = _connection.CreateCommand())
            {
                _command.CommandText = "INSERT INTO Brand(Description) VALUES(@Description);SELECT @@IDENTITY;";
                _command.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = value.Description;
                int id = 0;
                if (int.TryParse(_command.ExecuteScalar().ToString(), out id))
                {
                    value.Id = id;
                }
            }
            return value;
        }

        public bool Edit(Brand value)
        {
            bool ret = false;
            using (SqlCommand _command = _connection.CreateCommand())
            {
                _command.CommandText = "UPDATE Brand SET Description=@Description WHERE Id=@Id";
                _command.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = value.Description;
                _command.Parameters.Add("@Id", SqlDbType.Int).Value = value.Id;
                 ret = _command.ExecuteNonQuery() > 0;
            }
            return ret;
        }

        public Brand Find(object id)
        {
            Brand brand = null;
            using (SqlCommand _command = _connection.CreateCommand())
            {
                _command.CommandText = "SELECT Id, Description FROM Brand WHERE Id=@Id";
                _command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        brand = new Brand(reader.GetInt32(0), reader.GetString(1));                        
                    }
                }
            }
            return brand;
        }

        public bool Delete(object id)
        {
            bool ret = false;
            using (SqlCommand _command = _connection.CreateCommand())
            {
                _command.CommandText = "DELETE FROM Brand WHERE Id=@Id";
                _command.Parameters.Add("@Id", SqlDbType.Int).Value = (int)id;
                ret = _command.ExecuteNonQuery() > 0;
            }
            return ret;
        }

        public bool Delete(Brand value)
        {
            return Delete(value.Id);
        }

        public IEnumerable<Brand> List()
        {            
            using (SqlCommand _command = _connection.CreateCommand())
            {
                _command.CommandText = "SELECT Id, Description FROM Brand ORDER BY Id";                
                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            yield return new Brand(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }        
    }
}

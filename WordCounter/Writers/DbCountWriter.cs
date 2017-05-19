using System;
using System.Data.SqlClient;


namespace WordCounter.Writers
{
    public class DbCountWriter : ICountWriter
    {
        private readonly string ConnectionString;

        public DbCountWriter(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void WriteCount(long count)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sqlExpression = String.Format("INSERT INTO RESULT(WORD_COUNT) VALUES ({0});", count);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                var m = command.ExecuteNonQuery();
                Console.WriteLine(String.Format("{0} row(s) result was inserted into DB", m));
            }
        }
    }
}

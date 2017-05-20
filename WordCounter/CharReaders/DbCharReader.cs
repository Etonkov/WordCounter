using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WordCounter.CharReaders
{
    public class DbCharReader : ICharReader
    {
        private const int BufferSize = 10000;
        private readonly SqlConnection Connection;
        private readonly SqlCommand Command;
        private readonly SqlDataReader SqlReader;
        private readonly TextReader DbTextReader;

        public DbCharReader(string connectionString)
        {
            Console.WriteLine("DB reading is initialized...");
            IsFinished = false;
            Connection = new SqlConnection(connectionString);
            Connection.Open();
            Command = new SqlCommand("SELECT [TEXT_FIELD] FROM [TEXT_DATA] WHERE ID=1", Connection);
            SqlReader = Command.ExecuteReader(CommandBehavior.SequentialAccess);
            SqlReader.Read();

            if (SqlReader.IsDBNull(0))
            {
                IsFinished = true;
                SqlReader.Close();
                Command.Dispose();
                Connection.Close();
            }
            else
            {
                DbTextReader = SqlReader.GetTextReader(0);
            }
        }

        public bool IsFinished { get; private set; }

        public char[] ReadChars()
        {
#if DEBUG
            if (IsFinished)
            {
                throw new InvalidOperationException();
            }
#endif
            var buffer = new char[BufferSize];

            if (DbTextReader.Read(buffer, 0, BufferSize) <= 0)
            {
                IsFinished = true;
            }

            return buffer;
        }

        public void Dispose()
        {
            DbTextReader.Close();
            SqlReader.Close();
            Command.Dispose();
            Connection.Close();
        }
    }
}

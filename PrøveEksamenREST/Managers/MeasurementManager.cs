using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;

namespace PrøveEksamenREST.Managers
{
    public class MeasurementManager
    {
        private string DBstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProeveDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private string GET_ALL;
        private string GET_ONE;
        private string INSERT;
        private string DELETE;

        public MeasurementManager(bool testMode)
        {
            string tableName = testMode ? "TestMeasurement" : "Measurement";

            GET_ALL = $"select * from {tableName}";
            GET_ONE = $"select * from {tableName} where id = @Id";
            INSERT = $"insert into {tableName} (id,pressure,humidity,temperature,timestamp) values (@Id,@Pressure,@Humidity,@Temperature,@Timestamp)";
            DELETE = $"delete from {tableName} where id = @Id";
        }

        public List<Measurement> GetAll()
        {
            List<Measurement> list = new List<Measurement>();
            using (SqlConnection conn = new SqlConnection(DBstring))
            using (SqlCommand cmd = new SqlCommand(GET_ALL, conn))
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Measurement mes = ReadNextElement(reader);
                    list.Add(mes);
                }
                reader.Close();
            }

            return list;
        }
        private Measurement ReadNextElement(SqlDataReader reader)
        {
            Measurement meas = new Measurement();

            meas.Id = reader.GetInt32(0);
            meas.Pressure = reader.GetInt32(1);
            meas.Humidity = reader.GetInt32(2);
            meas.Temperature = reader.GetInt32(3);
            meas.Timestamp = reader.GetDateTime(4);
            return meas;
        }

        public Measurement GetOne(int id)
        {
            Measurement mes = null;
            using (SqlConnection conn = new SqlConnection(DBstring))
            using (SqlCommand cmd = new SqlCommand(GET_ONE,conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    mes = ReadNextElement(reader);
                }
                reader.Close();
            }

            return mes;
        }

        public bool AddMeasurement(Measurement measurement)
        {
            using (SqlConnection conn = new SqlConnection(DBstring))
            using (SqlCommand cmd = new SqlCommand(INSERT, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Id", measurement.Id);
                cmd.Parameters.AddWithValue("@Pressure", measurement.Pressure);
                cmd.Parameters.AddWithValue("@Humidity", measurement.Humidity);
                cmd.Parameters.AddWithValue("@Temperature", measurement.Temperature);
                cmd.Parameters.AddWithValue("@Timestamp", measurement.Timestamp);

                int noOfRowsAffected = cmd.ExecuteNonQuery();
                bool ok = noOfRowsAffected == 1;

                conn.Close();
                return ok;
            }
        }

        public bool DeleteMeasurement(int id)
        {
            using (SqlConnection conn = new SqlConnection(DBstring))
            using (SqlCommand cmd = new SqlCommand(DELETE,conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Id", id);
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                bool ok = noOfRowsAffected == 1;

                conn.Close();

                return ok;
            }
                
            
        }
    }
}

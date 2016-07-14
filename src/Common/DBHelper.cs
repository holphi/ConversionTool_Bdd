using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

using System.Reflection;

using DAX2.DTT.Convertion.Test.Entities;


namespace DAX2.DTT.Convertion.Test.Common
{
    public class DBHelper
    {
        private static SqlCeConnection conn;
        private static string dax2_db_path;

        //Get connection instance;
        public static SqlCeConnection GetConnection()
        {
            if (conn == null) {
                string connStr = String.Format("Data Source={0};Persist Security Info=False;Password=d01byX2Win", dax2_db_path);
                conn = new SqlCeConnection(connStr);
                try
                {
                    conn.Open();
                }
                catch (Exception ex) {
                    throw ex;
                }
            }

            return conn;
        }

        public static void SetDBFilePath(string file_path)
        {
            dax2_db_path = file_path;
        }

        public static List<Device_Endpoint> GetDeviceEndpoint(string device_id)
        {
            List<Device_Endpoint> ret = new List<Device_Endpoint>();

            try
            {
                SqlCeCommand command = new SqlCeCommand(String.Format("SELECT * FROM Device_Endpoints WHERE Device_ID={0}", device_id),
                                                        GetConnection());
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Device_Endpoint device_edp = new Device_Endpoint();

                    foreach (PropertyInfo pi in typeof(Device_Endpoint).GetProperties())
                    {
                        pi.SetValue(device_edp, reader[pi.Name].ToString());
                    }

                    ret.Add(device_edp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public static List<Device_Info> GetDeviceInfo(string device_id)
        {
            List<Device_Info> ret = new List<Device_Info>();

            try
            {
                SqlCeCommand command = new SqlCeCommand(String.Format("SELECT * FROM Device_Info WHERE Device_ID={0}", device_id),
                                                        GetConnection());
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Device_Info device_info = new Device_Info();

                    foreach (PropertyInfo pi in typeof(Device_Info).GetProperties())
                    {
                        pi.SetValue(device_info, reader[pi.Name].ToString());
                    }

                    ret.Add(device_info);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public static List<Device_Info> GetDeviceInfo()
        {
            List<Device_Info> ret = new List<Device_Info>();

            try
            {
                SqlCeCommand command = new SqlCeCommand("SELECT * FROM Device_Info", GetConnection());
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Device_Info device_info = new Device_Info();

                    foreach (PropertyInfo pi in typeof(Device_Info).GetProperties())
                    {
                        pi.SetValue(device_info, reader[pi.Name].ToString());
                    }

                    ret.Add(device_info);
                }
            }catch (Exception ex) {
                throw ex;
            }

            return ret;
        }

        public static List<Device_Endpoint> GetDeviceEndpoint()
        {
            List<Device_Endpoint> ret = new List<Device_Endpoint>();

            try
            {
                SqlCeCommand command = new SqlCeCommand("SELECT * FROM Device_Endpoints", GetConnection());
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Device_Endpoint device_endpoint = new Device_Endpoint();

                    foreach (PropertyInfo pi in typeof(Device_Endpoint).GetProperties())
                    {
                        pi.SetValue(device_endpoint, reader[pi.Name].ToString());
                    }

                    ret.Add(device_endpoint);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public static List<Profile_Tuning> GetProfileTuning(string device_id)
        {
            List<Profile_Tuning> ret = new List<Profile_Tuning>();

            try
            {
                SqlCeCommand command = new SqlCeCommand(String.Format("SELECT * FROM Profile_Tuning WHERE Device_ID={0}", device_id),
                                                        GetConnection());
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Profile_Tuning profile_tuning = new Profile_Tuning();

                    foreach (PropertyInfo pi in typeof(Profile_Tuning).GetProperties())
                    {
                        pi.SetValue(profile_tuning, reader[pi.Name].ToString());
                    }

                    ret.Add(profile_tuning);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public static List<Device_Tuning> GetDeviceTuning()
        {
            List<Device_Tuning> ret = new List<Device_Tuning>();

            try
            {
                SqlCeCommand command = new SqlCeCommand("SELECT * FROM Device_Tuning", GetConnection());
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Device_Tuning device_tuning = new Device_Tuning();

                    foreach (PropertyInfo pi in typeof(Device_Tuning).GetProperties())
                    {
                        pi.SetValue(device_tuning, reader[pi.Name].ToString());
                    }

                    ret.Add(device_tuning);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public static List<Profile_EndpointType> GetProfileEdpType(string device_id)
        {
            List<Profile_EndpointType> ret = new List<Profile_EndpointType>();

            try
            {
                SqlCeCommand command = new SqlCeCommand(String.Format("SELECT * FROM Profile_EndpointType WHERE Device_ID={0}", device_id),
                                                        GetConnection());
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Profile_EndpointType profile_edptype = new Profile_EndpointType();

                    foreach (PropertyInfo pi in typeof(Profile_EndpointType).GetProperties())
                    {
                        pi.SetValue(profile_edptype, reader[pi.Name].ToString());
                    }
                    ret.Add(profile_edptype);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public static List<Profile_EndpointPort> GetProfileEdpPort(string device_id)
        {
            List<Profile_EndpointPort> ret = new List<Profile_EndpointPort>();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT Device_ID, Profile, Endpoint_Port,");
                sb.Append("\"volume-leveler-in-target\" AS volume_leveler_in_target,");
                sb.Append("\"volume-leveler-out-target\" AS volume_leveler_out_target ");
                sb.Append("FROM Profile_EndpointPort ");
                sb.Append(String.Format("WHERE Device_ID={0}", device_id));

                SqlCeCommand command = new SqlCeCommand(sb.ToString(), GetConnection());
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Profile_EndpointPort profile_edpport = new Profile_EndpointPort();

                    foreach (PropertyInfo pi in typeof(Profile_EndpointPort).GetProperties())
                    {
                        pi.SetValue(profile_edpport, reader[pi.Name].ToString());
                    }
                    ret.Add(profile_edpport);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public static List<GEQ_Band> GetGEQBand(string device_id)
        {
            List<GEQ_Band> ret = new List<GEQ_Band>();

            try
            {
                SqlCeCommand command = new SqlCeCommand(String.Format("SELECT * FROM GEQ_Bands WHERE Device_ID={0}", device_id),
                                                        GetConnection());
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GEQ_Band geq_band = new GEQ_Band();
                    foreach (PropertyInfo pi in typeof(GEQ_Band).GetProperties())
                    {
                        pi.SetValue(geq_band, reader[pi.Name].ToString());
                    }
                    ret.Add(geq_band);
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }

        public static List<IEQ_Band> GetIEQBand(string device_id)
        {
            List<IEQ_Band> ret = new List<IEQ_Band>();

            try
            {
                SqlCeCommand command = new SqlCeCommand(String.Format("SELECT * FROM IEQ_Bands WHERE Device_ID={0}", device_id),
                                                        GetConnection());
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    IEQ_Band ieq_band = new IEQ_Band();
                    foreach (PropertyInfo pi in typeof(IEQ_Band).GetProperties()){
                        pi.SetValue(ieq_band, reader[pi.Name].ToString());
                    }
                    ret.Add(ieq_band);
                }
            }catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public static string GetDeviceID(string system_id)
        {
            try
            {
                SqlCeCommand command = new SqlCeCommand(String.Format("SELECT * FROM Device_Info WHERE System_ID='{0}'", system_id),
                                                        GetConnection());
                return command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ResetDB()
        {
            try
            {
                SqlCeCommand command = new SqlCeCommand("DELETE FROM Device_Info WHERE System_ID NOT IN ('default_hdac', 'default_hdac_core', 'default_dsp')", 
                                                        GetConnection());
                
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BackupDB(string DB_filename)
        {
            string BackupDB_filename = DB_filename + @".bak";
            try
            {
                System.IO.File.Copy(DB_filename, BackupDB_filename,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RestoreDB()
        {
            string BackupDB_filename = dax2_db_path + @".bak";
            try
            {
                System.IO.File.Copy(BackupDB_filename, dax2_db_path,true);
                System.IO.File.Delete(BackupDB_filename);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Device_Tuning> GetDeviceTuning(string device_id)
        {
            List<Device_Tuning> ret = new List<Device_Tuning>();

            try
            {
                SqlCeCommand command = new SqlCeCommand(String.Format("SELECT * FROM Device_Tuning WHERE Device_ID={0}", device_id),
                                                        GetConnection());
                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Device_Tuning device_tuning = new Device_Tuning();
                    foreach (PropertyInfo pi in typeof(Device_Tuning).GetProperties())
                    {
                        pi.SetValue(device_tuning, reader[pi.Name].ToString());
                    }
                    ret.Add(device_tuning);
                }
            } catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public static void CloseDBConnection()
        {
            try
            {   if (conn != null)
                {
                    conn.Close();
                    conn = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

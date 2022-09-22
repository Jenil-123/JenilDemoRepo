using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssGCollection
{
    internal class PatientDB
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        public PatientDB()
        {
            string conStr = "server=.;database=PD;user id=sa;pwd = Sarkarbrand";
            con = new SqlConnection(conStr);
        }

        public int GenerateID()
        {
            string cmdStr = "select max(pid) from Patient";
            cmd = new SqlCommand(cmdStr, con);
            int genid = 0;
            try
            {
                con.Open();
                object data = cmd.ExecuteScalar();
                if (data.ToString().Equals(""))
                {
                    genid = 1;
                }
                else
                {
                    genid = Convert.ToInt32(data) + 1;
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return genid;
        }

        public void AddPatient(Patient p)
        {
            string insStr = $"insert into Patient values ({p.PID},'{p.PNAME}','{p.PMOBILENO}','{p.PGENDER}','{p.PWEIGHT}','{p.PHEIGHT}','{p.PDEASES}')";
            cmd = new SqlCommand(insStr, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                throw se;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public bool UpdatePatient(int pid, Patient p)
        {
            string updStr = $"update Patient set cname='{p.PNAME}','{p.PMOBILENO}','{p.PGENDER}','{p.PWEIGHT}','{p.PHEIGHT}','{p.PDEASES}' where pid = {pid}";
            cmd = new SqlCommand(updStr, con);
            try
            {
                con.Open();
                int rEffected = cmd.ExecuteNonQuery();
                if (rEffected == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public bool DeletePatient(int pid)
        {
            string delStr = $"delete from Patient where cid = {pid}";
            cmd = new SqlCommand(delStr, con);
            try
            {
                con.Open();
                int rEffected = cmd.ExecuteNonQuery();
                if (rEffected == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public Patient FindPatirnt(int pid)
        {
            string finStr = $"select * from Patient where cid = {pid}";
            cmd = new SqlCommand(finStr, con);
            SqlDataReader dr = null;
            Patient cr = null;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    cr = new Patient
                    {
                        PID = dr.GetInt32(0),
                        PNAME = dr.GetString(1),
                        PMOBILENO = dr.GetString(2),
                        PGENDER = (Gen)dr.GetInt32(3),
                        PWEIGHT = (UInt32)dr.GetInt32(4),
                        PHEIGHT = dr.GetString(5),
                        PDEASES = dr.GetString(6)
                        
                    };
                    return cr;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public List<Patient> GetCustomers()
        {
            List<Patient> clst = new List<Patient>();
            string allStr = $"select * from Patient";
            cmd = new SqlCommand(allStr, con);
            SqlDataReader dr = null;
            Patient cr = null;
            try
            {
                con.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        cr = new Patient
                        {
                            PID = dr.GetInt32(0),
                            PNAME = dr.GetString(1),
                            PMOBILENO = dr.GetString(2),
                            PGENDER = (Gen)dr.GetInt32(3),
                            PWEIGHT = (UInt32)dr.GetInt32(4),
                            PHEIGHT = dr.GetString(5),
                            PDEASES = dr.GetString(6)
                        };
                        clst.Add(cr);
                    }
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return clst;
        }
    }
}

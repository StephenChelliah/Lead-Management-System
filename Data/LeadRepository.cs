using Lead_Management_System.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Data.Common;

namespace Lead_Management_System.Data
{
    public class LeadRepository
    {
        private SqlConnection conobj;
        public LeadRepository()
        {
             String ConnectionString="Data Source=LAPTOP-TIQIBM6G;Initial Catalog=LeadsManagement;User ID=sa;Password=99391226;Trusted_connection=True;TrustServerCertificate=True;";
            conobj = new SqlConnection(ConnectionString);
        }

        public List<LeadsEntity> GetallLeads()
        {
            List<LeadsEntity> allleads= new List<LeadsEntity>();
            SqlCommand cmd = new SqlCommand("GetallLeads", conobj);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter adapter= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                allleads.Add(new LeadsEntity
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    LeadDate = Convert.ToDateTime(dr["LeadDate"]),
                    LeadName = Convert.ToString(dr["LeadName"]),
                    EmailAddress = Convert.ToString(dr["EmailAddress"]),
                    Mobile = Convert.ToString(dr["Mobile"]),
                    LeadSource = Convert.ToString(dr["LeadSource"]),
                    LeadStatus = Convert.ToString(dr["LeadStatus"]),
                    NextFollowUpdate = Convert.ToDateTime(dr["NextFollowUpdate"])
                }
                              );
            }


            return allleads;

        }


        public bool AddLead(LeadsEntity lead)
        {
            SqlCommand cmd = new SqlCommand("AddLead", conobj);
            cmd.CommandType= System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", lead.Id);
            cmd.Parameters.AddWithValue("@LeadDate", lead.LeadDate);
            cmd.Parameters.AddWithValue("@LeadName", lead.LeadName);
            cmd.Parameters.AddWithValue("@EmailAddress", lead.EmailAddress);
            cmd.Parameters.AddWithValue("@Mobile", lead.Mobile);
            cmd.Parameters.AddWithValue("@LeadSource", lead.LeadSource);
            cmd.Parameters.AddWithValue("@LeadStatus", lead.LeadStatus);
            cmd.Parameters.AddWithValue("@NextFollowUpdate", lead.NextFollowUpdate);
            
            conobj.Open();
            int i=cmd.ExecuteNonQuery();
            conobj.Close();

            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public LeadsEntity GetaSingleLeadbyId(int Id) 
        {
            LeadsEntity lead=new LeadsEntity();
            SqlCommand cmd = new SqlCommand("GetLeadDetailsbyId", conobj);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param;
            cmd.Parameters.Add(new SqlParameter("Id",Id));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            adapter.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                lead.Id = Convert.ToInt32(dr["Id"]);
                lead.LeadDate = Convert.ToDateTime(dr["LeadDate"]);
                lead.LeadName = Convert.ToString(dr["LeadName"]);
                lead.EmailAddress = Convert.ToString(dr["EmailAddress"]);
                lead.Mobile = Convert.ToString(dr["Mobile"]);
                lead.LeadSource = Convert.ToString(dr["LeadSource"]);
                lead.LeadStatus = Convert.ToString(dr["LeadStatus"]);
                lead.NextFollowUpdate = Convert.ToDateTime(dr["NextFollowUpdate"]);
            }

            return lead;
        }


        public bool UpdateLead(int Id,LeadsEntity Updatedlead)
        {

            SqlCommand cmd = new SqlCommand("UpdateLead", conobj);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",Id);
            cmd.Parameters.AddWithValue("@LeadDate", Updatedlead.LeadDate);
            cmd.Parameters.AddWithValue("@LeadName", Updatedlead.LeadName);
            cmd.Parameters.AddWithValue("@EmailAddress", Updatedlead.EmailAddress);
            cmd.Parameters.AddWithValue("@Mobile", Updatedlead.Mobile);
            cmd.Parameters.AddWithValue("@LeadSource", Updatedlead.LeadSource);
            cmd.Parameters.AddWithValue("@LeadStatus", Updatedlead.LeadStatus);
            cmd.Parameters.AddWithValue("@NextFollowUpdate", Updatedlead.NextFollowUpdate);

            conobj.Open();
            int i = cmd.ExecuteNonQuery();
            conobj.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

         public void DeleteLead(int Id) 
         {
            
                SqlCommand cmd = new SqlCommand("DeleteLead", conobj);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",Id);
                conobj.Open();
               cmd.ExecuteNonQuery();
                conobj.Close();
                
            
            
        }




    }
}

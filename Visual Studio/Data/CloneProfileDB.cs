using CardsAgainstHumanityClone.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Data
{
    public class CloneProfileDB : IProfileDAL
    {
        private SqlConnection con = new SqlConnection("Data Source=userprofiles.database.windows.net;Initial Catalog=UserProfiles;User ID=admin1;Password=AdminPowers321");
        //private List<Profile> profiles = new List<Profile>();

        public bool AddProfile(Profile newProfile, out string errorMessage)
        {

            SqlCommand cmd = new SqlCommand($"insert into UsersTable(Id,Username,Password,Email) values('{newProfile.Id}','{newProfile.UserName}','{newProfile.Password}','{newProfile.Email}')", con);
            cmd.CommandType = CommandType.Text;
            bool isSuccessful = true;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                errorMessage = "Data inserted successfully";
                con.Close();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                isSuccessful = false;
            }
            return isSuccessful;
        }

        public bool DeleteProfileById(int id, out string errorMessage)
        {

            SqlCommand cmd = new SqlCommand($"delete from UsersTable where id = {id}", con);
            cmd.CommandType = CommandType.Text;
            bool isSuccessful = true;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                errorMessage = "Data inserted successfully";
                con.Close();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                isSuccessful = false;
            }
            return isSuccessful;
        }

        public IEnumerable<Profile> GetCollection()
        {
            List<Profile> profiles = new List<Profile>();
            SqlCommand cmd = new SqlCommand($"select * from UsersTable", con);
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        profiles.Add(new Profile(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(0)));
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
            }
            return profiles;
        }

        public bool CheckIfReturningUser(Profile profile)
        {
            bool returningUser = false;
            SqlCommand cmd = new SqlCommand($"select * from UsersTable where Username = '{profile.UserName}' and Password = '{profile.Password}'", con);
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    returningUser = reader.GetString(1).Trim().ToLower() == profile.UserName.ToLower() && reader.GetString(2).Trim() == profile.Password;
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
            }
            return returningUser;
        }
    }
}

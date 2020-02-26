using CardsAgainstHumanityClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Data
{
    public class CloneProfileDB : IProfileDAL
    {
        private static List<Profile> profiles = new List<Profile>();

        public bool AddProfile(Profile newProfile, out string errorMessage)
        {
            bool isSuccessful = true;
            errorMessage = "";
            foreach(Profile profile in profiles)
            {
                if(profile.UserName == newProfile.UserName)
                {
                    errorMessage = "User with that username already exists.";
                    isSuccessful = false;
                    return isSuccessful;
                }
                if (profile.Email == newProfile.Email)
                {
                    errorMessage = "User with that email already exists.";
                    isSuccessful = false;
                    return isSuccessful;
                }
            }
            profiles.Add(newProfile);
            errorMessage = "Profile created successfully";
            return isSuccessful;
        }

        public void DeleteProfileByIndex(int index)
        {
            profiles.RemoveAt(index);
        }
        public void DeleteProfileById(int id)
        {
            profiles.RemoveAt(profiles.IndexOf(profiles.Where(e => e.Id == id).FirstOrDefault()));
        }

        public IEnumerable<Profile> GetCollection()
        {
            return profiles;
        }

        public IEnumerable<Profile> SearchForProfile(string userName)
        {
            return profiles.Where(x => x.UserName == userName);
        }
    }
}

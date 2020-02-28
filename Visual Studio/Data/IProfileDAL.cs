using CardsAgainstHumanityClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Data
{
    public interface IProfileDAL
    {
        IEnumerable<Profile> GetCollection();
        bool CheckIfReturningUser(Profile profile);
        bool AddProfile(Profile newProfile, out string errorMessage);
        bool DeleteProfileById(int id, out string errorMessage);
    }
}

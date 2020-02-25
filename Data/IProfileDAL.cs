using CardsAgainstHumanityClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Data
{
    interface IProfileDAL
    {
        IEnumerable<Profile> GetCollection();
        IEnumerable<Profile> SearchForProfile(string username);
        bool AddProfile(Profile newProfile, out string errorMessage);
        void DeleteProfile(int index);
    }
}

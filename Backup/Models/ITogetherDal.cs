
using RoadBetterTogether.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadBetterTogether.Models
{
    public interface ITogetherDal : IDisposable
    {
        int ajouterUser(string prenom, string nom, int agee, string mail,string login, string mdp, bool goingMode = true);
        int ajouterUser(TogetherUsersSet user);
        List<TogetherUsersSet> obtenirTousLesUsers();
        void setUserModeTransport(bool mode, int id);
        int addUserVoiture(TogetherCarsSet voiture, int userId);
        int saveCar(TogetherCarsSet car);
        int saveTogetherUsersSet_TogetherDrivers(TogetherUsersSet_TogetherDrivers rel);
        int saveHomeAdress(AdressesSet_HomeAdress ad);
        int saveWorkAdress(AdressesSet_WorkAdress ad);
        int ajouterUserAdresse(AdressesSet adresse, int user_id);
        TogetherUsersSet obtenirUserByUserId(int user_id);
        TogetherUsersSet autentifier(string login, string mdp);
        string encodeStringMD5(string password);
        bool verifyMD5(string input, string password);
        int saveUserAccompt(CreateAccountViewModel vue);
    }
}

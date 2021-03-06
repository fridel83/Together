﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RoadBetterTogether.Models
{
    public class TogetherDal : ITogetherDal
    {
        public TogetherContext bdd;

        public TogetherDal()
        {
            this.bdd = new TogetherContext();
        }

        public int addUserVoiture(TogetherCarsSet voiture, int userId)
        {
            TogetherUsersSet user = bdd.TogetherUsersSet.FirstOrDefault(c => c.Id == userId);
            voiture.TogetherDrivers_Id = user.Id;
            bdd.TogetherCarsSet.Add(voiture);
            return bdd.SaveChanges();
        }

        public int saveHomeAdress(AdressesSet_HomeAdress ad)
        {
            this.bdd.AdressesSet.Add(ad.AdressesSet);
            int adressId = bdd.SaveChanges();
            this.bdd.AdressesSet_HomeAdress.Add(ad);
            return this.bdd.SaveChanges();
        }

        public int saveWorkAdress(AdressesSet_WorkAdress ad)
        {
            this.bdd.AdressesSet.Add(ad.AdressesSet);
            int adressId = bdd.SaveChanges();
            this.bdd.AdressesSet_WorkAdress.Add(ad);
            return this.bdd.SaveChanges();
        }


        public int ajouterUser(String prenom = "idriss", String nom = "eliguene", int agee = 33, String mail = "idriss.eliguene@gmail.com", bool goingMode = true)
        {
            TogetherUsersSet user = new TogetherUsersSet { firstname = prenom, name =nom, age = agee, email = mail, goingMode=goingMode };
            this.bdd.TogetherUsersSet.Add(user);
            return bdd.SaveChanges();
        }

        public int saveCar(TogetherCarsSet car)
        {
            this.bdd.TogetherCarsSet.Add(car);
            return this.bdd.SaveChanges();
        }

        public void Dispose()
        {
            this.bdd.Dispose();
        }

        public List<TogetherUsersSet> obtenirTousLesUsers()
        {
            List < TogetherUsersSet > users = new List<TogetherUsersSet>();
            users = this.bdd.TogetherUsersSet.ToList();
            return users;
        }

        public void setUserModeTransport(bool mode, int id)
        {
            TogetherUsersSet user = bdd.TogetherUsersSet.FirstOrDefault(c => c.Id == id);
            user.goingMode = mode;
            bdd.SaveChanges();
        }

        public int saveTogetherUsersSet_TogetherDrivers(TogetherUsersSet_TogetherDrivers rel)
        {
            this.bdd.TogetherUsersSet_TogetherDrivers.Add(rel);
            return bdd.SaveChanges();
        }

        public TogetherUsersSet obtenirUserByUserId(int user_id)
        {
            return this.bdd.TogetherUsersSet.FirstOrDefault(c => c.Id == user_id);
        }

        public int ajouterUser(TogetherUsersSet user)
        {
            this.bdd.TogetherUsersSet.Add(user);
            return this.bdd.SaveChanges();
        }

        public int ajouterUserAdresse(AdressesSet adresse, int user_id)
        {
            TogetherUsersSet user = this.obtenirUserByUserId(user_id);
            adresse.TogetherUsersSet = user;
            adresse.TogetherUsersSet_Id = 2005;
            this.bdd.AdressesSet.Add(adresse);
            return this.bdd.SaveChanges();
        }

        public TogetherUsersSet autentifier(string login, string mdp)
        {
            TogetherUsersSet user = this.bdd.TogetherUsersSet.FirstOrDefault(c => c.login == login);
            if (user != null)
            {
                if (verifyMD5(mdp, user.password))
                    return user;
                else
                    return null;
            }
            else
                return null;
        }

        public bool verifyMD5(string input, string password)
        {
            string chaine = encodeStringMD5(input);
            StringComparer comparer = StringComparer.Ordinal;
            if (0 == comparer.Compare(chaine, password))
            {
                return true;
            }
            else
                return false;
        }

        public string encodeStringMD5(string password)
        {
            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
            byte[] bites = crypto.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < bites.Length; i++)
            {
                str.Append(bites[i].ToString());
            }

            return str.ToString();
        }
    }
}
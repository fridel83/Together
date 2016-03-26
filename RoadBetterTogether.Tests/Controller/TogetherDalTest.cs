using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using RoadBetterTogether.Models;
using System.Collections.Generic;

namespace RoadBetterTogether.Tests.Controller
{
    [TestClass]
    public class TogetherDalTest
    {
        [TestInitialize]
        public void initTest()
        {
            IDatabaseInitializer<TogetherContext> init = new DropCreateDatabaseAlways<TogetherContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new TogetherContext());
        }


        [TestMethod]
        public void Test_ajouterUser()
        {
            using (ITogetherDal dal = new TogetherDal())
            {
                int idUser = dal.ajouterUser("test1", "son nom", 13, "sonmail@gmail.com","fridel","fridel", false);
                List<RoadBetterTogether.TogetherUsersSet> mesusers= dal.obtenirTousLesUsers();
                TogetherUsersSet user = dal.obtenirUserByUserId(idUser);
                Assert.AreEqual("test1", user.firstname);
                Assert.AreEqual(1, mesusers.Count);
            }
        }

        [TestMethod]
        public void test_addUserVoiture()
        {
            using (ITogetherDal dal = new TogetherDal())
            {
            }
        }

        [TestCleanup]
        public void apres_test()
        {

        }
    }
}

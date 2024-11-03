using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShootMeUp_GHE;
using System;

namespace MissileCollisions
{
    [TestClass]
    public class EnnemiVie
    {
        [TestMethod]
        public void EnnemiVieTest()
        {
            // Arrange
            int viesInitiales = 3;

            // Act
            var vaisseau = new Vaisseau(10, 10, viesInitiales); // Initialise le vaisseau avec 3 vies

            // Assert
            Assert.AreEqual(viesInitiales, vaisseau.Vies, "Le nombre de vies du vaisseau devrait être initialisé à 3.");
        }
    }
}

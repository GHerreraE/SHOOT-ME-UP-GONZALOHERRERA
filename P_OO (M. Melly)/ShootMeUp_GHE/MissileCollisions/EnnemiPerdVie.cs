using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShootMeUp_GHE;
using System;

namespace MissileCollisions
{
    [TestClass]
    public class EnnemiPerdVie
    {
        [TestMethod]
        public void EnnemiPerdVieTest()
        {
            // Arrange
            var ennemi = new Ennemi("<<*>>", 3, 5, 5, 10); // Ennemi avec 3 points de vie

            // Act
            ennemi.SubirDegat(); // Applique des dégâts

            // Assert
            Assert.AreEqual(2, ennemi.Vies, "La vie de l'ennemi devrait diminuer de 1 lorsqu'il subit des dégâts.");
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using ShootMeUp_GHE;

namespace MissileCollisions
{
    [TestClass]
    public class MissileCollisions
    {
        [TestMethod]
        public void CollisionsTest()
        {
            // Arrange
            var obstacle = new Obstacle(5, 5, 3); // Obstacle initialisé à la position (5, 5)
            var missile = new Missile(5, 5); // Missile initialisé à la même position pour tester la collision

            // Act
            bool collisionDetectee = missile.PositionX == obstacle.PosX && missile.PositionY == obstacle.PosY;

            // Assert
            Assert.IsTrue(collisionDetectee);
        }
    }
}

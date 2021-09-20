using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private Game game;

        [TestInitialize]
        public void Initialized()
        {
            game = new Game();
        }

        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            //var game = new Game();
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void Score_All_Rolls_Should_Be_One_test()
        {
            Roll(game, 1, 20);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void CanRollSpare_test()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            Roll(game, 0, 17);
            Assert.AreEqual(16, game.GetScore());
        }

        [TestMethod]
        public void CanRollStrike_test()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            Roll(game, 0, 16);
            Assert.AreEqual(24, game.GetScore());
        }

        [TestMethod]
        public void CanRollPerfectGame_test()
        {
            Roll(game, 10, 12);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void CanRollAssignmentGame_test()
        {
            game.Roll(10); // Frame 1
            game.Roll(9);  // Frame 2
            game.Roll(1);  // Frame 2
            game.Roll(5);  // Frame 3
            game.Roll(5);  // Frame 3
            game.Roll(7);  // Frame 4
            game.Roll(2);  // Frame 4
            game.Roll(10);  // Frame 5
            game.Roll(10);  // Frame 6
            game.Roll(10);  // Frame 7
            game.Roll(9);  // Frame 8
            game.Roll(0);  // Frame 8
            game.Roll(8);  // Frame 9
            game.Roll(2);  // Frame 9
            game.Roll(9);  // Frame 10
            game.Roll(1);  // Frame 10
            game.Roll(10);  // Frame 10
            Assert.AreEqual(187, game.GetScore());
        }

        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
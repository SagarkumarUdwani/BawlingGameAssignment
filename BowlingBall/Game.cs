using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    interface IGame
    {
        int GetScore();
    }

    public abstract class BowlingGame
    {
        protected const int _maxScore = 300;

        protected const int _minPins = 0;

        protected const int _maxPins = 10;

        public abstract void Roll(int ball);
    }

    public class Game : BowlingGame, IGame
    {
        /*
        Possible Solutions but can cause an issue
        Approach 1 : Variable Shuffling
        Approach 2 : Using Array of Array
        Approach 3 : List of Dictionary
        */

        //Approach 4  : Array
        private int[] rolls = null;

        //Hold recent roll index
        int currentRoll = 0;

        public Game()
        {
            //Maximum 10 Frame * 2 Balls in each frame + 1 for last frame
            rolls = new int[21];
        }

        public override void Roll(int pins)
        {
            //Adding each balls score to rolls
            if (pins < _minPins)
                pins = _minPins;
            else if (pins > _maxPins)
                pins = _maxPins;

            try
            {
                rolls[currentRoll++] = pins;
            }
            catch (IndexOutOfRangeException ex)
            {
                //Warning : Maximum 21 balls can be played
            }
        }

        public int GetScore()
        {
            // Returns the final score of the game.
            int score = 0;
            int rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score += CalculateSpecialScore(rollIndex);
                    rollIndex++;
                }
                else if (IsSpare(rollIndex))
                {
                    score += CalculateSpecialScore(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += CalculateStandardScore(rollIndex);
                    rollIndex += 2;
                }
            }

            return (score > _maxScore ? _maxScore : score) ;
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

        private int CalculateStandardScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }

        private int CalculateSpecialScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        /*
        private int CalculateSpareScore(int rollIndex)
        {
            return 10 + rolls[rollIndex + 2];
        }

        private int CalculateStrikeScore(int rollIndex)
        {
            return 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }
        */
    }
}
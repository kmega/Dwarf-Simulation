using System.Collections.Generic;

namespace RobotWars
{
    class Arena
    {
        private bool Hit(Robot first, Robot second)
        {
            second.HP -= first.Attack - (int)(second.Defense * 0.65);
            if (second.HP <= 0)
            {
                return true;
            }

            return false; 
        }
        public void Fight(List<Robot> robots)
        {
            Robot first = robots[0];
            Robot second = robots[1];
            while (true)
            {
                if (Hit(first, second))
                {
                    break;
                }
                if (Hit(second, first))
                {
                    break;
                }
            }
        }

        public void FightAlternativeVersion(List<Robot> robots)
        {
            int indexOfAttackingRobot = 0;
            int indexOfDefendingRobot = 1;
            while (true)
            {
                if (Hit(robots[indexOfAttackingRobot]
                    ,robots[indexOfDefendingRobot]))
                {
                    break;
                }

                int t = indexOfDefendingRobot;
                indexOfDefendingRobot = indexOfAttackingRobot;
                indexOfAttackingRobot = t;
            }
        }
    }
}
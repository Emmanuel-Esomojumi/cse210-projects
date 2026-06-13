using System;

/*
 * Creativity Feature:
 *
 * Added a Level System to enhance gamification.
 * Players gain a new level for every 1000 points earned.
 * The program displays the player's current level and
 * how many points are needed to reach the next level.
 */

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
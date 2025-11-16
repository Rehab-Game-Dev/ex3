using UnityEngine;

/**
 * This is a static class that keeps the player scores between scenes.
 */
public static class GAME_STATUS {
    public static int playerScore = 0;

    public static void AddScore(int amount) {
        playerScore += amount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // This script is used to control the game's state.
    // The game's state is controlled by the number of dinosaurs in the game.
    int TotalDinoCount;
    int killedDinoCount;
    public Text dinoCountText;

    void Start()
    {
        TotalDinoCount = GameObject.FindGameObjectsWithTag("Dino").Length;
    }
    void Update()
    {
        // When dinosaurs are killed, the killedDinoCount is updated.
        killedDinoCount = TotalDinoCount - GameObject.FindGameObjectsWithTag("Dino").Length;
        dinoCountText.text = killedDinoCount + "/" + TotalDinoCount;

        // Check each dinosaur's position
        GameObject[] dinos = GameObject.FindGameObjectsWithTag("Dino");
        foreach (GameObject dino in dinos)
        {
            if (dino.transform.position.z <= -15)
            {
                Lose();
                break;
            }
        }

        // Check if the game is over
        GameOver();
    }

    void GameOver()
    {
        // When all dinosaurs are killed, the game is over.
        if (killedDinoCount == TotalDinoCount)
        {
            Debug.Log("Game Over");
        }
    }
    void Lose()
    {
        // If one of the Dino tagged objects reaches position z = -20, the game is lost.
        Debug.Log("Game Lost");
    }

}

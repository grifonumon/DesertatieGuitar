using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorPuzzle : MonoBehaviour
{

    public int numberOfPuzzlesForUnlock = 0;
    public OpenObject door;

    private bool[] puzzlesUnlocked;
    // Start is called before the first frame update
    void Start()
    {
        puzzlesUnlocked = new bool[numberOfPuzzlesForUnlock];
    }

    public void UnlockPuzzle(int puzzleNumber)
    {
        puzzlesUnlocked[puzzleNumber] = true;

        //check if all puzzles are unlocked
        bool isAllUnlocked = true;
        for(int i = 0; i < numberOfPuzzlesForUnlock; i++)
        {
            if(puzzlesUnlocked[i] == false)
            {
                isAllUnlocked = false;
            }
        }

        if (isAllUnlocked) //All puzzles are unlocked. Call the main function to unlock door
        {
            door.isLocked = false;
        }

    }
}

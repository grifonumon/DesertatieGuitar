using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PuzzleToSolve : MonoBehaviour
{
    public int fixPuzzleObjectID = -1;
    public bool hasStates = true;
    public GameObject stateA, stateB;
    public bool hasAnimation = false;
    public bool isFixed = false;

    public PlayableDirector pd;
    public GameObject puzzleAffectedObject;
    

    public void SolvePuzzle(int handObjectID)
    {
        if(fixPuzzleObjectID == handObjectID && !isFixed)
        {
            if (hasStates)
            {
                stateA.SetActive(false);
                stateB.SetActive(true);
            }
            //Play Animation
            if (hasAnimation)
            {
                //play cinematic
                pd.Play();

                //Fix specific puzzle thinks.
                if(fixPuzzleObjectID == 0)
                {
                    if (puzzleAffectedObject)
                    {
                        puzzleAffectedObject.GetComponent<CodeLock>().ChangeState();
                    }
                }

                if(fixPuzzleObjectID == 2)
                {
                    if (puzzleAffectedObject)
                    {
                        puzzleAffectedObject.GetComponent<ExitDoorPuzzle>().UnlockPuzzle(1);
                    }
                }
            }

            isFixed = true;
        }
    }
}

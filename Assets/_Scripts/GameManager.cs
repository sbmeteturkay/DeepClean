using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject WaterVacuum;
    // Start is called before the first frame update
    void Start()
    {
        CollisionDetect.GameFinish += CollisionDetect_GameFinish;
    }

    private void CollisionDetect_GameFinish()
    {
        WaterVacuum.SetActive(true);


        //after  water enabled, finish game 6 seconds later. needs rework @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@LOOK UP HERE LATER@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this.Wait(6f, () =>
            { CollisionDetect.GameFinish -= CollisionDetect_GameFinish;
                finishPanel.SetActive(true);
            }
        );
    } 
}

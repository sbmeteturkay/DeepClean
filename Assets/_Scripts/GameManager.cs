using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject finishPanel;
    // Start is called before the first frame update
    void Start()
    {
        CollisionDetect.GameFinish += CollisionDetect_GameFinish;
    }

    private void CollisionDetect_GameFinish()
    {
        print("dsadsad");
        CollisionDetect.GameFinish -= CollisionDetect_GameFinish;
        finishPanel.SetActive(true);
    }
}

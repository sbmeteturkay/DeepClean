using DG.Tweening;
using UnityEngine;
using System;
public class CollisionDetect : MonoBehaviour
{
    public static event Action GameFinish;
    [SerializeField] GameObject chipsParent;
    [SerializeField] Transform[] objectPath;
    [SerializeField] Transform collectParent;
    Vector3[] wayPoints;
    private void Start()
    {
        wayPoints = new Vector3[objectPath.Length];
        for(int i = 0; i < objectPath.Length; i++)
        {
            wayPoints.SetValue(objectPath[i].localPosition, i);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("clean"))
        {
            other.transform.SetParent(collectParent);
            other.tag = "Untagged";
            other.transform.DOLocalPath(wayPoints,1f);
            other.transform.DOScale(0, 2);
            this.Wait(1f, () => {
                other.gameObject.SetActive(false);
                print(chipsParent.transform.childCount);
                if (chipsParent.transform.childCount == 0)
                {
                    GameFinish?.Invoke();
                    gameObject.SetActive(false);
                }

                });
        }
    }
}

using UnityEngine;
using DG.Tweening;
public class ObjectMove : MonoBehaviour
{
    [SerializeField]
    private LayerMask roomLayer;
    Camera main;
    private void Start()
    {
        main = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButton(0)) { MoveTarget(); }
    }
    private void MoveTarget() {
        Vector3 vector3 = Cast();
        transform.position = vector3;
        transform.DORotate(new Vector3(0,-Mathf.Abs(vector3.x * 20), 0), 0.1f);
    }

    private Vector3 Cast()
    {
        Ray ray = main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, roomLayer))
            if (hit.collider != null)
                return new Vector3(hit.point.x, -1.18f, hit.point.z);
        return new Vector3(0, 0, 0);
    }
}

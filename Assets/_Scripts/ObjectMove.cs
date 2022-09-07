using UnityEngine;
using DG.Tweening;
public class ObjectMove : MonoBehaviour
{
    [SerializeField] LayerMask roomLayer;
    [SerializeField] float yPosition = 0;
    [SerializeField] bool doRotate = false;
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
        vector3.z= Mathf.Clamp(vector3.z,-4,6.5f);
        transform.position = vector3;
        if(doRotate)
            transform.DORotate(new Vector3(20,-Mathf.Abs(vector3.x * 20), 0), 0.1f);
    }

    private Vector3 Cast()
    {
        Ray ray = main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, roomLayer))
            if (hit.collider != null)
                return new Vector3(hit.point.x, yPosition, hit.point.z);
        return new Vector3(0, 0, 0);
    }
}

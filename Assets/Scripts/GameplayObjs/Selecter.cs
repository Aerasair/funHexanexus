using UnityEngine;

public class Selecter : MonoBehaviour
{
    [SerializeField] private Vector3 _hitVector;

    private RaycastHit[] _hits;
    private int layerMask;



    public PosCube GetItem(int numItem)
    {
        layerMask = LayerMask.GetMask("posCubes");
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, _hitVector, 100.0F, layerMask);
        return hits[numItem - 1].transform.GetComponent<PosCube>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, _hitVector);
    }
}

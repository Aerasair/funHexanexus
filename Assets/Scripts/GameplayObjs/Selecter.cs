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

    private bool _result;
    public bool CheckWin(bool isWinTile)
    {
        _result = true;
        layerMask = LayerMask.GetMask("winCube");
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, _hitVector, 100.0F, layerMask);
        if(hits.Length == 0) {  if (isWinTile) _result = false; else _result = true;  }
        foreach(var item in hits)
        {
            if (item.transform.gameObject.GetComponent<Cube>())
            {
                if (isWinTile) { return _result = true;  }
                else { _result = false; continue;   }
            }
            else
            {
                if (isWinTile) { _result = false; continue; }
                else { return true;  }
            }
            
        }

        return _result;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, _hitVector);
    }
}

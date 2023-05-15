using UnityEngine;

public class Cube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.TryGetComponent(out PosCube posCube))
        {
            posCube.SetCube(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.TryGetComponent(out PosCube posCube))
        {
            posCube.gameObject.transform.SetParent(posCube.transform.parent);
        }
    }

}

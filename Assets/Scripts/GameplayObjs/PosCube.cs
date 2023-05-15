using UnityEngine;

public class PosCube : MonoBehaviour
{
   [SerializeField]  private Cube _cube;

    public Cube Cube => _cube;

    public void SetCube(Cube cube)
    {
        gameObject.transform.SetParent(cube.transform);
    }

    //public void RemoveCube()
    //{
        
    //}
}

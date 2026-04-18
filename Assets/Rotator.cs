using UnityEngine;

public class Rotator : MonoBehaviour
{
  [SerializeField] float x, y, z;
  void Start(){
  }

  // Update is called once per frame
  void Update()
   {
    // Rotate the object on X, Y, and Z axes by specified amounts, adjusted for frame rate.
    transform.Rotate (new Vector3 (x, y, z) * Time.deltaTime);
    }

}
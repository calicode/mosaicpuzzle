using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickRotate : MonoBehaviour
{


    void OnMouseDown()
    {
        transform.Rotate(Vector3.forward * 90);
    }

}

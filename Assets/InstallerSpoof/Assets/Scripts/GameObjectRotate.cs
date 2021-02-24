using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectRotate : MonoBehaviour
{
    public void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 1, 0);
    }
}

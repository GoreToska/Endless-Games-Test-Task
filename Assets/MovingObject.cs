using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float Speed = 6f;
    public float Distance = 10f;

    void Update()
    {
        if (this.transform.position.z >= Distance)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
    }
}

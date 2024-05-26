using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float rotationSpeed = 80f;
    void Update()
    {
        this.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}

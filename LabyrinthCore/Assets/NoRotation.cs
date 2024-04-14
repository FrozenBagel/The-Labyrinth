using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotation : MonoBehaviour
{
    private void FixedUpdate()
    {
        // Resetting rotation to zero
        transform.rotation = Quaternion.identity;
    }
}

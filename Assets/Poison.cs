using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Poison : MonoBehaviour
{
    public static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

        }
    }
}

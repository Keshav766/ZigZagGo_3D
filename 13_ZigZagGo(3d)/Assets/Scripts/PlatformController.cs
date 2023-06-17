using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            Invoke("FallDown", 0.1f);
        }
    }

    private void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        Destroy(transform.parent.gameObject, 1f);
    }
}

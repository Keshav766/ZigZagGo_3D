using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
   [SerializeField] GameObject target;
   [SerializeField] float lerpAmount = 5f;
    
    Vector3 offset;
    public bool gameOver = false;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if(!gameOver)
        {
            Vector3 pos = transform.position;
            Vector3 targetPos = target.transform.position - offset;
            pos = Vector3.Lerp(pos, targetPos, lerpAmount * Time.deltaTime);
            transform.position = pos;
        }
    }
}

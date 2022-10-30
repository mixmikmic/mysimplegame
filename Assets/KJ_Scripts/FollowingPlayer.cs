using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPlayer : MonoBehaviour
{

    [SerializeField]Transform target;
    [SerializeField] Vector3 offset;

    // Start is called before the first frame update


    void Update()
    {
        transform.position = target.position + offset;
    }

}

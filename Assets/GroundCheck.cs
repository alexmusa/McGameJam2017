using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    // Use this for initialization
    void Start()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        isGrounded = true;

    }

    void OnTriggerStay()
    {
        isGrounded = true;

    }

    void OnTriggerExit()
    {
        isGrounded = false;

    }
}

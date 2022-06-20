using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log("Camara pos > "+transform.position.ToString());
        Vector3 nuevaPos = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
        //Debug.Log("Nueva pos > " + nuevaPos.ToString());
        //transform.position = Vector3.Lerp(transform.position, nuevaPos, 10 * Time.deltaTime);
        transform.position = nuevaPos;
    }
}

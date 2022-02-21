using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject sphere;
    public Color toColour;
    Color originalColour;

    private void Start()
    {
        originalColour = sphere.GetComponent<Renderer>().material.color;
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            sphere.GetComponent<Renderer>().material.color = toColour;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(PlayerDetected(other))
        {
            sphere.transform.localScale += Vector3.one * 0.01f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (PlayerDetected(other))
        {
            sphere.GetComponent<Renderer>().material.color = originalColour;
            sphere.transform.localScale = Vector3.one;
        }
    }

    bool PlayerDetected(Collider _other)
    {
        return _other.CompareTag("Player");
    }
}

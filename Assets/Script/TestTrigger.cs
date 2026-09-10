using System;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        Destroy(collision.gameObject);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipPlayer : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity += Vector3.right * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity += Vector3.left * speed;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.velocity += Vector3.up * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            body.velocity += Vector3.down * speed;
        }





        // contrôle des canons

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Gun gun in GetComponentsInChildren<Gun>())
            {
                gun.enabled = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (Gun gun in GetComponentsInChildren<Gun>())
            {
                gun.enabled = false;
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        GetComponent<Life>().SetDamage(1);
    }

    void OnTriggerStay(Collider other)
    {
        GetComponent<Life>().SetDamage(10);

        other.GetComponentInParent<Life>()?.SetDamage(10);
    }

    void OnDestroy()
    {
        SceneManager.LoadScene("GameOver");
    }
}


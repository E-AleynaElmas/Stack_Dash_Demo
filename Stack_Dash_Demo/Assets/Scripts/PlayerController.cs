using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject mainObject;

    private bool left, right, up, down;
    private List<GameObject> list;

    void Start()
    {
        list = new List<GameObject>();
        list.Clear();
        list.Add(mainObject);
    }

    void FixedUpdate()
    {
        if (left)
        {
            //physics.MovePosition(physics.position + Vector3.left * speed * Time.deltaTime);
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (right)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else if (down)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed );
        }
        else if (up)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            left = false;
            right = false;
            down = false;
            up = false;
        }
    }

    public void Slide(string direction)
    {
        if (direction == "left")
        {
            left = true;
        }

        else if (direction == "right")
        {
            right = true;
        }

        else if (direction == "down")
        {
            down = true;
        }

        else if (direction == "up")
        {
            up = true;
        }
    }
    private void AddCube(GameObject cube)
    {
        list.Add(cube);
        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.position = new Vector3(list[i].transform.position.x, list[i].transform.position.y + 0.25f, list[i].transform.position.z);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "cube")
        {
            Debug.Log("değdi");
            if (transform.position.x >= other.transform.position.x)
            {
                other.transform.position = transform.position;
                AddCube(other.gameObject);
                //transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                other.transform.SetParent(transform);
                Debug.Log("coccuk");
            }
        }
    }
}

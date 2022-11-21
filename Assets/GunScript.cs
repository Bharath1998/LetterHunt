using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector2 gunpos = transform.position;
        // direction = mousepos-gunpos;
        // FaceMouse();
    }

    void FaceMouse()
    {
        // transform.right = direction;
    }
}

using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class MoveBoxX : MonoBehaviour

{

    private Vector3 mOffset;


    private float mZCoord;

    public float minClamp;
    public float maxClamp;

    public float xTransform;
    public float yTransform;
    public float zTransform;


    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;


        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }


    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;


        // z coordinate of game object on screen

        mousePoint.z = mZCoord;


        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }


    void OnMouseDrag()

    {

        transform.position = GetMouseAsWorldPoint() + mOffset;

    }

    void Update()
    {
        transform.position = new Vector3(xTransform, yTransform, transform.position.z);

        Vector3 clampedPosition = transform.position;
        clampedPosition.z = Mathf.Clamp(transform.position.z, minClamp, maxClamp);
        transform.position = clampedPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Collided");
        }
    }

}
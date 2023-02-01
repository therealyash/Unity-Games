using UnityEngine;
using System.Collections;

public class Check : MonoBehaviour
{
    private string currentGameobjectName;

    public string[] gameObjectNames;
    public Rigidbody2D[] circles_rb;

    private void Start()
    {
        foreach (Rigidbody2D rb in circles_rb)
        {
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                currentGameobjectName = hit.collider.gameObject.name;
                //Debug.Log(currentGameobjectName);
                hit.collider.attachedRigidbody.AddForce(Vector2.up);
            }
        }

        
    }
    /*
    public void MoveCircles()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        
        if (hit.collider != null)
        {
            Rigidbody2D rb = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1.5f;
        }


    }
    */
}
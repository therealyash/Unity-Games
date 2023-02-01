using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour {

    private bool selected;   

    private Check check;

    

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if(selected == true)
        {
            Vector2 curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(curPos.x, curPos.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                Rigidbody2D rb = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.None;
                rb.gravityScale = 1.5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            selected = true;            
        }
    }

    

}

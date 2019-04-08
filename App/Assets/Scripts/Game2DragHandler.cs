using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game2DragHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public int dragSpeed = 100;
    public GameObject placeholder;

    private Vector3 initialPosition;

    private Button btn;

    void Start()
    {
        //initialPosition = this.transform.position;
        btn = this.gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
//          if (Input.touchCount > 0) 
//  {
//      Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
     
//      if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) 
//      {
//          // get the touch position from the screen touch to world point
//          Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
//          // lerp and set the position of the current object to that of the touch, but smoothly over time.
//          transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
//      }
//  }
    }
    public void OnBeginDrag() {
        initialPosition = this.transform.position;
    }

    public void OnMouseDrag()
     {
         if(btn.interactable)
         {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragSpeed);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    
            transform.position = objPosition;
         }
     }

    public void OnMouseDrop()
     {
        float distance = Vector3.Distance(this.transform.position, placeholder.transform.position);

        if(distance < 0.5 && this.tag == placeholder.tag)
        {
            this.transform.position = placeholder.transform.position;
            Game2Logic.isWin = true;
            Game2Logic.isWrong = false;
        }
        else 
        {
            this.transform.position = initialPosition;
            Game2Logic.isWin = false;
            Game2Logic.isWrong = true;
        }
     }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    //touch position in world coordinates
    private Vector2 touch_pos_world;
    //layer mask of the buttons (the only affected by the raycast)
    public LayerMask layer_mask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //check if there has been a touch
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            //transform the touch to world coordinates
            touch_pos_world = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            //We now raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touch_pos_world, Camera.main.transform.forward, Mathf.Infinity,layer_mask);

            if (hitInformation.collider != null)
            {
                //deactivate the g.o.
                hitInformation.transform.gameObject.SetActive(false);
            }
        }
    }
}

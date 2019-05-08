using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_DragAndDrop : MonoBehaviour
{
    public Camera cam;
    public C_Manager manager;
    [HideInInspector] public bool inTrigger;

    public string collName;

    public Vector3 placedPos;
    private float placedMult; //mult for position that takes from parent's scale -- otherwise misplaced
    public Sprite placedImg;
    private bool isPlaced = false;

    private Vector3 initPos;
    private Vector3 initScale;
    readonly float hoverMult = 1.3f; //scale multiplier when hovered

    private bool selected = false;
    private bool updatedSlider = false;

    private void Start()
    {
        initPos = transform.position;
        initScale = transform.localScale;
        placedMult = transform.parent.parent.localScale.x;
        placedPos = new Vector3(placedPos.x * placedMult, placedPos.y * placedMult, placedPos.z);
    }

    private void Update()
        //gets "in trigger" from the C_Collider script
    {
        if (selected)
        {
            Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(cursorPos.x, cursorPos.y, -1);
        }

        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
            transform.localScale = initScale;

            if (inTrigger)
            {
                isPlaced = true;
                transform.position = placedPos;
                GetComponent<SpriteRenderer>().sprite = placedImg;

                if (!updatedSlider)
                    //no repeat counts!
                {
                    updatedSlider = true;
                    manager.UpdateCleanliness();
                }
            }
            else transform.position = initPos;
        }
    }

    private void OnMouseOver()
    {
        if (!isPlaced)
        {
            if (Input.GetMouseButtonDown(0))
            {
                selected = true;
                transform.localScale = initScale * hoverMult;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private PlantSO claimedItem;
    [SerializeField]private LayerMask clickLayer;
    [SerializeField]private SpriteRenderer mouseIcon;
    private bool canClick = false;
    Vector2 mousePos;
    RaycastHit2D hit;

    public PlantSO ClaimedItem{
        get{return claimedItem;}
        set{claimedItem = value;}
    }

    private void OnEnable() {
        GameManager.gameAction += OpenController;
        GameManager.endAction += CloseController;
    }
    private void OnDisable() {
        GameManager.gameAction -= OpenController;
        GameManager.endAction -= CloseController;
    }
    private void OpenController()
    {
        canClick = true;
    }
    private void CloseController()
    {
        canClick = false;
    }







    public void SetClaimedItem(PlantSO newItem)
    {
        if (claimedItem != null)
        return;

        
        claimedItem = newItem;
    }
    
    void Update()
    {
        if(!canClick)
        return;

        ClickControl();
    }
    void ClickControl()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos, Vector2.zero, 1f ,clickLayer);
            if (hit.collider != null )
            {
                bool value;
                string clickedTag ="";
                if (claimedItem != null)
                {
                    clickedTag = claimedItem.objectTag;
                }

                value = hit.collider.GetComponent<IA_Clickable>().ClickRequest(clickedTag);

                if(value)
                {
                    claimedItem = null;
                    mouseIcon.gameObject.SetActive(false);

                }

            }
        }

        if (claimedItem != null)
        {
            mouseIcon.sprite = claimedItem.slotIcon;
            mouseIcon.gameObject.SetActive(true);
            MouseIconControl();
        }
    }
    void MouseIconControl()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseIcon.gameObject.transform.position = mousePos;
    }

}

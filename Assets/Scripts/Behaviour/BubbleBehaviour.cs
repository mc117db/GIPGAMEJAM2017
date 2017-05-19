using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    public delegate void OnEvent();
    public static event OnEvent OnBubblePop;
    //public static bool playerIsInsideABubble; // This is to account for the case when player is inside two bubbles
    public bool playerIsInsideThisBubble;
    public float ammoVal = 200f;
    public float degradeRate = 10f;
    //public SpriteRenderer bubbleImage;
    void Start()
    {
        //if (!bubbleImage)
        //{
        //    bubbleImage = GetComponent<SpriteRenderer>();
        //}
    }

    void Update()
    {
        #region Old Code
        //if (playerIsInsideThisBubble)
        //{
        //    Color spriteColor = bubbleImage.color;
        //    spriteColor.a -= degradeRate * Time.deltaTime;
        //    bubbleImage.color = spriteColor;
        //    if (spriteColor.a <= 0)
        //    {
        //        GameObjectUtil.Destroy(gameObject); //If there isnt any pooling behaviour, gameobjectutil will call the default destroy method btw
        //    }
        //} 
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            FireController firecontroller = collision.transform.GetChild(0).GetComponent<FireController>();
            firecontroller.AddAmmo(ammoVal);
            if (OnBubblePop != null)
            {
                OnBubblePop();
            }
        }
        #region Old Code
        //if (collision.gameObject.layer == 8 && !playerIsInsideABubble)
        //{
        //    if (!playerIsInsideABubble)
        //    {
        //        playerIsInsideABubble = true;
        //        playerIsInsideThisBubble = true;
        //        IToggleFire fireComponent = (IToggleFire)collision.gameObject.GetComponent(typeof(IToggleFire));
        //        fireComponent.ToggleFire(true);
        //    }
        //    playerIsInsideThisBubble = true;
        //} 
        #endregion
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        #region Old Code
        //if (collision.gameObject.layer == 8)
        //{
        //    if (playerIsInsideABubble)
        //    {
        //        playerIsInsideABubble = false;
        //        IToggleFire fireComponent = (IToggleFire)collision.gameObject.GetComponent(typeof(IToggleFire));
        //        fireComponent.ToggleFire(false);
        //    }
        //    playerIsInsideThisBubble = false;
        //} 
        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject exitScreen;
    [SerializeField] DragNDrop dnd;
    [SerializeField] GameObject testTube;
    [SerializeField] GameObject boy;
    [SerializeField] Material materialT, materialA, materialB;
    GameObject conicalFlask;
    Animator myAnimator;
    Animator myAnimator2;
    Animator characterAnimator;
    int count;

    private void Start()
    {
        characterAnimator = boy.GetComponent<Animator>();
        count = 2;
    }
    public void PourButton()
    {
        if (conicalFlask == null)
        {
            conicalFlask = GameObject.FindWithTag(dnd.str);
        }
        myAnimator = testTube.GetComponent<Animator>();
        myAnimator.ResetTrigger("Putback");
        myAnimator.SetTrigger("Pour");
        materialT.SetFloat("_FillAmount", 0.6f);
    }
    public void ShakeButton() 
    {
        myAnimator2 = conicalFlask.GetComponent<Animator>();
        myAnimator2.enabled = true;
        if (conicalFlask.CompareTag("CFA"))
        {
            materialA.SetColor("_Tint", Color.magenta);
            characterAnimator.SetTrigger("Happy");
        }
        else if (conicalFlask.CompareTag("CFB"))
        {
            materialB.SetColor("_Tint", Color.green);
            characterAnimator.SetTrigger("Sad");
        }
    }
    public void DropButton()
    {
        count -= 1;
        myAnimator.ResetTrigger("Pour");
        myAnimator.SetTrigger("Putback");
        conicalFlask.SetActive(false);
        conicalFlask = null;
        gameObject.SetActive(false);
        materialT.SetFloat("_FillAmount", 0.46f);
        materialA.SetColor("_Tint", Color.white);
        materialB.SetColor("_Tint", Color.white);
        if(count == 0)
        {
            exitScreen.SetActive(true);
        }
    }
}

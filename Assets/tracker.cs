using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class tracker : MonoBehaviour
{

    public InputActionReference triggerButton;
    public bool isClicked;
    public TextMeshProUGUI m_Object;
    public GameObject knife;
    public Vector3 idealVector;
    private Vector3 malpractice;
    private bool isFirst;

    // Start is called before the first frame update
    private void Awake() {
        triggerButton.action.started += click;
        isFirst = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isClicked) {
            if (isFirst) {
                malpractice = knife.transform.position;
            } else {
                malpractice = knife.transform.position -  malpractice;
                generateScore();
            }
            isFirst = !isFirst;

            
            isClicked = false;
        } 
    }

    void click(InputAction.CallbackContext CallbackContext) {
        isClicked = true;
    }

    private void OnDestroy() {
        triggerButton.action.started -= click;
    }
    void generateScore() {
        Vector2 v2 = new Vector2(malpractice.x, malpractice.y) - new Vector2(idealVector.x, idealVector.y);
        float angle = Mathf.Atan2(v2.y, v2.x);
        if(angle < 0) {
            angle = 360 + angle;}
        angle = 360 - angle;
        float score = (angle / 360) * 100;
        if (score < 1) { score *= 10;}
        else if (score > 99.7) score *= 0.99f;
        else if (score > 99.5) score *= 0.9f;
        else if (score > 99.4) score *= 0.88f;
        else if (score > 99.2) score *= 0.84f;
        else if (score > 99) score *= 0.8f;
        if (score > 3 && score < 10) score *= 5;
        m_Object.text =  "Your Score is " + (score).ToString() + "%";
       
    }
}

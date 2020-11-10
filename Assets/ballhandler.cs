using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballhandler : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hook;
    bool isPressed = false;
    float maxDragDistance = 4f;
    public GameObject next;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            Vector2 mPos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector3.Distance(mPos,hook.position) <= maxDragDistance)
            {
                rb.position = mPos;
            }
            else
            {
                Vector2 newpos= (mPos - hook.position).normalized * maxDragDistance + hook.position;
                rb.position = newpos;
            }
        }
    }
    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(release());
    }
    IEnumerator release()
    {

        yield return new WaitForSeconds((float)(0.4));
        GetComponent<SpringJoint2D>().enabled = false;

        yield return new WaitForSeconds((float)(0.5));
        next.SetActive(true);
    }
}

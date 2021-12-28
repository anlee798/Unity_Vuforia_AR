using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour
{
    Vector2 oldPos1;
    Vector2 oldPos2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            oldPos1 = Input.GetTouch(0).position;
            oldPos2 = Input.GetTouch(1).position;
            if (Input.GetTouch(0).phase==TouchPhase.Moved|| Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                
                Vector2 temPos1 = Input.GetTouch(0).position;
                Vector2 temPos2 = Input.GetTouch(1).position;

                if (isEnlarge(oldPos1, oldPos2, temPos1, temPos2))
                {
                    float oldScale = transform.position.x;
                    float newScale = oldScale * 1.025f;

                    transform.localScale = new Vector3(newScale, newScale, newScale);
                }
                else
                {
                    float oldScale = transform.position.x;
                    float newScale = oldScale / 1.025f;

                    transform.localScale = new Vector3(newScale, newScale, newScale);
                }

                oldPos1 = temPos1;
                oldPos2 = temPos2;
            }
        }
    }

    //判断放大缩小
    bool isEnlarge(Vector2 oPos1,Vector2 oPos2,Vector2 nPos1,Vector2 nPos2)
    {
        float length1 = Mathf.Sqrt((oPos1.x - oPos2.x) * (oPos1.x - oPos2.x) + (oPos1.y - oPos2.y) * (oPos1.y - oPos2.y));
        float length2 = Mathf.Sqrt((nPos1.x - nPos2.x) * (nPos1.x - nPos2.x) + (nPos1.y - nPos2.y) * (nPos1.y - nPos2.y));
        if (length1 < length2)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskPanel : MonoBehaviour
{

    GuideController guideController;

    Canvas canvas;

    Vector3[] vectors;
 
    Vector2 curVector;

    int count = 0;
    private void Awake()
    {
        canvas = transform.GetComponentInParent<Canvas>();
    }

    // Start is called before the first frame update
    void Start()
    {
        guideController = transform.GetComponent<GuideController>();
        vectors = guideController.Guide(canvas, GameObject.Find("PauseButton").GetComponent<RectTransform>(), GuideType.Rect);
        //Debug.Log("1234"+GameObject.Find("/MapCube (32)").name);
        //Invoke("Test", 1);
        //count++;
        //Debug.Log("1:" + vectors[0] + "2:" + vectors[1] + "3:" + vectors[2] + "4:" + vectors[3]);
    }

    void Test()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas1").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.2f);
        count = 1;
        //Debug.Log("----"+count);
    }

    void Test1()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas2").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.2f);
        count = 2;
    }
    bool isFirst = true;
    void Test2()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("MissileToggle").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.2f);
        count = 3;
        //if (isFirst)
        //{
        //    GameObject Panel = (GameObject)Resources.Load("Panel");
        //    Panel = Instantiate(Panel, new Vector3(1259,614,0), Panel.transform.rotation);
        //    Panel.transform.parent = transform;
        //    isFirst = false;
        //}
    }

    void Test3()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas2").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.2f);
        count = 11;
    }

    void Test4()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas3").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.2f);
        count = 5;
    }

    void Test5()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas4").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.2f);
        count = 6;
    }

    void Test6()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas5").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.2f);
        count = 7;
    }

    void Test7()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas3").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.2f);
        count = 8;
    }
    //没钱

    void Test8()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas5").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.2f);
        count = 9;
    }

    void Test9()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas4").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.2f);
        count = 10;
    }

    void Test10()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas6").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.2f);
        count = 12;
    }

    void TestCircle()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas7").GetComponent<RectTransform>(), GuideType.Circle, TranslateType.Slow, 0.2f);
        count = 4;
    }

    void TestCircle1()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas8").GetComponent<RectTransform>(), GuideType.Circle, TranslateType.Slow, 0.2f);
        count = 13;
    }

    void TestCircle2()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas9").GetComponent<RectTransform>(), GuideType.Circle, TranslateType.Slow, 0.2f);
        count = 14;
    }

    void TestCircle3()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas10").GetComponent<RectTransform>(), GuideType.Circle, TranslateType.Slow, 0.2f);
        count = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            curVector = Vector2.one;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
                Input.mousePosition, canvas.worldCamera, out curVector);
            //Debug.Log("pos:" + curVector);
            if(count == 0 && isInArea()) {
                Invoke("Test", 0.5f);
            }
            if (count == 1 && isInArea())
            {
                Invoke("Test1", 0.5f);
            }
            if (count == 2 && isInArea())
            {
                Invoke("Test2", 0.5f);
            }
            if (count == 3 && isInArea())
            {
                Invoke("Test3", 0.5f);
            }
            if (count == 4)
            {
                Invoke("Test4", 0.5f);
            }
            if (count == 5 && isInArea())
            {
                Invoke("Test5", 0.5f);
            }
            if (count == 6 && isInArea())
            {
                Invoke("Test6", 0.5f);
            }
            if (count == 7 && isInArea())
            {
                Invoke("Test7", 0.5f);
            }
            if (count == 8 && isInArea())
            {
                Invoke("Test8", 0.5f);
            }
            if (count == 9 && isInArea())
            {
                Invoke("Test9", 0.5f);
            }
            if (count == 10 && isInArea())
            {
                Invoke("Test10", 0.5f);
            }
            if (count == 11)
            {
                Invoke("TestCircle", 0.5f);
            }
            if (count == 12)
            {
                Invoke("TestCircle1", 0.5f);
            }
            if (count == 13)
            {
                Invoke("TestCircle2", 0.5f);
            }
            if (count == 14)
            {
                Invoke("TestCircle3", 0.5f);
            }
            if (count == 15)
            {
                Destroy(this.gameObject);
            }


            //if (count == 0 && isInArea())
            //{
            //    Invoke("Test", 0.5f);
            //    count++;
            //}
            //if (count == 0 && isInArea())
            //{
            //    Invoke("Test", 0.5f);
            //    count++;
            //}
            //if (count == 0 && isInArea())
            //{
            //    Invoke("Test", 0.5f);
            //    count++;
            //}
            //Invoke("Test", 1);
        }
    }

    public bool isInArea()
    {
        //1:(-322.0, -50.0, 0.0)2:(-322.0, 50.0, 0.0)3:(-222.0, 50.0, 0.0)4:(-222.0, -50.0, 0.0)

        // 1-> 左下 2->左上 3->右上 4->右下
        if (curVector.x >= vectors[0].x && curVector.x <= vectors[2].x && curVector.y >= vectors[0].y && curVector.y <= vectors[2].y) return true;
        return false;
    }
}

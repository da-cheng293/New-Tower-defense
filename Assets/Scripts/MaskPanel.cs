using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MaskPanel : MonoBehaviour
{

    GuideController guideController;

    Canvas canvas;

    Vector3[] vectors;
 
    Vector2 curVector;
    //RectTransform can;

    //RectTransform rectTransform;

    //public Text explainText;

    int count = 0;
    private void Awake()
    {
        canvas = transform.GetComponentInParent<Canvas>();
    }

    // Start is called before the first frame update
    void Start()
    {
        guideController = transform.GetComponent<GuideController>();
        vectors = guideController.Guide(canvas, GameObject.Find("PauseButton").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);
        //Debug.Log("1234"+GameObject.Find("/MapCube (32)").name);
        GameObject.Find("Text1").GetComponent<Text>().enabled = true;//activate current canvas
        GameObject.Find("Image1").GetComponent<Image>().enabled = true;
        //Invoke("Test", 1);
        //count++;
        //Debug.Log("1:" + vectors[0] + "2:" + vectors[1] + "3:" + vectors[2] + "4:" + vectors[3]);
    }

    void Test()
    {
        GameObject.Find("Text1").GetComponent<Text>().enabled = false;//activate current canvas
        GameObject.Find("Image1").GetComponent<Image>().enabled = false;
        GameObject.Find("Text2").GetComponent<Text>().enabled = true;//activate current canvas
        GameObject.Find("Image2").GetComponent<Image>().enabled = true;
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas1").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);
        //can = new RectTransform();
        //can = GameObject.Find("Canvas1").GetComponent<RectTransform>();

        //can.GetComponent<Text>().text = "Paused";
        //myText = new GameObject();
        //myText.transform.parent = can.transform;
        //myText.name = "wibble";


        //text = myText.AddComponent<Text>();
        //text.font = (Font)Resources.Load("MyFont");
        //text.text = "wobble";
        //text.fontSize = 100;

        // Text position
        //rectTransform = text.GetComponent<RectTransform>();
        //rectTransform.localPosition = new Vector3(0, 0, 0);
        //rectTransform.sizeDelta = new Vector2(400, 200);

        count = 1;
        Debug.Log("Hereeee");

        
    }

    void Test1()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas2").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);
        count = 2;

        GameObject.Find("Text2").GetComponent<Text>().enabled = false;//deactivate last canvas
        GameObject.Find("Image2").GetComponent<Image>().enabled = false;
        GameObject.Find("Text3").GetComponent<Text>().enabled = true;//activate current canvas
        GameObject.Find("Image3").GetComponent<Image>().enabled = true;
    }
    bool isFirst = true;
    void Test2()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("MissileToggle").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);
        count = 3;
        //if (isFirst)
        //{
        //    GameObject Panel = (GameObject)Resources.Load("Panel");
        //    Panel = Instantiate(Panel, new Vector3(1259,614,0), Panel.transform.rotation);
        //    Panel.transform.parent = transform;
        //    isFirst = false;
        //}
        GameObject.Find("Text3").GetComponent<Text>().enabled = false;//deactivate last canvas
        GameObject.Find("Image3").GetComponent<Image>().enabled = false;//activate current canvas
        GameObject.Find("Text4").GetComponent<Text>().enabled = true;
        GameObject.Find("Image4").GetComponent<Image>().enabled = true;
    }

    void Test3()
    {
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas2").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);
        count = 11;
        GameObject.Find("Text4").GetComponent<Text>().enabled = false;
        GameObject.Find("Image4").GetComponent<Image>().enabled = false;
        GameObject.Find("Text5").GetComponent<Text>().enabled = true;
        GameObject.Find("Image5").GetComponent<Image>().enabled = true;
    }


    void TestCircle()
    {
        GameObject.Find("Text5").GetComponent<Text>().enabled = false;
        GameObject.Find("Image5").GetComponent<Image>().enabled = false;
        GameObject.Find("Text6").GetComponent<Text>().enabled = true;
        GameObject.Find("Image6").GetComponent<Image>().enabled = true;

        vectors = guideController.Guide(canvas, GameObject.Find("Canvas7").GetComponent<RectTransform>(), GuideType.Circle, TranslateType.Slow, 0.5f);
        count = 4;
    }


    void Test4()
    {
        GameObject.Find("Text6").GetComponent<Text>().enabled = false;
        GameObject.Find("Image6").GetComponent<Image>().enabled = false;
        GameObject.Find("Text7").GetComponent<Text>().enabled = true;
        GameObject.Find("Image7").GetComponent<Image>().enabled = true;
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas3").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);
        count = 5;
        
    }

    void Test5()
    {
        GameObject.Find("Text7").GetComponent<Text>().enabled = false;
        GameObject.Find("Image7").GetComponent<Image>().enabled = false;
        GameObject.Find("Text8").GetComponent<Text>().enabled = true;
        GameObject.Find("Image8").GetComponent<Image>().enabled = true;

        vectors = guideController.Guide(canvas, GameObject.Find("Canvas4").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);
        count = 6;
       
    }

    void Test6()
    {
        GameObject.Find("Text8").GetComponent<Text>().enabled = false;
        GameObject.Find("Image8").GetComponent<Image>().enabled = false;

        GameObject.Find("Text9").GetComponent<Text>().enabled = true;
        GameObject.Find("Image9").GetComponent<Image>().enabled = true;

        vectors = guideController.Guide(canvas, GameObject.Find("Canvas5").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);
        count = 7;
        
    }

    void Test7()
    {
        GameObject.Find("Text9").GetComponent<Text>().enabled = false;
        GameObject.Find("Image9").GetComponent<Image>().enabled = false;

        GameObject.Find("Text10").GetComponent<Text>().enabled = true;
        GameObject.Find("Image10").GetComponent<Image>().enabled = true;

        vectors = guideController.Guide(canvas, GameObject.Find("Canvas3").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);
        count = 8;
  
    }
    //没钱

    void Test8()
    {
        GameObject.Find("Text10").GetComponent<Text>().enabled = false;
        GameObject.Find("Image10").GetComponent<Image>().enabled = false;
        GameObject.Find("Text11").GetComponent<Text>().enabled = true;// marked square has no mine, destroy
        GameObject.Find("Image11").GetComponent<Image>().enabled = true;
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas5").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);
        count = 9;
    }

    void Test9()
    {
        GameObject.Find("Text11").GetComponent<Text>().enabled = false;// marked square has no mine, destroy
        GameObject.Find("Image11").GetComponent<Image>().enabled = false;
        GameObject.Find("Text12").GetComponent<Text>().enabled = true;// otherwise, upgrade
        GameObject.Find("Image12").GetComponent<Image>().enabled = true;

        vectors = guideController.Guide(canvas, GameObject.Find("Canvas4").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);
        count = 10;
        
    }

    void Test10()
    {
        GameObject.Find("Text12").GetComponent<Text>().enabled = false;// otherwise, upgrade
        GameObject.Find("Image12").GetComponent<Image>().enabled = false;
        GameObject.Find("Text13").GetComponent<Text>().enabled = true;// otherwise, upgrade
        GameObject.Find("Image13").GetComponent<Image>().enabled = true;

        vectors = guideController.Guide(canvas, GameObject.Find("Canvas6").GetComponent<RectTransform>(), GuideType.Rect, TranslateType.Slow, 0.5f);

        count = 12;
    }

   

    void TestCircle1()
    {
        GameObject.Find("Text13").GetComponent<Text>().enabled = false;// otherwise, upgrade
        GameObject.Find("Image13").GetComponent<Image>().enabled = false;
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas8").GetComponent<RectTransform>(), GuideType.Circle, TranslateType.Slow, 0.5f);

        GameObject.Find("Text14").GetComponent<Text>().enabled = true;
        GameObject.Find("Image14").GetComponent<Image>().enabled = true;
        count = 13;
    }

    void TestCircle2()
    {
        GameObject.Find("Text14").GetComponent<Text>().enabled = false;
        GameObject.Find("Image14").GetComponent<Image>().enabled = false;
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas9").GetComponent<RectTransform>(), GuideType.Circle, TranslateType.Slow, 0.5f);
        count = 14;
        GameObject.Find("Text15").GetComponent<Text>().enabled = true;
        GameObject.Find("Image15").GetComponent<Image>().enabled = true;
    }

    void TestCircle3()
    {
        GameObject.Find("Text15").GetComponent<Text>().enabled = false;
        GameObject.Find("Image15").GetComponent<Image>().enabled = false;
        vectors = guideController.Guide(canvas, GameObject.Find("Canvas10").GetComponent<RectTransform>(), GuideType.Circle, TranslateType.Slow, 0.5f);


        GameObject.Find("Text16").GetComponent<Text>().enabled = true;
        GameObject.Find("Image16").GetComponent<Image>().enabled = true;
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
            if (count == 11 && isInArea())
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
                GameObject.Find("Text16").GetComponent<Text>().enabled = false;
                GameObject.Find("Image16").GetComponent<Image>().enabled = false;
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

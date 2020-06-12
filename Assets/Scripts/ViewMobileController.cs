using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMobileController : MonoBehaviour
{
    //攝像機距離
    public float distance = 10.0f;
    //縮放係數
    public float scaleFactor = 1f;


    public float maxDistance = 30f;
    public float minDistance = 5f;


    //記錄上一次手機觸控位置判斷使用者是在左放大還是縮小手勢
    private Vector2 oldPosition1;
    private Vector2 oldPosition2;


    private Vector2 lastSingleTouchPosition;

    private Vector3 m_CameraOffset;
    private Camera m_Camera;

    public bool useMouse = true;

    //定義攝像機可以活動的範圍
    public float xMin = -100;
    public float xMax = 100;
    public float zMin = -100;
    public float zMax = 100;

    //這個變數用來記錄單指雙指的變換
    private bool m_IsSingleFinger;

    //初始化遊戲資訊設定
    void Start()
    {
        m_Camera = this.GetComponent<Camera>();
        m_CameraOffset = m_Camera.transform.position;
    }

    void Update()
    {
        //判斷觸控數量為單點觸控
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began || !m_IsSingleFinger)
            {
                //在開始觸控或者從兩字手指放開回來的時候記錄一下觸控的位置
                lastSingleTouchPosition = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                MoveCamera(Input.GetTouch(0).position);
            }
            m_IsSingleFinger = true;

        }
        else if (Input.touchCount > 1)
        {

            ////多点触摸, 放大缩小  
            Touch newTouch1 = Input.GetTouch(0);
            Touch newTouch2 = Input.GetTouch(1);

            //第2点刚开始接触屏幕, 只记录，不做处理  
            if (newTouch2.phase == TouchPhase.Began)
            {
                oldPosition2 = newTouch2.position;
                oldPosition1 = newTouch1.position;
                return;
            }

            //當從單指觸控進入多指觸控的時候,記錄一下觸控的位置
            //保證計算縮放都是從兩指手指觸碰開始的
            if (m_IsSingleFinger)
            {
                oldPosition1 = newTouch1.position;
                oldPosition2 = newTouch2.position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                ScaleCamera();
            }

            m_IsSingleFinger = false;
        }


        //用滑鼠的
        if (useMouse)
        {
            distance -= Input.GetAxis("Mouse ScrollWheel") * scaleFactor;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            if (Input.GetMouseButtonDown(0))
            {
                lastSingleTouchPosition = Input.mousePosition;
                Debug.Log("GetMouseButtonDown:" + lastSingleTouchPosition);
            }
            if (Input.GetMouseButton(0))
            {
                MoveCamera(Input.mousePosition);
            }
        }


    }

    /// <summary>
    /// 觸控縮放攝像頭
    /// </summary>
    private void ScaleCamera()
    {
        //計算出當前兩點觸控點的位置
        var tempPosition1 = Input.GetTouch(0).position;
        var tempPosition2 = Input.GetTouch(1).position;


        float currentTouchDistance = Vector3.Distance(tempPosition1, tempPosition2);
        float lastTouchDistance = Vector3.Distance(oldPosition1, oldPosition2);

        //計算上次和這次雙指觸控之間的距離差距
        //然後去更改攝像機的距離
        distance -= (currentTouchDistance - lastTouchDistance) * scaleFactor * Time.deltaTime;


        //把距離限制住在min和max之間
        distance = Mathf.Clamp(distance, minDistance, maxDistance);


        //備份上一次觸控點的位置，用於對比
        oldPosition1 = tempPosition1;
        oldPosition2 = tempPosition2;
    }


    //Update方法一旦呼叫結束以後進入這裡算出重置攝像機的位置
    private void LateUpdate()
    {
        var position = m_CameraOffset + m_Camera.transform.forward * -distance;
        m_Camera.transform.position = position;
    }


    private void MoveCamera(Vector3 scenePos)
    {
        Vector3 lastTouchPostion = m_Camera.ScreenToWorldPoint(new Vector3(lastSingleTouchPosition.x, lastSingleTouchPosition.y, -1));
        Vector3 currentTouchPosition = m_Camera.ScreenToWorldPoint(new Vector3(scenePos.x, scenePos.y, -1));

        Vector3 v = currentTouchPosition - lastTouchPostion;
        m_CameraOffset += new Vector3(v.x, 0, v.z) * m_Camera.transform.position.y;

        //把攝像機的位置控制在範圍內
        m_CameraOffset = new Vector3(Mathf.Clamp(m_CameraOffset.x, xMin, xMax), m_CameraOffset.y, Mathf.Clamp(m_CameraOffset.z, zMin, zMax));
        //Debug.Log(lastTouchPostion + "|" + currentTouchPosition + "|" + v);
        lastSingleTouchPosition = scenePos;
    }
}
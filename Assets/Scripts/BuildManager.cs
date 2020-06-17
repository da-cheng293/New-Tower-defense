using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;

    //表示当前选择的炮台(要建造的炮台)
    private TurretData selectedTurretData;
    //表示当前选择的炮台(场景中的游戏物体)
    private MapCube selectedMapCube;
    //表示当前cube的数字
    private GameObject selectedNumberData;

    public Text moneyText;

    public Animator moneyAnimator;

    public int money = 1000;
    //翻牌扣钱数
    public int flipcost = 100;

    public GameObject upgradeCanvas;

    private Animator upgradeCanvasAnimator;

    public Button buttonUpgrade;

    //地雷text控件，地雷数量
    public Text mineText;
    private int mineNum = 18;

    //更改地雷数量
    public void ChangeMine(int change = 0)
    {
        mineText = GameObject.Find("Canvas/Mine").GetComponent<Text>();
        mineNum += change;
        if (mineNum <= 0)
        {
            mineText.text = "Mine: \nEmpty";
        }
        else
        {
            mineText.text = "Mine: \n" + mineNum;
        }
        //Debug.Log(mineNum);     
    }

    public void ChangeMoney(int change=0)
    {
        money += change;
        moneyText.text = "￥" + money;
    }

    void Start()
    {
        upgradeCanvasAnimator = upgradeCanvas.GetComponent<Animator>();
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()==false)
            {
                //开发炮台的建造
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray,out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    Debug.Log(mapCube.name + " " + mapCube.isFlipped);

                    // 扫雷，显示数字
                    if (!mapCube.isFlipped)
                    {
                        if (money >= flipcost)
                        {
                            ChangeMoney(-flipcost);
                            mapCube.BuildNumber(mapCube);
                            if (mapCube.isMine)
                            {
                                ChangeMine(-1);
                            }
                        }
                        else
                        {
                            //提示钱不够
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }


                    //MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    else if (!mapCube.isMine && selectedTurretData != null && mapCube.turretGo == null)
                    {
                        //可以创建 
                        if (money >= selectedTurretData.cost)
                        {
                            ChangeMoney(-selectedTurretData.cost);
                            if (!mapCube.isNull)
                            {
                                // 在非null上创建
                                mapCube.BuildTurret(selectedTurretData);
                            }
                            else
                            {
                                // 在null上创建
                                mapCube.BonusTurret(selectedTurretData);
                            }
                                
                        }
                        else
                        {
                            //提示钱不够
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else if (mapCube.turretGo != null)
                    {

                        // 升级处理

                        // if (mapCube.isUpgraded)
                        // {
                        //     ShowUpgradeUI(mapCube.transform.position, true);
                        //  }
                        //  else
                        //  {
                        //    ShowUpgradeUI(mapCube.transform.position, false);
                        //   }
                        Debug.Log("reach");
                       if (mapCube == selectedMapCube && upgradeCanvas.activeInHierarchy)
                        {
                            StartCoroutine(HideUpgradeUI());
                       }
                        else
                        {
                            ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);
                        }
                        selectedMapCube = mapCube;
                    }

                }
            }
        }
    }

    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = laserTurretData;
        }
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
    }
    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;
        }
    }

    void ShowUpgradeUI(Vector3 pos, bool isDisableUpgrade=false)
    {
        StopCoroutine("HideUpgradeUI");
        upgradeCanvas.SetActive(false);
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        buttonUpgrade.interactable = !isDisableUpgrade;
    }

    IEnumerator HideUpgradeUI()
    {
        upgradeCanvasAnimator.SetTrigger("Hide");
        //upgradeCanvas.SetActive(false);
       yield return new WaitForSeconds(0.8f);
        upgradeCanvas.SetActive(false);
    }

    public void OnUpgradeButtonDown()
    {
        if (money >= selectedMapCube.turretData.costUpgraded)
        {
            ChangeMoney(-selectedMapCube.turretData.costUpgraded);
            selectedMapCube.UpgradeTurret();
        }
        else
        {
            moneyAnimator.SetTrigger("Flicker");
        }

        StartCoroutine(HideUpgradeUI());
    }
    public void OnDestroyButtonDown()
    {
        selectedMapCube.DestroyTurret();
        StartCoroutine(HideUpgradeUI());
    }
}

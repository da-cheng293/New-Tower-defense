using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;
    public TurretData Flag;

    public FlagHandler myFH;//Set a flag handler

    //表示当前选择的炮台(要建造的炮台)
    private TurretData selectedTurretData;
    //表示当前选择的炮台(场景中的游戏物体)
    private MapCube selectedMapCube;
    //表示当前cube的数字
    private GameObject selectedNumberData;

    public Text moneyText;

    public Animator moneyAnimator;

    public int money = 1000;


    public Text dropMoneyText;
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
        moneyText.text = "$" + money;
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
                    if (!mapCube.isFlipped)// 没翻，还要判定有没有插旗
                    {
                        if (myFH.flagModel)//如果有按flag 按钮进入插旗模式
                        {
                            //插旗，生成旗帜模型，
                            mapCube.buildFlag(mapCube);
                            mapCube.isFlipped = true;
                            Debug.Log("Set Flag");
                        }
                        else if (money >= flipcost)
                        {
                            ChangeMoney(-flipcost);
                            mapCube.BuildNumber(mapCube);
                            if(mapCube.isMine){
                                ChangeMine(-1);
                            }
                        }
                        else
                        {
                            //提示钱不够
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }

                    else if (mapCube.isFlipped && mapCube.hasFlag && selectedTurretData != null && mapCube.turretGo == null)//翻，有旗
                    {
                        //判定
                        //Cube确实是Mine
                        if (mapCube.name.Equals("MapCube (1)") || mapCube.name.Equals("MapCube (4)") || mapCube.name.Equals("MapCube (5)")
                || mapCube.name.Equals("MapCube (9)") || mapCube.name.Equals("MapCube (16)") || mapCube.name.Equals("MapCube (22)")
                || mapCube.name.Equals("MapCube (26)") || mapCube.name.Equals("MapCube (34)") || mapCube.name.Equals("MapCube (38)")
                || mapCube.name.Equals("MapCube (48)") || mapCube.name.Equals("MapCube (58)") || mapCube.name.Equals("MapCube (59)")
                || mapCube.name.Equals("MapCube (63)") || mapCube.name.Equals("MapCube (65)") || mapCube.name.Equals("MapCube (69)")
                || mapCube.name.Equals("MapCube (72)") || mapCube.name.Equals("MapCube (76)") || mapCube.name.Equals("MapCube (77)"))
                        {
                            
                            //Buildbonus
                            if (money >= selectedTurretData.cost)
                            {
                                ChangeMine(-1);
                                ChangeMoney(-selectedTurretData.cost);
                                mapCube.BonusTurret(selectedTurretData);
                            }
                            else
                            {
                                //提示钱不够
                                moneyAnimator.SetTrigger("Flicker");
                            }
                        }
                        else
                        {
                            //变叉
                            if (money >= selectedTurretData.cost)
                            {
                                ChangeMoney(-selectedTurretData.cost);
                                mapCube.BuildWrong(mapCube);
                            }
                            else
                            {
                                //提示钱不够
                                moneyAnimator.SetTrigger("Flicker");
                            }
                            
                        }
                    }
                    else if (mapCube.isFlipped && !mapCube.isMine && !mapCube.hasFlag && selectedTurretData != null && mapCube.turretGo == null)//翻，无旗
                    {
                        if (money >= selectedTurretData.cost)
                        {
                            ChangeMoney(-selectedTurretData.cost);
                            mapCube.BuildTurret(selectedTurretData);
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

                        //if (mapCube.isUpgraded)
                        //{
                        //    ShowUpgradeUI(mapCube.transform.position, true);
                        //}
                        //else
                        //{
                        //    ShowUpgradeUI(mapCube.transform.position, false);
                        //}
                        if (mapCube == selectedMapCube && upgradeCanvas.activeInHierarchy)
                        {
                            StartCoroutine(HideUpgradeUI());
                        }
                        else
                        {
                            dropMoneyText.text = "+$" + (int)((float)mapCube.turretData.cost * 0.8);
                            ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);
                        }
                        selectedMapCube = mapCube;
                    }

                }
            }
        }
    }


    //public void onFlagSelelcted(bool isOn) {

    //    if (isOn)
    //    {
    //        selectedTurretData = Flag;
    //        Debug.Log(isOn);
    //    }
    //}


    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = laserTurretData;
        }
        else
        {
            selectedTurretData = null;
        }
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
        else
        {
            selectedTurretData = null;
        }
    }
    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;
        }
        else
        {
            selectedTurretData = null;
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
        ChangeMoney((int)((float)selectedMapCube.turretData.cost * 0.8));
        selectedMapCube.DestroyTurret();
        StartCoroutine(HideUpgradeUI());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour {
    [HideInInspector]
    public GameObject turretGo;//保存当前cube身上的炮台
    [HideInInspector]
    public TurretData turretData;
    [HideInInspector]
    public GameObject numberGo;//保存当前cube身上的数字
    [HideInInspector]
    //public NumberData numberData;
    //[HideInInspector]
    public bool isUpgraded = false;
    public bool isFlipped = false;
    public bool isMine = false;
    public bool isNull = false;
    public bool hasFlag = false;
    
    public GameObject myFlagModel;
    public GameObject buildEffect;

    public AudioSource MineAudio;
    public AudioSource FlipAudio;
    public AudioSource UpgradeAudio;
    public AudioSource FlagAudio;
    public AudioSource BuildeAudio;

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        MineAudio = GameObject.Find("Mine_audio").GetComponent<AudioSource>();
        FlipAudio = GameObject.Find("Flip_audio").GetComponent<AudioSource>();
        UpgradeAudio = GameObject.Find("Upgrade_audio").GetComponent<AudioSource>();
        FlagAudio = GameObject.Find("FlagPut_audio").GetComponent<AudioSource>();
        BuildeAudio = GameObject.Find("Build_audio").GetComponent<AudioSource>();                
    }

    public void BuildTurret(TurretData turretData)
    {
        if (isFlipped)
        {
            if (hasFlag)
            {
                GameObject temp = myFlagModel;
                
                Destroy(myFlagModel);
                myFlagModel = null;
                //myFlagModel.gameObject.SetActive(false);
                Debug.Log("set active fail");

            }

            BuildeAudio.Play();
            this.turretData = turretData;
            isUpgraded = false;
            turretGo = GameObject.Instantiate(turretData.turretPrefab, transform.position, Quaternion.identity);
            GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);
        }
    }


    public void buildFlag(MapCube mapCube) {
        this.hasFlag = mapCube.hasFlag;
        if (!hasFlag)
        {
            hasFlag = true;
            //生成旗帜模型 Johan
            Debug.Log("生成旗帜模型");
            GameObject tempFlag = (GameObject)Resources.Load("FlagObj");
            myFlagModel = Instantiate(tempFlag, mapCube.transform.position, mapCube.transform.rotation);
            //this.myFlagModel = tempFlag;
            myFlagModel.transform.parent = transform;
            FlagAudio.Play();
        }

    }



    /**public void BuildNumber(MapCube mapCube)
    {
        this.isFlipped = mapCube.isFlipped;
        if (!isFlipped)
        {
            isFlipped = true;
            // 发现MapCube是one
            if (mapCube.name.Equals("MapCube (2)") || mapCube.name.Equals("MapCube (6)") || mapCube.name.Equals("MapCube (12)")
                || mapCube.name.Equals("MapCube (13)") || mapCube.name.Equals("MapCube (14)") || mapCube.name.Equals("MapCube (15)")
                || mapCube.name.Equals("MapCube (19)") || mapCube.name.Equals("MapCube (25)") || mapCube.name.Equals("MapCube (30)")
                || mapCube.name.Equals("MapCube (31)") || mapCube.name.Equals("MapCube (33)") || mapCube.name.Equals("MapCube (36)")
                || mapCube.name.Equals("MapCube (39)") || mapCube.name.Equals("MapCube (44)") || mapCube.name.Equals("MapCube (45)")
                || mapCube.name.Equals("MapCube (47)") || mapCube.name.Equals("MapCube (50)") || mapCube.name.Equals("MapCube (52)")
                || mapCube.name.Equals("MapCube (53)") || mapCube.name.Equals("MapCube (54)") || mapCube.name.Equals("MapCube (68)")
                || mapCube.name.Equals("MapCube (71)"))
            {
                Debug.Log("发现MapCube是one");
                //Debug.Log(mapCube.transform.rotation);
                GameObject selectedNumberData = (GameObject)Resources.Load("One");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
            }
            // 发现MapCube是two
            else if (mapCube.name.Equals("MapCube (3)") || mapCube.name.Equals("MapCube (8)") || mapCube.name.Equals("MapCube (10)")
                || mapCube.name.Equals("MapCube (18)") || mapCube.name.Equals("MapCube (21)") || mapCube.name.Equals("MapCube (23)")
                || mapCube.name.Equals("MapCube (28)") || mapCube.name.Equals("MapCube (29)") || mapCube.name.Equals("MapCube (37)")
                || mapCube.name.Equals("MapCube (49)") || mapCube.name.Equals("MapCube (55)") || mapCube.name.Equals("MapCube (56)")
                || mapCube.name.Equals("MapCube (57)") || mapCube.name.Equals("MapCube (60)") || mapCube.name.Equals("MapCube (62)")
                || mapCube.name.Equals("MapCube (70)") || mapCube.name.Equals("MapCube (73)") || mapCube.name.Equals("MapCube (75)")
                || mapCube.name.Equals("MapCube (78)"))
            {
                
                Debug.Log("在"+ mapCube.name + "发现MapCube是two");
                GameObject selectedNumberData = (GameObject)Resources.Load("Two");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
            }
            // 发现MapCube是three
            else if (mapCube.name.Equals("MapCube (17)"))
            {

                Debug.Log("在" + mapCube.name + "发现MapCube是three");
                GameObject selectedNumberData = (GameObject)Resources.Load("Three");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
            }
            // 发现MapCube是four
            else if (mapCube.name.Equals("MapCube (64)"))
            {

                Debug.Log("在" + mapCube.name + "发现MapCube是four");
                GameObject selectedNumberData = (GameObject)Resources.Load("Four");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
            }
            // 发现MapCube是雷
            else if (mapCube.name.Equals("MapCube (1)") || mapCube.name.Equals("MapCube (4)") || mapCube.name.Equals("MapCube (5)")
                || mapCube.name.Equals("MapCube (9)") || mapCube.name.Equals("MapCube (16)") || mapCube.name.Equals("MapCube (22)")
                || mapCube.name.Equals("MapCube (26)") || mapCube.name.Equals("MapCube (34)") || mapCube.name.Equals("MapCube (38)")
                || mapCube.name.Equals("MapCube (48)") || mapCube.name.Equals("MapCube (58)") || mapCube.name.Equals("MapCube (59)")
                || mapCube.name.Equals("MapCube (63)") || mapCube.name.Equals("MapCube (65)") || mapCube.name.Equals("MapCube (69)")
                || mapCube.name.Equals("MapCube (72)") || mapCube.name.Equals("MapCube (76)") || mapCube.name.Equals("MapCube (77)"))
            {
                isMine = true;
                Debug.Log("在" + mapCube.name + "发现MapCube是雷");
                GameObject selectedNumberData = (GameObject)Resources.Load("Mine1");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
            }
            // 发现MapCube是bonus

            else
            {
                isNull = true;
                Debug.Log("在" + mapCube.name + "发现MapCube是空");
                GameObject selectedNumberData = (GameObject)Resources.Load("Null");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
            }


            //this.numberData = numberData;
            //Debug.Log(numberData);
            //numberGo = GameObject.Instantiate(numberData, transform.position, Quaternion.identity);
            //Debug.Log(numberGo);
            GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);
        }
    }*/
    public void BuildNumber(MapCube mapCube)
    {
        this.isFlipped = mapCube.isFlipped;
        if (!isFlipped)
        {
            isFlipped = true;
            // 发现MapCube是one
            if (mapCube.name.Equals("MapCube1"))
            {
                Debug.Log("发现MapCube是one");
                //Debug.Log(mapCube.transform.rotation);
                GameObject selectedNumberData = (GameObject)Resources.Load("One");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
                FlipAudio.Play();
            }
            // 发现MapCube是two
            else if (mapCube.name.Equals("MapCube2"))
            {

                Debug.Log("在" + mapCube.name + "发现MapCube是two");
                GameObject selectedNumberData = (GameObject)Resources.Load("Two");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
                FlipAudio.Play();
            }
            // 发现MapCube是three
            else if (mapCube.name.Equals("MapCube3"))
            {

                Debug.Log("在" + mapCube.name + "发现MapCube是three");
                GameObject selectedNumberData = (GameObject)Resources.Load("Three");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
                FlipAudio.Play();
            }
            // 发现MapCube是four
            else if (mapCube.name.Equals("MapCube4"))
            {

                Debug.Log("在" + mapCube.name + "发现MapCube是four");
                GameObject selectedNumberData = (GameObject)Resources.Load("Four");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
                FlipAudio.Play();
            }
            // 发现MapCube是雷
            else if (mapCube.name.Equals("MapCubeM"))
            {                                                              
                isMine = true;
                Debug.Log("在" + mapCube.name + "发现MapCube是雷");
                GameObject selectedNumberData = (GameObject)Resources.Load("Mine1");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
                MineAudio.Play();
            }
            // 发现MapCube是bonus

            else
            {
                isNull = true;
                Debug.Log("在" + mapCube.name + "发现MapCube是空");
                GameObject selectedNumberData = (GameObject)Resources.Load("Null");
                Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
                FlipAudio.Play();
            }
            

            //this.numberData = numberData;
            //Debug.Log(numberData);
            //numberGo = GameObject.Instantiate(numberData, transform.position, Quaternion.identity);
            //Debug.Log(numberGo);
            GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);
        }
    }

    //在bonus点上建立Tower
    public void BonusTurret(TurretData turretData)
    {
        UpgradeAudio.Play();
        //Debug.Log("123");
        this.turretData = turretData;
        isUpgraded = true;
        turretGo = GameObject.Instantiate(turretData.turretUpgradedPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f); 
    }

    public void BuildWrong(MapCube mapCube)
    {                 
        mapCube.DestroyFlag();
        GameObject selectedNumberData = (GameObject)Resources.Load("Mine");
        Instantiate(selectedNumberData, mapCube.transform.position, mapCube.transform.rotation);
        MineAudio.Play();
    }

    public void UpgradeTurret()
    {
        if(isUpgraded==true)return;

        Destroy(turretGo);
        isUpgraded = true;
        turretGo = GameObject.Instantiate(turretData.turretUpgradedPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    
    public void DestroyTurret()
    {
        Destroy(turretGo);
        isUpgraded = false;
        turretGo = null;
        turretData=null;
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    public void DestroyFlag()
    {
        
        Destroy(myFlagModel);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    void OnMouseEnter()
    {

        if (turretGo == null && EventSystem.current.IsPointerOverGameObject()==false)
        {
            renderer.material.color = Color.red;
        }
    }
    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}

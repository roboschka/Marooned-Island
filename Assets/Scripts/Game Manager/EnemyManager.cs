using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;

    [SerializeField]
    private GameObject spider_Prefab, dragon_Prefab;

    public Transform[] dragon_SpawnPoints, spider_SpawnPoints;

    [SerializeField]
    private int dragon_Enemy_Count, spider_Enemy_Count;

    private int initial_Dragon_Count, initial_Spider_Count;

    public int currentSpider, currentDragon;
    public int StageNumber;

    public Text enemyText;
    public StageManager myStageManager;

    void Awake () {
        MakeInstance();
	}

    void Start() {
        //initial stage
        StageNumber = 1;

        initial_Dragon_Count = dragon_Enemy_Count;
        initial_Spider_Count = spider_Enemy_Count;
        SpawnEnemies();
        currentDragon = dragon_Enemy_Count;
        currentSpider = spider_Enemy_Count;
        enemyText.text = (currentDragon + currentSpider).ToString();
    }

    void Update() {
        //ngecek kalau semua musuh udah dihabisi
         if(currentDragon == 0 && currentSpider == 0) {
            Debug.Log("Next Stage");
            myStageManager.ShowCanvas();
        }
    }

    void FixedUpdate() {
        //update enemy counter in UI
        enemyText.text = (currentDragon + currentSpider).ToString(); 
    }

    void MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    void SpawnEnemies() {
        SpawnDragons();
        SpawnSpiders();
    }

    void SpawnDragons() {

        int index = 0;
        for (int i = 0; i < dragon_Enemy_Count; i++) {
            if (index >= dragon_SpawnPoints.Length) {
                index = 0;
            }
            Instantiate(dragon_Prefab, dragon_SpawnPoints[index].position, Quaternion.identity);
            index++;
        }
        //dragon_Enemy_Count = 0;
    }

    void SpawnSpiders() {
        int index = 0;
        for (int i = 0; i < spider_Enemy_Count; i++) {
            if (index >= spider_SpawnPoints.Length)
            {
                index = 0;
            }
            Instantiate(spider_Prefab, spider_SpawnPoints[index].position, Quaternion.identity);
            index++;
        }
    }

    public void EnemyDied(bool isDragon) {
        //if the enemy that died is a dragon kind
        if(isDragon) {
            currentDragon--;
            //Debug.Log(currentDragon);

        } else {
            currentSpider--;
            //Debug.Log(currentSpider);
        }

    }

} // class end



































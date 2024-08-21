using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PPENEMYSPAWNER : MonoBehaviour
    {
        [SerializeField] private List<PPENEMY> ppENEMY;
        [SerializeField] private TMP_Text ppTimer;
        [SerializeField] private TMP_Text ppLevel;
        [SerializeField] private PPGameOver ppGameOver;
        
        private int ppLevelNumber = 0;
        private float ppTimerLvl = 60;
        
        private float PPMAXX;
        private float PPMAXY;

        private float PPTIMER;
        
        private void Start()
        {
            var leftScreenPoint = new Vector3(0, Screen.height, 0);
            var ppALL = Camera.main.ScreenToWorldPoint(leftScreenPoint);
            
            PPMAXX = ppALL.x;
            PPMAXX += 0.25f;
            
            PPMAXY = ppALL.y;
            PPMAXY += 2f;
            
            ppLevelNumber = PlayerPrefs.GetInt("PPLEVEL", 1);
            
            ppLevel.text = $"level {ppLevelNumber}";
        }

        private void Update()
        {
            if (!PPSTATICHELPER.PPisGame)
                return;
            
            ppTimerLvl -= Time.deltaTime;
            
            if (ppTimerLvl <= 0)
            {
                ppGameOver.PPSHOWWIN(ppLevelNumber);
                return;
            }
            
            var PPminutes = Mathf.FloorToInt(ppTimerLvl / 60);
            var PPseconds = Mathf.FloorToInt(ppTimerLvl % 60);

            ppTimer.text = PPminutes.ToString("00") + ":" + PPseconds.ToString("00");
            
            PPTIMER += Time.deltaTime;
            if (!(PPTIMER > 1.0f)) 
                return;
            
            PPTIMER = 0.0f;
            
            Spawn();
        }

        private void Spawn()
        {
            Instantiate(ppENEMY[Random.Range(0, ppENEMY.Count)], new Vector3(Random.Range(PPMAXX, -PPMAXX), PPMAXY, 0), Quaternion.identity);
        }
    }

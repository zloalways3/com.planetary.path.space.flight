    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class PPGAMEMANAGER : MonoBehaviour
    {
        [SerializeField] private CanvasGroup ppMAIN;
        [SerializeField] private CanvasGroup ppRules;
        [SerializeField] private CanvasGroup ppExit;
        
        [SerializeField] private Button ppPLAY;
        [SerializeField] private Button ppRULES;
        [SerializeField] private Button ppEXIT;
        [SerializeField] private Button ppEXITexit;

        [SerializeField] private Button[] ppBacks;

        private void Awake()
        {
            ppChanger();
            
            ppPLAY.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(2);
            });
            ppRULES.onClick.AddListener(() =>
            {
                ppMAIN.PPCHANGE(false);
                ppRules.PPCHANGE(true);
            });
            ppEXIT.onClick.AddListener(() =>
            {
                ppMAIN.PPCHANGE(false);
                ppExit.PPCHANGE(true);
            });
            
            ppEXITexit.onClick.AddListener(Application.Quit);
            
            foreach (var ppBack in ppBacks)
                ppBack.onClick.AddListener(ppChanger);
            
            return;

            void ppChanger()
            {
                ppMAIN.PPCHANGE(true);
                ppRules.PPCHANGE(false);
                ppExit.PPCHANGE(false);
            }
        }
    }

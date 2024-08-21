using System;
using UnityEngine;

public class PPPLAYER : MonoBehaviour
{
    [SerializeField] private PPBUTTON PPLEFT;
    [SerializeField] private PPBUTTON PPRIGHT;
    
    [SerializeField] private PPGameOver ppGameOver;
    
    [SerializeField] private float PPSPEED = 20f;

    private float PPMAXX;

    private void Awake()
    {
        PPLEFT.PPPRESS += PPMOVELEFT;
        PPRIGHT.PPPRESS += PPMOVERIGHT;
    }

    private void Start()
    {
        var leftScreenPoint = new Vector3(0, Screen.height / 2, 0);
        PPMAXX = Camera.main.ScreenToWorldPoint(leftScreenPoint).x;
        PPMAXX += 0.25f;
    }

    private void PPMOVELEFT()
    {
        PPMove(-1);
    }

    private void PPMOVERIGHT()
    {
        PPMove(1);
    }

    private void PPMove(int ppdir)
    {
        if (!PPSTATICHELPER.PPisGame)
            return;
        
        var ppNewPos = transform.position + (Vector3)((Vector2.right * ppdir) * PPSPEED * Time.deltaTime);
        
        ppNewPos.x = Mathf.Clamp(ppNewPos.x, PPMAXX, -PPMAXX);

        transform.position = ppNewPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PPSTATICHELPER.PPisGame = false;
        ppGameOver.PPSHOWLOSE();
    }

    private void OnDestroy()
    {
        PPLEFT.PPPRESS -= PPMOVELEFT;
        PPRIGHT.PPPRESS -= PPMOVERIGHT;
    }
}

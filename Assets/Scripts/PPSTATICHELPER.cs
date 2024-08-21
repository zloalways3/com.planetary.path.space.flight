using UnityEngine;

public static class PPSTATICHELPER
{
    public static bool PPisGame = false;

    public static void PPCHANGE(this CanvasGroup ppcg, bool ppval)
    {
        ppcg.alpha = ppval ? 1 : 0;
        ppcg.interactable = ppval;
        ppcg.blocksRaycasts = ppval;
    } 
}
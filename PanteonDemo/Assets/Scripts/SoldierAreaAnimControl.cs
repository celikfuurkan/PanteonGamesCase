using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoldierAreaAnimControl : MonoBehaviour
{
    [SerializeField] GameObject soldier1;
    [SerializeField] GameObject soldier2;
    [SerializeField] GameObject soldier3;

    void Start()
    {
        StartCoroutine(SoldierControl());
    }


    //DoTween ile Informations menüsündeki askerlere animasyon verildi
    public IEnumerator SoldierControl()
    {
        soldier1.transform.DOJump(soldier1.transform.position,4f,1,1f).SetLoops(-1);
        yield return new WaitForSeconds(0.5f);
        soldier2.transform.DOJump(soldier2.transform.position, 4f, 1, 1f).SetLoops(-1);
        yield return new WaitForSeconds(0.3f);
        soldier3.transform.DOJump(soldier3.transform.position, 4f, 1, 1f).SetLoops(-1);
    }
}

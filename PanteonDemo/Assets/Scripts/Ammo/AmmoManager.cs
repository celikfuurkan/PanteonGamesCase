using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AmmoManager : MonoBehaviour
{
    [SerializeField] GameObject ammo;

    void Update()
    {
        /// <summary>
        /// Sað týk yapýlýnca mouse pozisyonuna bir raycast atýlýr ve eðer o raycast ismi veya tagý
        /// Power, Barrack, Character olan bir gameobjeye çarparsa bir mermi yaratýr.
        /// </summary>
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider == null)
            {
                return;
            }

            if (hit.collider.CompareTag("Power") || hit.collider.CompareTag("Barrack") || hit.collider.name.StartsWith("Character") && (BuildControl.selectedSoldier.name.StartsWith("Character") || BuildControl.selectedSoldier.name=="Character") )
            {
                GameObject GO = Instantiate(ammo, BuildControl.selectedSoldier.transform.position, Quaternion.identity);
                GO.transform.DOMove(mousePosition, 0.4f).SetEase(Ease.Linear);
            }
        }
    }
}

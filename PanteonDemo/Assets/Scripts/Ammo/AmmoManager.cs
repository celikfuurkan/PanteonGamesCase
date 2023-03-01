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
        /// Sa� t�k yap�l�nca mouse pozisyonuna bir raycast at�l�r ve e�er o raycast ismi veya tag�
        /// Power, Barrack, Character olan bir gameobjeye �arparsa bir mermi yarat�r.
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

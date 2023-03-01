using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildControl : MonoBehaviour
{
    public GameObject selectInfo;
    public static GameObject selectedBuild;   //se�ilen build
    public static GameObject selectedSoldier; //se�ilen asker
    public GameObject _selectedSoldier;       //se�ilen askerin public ama static olmayan hali
    


    void Update()
    {

        /// <summary>
        /// Mousenin bulundu�u pozisyona sol t�k ile bir raycast at�l�r ve g�rd��� objenim ismi "Character"
        /// i�eriyorsa selectedSoldier'a se�ilen asker atan�r. E�er g�rd��� objenin ismi "Barrack(Clone)" ise
        /// asker yaratma penceresi (Informations) a��l�r.
        /// </summary>
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider == null)
                return;
            

            if (hit.collider.name.Contains("Character"))
            {
                if (selectedSoldier!=null)
                {
                    selectedSoldier.GetComponent<CharacterPathfindingMovementHandler>().enabled = false; // E�er selectedSoldier, null de�ilse se�ti�im askerin scriptini false yap
                }
                
                selectedSoldier = hit.collider.gameObject;
                selectedSoldier.GetComponent<CharacterPathfindingMovementHandler>().enabled = true; //se�ti�im askerin scriptini true yap
            }

            _selectedSoldier = selectedSoldier;

            if (hit.collider.name == "Barrack(Clone)")
            {
                selectedBuild = hit.collider.gameObject;
                selectInfo.SetActive(true);
            }
        }
    }
}

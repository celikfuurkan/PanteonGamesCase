using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildControl : MonoBehaviour
{
    public GameObject selectInfo;
    public static GameObject selectedBuild;   //seçilen build
    public static GameObject selectedSoldier; //seçilen asker
    public GameObject _selectedSoldier;       //seçilen askerin public ama static olmayan hali
    


    void Update()
    {

        /// <summary>
        /// Mousenin bulunduðu pozisyona sol týk ile bir raycast atýlýr ve gördüðü objenim ismi "Character"
        /// içeriyorsa selectedSoldier'a seçilen asker atanýr. Eðer gördüðü objenin ismi "Barrack(Clone)" ise
        /// asker yaratma penceresi (Informations) açýlýr.
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
                    selectedSoldier.GetComponent<CharacterPathfindingMovementHandler>().enabled = false; // Eðer selectedSoldier, null deðilse seçtiðim askerin scriptini false yap
                }
                
                selectedSoldier = hit.collider.gameObject;
                selectedSoldier.GetComponent<CharacterPathfindingMovementHandler>().enabled = true; //seçtiðim askerin scriptini true yap
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealtControl : MonoBehaviour
{
    [SerializeField] Slider healt;
    [SerializeField] TextMeshProUGUI healtNumber;

    /// <summary>
    /// Oyun alan�nda bulunan t�m objelerin (units or builds) Healt Bar lar� bu fonksiyonda hesaplan�r.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.name == BuildControl.selectedSoldier.name)
            return;

        if (BuildControl.selectedSoldier.GetComponent<SpriteRenderer>().sprite.name == "Soldier-1")
        {
            healt.value -= 10;
            healtNumber.text = healt.value.ToString();
        }
        else if (BuildControl.selectedSoldier.GetComponent<SpriteRenderer>().sprite.name == "Soldier-2")
        {
            healt.value -= 5;
            healtNumber.text = healt.value.ToString();
        }
        else if (BuildControl.selectedSoldier.GetComponent<SpriteRenderer>().sprite.name == "Soldier-3")
        {
            healt.value -= 2;
            healtNumber.text = healt.value.ToString();
        }


        if (collision.tag=="Ammo")
        {
            if (healt.value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoOperations : MonoBehaviour
{

    /// <summary>
    /// E�er mermi ismi veya tag� Power, Barrack, Character olan bir gameobjeye �arparsa �arpt��� objenin
    /// rengi de�i�ir ve mermi �arpt�ktan 0.3f s�resinde yok yolur.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == BuildControl.selectedSoldier.name)
        {
            return;
        }
            
        if (collision.tag=="Power" || collision.tag == "Barrack")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 225);
            StartCoroutine(Destroy(collision));
        }

        if (collision.name.Contains("Character"))
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 225);
            StartCoroutine(Destroy(collision));
        }
    }

    IEnumerator Destroy(Collider2D collision)
    {
        yield return new WaitForSeconds(0.1f);
        if (collision != null)
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 225);
        }
        yield return new WaitForSeconds(0.2f);
        
        Destroy(gameObject);
        
    }

    

}

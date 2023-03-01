using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSoldierManager : MonoBehaviour
{
    Vector3 soldierPosition;
    [SerializeField] GameObject character;
    [SerializeField] GameObject soldier1;
    [SerializeField] GameObject soldier2;
    [SerializeField] GameObject soldier3;
    [SerializeField] AudioSource sound;
    public static GameObject GO;
    int i=0;

    /// <summary>
    /// Bu script ile harita üzerinde asker yaratýlýr.
    /// </summary>

    public void CrateSoldier(string soldierName)
    {
        soldierPosition = soldierName switch  //seçilen asker hücre boyutuna (32px) göre yaratýlýr.
        {
            "Soldier-1" => (Pathfinding.Instance.GetTile(BuildControl.selectedBuild.transform.position) + new Vector3Int(2, 1)) *
                             Pathfinding.Instance.grid.GetCellSize() + Vector3.one * Pathfinding.Instance.grid.GetCellSize() * .5f,
            "Soldier-2" => (Pathfinding.Instance.GetTile(BuildControl.selectedBuild.transform.position) + new Vector3Int(2, -1)) *
                             Pathfinding.Instance.grid.GetCellSize() + Vector3.one * Pathfinding.Instance.grid.GetCellSize() * .5f,
            "Soldier-3" => (Pathfinding.Instance.GetTile(BuildControl.selectedBuild.transform.position) + new Vector3Int(2, -3)) *
                             Pathfinding.Instance.grid.GetCellSize() + Vector3.one * Pathfinding.Instance.grid.GetCellSize() * .5f,
            _ => soldierPosition // default case
        };

        soldierPosition.z = 0;

        Dictionary<string, GameObject> soldierDictionary = new Dictionary<string, GameObject>()
        {
            { "Soldier-1", soldier1 },
            { "Soldier-2", soldier2 },
            { "Soldier-3", soldier3 }
        };

        if (soldierDictionary.ContainsKey(soldierName))   //character objesi ile yaratýlan asker eþitlenir ve crate edilen character nesnesine ID verilerek eþsiz olamasý saðlanýr.
        {
            GO = Instantiate(character, soldierPosition, Quaternion.identity);
            GameObject soldierPrefab = soldierDictionary[soldierName];
            GameObject GO_soldier = Instantiate(soldierPrefab, soldierPosition, Quaternion.identity);
            GO_soldier.transform.localScale *= 3;
            GO.GetComponent<SpriteRenderer>().sprite = GO_soldier.GetComponent<SpriteRenderer>().sprite;
            GO.SetActive(true);
            GO.name="Character(Clone)" + i;
            SoundEffect.RandomNumber();
            sound.clip=SoundEffect.sound[SoundEffect.random];
            sound.Play();
            i++;

            
            Destroy(GO_soldier);
        }
    }
}

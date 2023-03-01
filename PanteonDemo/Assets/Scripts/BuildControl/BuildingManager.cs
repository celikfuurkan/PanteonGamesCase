using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject currentBuild;
    public CustomCursor customCursor;
    public static GameObject _currentBuild;

    [SerializeField] Testing _testing;

    /// <summary>
    /// Seçilen build (barrack veya power) harita üzerinde mouse pozisyonunda gride göre yaratýlr.
    /// </summary>
    public void ChangeBuild(GameObject build)
    {
        currentBuild = build;
        _currentBuild = build;
        customCursor.gameObject.SetActive(true);
        customCursor.GetComponent<SpriteRenderer>().sprite = currentBuild.GetComponent<SpriteRenderer>().sprite;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&&currentBuild)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (currentBuild.name == "Barrack")
            {
                Vector3 buildPosition = new Vector3(Pathfinding.Instance.GetTile(mousePosition).x - 0.5f, Pathfinding.Instance.GetTile(mousePosition).y - 0.5f) *
                Pathfinding.Instance.grid.GetCellSize() + Vector3.one * Pathfinding.Instance.grid.GetCellSize() * .5f;
                buildPosition.z = 0;

                Instantiate(currentBuild, buildPosition, Quaternion.identity).gameObject.transform.localScale *= 12;
                _testing.denem();
            }
            else if(currentBuild.name == "Power")
            {
                Vector3 buildPosition = new Vector3(Pathfinding.Instance.GetTile(mousePosition).x - 0.5f, Pathfinding.Instance.GetTile(mousePosition).y) *
                Pathfinding.Instance.grid.GetCellSize() + Vector3.one * Pathfinding.Instance.grid.GetCellSize() * .5f;
                buildPosition.z = 0;

                Instantiate(currentBuild, buildPosition, Quaternion.identity).gameObject.transform.localScale *= 7;
                _testing.denem();
            }
                

            Cursor.visible = true;
            currentBuild = null;
            _currentBuild = null;
            customCursor.GetComponent<SpriteRenderer>().sprite = null;

        }
    }


}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour {

    [SerializeField] GameObject character;


    [SerializeField] 
    private PathfindingVisual pathfindingVisual;

    [SerializeField] 
    private CharacterPathfindingMovementHandler characterPathfinding;

    private Pathfinding pathfinding;
    private void Start() {
        pathfinding = new Pathfinding(32, 32);
        pathfindingVisual.SetGrid(pathfinding.GetGrid());
    }

    

    private void Update() {
        
        if (Input.GetMouseButtonDown(1)) {

            if (BuildControl.selectedSoldier == null)
                return;

            if (BuildControl.selectedSoldier.name.StartsWith("Soldier-"))
                Destroy(BuildControl.selectedSoldier);

            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null) {
                for (int i=0; i<path.Count - 1; i++) {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i+1].x, path[i+1].y) * 10f + Vector3.one * 5f, Color.green, 5f);
                }
            }
            characterPathfinding.SetTargetPosition(mouseWorldPosition);
        }
        
    }

    public void GridChoose()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (BuildingManager._currentBuild == null)
            {
                return;
            }

            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);


            // Bu if 4x4 yer kaplar
            if (BuildingManager._currentBuild.name == "Barrack" && BuildingManager._currentBuild.name != null) // 4x4 lük yer kaplar
            {
                for (int i = -1; i < 3; i++)
                    pathfinding.GetNode(x - 2, y - i).SetIsWalkable(!pathfinding.GetNode(x - 2, y - i).isWalkable);
                for (int i = -2; i < 2; i++)
                    pathfinding.GetNode(x + 1, y + i).SetIsWalkable(!pathfinding.GetNode(x + 1, y + i).isWalkable);

                pathfinding.GetNode(x, y + 1).SetIsWalkable(!pathfinding.GetNode(x, y + 1).isWalkable);
                pathfinding.GetNode(x - 1, y + 1).SetIsWalkable(!pathfinding.GetNode(x - 1, y + 1).isWalkable);

                pathfinding.GetNode(x, y - 2).SetIsWalkable(!pathfinding.GetNode(x, y - 2).isWalkable);
                pathfinding.GetNode(x - 1, y - 2).SetIsWalkable(!pathfinding.GetNode(x - 1, y - 2).isWalkable);
            }
            // bu else if 2x3 lük yer kaplar
            else if (BuildingManager._currentBuild.name == "Power" && BuildingManager._currentBuild.name != null) // bu else if 2x3 lük yer kaplar
            {
                for (int i = -1; i < 2; i++)
                    pathfinding.GetNode(x - 1, y - i).SetIsWalkable(!pathfinding.GetNode(x - 1, y - i).isWalkable);
                for (int i = -1; i < 2; i++)
                    pathfinding.GetNode(x, y - i).SetIsWalkable(!pathfinding.GetNode(x, y - i).isWalkable);
            }
        }
    }
}

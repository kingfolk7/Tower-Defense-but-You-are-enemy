using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tower;
    public Transform spawnRoot;
    int spawnID = 1;
    public Tilemap spawnTilemap;


    private void Update()
    {
        DetechSpawnPoint();
    }

    void DetechSpawnPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var cellPosDefault = spawnTilemap.WorldToCell(mousepos);
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);

            if(spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                SpawnCharacter(cellPosCentered);
                spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                
            }
        }
    }

    void SpawnCharacter(Vector3 position)
    {
        GameObject towerspawn = Instantiate(tower, spawnRoot);
        towerspawn.transform.position = position;
    }
}
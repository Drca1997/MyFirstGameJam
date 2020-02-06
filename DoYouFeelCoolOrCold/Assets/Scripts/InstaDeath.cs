using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InstaDeath : MonoBehaviour
{
    public GameObject Player;
    private Tilemap tilemap;
    private TileBase tile;
    private Grid grid;

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.name == "Collisions")
        {
           Vector3 temp;
           Vector3Int coordenadas;
           tilemap = collision.otherCollider.GetComponent<Tilemap>();
           grid = tilemap.layoutGrid;
           temp = grid.WorldToCell(collision.GetContact(0).point);
           coordenadas = Vector3Int.RoundToInt(temp);
           tile = tilemap.GetTile(coordenadas);
           Debug.Log("TILE: " + tile);
           if (tile)
           {
                if (tile.name.Equals("lava"))
                {
                    Player.GetComponent<Health>().Death();
                }
           }

        }
       
    }
}

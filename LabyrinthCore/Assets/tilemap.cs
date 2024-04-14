using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AddComponentsToTile : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;

    void Start()
    {
        // Convert the tile to a GameObject
        GameObject tileGameObject = tilemap.GetInstantiatedObject(new Vector3Int(0, 0, 0));

        // Add Rigidbody2D component to the tile GameObject
        Rigidbody2D rb2D = tileGameObject.AddComponent<Rigidbody2D>();

        // Add BoxCollider2D component to the tile GameObject
        BoxCollider2D boxCollider2D = tileGameObject.AddComponent<BoxCollider2D>();

        // Optionally, configure Rigidbody2D and BoxCollider2D properties
        rb2D.bodyType = RigidbodyType2D.Static; // Set body type to static or dynamic based on your requirements
        boxCollider2D.size = new Vector2(1f, 1f); // Set collider size based on your tile size
    }
}
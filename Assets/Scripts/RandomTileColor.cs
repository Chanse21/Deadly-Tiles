using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTileColor : MonoBehaviour
    {
        public float changeInterval = 1f; // Time in seconds between color changes
        private Renderer tileRenderer; // For standard GameObjects
        private Tilemap tilemap; // For Tilemaps
        private Vector3Int tilePosition; // For Tilemaps

        void Start()
        {
            // Check if it's a standard GameObject with a Renderer
            tileRenderer = GetComponent<Renderer>();

            // Check if it's part of a Tilemap
            if (transform.parent != null)
            {
                tilemap = transform.parent.GetComponent<Tilemap>();
                if (tilemap != null)
                {
                    // Get the local position of the tile within the Tilemap
                    tilePosition = tilemap.WorldToCell(transform.position);
                    // Ensure the tile can have its color changed
                    tilemap.SetTileFlags(tilePosition, TileFlags.None); 
                }
            }
            
            // Start the color changing routine
            InvokeRepeating("ChangeColor", 0f, changeInterval);
        }

        void ChangeColor()
        {
            // Generate a random color
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            // Apply the color based on whether it's a standard GameObject or a Tilemap tile
            if (tileRenderer != null)
            {
                tileRenderer.material.color = randomColor;
            }
            else if (tilemap != null)
            {
                tilemap.SetColor(tilePosition, randomColor);
            }
        }
    }

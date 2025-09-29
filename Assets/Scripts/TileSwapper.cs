using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSwapper : MonoBehaviour
{
    // Public variables to assign the tiles in the Inspector
    public Transform tileA;
    public Transform tileB;

    // Time it takes for the tiles to swap positions
    public float swapDuration = 1.0f;

    // Interval between automatic swaps
    public float swapInterval = 2.0f;

    private Vector3 positionA;
    private Vector3 positionB;

    void Start()
    {
        // Store the initial positions of the tiles
        positionA = tileA.position;
        positionB = tileB.position;

        // Start the coroutine for automatic swapping
        StartCoroutine(AutoSwapTiles());
    }

    private IEnumerator AutoSwapTiles()
    {
        while (true) // Infinite loop to keep swapping
        {
            // Wait for the specified interval before swapping
            yield return new WaitForSeconds(swapInterval);

            // Start the animated swap
            yield return StartCoroutine(MoveAndSwap());

            // After swapping, update the stored positions
            Vector3 tempPos = positionA;
            positionA = positionB;
            positionB = tempPos;
        }
    }

    private IEnumerator MoveAndSwap()
    {
        float timeElapsed = 0f;

        Vector3 startPosA = tileA.position;
        Vector3 startPosB = tileB.position;

        Vector3 endPosA = positionB; // TileA moves to B's position
        Vector3 endPosB = positionA; // TileB moves to A's position

        while (timeElapsed < swapDuration)
        {
            // Calculate the interpolation ratio (0 to 1)
            float t = timeElapsed / swapDuration;

            // Use Vector3.Lerp to smoothly move the tiles
            tileA.position = Vector3.Lerp(startPosA, endPosA, t);
            tileB.position = Vector3.Lerp(startPosB, endPosB, t);

            // Increment time and wait for the next frame
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the tiles snap to their final positions
        tileA.position = endPosA;
        tileB.position = endPosB;
    }
}
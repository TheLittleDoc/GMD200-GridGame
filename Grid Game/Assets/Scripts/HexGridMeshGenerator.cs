// Programmed by Arija

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class HexGridMeshGenerator : MonoBehaviour
{
    /*
    [field: SerializeField] public LayerMask gridLayer { get; private set; }
    [field: SerializeField] public HexGrid hexGrid { get; private set; }

    private void Awake()
    {
        if (hexGrid == null) 
        { 
            hexGrid = GetComponentInParent<HexGrid>(); 
        }
        if (hexGrid == null)
        {
            Debug.LogError("HexGridMeshGenerator could not find a HexGrid component in its parent or itself.");
        }
    }

    public void CreateHexMesh()
    {
        CreateHexMesh(hexGrid.Width, hexGrid.Height, hexGrid.HexSize, hexGrid.Orientation, gridLayer);
    }

    public void CreateHexMesh(HexGrid hexGrid, LayerMask layerMask)
    {
        this.hexGrid = hexGrid;
        this.gridLayer = layerMask;
        CreateHexMesh(hexGrid.Width, hexGrid.Height, hexGrid.HexSize, hexGrid.Orientation, layerMask);
    }

    public void CreateHexMesh(int width, int height, float hexSize, HexOrientation orientation, LayerMask layerMask)
    {
        ClearHexGridMesh();
        Vector3[] vertices = new Vector3[7 * width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 centerPosition = HexMetrics.Center(hexSize, x, y, orientation);
                vertices[(y * width + x) * 7] = centerPosition;
                for (int s = 0; s < HexMetrics.Corners(hexSize, orientation).Length; s++)
                {
                    vertices[(y * width + x) * 7 + s + 1] = centerPosition + HexMetrics.Corners(hexSize, orientation)[s % 6];
                }
            }
        }

        int[] triangles = new int[3 * 6 * width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                for (int s = 0; s < HexMetrics.Corners(hexSize, orientation).Length; s++)
                {
                    int cornerIndex = s + 2 > 6 ? s + 2 - 6 : s + 2;
                    triangles[3 * 6 * (y * width + x) + s * 3 + 0] = (y * width + x) * 7;
                    triangles[3 * 6 * (y * width + x) + s * 3 + 1] = (y * width + x) * 7 + s + 1;
                    triangles[3 * 6 * (y * width + x) + s * 3 + 2] = (y * width + x) * 7 + cornerIndex;
                }
            }
        }
    }



    public void ClearHexGridMesh()
    {
        if (GetComponent<MeshFilter>.sharedMesh == null)
        {
            return;
        }
        GetComponent<MeshFilter>().sharedMesh.Clear();
        GetComponent<MeshCollider>().sharedMesh.Clear();
    }

*/
} 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    TerrainData m_terrainData = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        for (int i = 0; i < m_terrainData.alphamapTextureCount; ++i)
        {
            SplatmapHelperImpl.CreatePNG(m_terrainData.GetAlphamapTexture(i), Application.persistentDataPath + "/testdata.png");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

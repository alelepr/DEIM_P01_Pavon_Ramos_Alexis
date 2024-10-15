using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private GameObject[] levelPieces; //array de piezas
    [SerializeField] private int pieceHeight; //altura de pieza
    [SerializeField] private int levelHeight; //altura de nivel

    [SerializeField] private List<GameObject> piecesToUse; //bolsa de piezas que usaremos en el nivel

    [SerializeField] private GameObject[] startPieces;
    [SerializeField] private GameObject[] endPieces;




    // Start is called before the first frame update
    void Start()
    {
        PiecesToUse();
        GenerateLevelByHeight();

        
    }

    private void GenerateLevelByHeight()
    {
        Instantiate(startPieces[Random.Range(0, startPieces.Length)], Vector3.zero, Quaternion.identity, transform);

        for (int i = pieceHeight; i < levelHeight; i += pieceHeight)
        {
            //0, 20, 40, 60...                          Longitud de la lista para coger el valor de la última posición
            int pieceIndex = Random.Range(0, piecesToUse.Count);
            Instantiate(piecesToUse[pieceIndex], new Vector3(0, -i, 0), Quaternion.identity, transform);
            piecesToUse.RemoveAt(pieceIndex);

        }

        Instantiate(endPieces[Random.Range(0, endPieces.Length)], new Vector3(0, -levelHeight, 0), Quaternion.identity, transform);
    }

    private void PiecesToUse()
    {
        piecesToUse = new List<GameObject>();
        int piecesPerType = Mathf.CeilToInt((float)(levelHeight / pieceHeight) / levelPieces.Length);
        //Piezas de cada tipo = redondeo hacia arriba de (altura de nivel / altura de la pieza) / el numero de piezas que hay en la lista (4 de resultado), float para que no ignore los decimales

        /*while (piecesToUse.Count < piecesPerType)
        { piecesToUse.Add(levelPieces[1]); }*/

        for (int lp = 0; lp < levelPieces.Length; lp++)
        {
            for (int p = 0; p < piecesPerType; p++)
            {
                piecesToUse.Add(levelPieces[lp]); //- añado el tipo de pieza definido en el array[lp], a la lista
            }
        }
    }

}

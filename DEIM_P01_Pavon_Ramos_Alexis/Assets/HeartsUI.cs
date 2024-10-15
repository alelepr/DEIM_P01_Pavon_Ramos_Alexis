using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class HeartsUI : MonoBehaviour
{
    public List<Image> listHearts;
    public GameObject heartPrefab;
    public LivesController playerLife;

    public int indexActual;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void Awake()
    {
        playerLife.lifeChange.AddListener(ChangeHearts);
    }

    private void ChangeHearts(int actualLives)
    {
        if (!listHearts.Any()) {
            CreateHearts(actualLives);
        }
        else
        {
            ChangeLife(actualLives);
        }

    }

    private void CreateHearts(int maxLifeAmount)
    {
        for (int i = 0; i < maxLifeAmount; i++)
        {
            GameObject heart = Instantiate(heartPrefab,transform);
            listHearts.Add(heart.GetComponent<Image>());
        }
        indexActual = maxLifeAmount - 1;
    }
    private void ChangeLife(int actualLives)
    {
        if (actualLives <= indexActual)
        {
            DeleteHearts(actualLives);

        }
        else
        {
            AddHearts(actualLives);
        }
    }

    private void AddHearts(int actualLives)
    {
        for (int i = indexActual; i < actualLives; i++)
        {
            indexActual = i;
            listHearts[indexActual].sprite = fullHeart;
        }
    }

    private void DeleteHearts(int actualLives)
    {
        for(int i = indexActual; i<=actualLives; i--)
        {
            indexActual = i;
            listHearts[indexActual].sprite = emptyHeart;
        }
    }
}

using System;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private PickupController[] pickups;
    [SerializeField] private Image[] itemImages;

    [SerializeField] private GameObject itemList;
    [SerializeField] private GameObject finale;

    private int itemsLeft;

    void Awake()
    {
        itemsLeft = pickups.Length;
        foreach(Image image in itemImages) {
            image.enabled = false;
        }
    }


    void Update()
    {
        
    }

    public void PickupItem(PickupController item) {
        for(int i = 0; i < pickups.Length; i++) {
            if(pickups[i] == item) {
                itemImages[i].enabled = true;
                itemsLeft--;
                break;
            }
        }

        if (itemsLeft == 0) {
            //itemList.SetActive(false);
            finale.SetActive(true);
        }
    }
}

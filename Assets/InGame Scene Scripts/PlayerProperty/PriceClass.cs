using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceClass
{
    private static int price;

    public PriceClass(int Price)
    {
        price = Price;
    }
    public int GetPrice
    {
        get => price;
    }
    public void PriceUp(int Price)
    {
        price += Price;
    }
}

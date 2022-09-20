using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System;

public class IAPController : MonoBehaviour, IStoreListener
{

    public UIManager uiManager;
    public SoundManager soundManager;

    IStoreController controller;
    public string[] products;

    private void Start()
    {
        IAPStart();
    }
    public void IAPStart()
    {
        var module = StandardPurchasingModule.Instance();
         ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);
        

        foreach (string item in products)
        {
            builder.AddProduct(item, ProductType.Consumable);
        }
        UnityPurchasing.Initialize(this, builder);
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Failed Initialize");
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Purchase Failed ");
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        if (string.Equals(e.purchasedProduct.definition.id, products[0], StringComparison.Ordinal))
        {
            int money = PlayerPrefs.GetInt("Money");
            PlayerPrefs.SetInt("Money", money + 2500);
            uiManager.CoinTextUpdate();
            soundManager.CashClickSound();
            return PurchaseProcessingResult.Complete;

        }
        else if (string.Equals(e.purchasedProduct.definition.id, products[1], StringComparison.Ordinal))
        {
            int money = PlayerPrefs.GetInt("Money");
            PlayerPrefs.SetInt("Money", money + 7000);
            uiManager.CoinTextUpdate();
            soundManager.CashClickSound();
            return PurchaseProcessingResult.Complete;

        }
        else if (string.Equals(e.purchasedProduct.definition.id, products[2], StringComparison.Ordinal))
        {
            int money = PlayerPrefs.GetInt("Money");
            PlayerPrefs.SetInt("Money", money + 20000);
            uiManager.CoinTextUpdate();
            soundManager.CashClickSound();
            return PurchaseProcessingResult.Complete;

        }
        else if (string.Equals(e.purchasedProduct.definition.id, products[3], StringComparison.Ordinal))
        {
            if (PlayerPrefs.HasKey("Noads") == true) 
            {
                PlayerPrefs.SetInt("Noads", 1);
                uiManager.RemoveNoAds();
                soundManager.CashClickSound();
            }
            
            
            return PurchaseProcessingResult.Complete;

        }
        else
        {
            return PurchaseProcessingResult.Pending;
        }
    }


    public void IAPButton(string id)
    {
        Product product = controller.products.WithID(id);
        if (product != null && product.availableToPurchase)
        {
            controller.InitiatePurchase(product);
            Debug.Log("Buying");
        }
        else
            Debug.Log("Not Buying");
    }
}

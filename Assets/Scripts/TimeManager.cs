using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private int openingHour = 8;
    [SerializeField] private int closingHour = 18;
    [SerializeField] private int dayLength = 5;

    private float currentTime = 0f;
    private int currentDay = 0;
    private bool isShopOpen = false;

    public event Action onCloseShop;
    public event Action onOpenShop;

    private void Awake()
    {
        currentTime = openingHour;
    }

    private void Start()
    {
        isShopOpen = true;
    }

    private void Update()
    {
        if (isShopOpen)
        {
            currentTime += Time.deltaTime * (closingHour - openingHour) / dayLength / 60;
            if (currentTime >= closingHour)
            {
                CloseShop();
            }
        }
    }

    private void CloseShop()
    {
        Debug.Log("TIMEMANAGER: Close Shop");
        onCloseShop?.Invoke();
        Invoke("OpenShop", 5f);
        isShopOpen = false;
    }

    private void OpenShop()
    {
        Debug.Log("TIMEMANAGER: Open Shop");
        onOpenShop?.Invoke();
        currentTime = openingHour;
        currentDay++;
        isShopOpen = true;
    }

    public void GetHourAndMinute(out int hour, out int minute)
    {
        hour = (int)currentTime;
        minute = (int)((currentTime - hour) * 60);
    }

    public int CurrentDay => currentDay;
    public float CurrentTime => currentTime;
    public int OpeningHour => openingHour;
    public int ClosingHour => closingHour;
}

using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI dayText;

    private TimeManager timeManager;

    private string[] dayNames = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    private void Awake()
    {
        timeManager = FindFirstObjectByType<TimeManager>();
    }

    private void Update()
    {
        if (timeManager != null)
        {
            int hour, minute;
            timeManager.GetHourAndMinute(out hour, out minute);
            timeText.text = hour.ToString("00") + ":" + minute.ToString("00");
            dayText.text = dayNames[timeManager.CurrentDay] + ", June " + (timeManager.CurrentDay + 1);
        }
    }
}

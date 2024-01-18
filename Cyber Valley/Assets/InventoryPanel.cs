using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    [SerializeField] List<InventoryButton> buttons;

    private void Start()
    {
        SetIndex();
        show();
    }

    private void OnEnable()
    {
        Debug.Log("InventoryPanel is enabled!");
        show();
    }

    private void SetIndex()
    {
        int numButtons = Mathf.Min(buttons.Count, inventory.slots.Count);

        for (int i = 0; i < numButtons; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    private void show()
    {
        int numButtons = Mathf.Min(buttons.Count, inventory.slots.Count);

        for (int i = 0; i < numButtons; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }

        }
    }


}

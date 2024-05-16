using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Catalog : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public struct Item
    {
        public string Title;
        public float Price;
        public string Description;
        public Sprite Sprite;
    }
    
    // Меню каталога
    public List<Item> items;
    public GameObject Panel;   // Панель каталога
    public GameObject UI_Item; // Кнопка предмета

    // Меню Предмета
    public GameObject UI_Menu_Item;
    public GameObject TitleItem;
    public GameObject DescriptionItem;
    public GameObject PriceItem;

    private GameObject instance; // Распакованный префаб предмета

    void Start()
    {
        for (int i = 0;  i < items.Count; i++) 
        {
            instance = Instantiate(UI_Item, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            
            instance.name = i.ToString();

            instance.transform.Find("Icon").gameObject.GetComponent<Image>().sprite = items[i].Sprite;
            instance.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = $"{items[i].Title}\nЦена: {items[i].Price}";

            instance.transform.SetParent(Panel.transform, false);

            string name = Panel.transform.GetChild(i).name;
            Panel.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(() => OpenMenuItem(name));
        }
    }

    public void OpenMenuItem(string name)
    {
        int index = int.Parse(name);
        UI_Menu_Item.SetActive(true);
        TitleItem.GetComponent<TextMeshProUGUI>().text = items[index].Title;
        DescriptionItem.GetComponent<TextMeshProUGUI>().text = items[index].Description;
        PriceItem.GetComponent<TextMeshProUGUI>().text = $"Цена: {items[index].Price}";
    }
}

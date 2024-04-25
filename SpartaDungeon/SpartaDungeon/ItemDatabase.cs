using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    class ItemDatabase
    {
        public Dictionary<string, BaseItem> itemDB = new Dictionary<string, BaseItem> ();

        public ItemDatabase()
        {
            BaseItem Armor1 = new BaseItem ();
            Armor1.index = 0;
            Armor1.itemName = "수련자 갑옷";
            Armor1.type = 1;
            Armor1.dPower = 5;
            Armor1.data = "수련에 도움을 주는 갑옷입니다.";
            Armor1.price = 1000;

            BaseItem Armor2 = new BaseItem();
            Armor2.index = 1;
            Armor2.itemName = "무쇠 갑옷";
            Armor2.type = 1;
            Armor2.dPower = 9;
            Armor2.data = "무쇠로 만들어져 튼튼한 갑옷입니다.";
            Armor2.price = 1000;

            BaseItem Armor3 = new BaseItem();
            Armor3.index = 2;
            Armor3.itemName = "스파르타의 갑옷";
            Armor3.type = 1;
            Armor3.dPower = 15;
            Armor3.data = "스파르타 전사들이 사용했다는 전설의 갑옷입니다.";
            Armor3.price = 3500;

            BaseItem weapon1 = new BaseItem();
            weapon1.index = 3;
            weapon1.itemName = "낡은 검";
            weapon1.type = 2;
            weapon1.power = 2;
            weapon1.data = "쉽게 볼 수 있는 낡은 검입니다.";
            weapon1.price = 600;

            BaseItem weapon2 = new BaseItem();
            weapon2.index = 4;
            weapon2.itemName = "청동 도끼";
            weapon2.type = 2;
            weapon2.power = 5;
            weapon2.data = "어디선가 사용됐던거 같은 도끼입니다.";
            weapon2.price = 1500;

            BaseItem weapon3 = new BaseItem();
            weapon3.index = 4;
            weapon3.itemName = "스파르타의 창";
            weapon3.type = 2;
            weapon3.power = 7;
            weapon3.data = "스파르타 전사들이 사용했다는 전설의 창입니다.";
            weapon3.price = 5000;

            itemDB.Add(Armor1.itemName, Armor1);
            itemDB.Add(Armor2.itemName, Armor2);
            itemDB.Add(Armor3.itemName, Armor3);
            itemDB.Add(weapon1.itemName, weapon1 );
            itemDB.Add(weapon2.itemName, weapon2 );
            itemDB.Add(weapon3.itemName, weapon3 );
        }

        public BaseItem GetItem(string name)
        {
            if (itemDB.ContainsKey(name))
            {
                return itemDB[name];
            }
            else
            {
                return null;
            }
        }
    }

    class BaseItem
    {
        public string itemName;
        public string data;
        public int index;
        public int type;
        public int dPower;
        public int power;
        public int price;
    }
}

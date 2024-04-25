using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Character
    {
        public string Name = "Chad";
        public string Job = "전사";
        public int Attack = 10;
        public int Defense = 5;
        public int Health = 100;
        public int Gold = 1500;
        public int Level = 01;
        public List<int> Inventory;

        //생성자
        public Character(string name, string job, int attack, 
            int defense, int health, int gold)
        {
            Name = name; 
            Job = job;
            Attack = attack;
            Defense = defense;
            Health = health;
            Gold = gold;
            Level = 1;
            Inventory = new List<int>();
        }
    }
}

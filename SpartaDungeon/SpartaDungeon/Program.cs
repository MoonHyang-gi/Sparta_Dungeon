using SpartaDungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungoen
{
    class Start
    {
        //전역 변수로 지정
        static Character player = new Character("Chad", "전사", 10, 5, 100, 1500);
        static ItemDatabase itemDatabase = new ItemDatabase();

        static void Main()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("\n1. 상태 보기\n2. 인벤토리\n3. 상점\n");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string startScene;
            startScene = Console.ReadLine();

            switch (startScene)
            {
                case "1":
                    Console.Clear();
                    Status();
                    break;
                case "2":
                    Console.Clear();
                    Inventory();
                    break;
                case "3":
                    Console.Clear();
                    Shop();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }

        static void Status()
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv. {0}", player.Level);
            Console.WriteLine("{0} ( {1} )", player.Name, player.Job);
            Console.WriteLine("공격력 : {0}", player.Attack);
            Console.WriteLine("방어력 : {0}", player.Defense);
            Console.WriteLine("체력 : {0}", player.Health);
            Console.WriteLine("Gold : {0} G", player.Gold);
            
            Console.WriteLine("\n0. 나가기\n");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Console.Clear();
                    Main();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }

        static void Inventory()
        {
            //아이템(데이터) 명세서 작성

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n[아이템 목록]");
            //보유중인 아이템 목록 추가
            //장착 중인 아이템은 앞에 [E] 표시 추가

            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("\n0. 나가기\n");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Console.Clear();
                    Main();
                    break;
                case "1":
                    Console.Clear();
                    Equip();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }

        static void Equip()
        {
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n[아이템 목록]");
            //아이템 목록 추가

            Console.WriteLine("\n0. 나가기\n");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string input = Console.ReadLine();

            if (input == "0")
            {
                Console.Clear();
                Inventory();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        static void Shop()
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("\n[보유 골드]");
            Console.WriteLine("{0} G", player.Gold);
            Console.WriteLine("\n[아이템 목록]");

            foreach (var item in itemDatabase.itemDB)
            {
                BaseItem Item = item.Value;
                string equipped = ""; //장착 여부 표시를 위한 문자열

                //구매된 아이템인 경우
                if (IsHave(Item))
                {
                    equipped = "|  구매완료";
                }

                //아이템 정보 출력
                Console.WriteLine("- {0} | {1} | {2} | {3} G {4}",
                    Item.itemName,
                    Item.type == 1 ? "방어력 +" + Item.dPower : "공격력 +" + Item.power,
                    Item.data,
                    Item.price,
                    equipped);
            }

            Console.WriteLine("\n1. 아이템 구매\n");
            Console.WriteLine("0. 나가기\n");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string input = Console.ReadLine();

            if (input == "0")
            {
                Console.Clear();
                Main();
            }
            else if (input == "1") 
            {
                BuyItem();
            }
        }

        static bool IsHave(BaseItem item)
        {
            return player.Inventory.Contains(item.index);
        }

        static void BuyItem()
        {
            Console.Write("\n구매할 아이템의 숫자를 입력해주세요.\n>>");
            int index = int.Parse(Console.ReadLine());

            //아이템이 존재하는지
            BaseItem itemToBuy = itemDatabase.GetItem(index);
            if (itemToBuy != null)
            {
                //이미 구매한 아이템인지
                if (IsHave(itemToBuy))
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                }
                else
                {
                    //보유 금액이 충분한지
                    if (player.Gold >= itemToBuy.price)
                    {
                        //아이템 구매, 인벤토리 추가
                        player.Gold -= itemToBuy.price;
                        player.Inventory.Add(itemToBuy.index);
                        Console.WriteLine("구매를 완료했습니다.");
                    }
                    else
                    {
                        Console.WriteLine("보유한 골드가 부족합니다.");
                    }
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}
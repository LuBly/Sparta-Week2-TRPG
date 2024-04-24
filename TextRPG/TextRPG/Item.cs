﻿using System.Runtime;

namespace TextRPG
{
    public enum ItemType
    {
        None = 0,
        Weapon,
        Armor,
    }

    // Item을 db에 모두 생성하고 Inventory, store에 뿌려야하나?
    internal class Item
    {
        public bool isEquiped = false;
        public string name;

        ItemType itemType;
        int increase;
        string description;

        // DB에서 모든 아이템을 생성하고 메모리에 올려두고 있을까?
            // 데이터를 배열화해서 모두 new하고 만들어 놓기
        // 아니면 필요할 때마다 배열에 접근해서 가져오기
        public Item(string name, ItemType itemType, int increase, string description)
        {
            this.name = name;
            this.itemType = itemType;
            this.increase = increase;
            this.description = description;
        }

        public void ShowItem()
        {
            int originRow = Console.CursorTop;
            // 장착중인 아이템이라면 인벤토리에 [E] 표시
            if (isEquiped)
            {
                Console.Write("[E]");
            }
            // 이름
            Console.Write($"{name}");
            // 수치
            Console.SetCursorPosition(20, originRow);
            switch (itemType)
            {
                case ItemType.Weapon:
                    Console.Write($"| 공격력 + {increase} |");
                    break;
                case ItemType.Armor:
                    Console.Write($"| 방어력 + {increase} |");
                    break;

            }
            // 설명
            Console.SetCursorPosition(35, originRow);
            Console.WriteLine($"{description}");
        }

        public void EquipItem(Player player)
        {
            switch (itemType)
            {
                case ItemType.Weapon:
                    player.increaseAttack = increase;           
                    break;
                case ItemType.Armor:
                    player.increaseDefense = increase;
                    break;

            }

            // 장착 중일 때
            if (isEquiped)
            {
                Console.WriteLine($"{this.name}을 해제하였습니다.");
                isEquiped = false;
            }
            // 장착 중이 아닐 때
            else
            {
                Console.WriteLine($"{this.name}을 장착했습니다.");
                isEquiped = true;
            }
        }
    }
}
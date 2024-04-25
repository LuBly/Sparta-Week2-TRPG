namespace TextRPG
{
    public enum InventoryType
    {
        noneIdx,
        idx,
    }
    internal class Inventory
    {
        // inventory에 보유하고 있는 아이템 
        List<Item> inventoryItems = new List<Item>();
        bool isIn = false;

        public int CountInventory()
        {
            return inventoryItems.Count;
        }
        public void AddItem(Item item)
        {
            inventoryItems.Add(item);
        }
        public Item ChooceItem(int index)
        {
            return inventoryItems[index];
        }
        public void ShowInventory()
        {
            /*
            // [For Dev]
            if (!isIn)
            {
                Item tempItem1 = new Item("무쇠갑옷", ItemType.Armor, 5, "무쇠로 만들어져 튼튼한 갑옷입니다.");
                AddItem(tempItem1);
                Item tempItem2 = new Item("스파르타의 창", ItemType.Weapon, 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.");
                AddItem(tempItem2);
                Item tempItem3 = new Item("낡은 검", ItemType.Weapon, 2, "쉽게 볼 수 있는 낡은 검 입니다.");
                AddItem(tempItem3);
                isIn = true;
            }
            */
            Console.Clear();

            ShowItemList(InventoryType.noneIdx, Menu.inventory);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
        }

        // Inventory 장착 
        public void EquipInventory(Player player)
        {
            // 장착 메세지 출력
            while (true)
            {
                // 기존 Inventory 내용 삭제
                Console.Clear();

                ShowItemList(InventoryType.idx, Menu.inventory);

                Console.WriteLine("\n장착할 장비를 선택해주세요.(0 : 뒤로가기)");
                Console.Write(">> ");
                int equipIdx = int.Parse(Console.ReadLine());
                // 범위 밖의 번호를 선택했을 때
                if (equipIdx > inventoryItems.Count || equipIdx < 0) 
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    continue;
                }
                // 0을 선택했을 때
                else if(equipIdx == 0)
                {
                    ShowInventory();
                    break;
                }
                // 장비를 선택했을 때
                else
                {
                    // 장비 장착 및 해제
                    inventoryItems[equipIdx - 1].EquipItem(player);
                }

                // 약간의 Delay 부여
                Thread.Sleep(500);
            }
        }

        // ItemList 출력
        public void ShowItemList(InventoryType type, Menu menuType)
        {
            Console.WriteLine("\n[아이템 목록]");

            // 아이템 리스트 표기
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                Console.Write("- ");
                if(type == InventoryType.idx)
                    Console.Write($"{i + 1} ");
                inventoryItems[i].ShowItem(menuType);
            }
        }
    }
}

namespace TextRPG
{
    public enum StoreType
    {
        Buy = 1,
        Sell = 2,
    }
    internal class Store
    {
        // store에 inventory를 붙혀서 사용
        Inventory storeInventory = new Inventory();
        bool isFirst = true;
        void D_addStoreItem()
        {
            // [임시]DataBase
            List<Item> items = new List<Item>() {
                new Item("수련자 갑옷", ItemType.Armor, 5, "수련에 도움을 주는 갑옷입니다.", 1000),
                new Item("무쇠갑옷", ItemType.Armor, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 1500),
                new Item("스파르타의 갑옷", ItemType.Armor, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500),
                new Item("낡은 검", ItemType.Weapon, 2, "쉽게 볼 수 있는 낡은 검 입니다. ", 600),
                new Item("청동 도끼", ItemType.Weapon, 5, "어디선가 사용됐던거 같은 도끼입니다.", 1500),
                new Item("스파르타의 창", ItemType.Weapon, 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 4000),
                new Item("AK47", ItemType.Weapon, 47, "전설의 외할머니가 사용하던 무기입니다.", 4747),
            };

            foreach(Item item in items)
            {
                storeInventory.AddItem(item);
            }
        }
        // ShowStore(Player)
        public void ShowStore(Player player)
        {
            // 최초 방문 시 Item List를 inventory에 저장
            if (isFirst)
            {
                D_addStoreItem();
                isFirst = false;
            }
            Console.Clear();
            // Player 골드 출력
            Console.WriteLine("[상점]\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.gold} G\n");

            // Store에 들어갈 Item List 불러오기
            storeInventory.ShowItemList(InventoryType.noneIdx, Menu.store);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
        }

        // 구매 (+ 판매)
        // type 1 = 구매
        // type 2 = 판매
        // inventory불러오기
        // 비슷한 기능을 하는 함수들이 있는데, 얘네를 묶어? 풀어?
        // 묶자니 세부조건(store인지, inventory인지)들이 필요하고, 풀자니 겹치는게 많고.
        // 안내창class를(싱글톤으로 제작해서) 따로 빼서 관리
        // 0 >> 나가기는 

        public void UseStore(int type, Player player)
        {
            switch(type)
            {
                // Buy
                case 1:
                    // 아이템 구매 함수 불러오기
                    BuyItem(player);
                    break;
                // Sell
                case 2:
                    // 아이템 판매 함수 불러오기
                    SellItem(player);
                    break;
            }
        }

        // Inventory의 아이템을 구매
        public void BuyItem(Player player)
        {
            // 장착 메세지 출력
            while (true)
            {
                // 기존 Inventory 내용 삭제
                Console.Clear();

                // Player 골드 출력
                Console.WriteLine("[상점]\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.gold} G\n");
                storeInventory.ShowItemList(InventoryType.idx, Menu.store);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("구매하시려는 아이템을 선택해주세요 (0 : 뒤로가기)");
                Console.Write(">> ");
                int choiceIdx = int.Parse(Console.ReadLine());
                // 범위 밖의 번호를 선택했을 때
                if (choiceIdx > storeInventory.CountInventory() || choiceIdx < 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    continue;
                }
                // 0을 선택했을 때
                else if (choiceIdx == 0)
                {
                    // 초기 페이지 재호출
                    ShowStore(player);
                    break;
                }
                // 장비를 선택했을 때
                else
                {
                    Item curItem = storeInventory.ChooceItem(choiceIdx - 1);
                    // 장비 가격보다 보유 gold가 많으면 add
                    if (player.gold >= curItem.price)
                    {
                        curItem.isUsable = true;
                        player.gold -= curItem.price;
                        player.inventory.AddItem(curItem);
                        Console.WriteLine($"{curItem.name}를 구매했습니다.");
                    }
                    // 장비 가격보다 보유 gold가 적으면 패스
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                }

                // 약간의 Delay 부여
                Thread.Sleep(500);
            }
        }

        public void SellItem(Player player)
        {
            // 장착 메세지 출력
            while (true)
            {
                // 기존 Inventory 내용 삭제
                Console.Clear();

                // Player 골드 출력
                Console.WriteLine("[상점]\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.gold} G\n");
                player.inventory.ShowItemList(InventoryType.idx, Menu.store);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("판매하시려는 아이템을 선택해주세요 (0 : 뒤로가기)");
                Console.Write(">> ");
                int choiceIdx = int.Parse(Console.ReadLine());
                // 범위 밖의 번호를 선택했을 때
                if (choiceIdx > player.inventory.CountInventory() || choiceIdx < 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    continue;
                }
                // 0을 선택했을 때
                else if (choiceIdx == 0)
                {
                    // 초기 페이지 재호출
                    ShowStore(player);
                    break;
                }
                // 장비를 선택했을 때
                else
                {
                    Item curItem = player.inventory.ChooceItem(choiceIdx - 1);
                    curItem.isUsable = false;
                    player.gold += curItem.price * 0.85f;
                    
                    // 인벤토리에서 아이템 빼기
                    player.inventory.RemoveItem(curItem);
                    Console.WriteLine($"{curItem.name}를 {curItem.price * 0.85f}에 판매했습니다.");
                }

                // 약간의 Delay 부여
                Thread.Sleep(500);
            }
        }
    }
}

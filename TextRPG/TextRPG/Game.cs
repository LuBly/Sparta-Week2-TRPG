namespace TextRPG
{
    public enum Menu
    {
        start,
        status,
        inventory,
        store,
        dungeon
    }
    public class Game
    {
        /// <summary>
        /// 현재 선택한 Menu를 담당할 열거형
        /// 0 = 시작화면
        /// 1 = 상태 보기 화면
        /// 2 = 인벤토리 화면
        /// 3 = 상점 화면
        /// 
        /// ++
        /// 4 = 던전 입장 화면
        /// </summary>
        
        // 초기 화면 설정(맨 처음 실행됐을 때)
        Menu curMenu = Menu.start;

        // Player 생성 (임의 생성)
        Player player = new Player();

        // Store 생성
        Store store = new Store();

        // 던전 생성
        Dungeon dungeon = new Dungeon();

        public void StartGame()
        {
            // 게임화면
            while (true)
            {
                // 메뉴가 뜨고 사라질때마다 Console 초기화
                Console.Clear();
                // 각 씬별 동작
                switch (curMenu)
                {
                    case Menu.start:
                        LoadStartMenu();
                        break;

                    case Menu.status:
                        LoadStatusMenu();
                        break;

                    case Menu.inventory:
                        LoadInventoryMenu();
                        break;

                    case Menu.store:
                        LoadStoreMenu();
                        break;

                    case Menu.dungeon:
                        LoadDungeonMenu();
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        curMenu = Menu.start;
                        break;
                }
                // 각 절차별 약간의 시간 부여
                Thread.Sleep(100);
            }
        }

        void LoadStartMenu()
        {
            Console.WriteLine("안녕?");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 정할 수 있어\n");

            Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전입장");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            curMenu = (Menu)int.Parse(Console.ReadLine());
        }

        void LoadStatusMenu()
        {
            player.ShowStatus();
            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            curMenu = (Menu)int.Parse(Console.ReadLine());
        }

        void LoadInventoryMenu()
        {
            // Inventory 초기 화면
            player.inventory.ShowInventory();
            while (true)
            {
                bool isContinue = true;
                int choiceIdx = int.Parse(Console.ReadLine());
                switch (choiceIdx)
                {
                    case 0:
                        isContinue = false;
                        curMenu = 0;
                        break;
                    case 1:
                        LoadEquipMenu();
                        break;
                }

                if (!isContinue) break;
            }
        }

        // 인벤토리 세부 매뉴
        void LoadEquipMenu()
        {
            player.inventory.EquipInventory(player);
        }

        void LoadStoreMenu()
        {
            store.ShowStore(player);
            while (true)
            {
                bool isContinue = true;
                int choiceIdx = int.Parse(Console.ReadLine());
                switch (choiceIdx)
                {
                    case 0:
                        isContinue = false;
                        curMenu = 0;
                        break;
                    case 1:
                        store.UseStore(1, player);
                        break;
                    case 2:
                        store.UseStore(2, player);
                        break;
                }

                if (!isContinue) break;
            }
        }
        void LoadDungeonMenu()
        {
            dungeon.ShowDungeon();
            while (true)
            {
                bool isContinue = true;
                int choiceIdx = int.Parse(Console.ReadLine());
                switch (choiceIdx)
                {
                    case 0:
                        isContinue = false;
                        curMenu = 0;
                        break;
                    default:
                        dungeon.ShowStage(choiceIdx, player);
                        break;
                }

                if(!isContinue) break;
            }
        }
    }
}

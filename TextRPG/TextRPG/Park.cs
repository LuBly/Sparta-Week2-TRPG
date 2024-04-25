namespace TextRPG
{
    internal class Park
    {
        int price;
        int targetHp;

        public Park()
        {
            price = 500;
            targetHp = 100;
        }

        public void ShowRestPlace(Player player)
        {
            Console.Clear();
            Console.WriteLine("[휴식하기]");
            Console.WriteLine($"{price} G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.gold} G)");
            Console.WriteLine("\n1. 휴식하기");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
        }

        public void HealHp(Player player)
        {
            // 보유 금액이 충분하다면
            if(player.gold >= price)
            {
                // 휴식을 완료했습니다. 출력
                player.gold -= price;
                player.health = targetHp;
                Console.WriteLine("휴식을 완료했습니다.");
                Thread.Sleep(500);
            }
            // 보유 금액이 부족하다면
            else
            {
                Console.WriteLine("골드가 부족합니다.");
                Thread.Sleep(500);
            }
        }
    }
}

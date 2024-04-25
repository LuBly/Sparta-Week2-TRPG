using System.Diagnostics;
using System.Numerics;

namespace TextRPG
{
    internal class Stage
    {
        // 필요한 정보
        // 이름
        public string name;
        // 권장 방어력
        public int RecommendedDefense;
        // 클리어 보상
        public float ClearReward;

        public Stage(string name, int RecommendedDefense, float ClearReward)
        {
            this.name = name;
            this.RecommendedDefense = RecommendedDefense;
            this.ClearReward = ClearReward;
        }

        public void ShowStageInfo()
        {
            int originRow = Console.CursorTop;
            // 이름
            Console.Write($"{name}");
            // 권장 방어력
            Console.SetCursorPosition(20, originRow);
            Console.WriteLine($"| 방어력 {RecommendedDefense} 이상 권장");

            Console.SetCursorPosition(50, originRow);
            Console.WriteLine($"| 보상 {ClearReward} G");
        }

        public void GetStageResult(Player player)
        {
            // 던전 클리어 
            if (CheckClear(player))
            {
                StageClear(player);
            }
            else
            {
                StageFail(player);
            }
        }

        // 클리어 여부 판단 (방어력)
        bool CheckClear(Player player)
        {
            // 권장 방어력보다 낮다면
            if (player.defensePower + player.increaseDefense < RecommendedDefense)
            {
                // 40% 확률로 던전 실패
                Random random = new Random();
                // 101보다 작은 양수를 임의로 선정 (0 ~ 100)
                int dice = random.Next(101);

                // 40% 이내에 들어왔다면 성공
                if (dice < 40)
                {
                    return true;
                }

                // 못들어왔다면 실패
                else return false;
            }
            // 권장 방어력 보다 높다면 무조건 성공
            else
            {
                return true;
            }
        }

        void StageClear(Player player)
        {
            Console.Clear();
            Console.WriteLine("축하합니다!!");
            Console.WriteLine($"{name}을 클리어 하였습니다.");


            Console.WriteLine("\n[탐험 결과]");
            Console.WriteLine($"체력 {player.health} -> {ChangeHealth(player)}");
            Console.WriteLine($"골드 {player.gold} -> {ChangeGold(player)}");
        }

        void StageFail(Player player)
        {
            Console.Clear();
            Console.WriteLine("힝잉잉!!");
            Console.WriteLine($"{name}에 실패했습니다.");


            Console.WriteLine("\n[탐험 결과]");
            Console.WriteLine($"체력 {player.health} -> {player.health / 2}");
            player.health /= 2;
        }

        // hp 변화량 계산
        int ChangeHealth(Player player)
        {
            // 기본 체력 감소량
            Random random = new Random();
            // 20 ~ 35 랜덤
            int minusHp = random.Next(20, 36);
            int playerDeffence = player.defensePower + player.increaseDefense;
            int changeValue = playerDeffence - RecommendedDefense;
            int damage = minusHp + changeValue;
            player.health -= damage;
            
            return player.health;
        }

        // 보상 골드 변화량 계산
        float ChangeGold(Player player)
        {
            Random random = new Random();
            int playerAttack = player.attackPower + player.increaseAttack;
            int plusGoldRate = random.Next(playerAttack, playerAttack*2);
            ClearReward += ClearReward * (plusGoldRate / 100f);
            player.gold += ClearReward;
            return player.gold;
        }
    }
}

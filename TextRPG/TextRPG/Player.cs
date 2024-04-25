using System.Numerics;

namespace TextRPG
{
    public enum CreatureType
    {
        None = 0,
        Warrior,
        Enemy
    }
    internal class Player : ICreature
    {
        public int level;
        int levelPoint;
        public string name { get; set; }
        public CreatureType classType { get; set; }
        public float attackPower { get; set; }
        public float increaseAttack;
        public float defensePower { get; set; }
        public float increaseDefense;
        public float health { get; set; }
        public float gold;
        public Item Waepon, Armor;
        public Inventory inventory = new Inventory();
        
        // level 정보를 저장할 자료구조
        /// <summary>
        /// key   : 현재 레벨
        /// value : 현재 레벨에서 다음 레벨로 올라가기 위해 필요한 클리어 횟수
        /// </summary>
        Dictionary<int,int> levelData = new Dictionary<int,int>();
        public Player()
        {
            level = 1;
            levelPoint = 0;
            name = "Player";
            classType = CreatureType.Warrior;
            attackPower = 10;
            defensePower = 5;
            health = 100;
            gold = 2500f;
            levelData.Add(1, 1);
            levelData.Add(2, 2);
            levelData.Add(3, 3);
            levelData.Add(4, 4);
        }

        public void ShowStatus()
        {
            Console.WriteLine("[상태 보기]");
            // Lv
            Console.WriteLine($"Lv. {level}");
            // 직업
            Console.WriteLine($"Chad : {classType}");
            // 공격력
            Console.Write($"공격력 : {attackPower}");
            if(increaseAttack > 0)
            {
                Console.WriteLine($" + ({increaseAttack})");
            }
            else
            {
                Console.WriteLine();
            }
            // 방어력
            Console.Write($"방어력 : {defensePower}");
            if (increaseDefense > 0)
            {
                Console.WriteLine($" + ({increaseDefense})");
            }
            else
            {
                Console.WriteLine();
            }
            // 체력
            Console.WriteLine($"체 력 : {health}");
            // 소유 gold
            Console.WriteLine($"Gold : {gold}");
        }

        public void EditLevel()
        {
            levelPoint++;
            int requirePoint = levelData[level];
            // levelPoint가 requirePoint와 같아진다면?
            // LevelUp
            if(levelPoint == requirePoint) 
            {
                LevelUp();
            }
        }

        void LevelUp()
        {
            // levelPoint 초기화
            levelPoint = 0;
            // levelUp 적용
            level++;
            attackPower += 0.5f;
            defensePower += 1f;
        }
    }
}

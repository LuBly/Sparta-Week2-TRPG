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
        public string name { get; set; }
        public CreatureType classType { get; set; }
        public int attackPower { get; set; }
        public int defensePower { get; set; }
        public int health { get; set; }
        
        public int gold;
        public Inventory inventory = new Inventory();
        public Player()
        {
            level = 1;
            name = "Player";
            classType = CreatureType.Warrior;
            attackPower = 10;
            defensePower = 5;
            health = 100;
            gold = 1500;
        }

        public void ShowStatus()
        {
            Console.WriteLine("[상태 보기]");
            // Lv
            Console.WriteLine($"Lv. {level}");
            // 직업
            Console.WriteLine($"Chad : {classType}");
            // 공격력
            Console.WriteLine($"공격력 : {attackPower}");
            // 방어력
            Console.WriteLine($"방어력 : {defensePower}");
            // 체력
            Console.WriteLine($"체 력 : {health}");
            // 소유 gold
            Console.WriteLine($"Gold : {gold}");
        }
    }
}

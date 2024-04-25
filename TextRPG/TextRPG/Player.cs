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
        public int increaseAttack;
        public int defensePower { get; set; }
        public int increaseDefense;
        public int health { get; set; }
        public float gold;
        public Item Waepon, Armor;


        public Inventory inventory = new Inventory();
        public Player()
        {
            level = 1;
            name = "Player";
            classType = CreatureType.Warrior;
            attackPower = 10;
            defensePower = 5;
            health = 100;
            gold = 2500f;
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
    }
}

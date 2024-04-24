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
    }
}

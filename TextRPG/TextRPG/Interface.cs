namespace TextRPG
{
    // 
    /// <summary>
    /// 체력과 공격력을 가지고 있는 class 
    /// 이름, type, 공격력, 방어력, 체력 정보를 가지고 있다.
    /// isDead = 차후 던전 입장 시 추가
    /// TakeDamage = 차후 던전 입장 시 추가
    /// </summary>
    internal interface ICreature
    {
        string name { get; set; }
        CreatureType classType { get; set; }
        int attackPower { get; set; }
        int defensePower { get; set; }
        int health { get; set; }
    }
}

// https://www.youtube.com/watch?v=Wud_ooJKdzU&list=PLnJJ5frTPwRMCCDVE_wFIt3WIj163Q81V&index=1&t=1s

using UnityEngine;

public class Enemy: MonoBehaviour
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public float Speed { get; private set; }
    public int Damage { get; private set; }
    public bool IsBoss { get; private set; }
    
    public class Builder
    {
        private string name;
        private int health;
        private float speed;
        private int damage;
        private bool isBoss;
        
        public Builder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public Builder WithHealth(int health)
        {
            this.health = health;
            return this;
        }
        
        public Builder WithSpeed(float speed)
        {
            this.speed = speed;
            return this;
        }
        
        public Builder WithDamage(int damage)
        {
            this.damage = damage;
            return this;
        }
        
        public Builder WithIsBoss(bool isBoss)
        {
            this.isBoss = isBoss;
            return this;
        }

        public Enemy Build()
        {
            var enemy = new GameObject("Enemy").AddComponent<Enemy>();
            enemy.Name = name;
            enemy.Health = health;
            enemy.Speed = speed;
            enemy.Damage = damage;
            enemy.IsBoss = isBoss;
            return enemy;
        }
    }
}
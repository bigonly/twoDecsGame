using Leopotam.Ecs;

namespace NTC.Source.Code.Ecs
{
    public class WeaponShootSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Weapon, Shoot> filter;
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var weapon = ref filter.Get1(i);

                if (weapon.currentInMagazine > 0)
                {
                    weapon.currentInMagazine--;
                    ref var entity = ref filter.GetEntity(i);
                    ref var spawnProjectile = ref entity.Get<SpawnProjectile>();
                    entity.Del<Shoot>();
                }
            }
        }
    }
}
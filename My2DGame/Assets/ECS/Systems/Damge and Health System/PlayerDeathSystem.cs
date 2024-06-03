using Leopotam.Ecs;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDeathSystem : IEcsRunSystem
{
    private EcsFilter<Player, DeathEvent, AnimatorRef> deadPlayers;
    private RuntimeData runtimeData;
    private UI ui;

    public void Run()
    {
        foreach (var i in deadPlayers)
        {
            ref var player = ref deadPlayers.Get1(i);
            ref var animatorRef = ref deadPlayers.Get3(i);

            animatorRef.animator.SetTrigger("Death");
            ui.deathScreen.Show();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            runtimeData.gameOver = true;
            Debug.Log("Player Dead");

            player.playerPrefab.SetActive(false);
            //deadPlayers.GetEntity(i).Destroy();
        }
    }
}
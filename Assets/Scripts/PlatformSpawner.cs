using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Referencja do platformy, któr¹ chcemy spawnowaæ
    public GameObject platformPrefab;

    // Referencja do gracza
    public Transform player;

    // Odleg³oœæ przed graczem, w której maj¹ pojawiaæ siê platformy
    public float spawnDistance = 10f;

    // Odleg³oœæ pomiêdzy kolejnymi platformami
    public float platformSpacing = 3f;

    // Ostatnia pozycja X, gdzie zosta³a zespawnowana platforma
    private float lastSpawnX;

    void Start()
    {
        // Ustawienie pocz¹tkowej wartoœci lastSpawnX na pozycji gracza
        lastSpawnX = player.position.x;
    }

    void Update()
    {
        // Sprawdzanie, czy gracz zbli¿y³ siê do miejsca, w którym powinna byæ nowa platforma
        if (player.position.x + spawnDistance > lastSpawnX)
        {
            // Spawnowanie nowej platformy przed graczem
            SpawnPlatform();

            // Aktualizowanie ostatniej pozycji spawnowanej platformy
            lastSpawnX += platformSpacing;
        }
    }

    void SpawnPlatform()
    {
        // Pozycja do spawnowania platformy (X + odleg³oœæ miêdzy platformami, Y na poziomie gracza)
        Vector2 spawnPosition = new Vector2(lastSpawnX, player.position.y - 1f); // -1f to wysokoœæ platformy poni¿ej gracza

        // Instancja platformy
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}

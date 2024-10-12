using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Referencja do platformy, kt�r� chcemy spawnowa�
    public GameObject platformPrefab;

    // Referencja do gracza
    public Transform player;

    // Odleg�o�� przed graczem, w kt�rej maj� pojawia� si� platformy
    public float spawnDistance = 10f;

    // Odleg�o�� pomi�dzy kolejnymi platformami
    public float platformSpacing = 3f;

    // Ostatnia pozycja X, gdzie zosta�a zespawnowana platforma
    private float lastSpawnX;

    void Start()
    {
        // Ustawienie pocz�tkowej warto�ci lastSpawnX na pozycji gracza
        lastSpawnX = player.position.x;
    }

    void Update()
    {
        // Sprawdzanie, czy gracz zbli�y� si� do miejsca, w kt�rym powinna by� nowa platforma
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
        // Pozycja do spawnowania platformy (X + odleg�o�� mi�dzy platformami, Y na poziomie gracza)
        Vector2 spawnPosition = new Vector2(lastSpawnX, player.position.y - 1f); // -1f to wysoko�� platformy poni�ej gracza

        // Instancja platformy
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}

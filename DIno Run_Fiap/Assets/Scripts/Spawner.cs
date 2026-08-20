using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe responsável por controlar a geração (spawn) de cactos na cena
public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabList;
    
    // Prefab do cacto que será instanciado na cena
    // SerializeField permite configurar esse valor diretamente no Inspector da Unity
    //[SerializeField] private GameObject cactusPrefab;

    // Intervalo de tempo entre cada spawn (em segundos)
    [SerializeField] private float intervalToSpawnMax = 2f;
    [SerializeField] private float intervalToSpawnMin = .5f;


    // Método chamado automaticamente quando o objeto é iniciado na cena
    void Start()
    {
        // Inicia a coroutine que controla o spawn dos cactos
        StartCoroutine(SpawnCactus());
    }

    // Coroutine responsável por criar cactos de forma repetida com intervalo de tempo
    IEnumerator SpawnCactus()
    {
        float t = Random.Range(intervalToSpawnMin, intervalToSpawnMax); //variavel temporaria que randomiza o tempo de spawn dos cactus
        
        // Aguarda o tempo definido antes de executar o spawn
        yield return new WaitForSeconds(t);

        SpawnRandomPrefab();

        // Reinicia a coroutine para continuar o processo de spawn em loop infinito
        StartCoroutine(SpawnCactus());
    }

    public void SpawnRandomPrefab()
    {
        int randomIndex = Random.Range(0, prefabList.Count); //escolhe um indice aleatório da lista

        GameObject selectedPrefab = prefabList[randomIndex]; //seleciona o prefab

        // Cria uma nova instância do prefab do cacto na cena
        GameObject cactus = Instantiate(selectedPrefab);

        // Define a posição do cacto recém-criado como a posição do objeto que possui este script
        cactus.transform.position = transform.position;

    }
}

using System;
using System.Linq;
using UnityEngine;

public class CraftModel : MonoBehaviour
{
    private CraftTask[] craftTasks;
    private Answer[] shuffledAnswers;
    private CraftManager manager;
    public Ability CurrentAbility;

    void Start()
    {
        craftTasks = Resources.LoadAll("CraftTasks", typeof(CraftTask)).Cast<CraftTask>().ToArray();
        manager = FindObjectOfType<CraftManager>();
    }

    public void StartSession()
    {
        LoadTask();
        manager.Show();
    }

    private void LoadTask()
    {
        var task = craftTasks[UnityEngine.Random.Range(0, craftTasks.Length)];
        shuffledAnswers = Shuffle(task.Answers);
        manager.ShowTask(task, shuffledAnswers);
    }

    private T[] Shuffle<T>(T[] arr)
    {
        var result = new T[arr.Length];
        Array.Copy(arr, result, arr.Length);
        for (var t = 0; t < result.Length; t++)
        {
            var tmp = result[t];
            var r = UnityEngine.Random.Range(t, result.Length);
            result[t] = result[r];
            result[r] = tmp;
        }
        return result;
    }

    public void CheckAnswer(int index)
    {
        if (shuffledAnswers[index].IsCorrect)
        {
            IncreaseAbility();
        }
        LoadTask();
    }

    private void IncreaseAbility()
    {
        switch (CurrentAbility)
        {
            case Ability.Shot:
                Inventory.Instance.ShotsCounter += 3;
                break;
        }
    }
}

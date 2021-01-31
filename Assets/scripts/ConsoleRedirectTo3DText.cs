using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConsoleRedirectTo3DText : MonoBehaviour
{
    // public Text3D
    public TextMesh textMesh;

    public Queue<string> consoleMessages = new Queue<string>();

    [Range(2, 10)]
    public int QUEUE_MAX_LENGTH = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestAddMessages());
    }

    public IEnumerator TestAddMessages()
    {
        while(true)
        {
            this.Log($"Update, the time is {Time.time}");
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void Log(string message)
    {
        //Enqueue message
        consoleMessages.Enqueue(message);

        //Queue length > max size? dequeue
        if(consoleMessages.Count > QUEUE_MAX_LENGTH)
            consoleMessages.Dequeue();

        //R-r-r-render
        this.Render();
    }

    public void Render()
    {
        //Just join them all together
        textMesh.text = consoleMessages.Aggregate((a, b) => $"{a}\n{b}");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConsoleRedirectTo3DText : MonoBehaviour
{
    // public Text3D
    public TextMesh textMesh;

    public Queue<string> consoleMessages = new Queue<string>();

    [Range(2, 20)]
    public int QUEUE_MAX_LENGTH = 5;

    public void OnEnable()
    {
        Application.logMessageReceived += HandleLogMessage;
    }

    public void OnDisable()
    {
        Application.logMessageReceived -= HandleLogMessage;
    }

    private void HandleLogMessage(string logStr, string stack, LogType type)
    {   
        //Prepend if needed
        if(type == LogType.Error)
            logStr = $"ERROR: {logStr}";

        //Log the message
        this.Log(logStr);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestAddMessages());
    }

    public IEnumerator TestAddMessages()
    {
        while(true)
        {
            Debug.Log($"Update, the time is {Time.time}");
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

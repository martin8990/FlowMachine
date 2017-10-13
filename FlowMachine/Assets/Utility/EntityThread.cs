using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class EntityThread : MonoBehaviour
{

    public Queue<OperationRequest> Requests = new Queue<OperationRequest>();
    public Queue<OperationResult> Results = new Queue<OperationResult>();
    
   

    bool debug;
    bool ThreadRunning;

    Thread TheThread;

   
    void start()
    {
        Debug.Log("Initialized Thread, Debug set to " + debug);
        if (debug)
        {
            StartCoroutine(DebugRoutine());
        }
        else
        {
            TheThread = new Thread(ThreadRoutine);
            TheThread.Start();
        }
    }

    public void ThreadRoutine()
    {
        ThreadRunning = true;
        while (ThreadRunning)
        {

            if (Requests.Count > 0)
            {

                var CurrentRequest = Requests.Dequeue();
                var output = CurrentRequest.operation(CurrentRequest.inputEntities);
                Results.Enqueue(new OperationResult(CurrentRequest.Callback, output));
            }
            if (Results.Count > 0)
            {
                var CurrentResult = Results.Dequeue();
                CurrentResult.callback(CurrentResult.outputEntities);
            }

        }
        ThreadRunning = false;

    }
    public void RequestOperation(OperationRequest request)
    {
        Requests.Enqueue(request);       
    }

    public IEnumerator DebugRoutine()
    {
        ThreadRunning = true;
        Debug.Log("Yow?");
        while (ThreadRunning)
        {
            if (Requests.Count > 0)
            {

                var CurrentRequest = Requests.Dequeue();
                var output = CurrentRequest.operation(CurrentRequest.inputEntities);
                Results.Enqueue(new OperationResult(CurrentRequest.Callback, output));
            }
            if (Results.Count > 0)
            {
                var CurrentResult = Results.Dequeue();
                CurrentResult.callback(CurrentResult.outputEntities);
            }
            yield return null;


        }
        ThreadRunning = false;
        yield return null;
    }

   
    void OnDisable()
    {
        if (ThreadRunning)
        {

            ThreadRunning = false;
            if (TheThread != null)
            {
                TheThread.Join();

            }
        }
    }
}


public class OperationRequest
{
    public Func<List<Entity>,List<Entity>> operation;
    public Action<List<Entity>> Callback;
    public List<Entity> inputEntities;

    public OperationRequest(Func<List<Entity>, List<Entity>> operation, Action<List<Entity>> callback, List<Entity> inputEntities)
    {
        this.operation = operation;
        Callback = callback;
        this.inputEntities = inputEntities;
    }
}

public class OperationResult
{
    public Action<List<Entity>> callback;
    public List<Entity> outputEntities;

    public OperationResult(Action<List<Entity>> callback, List<Entity> outputEntities)
    {
        this.callback = callback;
        this.outputEntities = outputEntities;
    }
}


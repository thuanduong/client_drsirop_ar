using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using ParseData;
using Core;

public class UserService : IDisposable
{
    private readonly IDIContainer container;
    private CancellationTokenSource cts;

    private static UserService instance;
    public static UserService Instance => instance;

    public void Save()
    {
        var lm = UserData.Instance.GetOne<UserProfileModel>();
    }

    public void Load()
    {
        var lm = UserData.Instance.GetOne<UserProfileModel>();
        UserData.Instance.InsertOrUpdate(lm);
    }

    public static UserService Instantiate(IDIContainer container)
    {
        if (instance == default)
        {
            instance = new UserService(container);
        }
        return instance;
    }

    private UserService(IDIContainer container)
    {
        this.container = container;
    }

    public void Dispose()
    {
        DisposeUtility.SafeDispose(ref cts);
        instance = default;
    }

}

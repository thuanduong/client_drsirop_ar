using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Core.Model;

public class UIMainMenuPresenter : IDisposable
{
    private IDIContainer Container { get; }
    private CancellationTokenSource cts;
            
    public UIMainMenu uiMainMenu;

    public UIMainMenuPresenter(IDIContainer container)
    {
        Container = container;
    }

    public void Dispose()
    {
        cts.SafeCancelAndDispose();
        cts = default;
        UILoader.SafeRelease(ref uiMainMenu);
    }

    public async UniTask ShowMainMenuAsync()
    {
        cts.SafeCancelAndDispose();
        cts = new CancellationTokenSource();
        await FetchData();



        uiMainMenu ??= await UILoader.Instantiate<UIMainMenu>(token: cts.Token);
        await UniTask.Delay(100);
        uiMainMenu.SetEntity(new UIMainMenu.Entity()
        {
        });
        await uiMainMenu.In();
    }

    public async UniTask ShowAsync()
    {
        cts.SafeCancelAndDispose();
        cts = new CancellationTokenSource();

        await uiMainMenu.In();
    }

    public async UniTask HideAsync()
    {
        cts.SafeCancelAndDispose();
        cts = new CancellationTokenSource();

        await uiMainMenu.Out();
    }

    private async UniTask FetchData()
    {
        await UniTask.CompletedTask;
    }


}

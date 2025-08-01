using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;

public class MainMenuState : InjectedBState
{
    private LoadingPresenter uiLoadingPresenter;
    private LoadingPresenter UiLoadingPresenter => uiLoadingPresenter ??= this.Container.Inject<LoadingPresenter>();

    private UIMainMenuPresenter uiMainMenuPresenter;

    private BackgroundPresenter backgroundPresenter;
    private BackgroundPresenter BackgroundPresenter => backgroundPresenter ??= Container.Inject<BackgroundPresenter>();


    private UIHeaderPresenter uiHeaderPresenter;
    private UIHeaderPresenter UIHeaderPresenter => uiHeaderPresenter ??= Container.Inject<UIHeaderPresenter>();

    private UIBottomMenuPresenter bottom;
    private UIBottomMenuPresenter Bottom => bottom ??= Container.Inject<UIBottomMenuPresenter>();


    private AudioPresenter audioPresenter;
    private AudioPresenter AudioPresenter => audioPresenter ??= Container.Inject<AudioPresenter>();

    
    private CancellationTokenSource cts;


    public override void Enter()
    {
        base.Enter();
        cts.SafeCancelAndDispose();
        cts = new CancellationTokenSource();
        
        uiMainMenuPresenter ??= new UIMainMenuPresenter(this.Container);

        SubcribeEvents();

        _ = OnStartState();
        //_ = ShowBackGroundAsync();

    }

    public override void Exit()
    {
        base.Exit();
        UnSubcribeEvents();

        uiMainMenuPresenter.Dispose();
        uiMainMenuPresenter = default;

        uiLoadingPresenter = default;
        uiHeaderPresenter = default;
        bottom = default;

        cts.SafeCancelAndDispose();
        cts = default;
    }

    private async UniTask ShowBackGroundAsync()
    {
        await BackgroundPresenter.LoadBackground("Sprite/UI/BackgroudGame/BG_MainMenu", FromAsset: true);
        UiLoadingPresenter.HideLoading();
    }

    private async UniTask HideBackgroundAsync()
    {
        await BackgroundPresenter.HideBackground();
        UiLoadingPresenter.HideLoading();
    }

    private void SubcribeEvents()
    {
    }

    private void UnSubcribeEvents()
    {
        
    }


    private async UniTask OnStartState()
    {
        try
        {
            AudioPresenter.PlayMusic("MainTheme");

            await ToMainMenu();
        }
        catch (Exception ex) { Debug.LogError($"Err: {ex.Message}"); }
    }

    private async UniTask ToMainMenu()
    {
        try
        {
            await uiMainMenuPresenter.ShowMainMenuAsync().AttachExternalCancellation(cts.Token);
            await UIHeaderPresenter.ShowHeaderAsync();
        }
        catch (Exception ex) { Debug.LogError($"Err: {ex.Message}"); }
    }


    private void ToPlayState()
    {
        cts.SafeCancelAndDispose();
        cts = new CancellationTokenSource();
        _ = ToPlayStateAsync();
    }

    private async UniTask ToPlayStateAsync()
    {
        await UniTask.WhenAll(uiMainMenuPresenter.HideAsync(), UIHeaderPresenter.HideHeaderAsync()
            , Bottom.HideAsync(), backgroundPresenter.HideBackground(), UiLoadingPresenter.ShowLoadingAsync()).AttachExternalCancellation(cts.Token);
    }
}

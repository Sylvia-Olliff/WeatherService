﻿namespace BlazorAdmin.Helpers;

internal sealed class RefreshBroadcast
{
    private static readonly Lazy<RefreshBroadcast>
        Lazy =
            new(() => new RefreshBroadcast());

    public static RefreshBroadcast Instance => Lazy.Value;

    private RefreshBroadcast() { }

    public event Action RefreshRequested;

    public void CallRequestRefresh()
    {
        RefreshRequested?.Invoke();
    }
}

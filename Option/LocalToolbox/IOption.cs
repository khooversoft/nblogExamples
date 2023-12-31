﻿namespace LocalToolbox;

public interface IOption
{
    StatusCode StatusCode { get; }
    bool HasValue { get; }
    object ValueObject { get; }
    string? Error { get; }
}

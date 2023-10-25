using System.ComponentModel;

namespace B2B.Framework.Contracts.Common.Enums;

public enum EventAttenderType
{
    /// <summary>
    /// غرفه‌دار
    /// </summary>
    [Description("غرفه‌دار")]
    Exhibitor = 1,

    /// <summary>
    /// بازدید کننده
    /// </summary>
    [Description("بازدید کننده")]
    Visitor = 2,

    /// <summary>
    /// شرکت در B2B
    /// </summary>
    [Description("شرکت در B2B")]
    Participant = 3,

    /// <summary>
    /// غرفه‌دار - شرکت در B2B
    /// </summary>
    [Description("غرفه‌دار - شرکت در B2B")]
    ExhibitorParticipant = 4,

    /// <summary>
    /// بازدید کننده - شرکت در B2B
    /// </summary>
    [Description("بازدید کننده - شرکت در B2B")]
    VisitorParticipant = 5
}
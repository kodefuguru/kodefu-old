//-----------------------------------------------------------------------
// <copyright file="ViewModel_1.cs" company="Microsoft">
//     Copyright (c) KodefuGuru, Microsoft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace TouchCafe
{
    using System;
    using System.Linq;

    /// <summary>
    /// TODO: Provide summary section in the documentation header.
    /// </summary>
    public class ViewModel<T> : ViewModel where T : new()
    {
        protected T Model { get; set; }
    }
}

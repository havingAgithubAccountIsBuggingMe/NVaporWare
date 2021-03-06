﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SegmentData.cs" company="bitterskittles">
//   Copyright © 2013 bitterskittles.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the SegmentData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NVaporWare
{
    using System;
    using System.Diagnostics.Contracts;

    public class SegmentData<T> : ISegmentData<T>
        where T : class
    {
        #region Fields

        private readonly T data;

        private readonly int offset;

        private readonly int size;

        #endregion

        #region Constructors and Destructors

        public SegmentData(T data, int offset, int size)
        {
            Contract.Requires<ArgumentNullException>(data != null);
            Contract.Requires<ArgumentOutOfRangeException>(offset >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(offset <= 0xFFFF);
            Contract.Requires<ArgumentOutOfRangeException>(size >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(size + offset - 1 <= 0xFFFF);

            this.data = data;
            this.offset = offset;
            this.size = size;
        }

        #endregion

        #region Public Properties

        public T Data
        {
            get
            {
                return this.data;
            }
        }

        public int Offset
        {
            get
            {
                return this.offset;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.data != null);
            Contract.Invariant(this.offset >= 0);
            Contract.Invariant(this.offset <= 0xFFFF);
            Contract.Invariant(this.size >= 0);
            Contract.Invariant(this.size + this.offset + -1 <= 0xFFFF);
        }

        #endregion
    }
}
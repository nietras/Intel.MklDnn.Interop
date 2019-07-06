 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DotNetCross.Memory.Views
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct View1D<T>
    {
        readonly object _objectOrNull;
        readonly IntPtr _byteOffsetOrPointer;
        // .NET has for good chosen int as size, would have preferred IntPtr e.g. nint
        // for length but this would give issues with interoperating with BCL
        readonly int _length0;

        public View1D(T[] array)
        {
            if (array == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
            if (default(T) == null && array.GetType() != typeof(T[]))
                ThrowHelper.ThrowArrayTypeMismatchException_ArrayTypeMustBeExactMatch(typeof(T));

            _objectOrNull = array;
            _byteOffsetOrPointer = ViewHelper.PerTypeValues<T>.ArrayAdjustment1D;
            _length0 = array.GetLength(0);
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct View2D<T>
    {
        readonly object _objectOrNull;
        readonly IntPtr _byteOffsetOrPointer;
        readonly IntPtr _byteStride0;
        // .NET has for good chosen int as size, would have preferred IntPtr e.g. nint
        // for length but this would give issues with interoperating with BCL
        readonly int _length0;
        readonly int _length1;

        public View2D(T[,] array)
        {
            if (array == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
            if (default(T) == null && array.GetType() != typeof(T[]))
                ThrowHelper.ThrowArrayTypeMismatchException_ArrayTypeMustBeExactMatch(typeof(T));

            _objectOrNull = array;
            _byteOffsetOrPointer = ViewHelper.PerTypeValues<T>.ArrayAdjustment2D;
            _length0 = array.GetLength(0);
            _length1 = array.GetLength(1);
            _byteStride0 = new IntPtr(_length1).Multiply(Unsafe.SizeOf<T>());
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct View3D<T>
    {
        readonly object _objectOrNull;
        readonly IntPtr _byteOffsetOrPointer;
        readonly IntPtr _byteStride0;
        readonly IntPtr _byteStride1;
        // .NET has for good chosen int as size, would have preferred IntPtr e.g. nint
        // for length but this would give issues with interoperating with BCL
        readonly int _length0;
        readonly int _length1;
        readonly int _length2;

        public View3D(T[,,] array)
        {
            if (array == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
            if (default(T) == null && array.GetType() != typeof(T[]))
                ThrowHelper.ThrowArrayTypeMismatchException_ArrayTypeMustBeExactMatch(typeof(T));

            _objectOrNull = array;
            _byteOffsetOrPointer = ViewHelper.PerTypeValues<T>.ArrayAdjustment3D;
            _length0 = array.GetLength(0);
            _length1 = array.GetLength(1);
            _length2 = array.GetLength(2);
            _byteStride1 = new IntPtr(_length2).Multiply(Unsafe.SizeOf<T>());
            _byteStride0 = _byteStride1.Multiply(_length1);
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct View4D<T>
    {
        readonly object _objectOrNull;
        readonly IntPtr _byteOffsetOrPointer;
        readonly IntPtr _byteStride0;
        readonly IntPtr _byteStride1;
        readonly IntPtr _byteStride2;
        // .NET has for good chosen int as size, would have preferred IntPtr e.g. nint
        // for length but this would give issues with interoperating with BCL
        readonly int _length0;
        readonly int _length1;
        readonly int _length2;
        readonly int _length3;

        public View4D(T[,,,] array)
        {
            if (array == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
            if (default(T) == null && array.GetType() != typeof(T[]))
                ThrowHelper.ThrowArrayTypeMismatchException_ArrayTypeMustBeExactMatch(typeof(T));

            _objectOrNull = array;
            _byteOffsetOrPointer = ViewHelper.PerTypeValues<T>.ArrayAdjustment4D;
            _length0 = array.GetLength(0);
            _length1 = array.GetLength(1);
            _length2 = array.GetLength(2);
            _length3 = array.GetLength(3);
            _byteStride2 = new IntPtr(_length3).Multiply(Unsafe.SizeOf<T>());
            _byteStride1 = _byteStride2.Multiply(_length2);
            _byteStride0 = _byteStride1.Multiply(_length1);
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct View5D<T>
    {
        readonly object _objectOrNull;
        readonly IntPtr _byteOffsetOrPointer;
        readonly IntPtr _byteStride0;
        readonly IntPtr _byteStride1;
        readonly IntPtr _byteStride2;
        readonly IntPtr _byteStride3;
        // .NET has for good chosen int as size, would have preferred IntPtr e.g. nint
        // for length but this would give issues with interoperating with BCL
        readonly int _length0;
        readonly int _length1;
        readonly int _length2;
        readonly int _length3;
        readonly int _length4;

        public View5D(T[,,,,] array)
        {
            if (array == null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
            if (default(T) == null && array.GetType() != typeof(T[]))
                ThrowHelper.ThrowArrayTypeMismatchException_ArrayTypeMustBeExactMatch(typeof(T));

            _objectOrNull = array;
            _byteOffsetOrPointer = ViewHelper.PerTypeValues<T>.ArrayAdjustment5D;
            _length0 = array.GetLength(0);
            _length1 = array.GetLength(1);
            _length2 = array.GetLength(2);
            _length3 = array.GetLength(3);
            _length4 = array.GetLength(4);
            _byteStride3 = new IntPtr(_length4).Multiply(Unsafe.SizeOf<T>());
            _byteStride2 = _byteStride3.Multiply(_length3);
            _byteStride1 = _byteStride2.Multiply(_length2);
            _byteStride0 = _byteStride1.Multiply(_length1);
        }
    }
}
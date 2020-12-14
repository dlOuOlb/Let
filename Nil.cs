#nullable enable

namespace dlOuOlb
{
	using S = System;
	using Any = System.Collections;
	using Typed = System.Collections.Generic;
	using Compiler = System.Runtime.CompilerServices;

	///<summary>This readonly struct represents an empty set.</summary>
	///<typeparam name="T">The type of the empty set's non-existent component.</typeparam>
	[S.Diagnostics.DebuggerDisplay(value: @"( )")]
	public readonly struct Nil<T>:S.IDisposable, Typed.IReadOnlyList<T>, Typed.IReadOnlySet<T>, Compiler.ITuple
	{
		#region Constructor
		///<summary>An empty set for the given type.</summary>
		public static readonly Nil<T> Static = new Nil<T>();
		#endregion

		#region Object
		///<summary>This method returns a string that represents the current empty set.</summary>
		///<returns>@"()"; an opening parenthesis and a closing parenthesis.</returns>
		public override S.String ToString() => @"()";
		#endregion

		#region Interface
		///<value>This as <see cref="Typed.IReadOnlySet{T}"/>.</value>
		public Typed.IReadOnlySet<T> Set => this;
		#endregion

		#region IDisposable
		void S.IDisposable.Dispose() { return; }
		#endregion

		#region IEnumerable
		Any.IEnumerator Any.IEnumerable.GetEnumerator() { yield break; }
		Typed.IEnumerator<T> Typed.IEnumerable<T>.GetEnumerator() { yield break; }
		#endregion

		#region IReadOnlyCollection
		S.Int32 Typed.IReadOnlyCollection<T>.Count => 0;
		#endregion

		#region IReadOnlyList
		T Typed.IReadOnlyList<T>.this[S.Int32 _] => throw new S.IndexOutOfRangeException();
		#endregion

		#region IReadOnlySet
		S.Boolean Typed.IReadOnlySet<T>.Contains(T V) => false;
		S.Boolean Typed.IReadOnlySet<T>.Overlaps(Typed.IEnumerable<T> P) => false;
		S.Boolean Typed.IReadOnlySet<T>.SetEquals(Typed.IEnumerable<T> P) => (this as Typed.IReadOnlySet<T>).IsSupersetOf(other: P);
		S.Boolean Typed.IReadOnlySet<T>.IsSubsetOf(Typed.IEnumerable<T> P) => true;
		S.Boolean Typed.IReadOnlySet<T>.IsSupersetOf(Typed.IEnumerable<T> P) { foreach(var _ in P) return false; return true; }
		S.Boolean Typed.IReadOnlySet<T>.IsProperSubsetOf(Typed.IEnumerable<T> P) { foreach(var _ in P) return true; return false; }
		S.Boolean Typed.IReadOnlySet<T>.IsProperSupersetOf(Typed.IEnumerable<T> P) => false;
		#endregion

		#region ITuple
		S.Int32 Compiler.ITuple.Length => 0;
		S.Object? Compiler.ITuple.this[S.Int32 _] => throw new S.IndexOutOfRangeException();
		#endregion
	}
}

#nullable restore

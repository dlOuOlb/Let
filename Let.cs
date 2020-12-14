#nullable enable

namespace dlOuOlb
{
	using S = System;
	using Any = System.Collections;
	using Typed = System.Collections.Generic;
	using Compiler = System.Runtime.CompilerServices;

	///<summary>This class provides <see langword="static"/> methods for creating a <see cref="Let{T}"/> instance.</summary>
	public static class Let:S.Object
	{
		///<summary>This <see langword="static"/> method creates a singleton, which holds a readonly value.</summary>
		///<typeparam name="T">The type of the singleton's only component.</typeparam>
		///<param name="V">The value of the singleton's only component.</param>
		///<returns>A singleton, which holds a readonly value.</returns>
		public static Let<T> New<T>(T V) => new Let<T>(V: V);
		///<summary>This <see langword="static"/> method creates a singleton, which holds a readonly value.</summary>
		///<typeparam name="T">The type of the singleton's only component.</typeparam>
		///<param name="V">The singleton to be copied.</param>
		///<returns>A singleton, which holds a readonly value.</returns>
		public static Let<T> New<T>(in Let<T> V) => V;
	}

	///<summary>This readonly struct represents a singleton, which holds a readonly value.</summary>
	///<typeparam name="T">The type of the singleton's only component.</typeparam>
	[S.Diagnostics.DebuggerDisplay(value: @"( {"+nameof(V)+@"} )")]
	public readonly struct Let<T>:S.IDisposable, Typed.IReadOnlyList<T>, Typed.IReadOnlySet<T>, Compiler.ITuple
	{
		#region Constructor
		///<summary>The value of the current singleton's only component.</summary>
		public readonly T V;
		///<summary>This constructor creates a new singleton, which holds a readonly value.</summary>
		///<param name="V">The value of the singleton's only component.</param>
		public Let(T V) => this.V=V;
		#endregion

		#region Operator
		///<summary>This operator takes a value from a singleton.</summary>
		///<param name="C">The singleton to be unwrapped.</param>
		public static explicit operator T(in Let<T> C) => C.V;
		///<summary>This operator wraps a value into a singleton.</summary>
		///<param name="V">The value to be wrapped.</param>
		public static explicit operator Let<T>(T V) => new Let<T>(V: V);
		#endregion

		#region Object
		///<summary>This method returns a string that represents the current singleton.</summary>
		///<returns>$"({<see cref="V"/>})"; the value inside parentheses.</returns>
		///<exception cref="S.NullReferenceException"/>
		public override S.String? ToString() => this.V is S.Object X ? X.ToString() is S.String Y ? $"({Y})" : null : throw new S.NullReferenceException();
		#endregion

		#region Interface
		///<value>This as <see cref="Typed.IReadOnlySet{T}"/>.</value>
		public Typed.IReadOnlySet<T> Set => this;
		#endregion

		#region IDisposable
		void S.IDisposable.Dispose() { return; }
		#endregion

		#region IEnumerable
		Any.IEnumerator Any.IEnumerable.GetEnumerator() { yield return this.V; yield break; }
		Typed.IEnumerator<T> Typed.IEnumerable<T>.GetEnumerator() { yield return this.V; yield break; }
		#endregion

		#region IReadOnlyCollection
		S.Int32 Typed.IReadOnlyCollection<T>.Count => 1;
		#endregion

		#region IReadOnlyList
		T Typed.IReadOnlyList<T>.this[S.Int32 I] => 0==I ? this.V : throw new S.IndexOutOfRangeException();
		#endregion

		#region IReadOnlySet
		S.Boolean Typed.IReadOnlySet<T>.Contains(T V) => this.V is S.Object X ? X.Equals(obj: V) : throw new S.NullReferenceException();
		S.Boolean Typed.IReadOnlySet<T>.Overlaps(Typed.IEnumerable<T> P) => (this as Typed.IReadOnlySet<T>).IsSubsetOf(other: P);
		S.Boolean Typed.IReadOnlySet<T>.SetEquals(Typed.IEnumerable<T> P) { if(this.V is S.Object X) { var Y = false; foreach(var V in P) if(X.Equals(obj: V)) Y=true; else return false; return Y; } else throw new S.NullReferenceException(); }
		S.Boolean Typed.IReadOnlySet<T>.IsSubsetOf(Typed.IEnumerable<T> P) { if(this.V is S.Object X) { foreach(var V in P) if(X.Equals(obj: V)) return true; else continue; return false; } else throw new S.NullReferenceException(); }
		S.Boolean Typed.IReadOnlySet<T>.IsSupersetOf(Typed.IEnumerable<T> P) { if(this.V is S.Object X) { foreach(var V in P) if(X.Equals(obj: V)) continue; else return false; return true; } else throw new S.NullReferenceException(); }
		S.Boolean Typed.IReadOnlySet<T>.IsProperSubsetOf(Typed.IEnumerable<T> P) { if(this.V is S.Object X) { S.Span<S.Boolean> M = stackalloc S.Boolean[2] { false,false }; foreach(var V in P) { var I = X.Equals(obj: V) ? 1 : 0; if(M[index: 1^I]) return true; else M[index: I]=true; } return false; } else throw new S.NullReferenceException(); }
		S.Boolean Typed.IReadOnlySet<T>.IsProperSupersetOf(Typed.IEnumerable<T> P) { if(this.V is S.Object) { foreach(var _ in P) return false; return true; } else throw new S.NullReferenceException(); }
		#endregion

		#region ITuple
		S.Int32 Compiler.ITuple.Length => 1;
		S.Object? Compiler.ITuple.this[S.Int32 I] => 0==I ? this.V : throw new S.IndexOutOfRangeException();
		#endregion
	}
}

#nullable restore

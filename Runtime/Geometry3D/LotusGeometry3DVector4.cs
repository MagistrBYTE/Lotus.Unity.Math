﻿//=====================================================================================================================
// Проект: LotusPlatform
// Раздел: Модуль математической системы
// Подраздел: Подсистема 3D геометрии
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusGeometry3DVector4.cs
*		Четырехмерный вектор.
*		Реализация четырехмерного вектора для реализации базовой информации и представления математических структур
*	данных о трехмерном пространстве.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 04.04.2021
//=====================================================================================================================
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
//---------------------------------------------------------------------------------------------------------------------
using Lotus.Core;
//=====================================================================================================================
namespace Lotus
{
	namespace Maths
	{
		//-------------------------------------------------------------------------------------------------------------
		//! \addtogroup Geometry3D
		/*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Четырехмерный вектор
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		[StructLayout(LayoutKind.Sequential)]
		public struct Vector4D : IEquatable<Vector4D>, IComparable<Vector4D>, ICloneable
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Единичный вектор
			/// </summary>
			public static readonly Vector4D One = new Vector4D(1, 1, 1);

			/// <summary>
			/// Вектор "право"
			/// </summary>
			public static readonly Vector4D Right = new Vector4D(1, 0, 0);

			/// <summary>
			/// Вектор "вверх"
			/// </summary>
			public static readonly Vector4D Up = new Vector4D(0, 1, 0);

			/// <summary>
			/// Вектор "вперед"
			/// </summary>
			public static readonly Vector4D Forward = new Vector4D(0, 0, 1);

			/// <summary>
			/// Нулевой вектор
			/// </summary>
			public static readonly Vector4D Zero = new Vector4D(0, 0, 0);
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			/// <summary>
			/// Текстовый формат отображения параметров вектора
			/// </summary>
			public static String ToStringFormat = "X = {0:0.00}; Y = {1:0.00}; Z = {2:0.00}";
			#endregion

			#region ======================================= СТАТИЧЕСКИЕ МЕТОДЫ  =======================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Косинус угла между векторами
			/// </summary>
			/// <param name="from">Начальный вектор</param>
			/// <param name="to">Конечный вектор</param>
			/// <returns>Косинус угла</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double Cos(ref Vector4D from, ref Vector4D to)
			{
				Double dot = from.X * to.X + from.Y * to.Y + from.Z * to.Z;
				Double ll = from.Length * to.Length;
				return dot / ll;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Угол между двумя векторами (в градусах)
			/// </summary>
			/// <param name="from">Начальный вектор</param>
			/// <param name="to">Конечные вектор</param>
			/// <returns>Угол в градусах</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double Angle(ref Vector4D from, ref Vector4D to)
			{
				Double dot = from.X * to.X + from.Y * to.Y + from.Z * to.Z;
				Double ll = from.Length * to.Length;
				Double csv = dot / ll;
				return Math.Acos(csv) * XMath.RadianToDegree_d;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Расстояние между двумя векторами
			/// </summary>
			/// <param name="a">Первый вектор</param>
			/// <param name="b">Второй вектор</param>
			/// <returns>Расстояние между двумя векторами</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double Distance(ref Vector3D a, ref Vector4D b)
			{
				Double x = b.X - a.X;
				Double y = b.Y - a.Y;
				Double z = b.Z - a.Z;

				return Math.Sqrt(x * x + y * y + z * z);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Скалярное произведение векторов
			/// </summary>
			/// <param name="a">Первый вектор</param>
			/// <param name="b">Второй вектор</param>
			/// <returns>Скаляр</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double Dot(Vector4D a, Vector4D b)
			{
				return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Линейная интерполяция векторов
			/// </summary>
			/// <param name="from">Начальный вектор</param>
			/// <param name="to">Конечный вектор</param>
			/// <param name="time">Время от 0 до 1</param>
			/// <returns>Интерполированный вектор</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector4D Lerp(ref Vector4D from, ref Vector4D to, Double time)
			{
				Vector4D vector;
				vector.X = from.X + (to.X - from.X) * time;
				vector.Y = from.Y + (to.Y - from.Y) * time;
				vector.Z = from.Z + (to.Z - from.Z) * time;
				vector.W = from.W + (to.W - from.W) * time;
				return vector;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Десереализация четырехмерного вектора из строки
			/// </summary>
			/// <param name="data">Строка данных</param>
			/// <returns>Четырехмерный вектор</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector4D DeserializeFromString(String data)
			{
				Vector4D vector = new Vector4D();
				String[] vector_data = data.Split(';');
				vector.X = XNumbers.ParseDouble(vector_data[0]);
				vector.Y = XNumbers.ParseDouble(vector_data[1]);
				vector.Z = XNumbers.ParseDouble(vector_data[2]);
				vector.W = XNumbers.ParseDouble(vector_data[3]);
				return vector;
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			/// <summary>
			/// Координата X
			/// </summary>
			public Double X;

			/// <summary>
			/// Координата Y
			/// </summary>
			public Double Y;

			/// <summary>
			/// Координата Z
			/// </summary>
			public Double Z;

			/// <summary>
			/// Координата W
			/// </summary>
			public Double W;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Квадрат длины вектора
			/// </summary>
			public Double SqrLength
			{
				get { return X * X + Y * Y + Z * Z; }
			}

			/// <summary>
			/// Длина вектора
			/// </summary>
			public Double Length
			{
				get { return Math.Sqrt(X * X + Y * Y + Z * Z); }
			}

			/// <summary>
			/// Нормализованный вектор
			/// </summary>
			public Vector4D Normalized
			{
				get
				{
					Double inv_lentgh = XMath.InvSqrt(X * X + Y * Y + Z * Z);
					return new Vector4D(X * inv_lentgh, Y * inv_lentgh, Z * inv_lentgh);
				}
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует вектор указанными параметрами
			/// </summary>
			/// <param name="x">X - координата</param>
			/// <param name="y">Y - координата</param>
			/// <param name="z">Z - координата</param>
			/// <param name="w">W - координата</param>
			//---------------------------------------------------------------------------------------------------------
			public Vector4D(Double x, Double y, Double z, Double w = 1.0)
			{
				X = x;
				Y = y;
				Z = z;
				W = w;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует вектор указанным вектором
			/// </summary>
			/// <param name="source">Вектор</param>
			//---------------------------------------------------------------------------------------------------------
			public Vector4D(Vector4D source)
			{
				X = source.X;
				Y = source.Y;
				Z = source.Z;
				W = source.W;
			}
			#endregion

			#region ======================================= СИСТЕМНЫЕ МЕТОДЫ ==========================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверяет равен ли текущий объект другому объекту того же типа
			/// </summary>
			/// <param name="obj">Сравниваемый объект</param>
			/// <returns>Статус равенства объектов</returns>
			//---------------------------------------------------------------------------------------------------------
			public override Boolean Equals(Object obj)
			{
				if (obj != null)
				{
					if (typeof(Vector4D) == obj.GetType())
					{
						Vector4D vector = (Vector4D)obj;
						return Equals(vector);
					}
				}
				return base.Equals(obj);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка равенства векторов по значению
			/// </summary>
			/// <param name="other">Сравниваемый вектор</param>
			/// <returns>Статус равенства векторов</returns>
			//---------------------------------------------------------------------------------------------------------
			public Boolean Equals(Vector4D other)
			{
				return this == other;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение векторов для упорядочивания
			/// </summary>
			/// <param name="other">Вектор</param>
			/// <returns>Статус сравнения векторов</returns>
			//---------------------------------------------------------------------------------------------------------
			public Int32 CompareTo(Vector4D other)
			{
				if (X > other.X)
				{
					return 1;
				}
				else
				{
					if (X == other.X && Y > other.Y)
					{
						return 1;
					}
					else
					{
						if (X == other.X && Y == other.Y && Z > other.Z)
						{
							return -1;
						}
						else
						{
							return 0;
						}
					}
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение хеш-кода вектора
			/// </summary>
			/// <returns>Хеш-код вектора</returns>
			//---------------------------------------------------------------------------------------------------------
			public override Int32 GetHashCode()
			{
				return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Полное копирование вектора
			/// </summary>
			/// <returns>Копия вектора</returns>
			//---------------------------------------------------------------------------------------------------------
			public Object Clone()
			{
				return MemberwiseClone();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование к текстовому представлению
			/// </summary>
			/// <param name="format">Формат отображения компонентов вектора</param>
			/// <returns>Текстовое представление вектора с указанием значений координат</returns>
			//---------------------------------------------------------------------------------------------------------
			public String ToString(String format)
			{
				return String.Format(ToStringFormat.Replace("0.00", format), X, Y, Z);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование к текстовому представлению
			/// </summary>
			/// <returns>Текстовое представление вектора с указанием значений координат</returns>
			//---------------------------------------------------------------------------------------------------------
			public override String ToString()
			{
				return String.Format(ToStringFormat, X, Y, Z);
			}
			#endregion

			#region ======================================= ОПЕРАТОРЫ =================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сложение векторов
			/// </summary>
			/// <param name="left">Первый вектор</param>
			/// <param name="right">Второй вектор</param>
			/// <returns>Сумма векторов</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector4D operator +(Vector4D left, Vector4D right)
			{
				return new Vector4D(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычитание векторов
			/// </summary>
			/// <param name="left">Первый вектор</param>
			/// <param name="right">Второй вектор</param>
			/// <returns>Разность векторов</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector4D operator -(Vector4D left, Vector4D right)
			{
				return new Vector4D(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Умножение вектора на скаляр
			/// </summary>
			/// <param name="vector">Вектор</param>
			/// <param name="scalar">Скаляр</param>
			/// <returns>Масштабированный вектор</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector4D operator *(Vector4D vector, Double scalar)
			{
				return new Vector4D(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Деление вектора на скаляр
			/// </summary>
			/// <param name="vector">Вектор</param>
			/// <param name="scalar">Скаляр</param>
			/// <returns>Масштабированный вектор</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector4D operator /(Vector4D vector, Double scalar)
			{
				scalar = 1 / scalar;
				return new Vector4D(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Умножение вектора на вектор. Скалярное произведение векторов
			/// </summary>
			/// <param name="left">Первый вектор</param>
			/// <param name="right">Второй вектор</param>
			/// <returns>Скаляр</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double operator *(Vector4D left, Vector4D right)
			{
				return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Умножение вектора на вектор. Векторное произведение векторов
			/// </summary>
			/// <param name="left">Левый вектор</param>
			/// <param name="right">Правый вектор</param>
			/// <returns>Вектор</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector4D operator ^(Vector4D left, Vector4D right)
			{
				return new Vector4D(left.Y * right.Z - left.Z * right.Y,
					left.Z * right.X - left.X * right.Z,
					left.X * right.Y - left.Y * right.X);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Умножение вектора на матрицу трансформации
			/// </summary>
			/// <param name="vector">Вектор</param>
			/// <param name="matrix">Матрица трансформации</param>
			/// <returns>Трансформированный вектор</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector4D operator *(Vector4D vector, Matrix3Dx3 matrix)
			{
				return new Vector4D(vector.X * matrix.M11 + vector.Y * matrix.M21 + vector.Z * matrix.M31,
					vector.X * matrix.M12 + vector.Y * matrix.M22 + vector.Z * matrix.M32,
					vector.X * matrix.M13 + vector.Y * matrix.M23 + vector.Z * matrix.M33);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Умножение вектора на матрицу трансформации
			/// </summary>
			/// <param name="vector">Вектор</param>
			/// <param name="matrix">Матрица трансформации</param>
			/// <returns>Трансформированный вектор</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector4D operator *(Vector4D vector, Matrix4Dx4 matrix)
			{
				return new Vector4D(vector.X * matrix.M11 + vector.Y * matrix.M21 + vector.Z * matrix.M31 + matrix.M41,
					vector.X * matrix.M12 + vector.Y * matrix.M22 + vector.Z * matrix.M32 + matrix.M42,
					vector.X * matrix.M13 + vector.Y * matrix.M23 + vector.Z * matrix.M33 + matrix.M43);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение векторов на равенство
			/// </summary>
			/// <param name="left">Первый вектор</param>
			/// <param name="right">Второй вектор</param>
			/// <returns>Статус равенства векторов</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean operator ==(Vector4D left, Vector4D right)
			{
				return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение векторов на неравенство
			/// </summary>
			/// <param name="left">Первый вектор</param>
			/// <param name="right">Второй вектор</param>
			/// <returns>Статус не равенства векторов</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean operator !=(Vector4D left, Vector4D right)
			{
				return left.X != right.X || left.Y != right.Y || left.Z != right.Z;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Реализация лексикографического порядка отношений векторов
			/// </summary>
			/// <param name="left">Левый вектор</param>
			/// <param name="right">Правый вектор</param>
			/// <returns>Статус меньше</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean operator <(Vector4D left, Vector4D right)
			{
				return left.X < right.X || left.X == right.X && left.Y < right.Y ||
				       left.X == right.X && left.Y == right.Y && left.Z < right.Z;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Реализация лексикографического порядка отношений векторов
			/// </summary>
			/// <param name="left">Левый вектор</param>
			/// <param name="right">Правый вектор</param>
			/// <returns>Статус больше</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean operator >(Vector4D left, Vector4D right)
			{
				return left.X > right.X || left.X == right.X && left.Y > right.Y ||
				       left.X == right.X && left.Y == right.Y && left.Z > right.Z;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обратный вектор
			/// </summary>
			/// <param name="vector">Исходный вектор</param>
			/// <returns>Обратный вектор</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector4D operator -(Vector4D vector)
			{
				return new Vector4D(-vector.X, -vector.Y, -vector.Z);
			}
			#endregion

			#region ======================================= ОПЕРАТОРЫ ПРЕОБРАЗОВАНИЯ ==================================
#if (UNITY_2017_1_OR_NEWER)
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Неявное преобразование в объект типа <see cref="UnityEngine.Vector3"/>
			/// </summary>
			/// <param name="vector">Вектор</param>
			/// <returns>Объект <see cref="UnityEngine.Vector3"/></returns>
			//---------------------------------------------------------------------------------------------------------
			public static implicit operator UnityEngine.Vector3(Vector4D vector)
			{
				return new UnityEngine.Vector3((Single)vector.X, (Single)vector.Y, (Single)vector.Z);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Неявное преобразование в объект типа <see cref="UnityEngine.Vector4"/>
			/// </summary>
			/// <param name="vector">Вектор</param>
			/// <returns>Объект <see cref="UnityEngine.Vector4"/></returns>
			//---------------------------------------------------------------------------------------------------------
			public static implicit operator UnityEngine.Vector4(Vector4D vector)
			{
				return new UnityEngine.Vector4((Single)vector.X, (Single)vector.Y, 
					(Single)vector.Z, (Single)vector.W);
			}
#endif
			#endregion

			#region ======================================= ИНДЕКСАТОР ================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Индексация компонентов вектора на основе индекса
			/// </summary>
			/// <param name="index">Индекс компонента</param>
			/// <returns>Компонента вектора</returns>
			//---------------------------------------------------------------------------------------------------------
			public Double this[Int32 index]
			{
				get
				{
					switch (index)
					{
						case 0:
							return X;
						case 1:
							return Y;
						case 2:
							return Z;
						default:
							return W;
					}
				}
				set
				{
					switch (index)
					{
						case 0:
							X = value;
							break;
						case 1:
							Y = value;
							break;
						case 2:
							Z = value;
							break;
						default:
							W = value;
							break;
					}
				}
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Нормализация вектора
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public void Normalize()
			{
				Double inv_lentgh = XMath.InvSqrt(X * X + Y * Y + Z * Z);
				X *= inv_lentgh;
				Y *= inv_lentgh;
				Z *= inv_lentgh;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление расстояние до вектора
			/// </summary>
			/// <param name="vector">Вектор</param>
			/// <returns>Расстояние до вектора</returns>
			//---------------------------------------------------------------------------------------------------------
			public Double Distance(Vector4D vector)
			{
				Double x = vector.X - X;
				Double y = vector.Y - Y;
				Double z = vector.Z - Z;

				return Math.Sqrt(x * x + y * y + z * z);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление скалярного произведения векторов
			/// </summary>
			/// <param name="vector">Вектор</param>
			/// <returns>Скалярное произведение векторов</returns>
			//---------------------------------------------------------------------------------------------------------
			public Double Dot(Vector4D vector)
			{
				return X * vector.X + Y * vector.Y + Z * vector.Z;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Установка компонентов вектора из наибольших компонентов двух векторов
			/// </summary>
			/// <param name="a">Первый вектор</param>
			/// <param name="b">Второй вектор</param>
			//---------------------------------------------------------------------------------------------------------
			public void SetMaximize(Vector4D a, Vector4D b)
			{
				X = a.X > b.X ? a.X : b.X;
				Y = a.Y > b.Y ? a.Y : b.Y;
				Z = a.Z > b.Z ? a.Z : b.Z;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Установка компонентов вектора из наименьших компонентов двух векторов
			/// </summary>
			/// <param name="a">Первый вектор</param>
			/// <param name="b">Второй вектор</param>
			//---------------------------------------------------------------------------------------------------------
			public void SetMinimize(Vector4D a, Vector4D b)
			{
				X = a.X < b.X ? a.X : b.X;
				Y = a.Y < b.Y ? a.Y : b.Y;
				Z = a.Z < b.Z ? a.Z : b.Z;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Векторное произведение c нормализацией результата
			/// </summary>
			/// <param name="left">Левый вектор</param>
			/// <param name="right">Правый вектор</param>
			//---------------------------------------------------------------------------------------------------------
			public void CrossNormalize(Vector4D left, Vector4D right)
			{
				X = left.Y * right.Z - left.Z * right.Y;
				Y = left.Z * right.X - left.X * right.Z;
				Z = left.X * right.Y - left.Y * right.X;
				Double inv_length = XMath.InvSqrt(X * X + Y * Y + Z * Z);
				X *= inv_length;
				Y *= inv_length;
				Z *= inv_length;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Трансформация вектора как точки
			/// </summary>
			/// <param name="matrix">Матрица трансформации</param>
			//---------------------------------------------------------------------------------------------------------
			public void TransformAsPoint(Matrix4Dx4 matrix)
			{
				this = new Vector4D(X * matrix.M11 + Y * matrix.M21 + Z * matrix.M31 + matrix.M41,
									X * matrix.M12 + Y * matrix.M22 + Z * matrix.M32 + matrix.M42,
									X * matrix.M13 + Y * matrix.M23 + Z * matrix.M33 + matrix.M43);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Трансформация вектора как вектора
			/// </summary>
			/// <param name="matrix">Матрица трансформации</param>
			//---------------------------------------------------------------------------------------------------------
			public void TransformAsVector(Matrix4Dx4 matrix)
			{
				this = new Vector4D(X * matrix.M11 + Y * matrix.M21 + Z * matrix.M31,
									X * matrix.M12 + Y * matrix.M22 + Z * matrix.M32,
									X * matrix.M13 + Y * matrix.M23 + Z * matrix.M33);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сериализация вектора в строку
			/// </summary>
			/// <returns>Строка данных</returns>
			//---------------------------------------------------------------------------------------------------------
			public String SerializeToString()
			{
				return String.Format("{0};{1};{2};{3}", X, Y, Z, W);
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/*@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
﻿//=====================================================================================================================
// Проект: LotusPlatform
// Раздел: Модуль математической системы
// Подраздел: Подсистема 3D геометрии
// Группа: Трехмерные геометрические примитивы
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusGeometry3DRay.cs
*		Структура для представления луча в трехмерном пространстве.
*		Реализация структуры для представления луча в трехмерном пространстве.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 04.04.2021
//=====================================================================================================================
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
		/// Трехмерный луч
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		[StructLayout(LayoutKind.Sequential)]
		public struct Ray3D : IEquatable<Ray3D>, IComparable<Ray3D>
		{
			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			/// <summary>
			/// Текстовый формат отображения параметров луча
			/// </summary>
			public static String ToStringFormat = "Pos = {0:0.00}, {1:0.00}, {2:0.00}; Dir = {3:0.00}, {4:0.00}, {5:0.00}";
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			/// <summary>
			/// Позиция луча
			/// </summary>
			public Vector3D Position;

			/// <summary>
			/// Направление луча
			/// </summary>
			public Vector3D Direction;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует луч указанными параметрами
			/// </summary>
			/// <param name="pos">Позиция луча</param>
			/// <param name="dir">Направление луча</param>
			//---------------------------------------------------------------------------------------------------------
			public Ray3D(Vector3D pos, Vector3D dir)
			{
				Position = pos;
				Direction = dir;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует луч указанным лучом
			/// </summary>
			/// <param name="source">Луч</param>
			//---------------------------------------------------------------------------------------------------------
			public Ray3D(Ray3D source)
			{
				Position = source.Position;
				Direction = source.Direction;
			}

#if (UNITY_2017_1_OR_NEWER)
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует луч указанными параметрами
			/// </summary>
			/// <param name="pos">Позиция луча</param>
			/// <param name="dir">Направление луча</param>
			//---------------------------------------------------------------------------------------------------------
			public Ray3D(UnityEngine.Vector3 pos, UnityEngine.Vector3 dir)
			{
				Position = new Vector3D(pos.x, pos.y, pos.z);
				Direction = new Vector3D(dir.x, dir.y, dir.z);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует луч указанным лучом
			/// </summary>
			/// <param name="source">Луч</param>
			//---------------------------------------------------------------------------------------------------------
			public Ray3D(UnityEngine.Ray source)
			{
				Position = new Vector3D(source.origin.x, source.origin.y, source.origin.z);
				Direction = new Vector3D(source.direction.x, source.direction.y, source.direction.z);
			}
#endif
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
					if (typeof(Ray3D) == obj.GetType())
					{
						Ray3D ray = (Ray3D)obj;
						return Equals(ray);
					}
				}
				return base.Equals(obj);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка равенства лучей по значению
			/// </summary>
			/// <param name="other">Сравниваемый луч</param>
			/// <returns>Статус равенства лучей</returns>
			//---------------------------------------------------------------------------------------------------------
			public Boolean Equals(Ray3D other)
			{
				return this == other;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение лучей для упорядочивания
			/// </summary>
			/// <param name="other">Сравниваемый луч</param>
			/// <returns>Статус сравнения лучей</returns>
			//---------------------------------------------------------------------------------------------------------
			public Int32 CompareTo(Ray3D other)
			{
				if (Position > other.Position)
				{
					return 1;
				}
				else
				{
					if (Position == other.Position && Direction > other.Direction)
					{
						return 1;
					}
					else
					{
						return 0;
					}
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение хеш-кода луча
			/// </summary>
			/// <returns>Хеш-код луча</returns>
			//---------------------------------------------------------------------------------------------------------
			public override Int32 GetHashCode()
			{
				return Position.GetHashCode() ^ Direction.GetHashCode();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Полное копирование луча
			/// </summary>
			/// <returns>Копия луча</returns>
			//---------------------------------------------------------------------------------------------------------
			public Object Clone()
			{
				return MemberwiseClone();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование к текстовому представлению
			/// </summary>
			/// <returns>Текстовое представление луча с указанием значений</returns>
			//---------------------------------------------------------------------------------------------------------
			public override String ToString()
			{
				return String.Format(ToStringFormat, Position.X, Position.Y, Position.Z, 
					Direction.X, Direction.Y, Direction.Z);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование к текстовому представлению
			/// </summary>
			/// <param name="format">Формат отображения</param>
			/// <returns>Текстовое представление луча с указанием значений</returns>
			//---------------------------------------------------------------------------------------------------------
			public String ToString(String format)
			{
				return "Pos = " + Position.ToString(format) + "; Dir = " + Direction.ToString(format);
			}
			#endregion

			#region ======================================= ОПЕРАТОРЫ =================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение лучей на равенство
			/// </summary>
			/// <param name="left">Первый луч</param>
			/// <param name="right">Второй луч</param>
			/// <returns>Статус равенства лучей</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean operator ==(Ray3D left, Ray3D right)
			{
				return left.Position == right.Position && left.Direction == right.Direction;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение лучей на неравенство
			/// </summary>
			/// <param name="left">Первый луч</param>
			/// <param name="right">Второй луч</param>
			/// <returns>Статус неравенства лучей</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean operator !=(Ray3D left, Ray3D right)
			{
				return left.Position != right.Position || left.Direction != right.Direction;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обратный луч
			/// </summary>
			/// <param name="ray">Исходный луч</param>
			/// <returns>Обратный луч</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Ray3D operator -(Ray3D ray)
			{
				return new Ray3D(ray.Position, -ray.Direction);
			}
			#endregion

			#region ======================================= ОПЕРАТОРЫ ПРЕОБРАЗОВАНИЯ ==================================
#if (UNITY_2017_1_OR_NEWER)
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Неявное преобразование в объект типа <see cref="UnityEngine.Ray"/> 
			/// </summary>
			/// <param name="ray">Луч</param>
			/// <returns>Объект <see cref="UnityEngine.Ray"/></returns>
			//---------------------------------------------------------------------------------------------------------
			public static implicit operator UnityEngine.Ray(Ray3D ray)
			{
				return new UnityEngine.Ray(new UnityEngine.Vector3((Single)ray.Position.X, (Single)ray.Position.Y, (Single)ray.Position.Z),
					new UnityEngine.Vector3((Single)ray.Direction.X, (Single)ray.Direction.Y, (Single)ray.Direction.Z));
			}
#endif
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение точки на луче
			/// </summary>
			/// <param name="distance">Дистанция от начала луча</param>
			/// <returns>Точка на луче</returns>
			//---------------------------------------------------------------------------------------------------------
			public Vector3D GetPoint(Double distance)
			{
				return Position + Direction * distance;
			}
			#endregion
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Трехмерный луч
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		[StructLayout(LayoutKind.Sequential)]
		public struct Ray3Df : IEquatable<Ray3Df>, IComparable<Ray3Df>
		{
			#region ======================================= СТАТИЧЕСКИЕ ДАННЫЕ ========================================
			/// <summary>
			/// Текстовый формат отображения параметров луча
			/// </summary>
			public static String ToStringFormat = "Pos = {0:0.00}, {1:0.00}, {2:0.00}; Dir = {3:0.00}, {4:0.00}, {5:0.00}";
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			/// <summary>
			/// Позиция луча
			/// </summary>
			public Vector3Df Position;

			/// <summary>
			/// Направление луча
			/// </summary>
			public Vector3Df Direction;
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует луч указанными параметрами
			/// </summary>
			/// <param name="pos">Позиция луча</param>
			/// <param name="dir">Направление луча</param>
			//---------------------------------------------------------------------------------------------------------
			public Ray3Df(Vector3Df pos, Vector3Df dir)
			{
				Position = pos;
				Direction = dir;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует луч указанным лучом
			/// </summary>
			/// <param name="source">Луч</param>
			//---------------------------------------------------------------------------------------------------------
			public Ray3Df(Ray3Df source)
			{
				Position = source.Position;
				Direction = source.Direction;
			}

#if (UNITY_2017_1_OR_NEWER)
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует луч указанными параметрами
			/// </summary>
			/// <param name="pos">Позиция луча</param>
			/// <param name="dir">Направление луча</param>
			//---------------------------------------------------------------------------------------------------------
			public Ray3Df(UnityEngine.Vector3 pos, UnityEngine.Vector3 dir)
			{
				Position = new Vector3Df(pos.x, pos.y, pos.z);
				Direction = new Vector3Df(dir.x, dir.y, dir.z);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует луч указанным лучом
			/// </summary>
			/// <param name="source">Луч</param>
			//---------------------------------------------------------------------------------------------------------
			public Ray3Df(UnityEngine.Ray source)
			{
				Position = new Vector3Df(source.origin.x, source.origin.y, source.origin.z);
				Direction = new Vector3Df(source.direction.x, source.direction.y, source.direction.z);
			}
#endif
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
					if (typeof(Ray3Df) == obj.GetType())
					{
						Ray3Df ray = (Ray3Df)obj;
						return Equals(ray);
					}
				}
				return base.Equals(obj);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка равенства лучей по значению
			/// </summary>
			/// <param name="other">Сравниваемый луч</param>
			/// <returns>Статус равенства лучей</returns>
			//---------------------------------------------------------------------------------------------------------
			public Boolean Equals(Ray3Df other)
			{
				return this == other;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение лучей для упорядочивания
			/// </summary>
			/// <param name="other">Сравниваемый луч</param>
			/// <returns>Статус сравнения лучей</returns>
			//---------------------------------------------------------------------------------------------------------
			public Int32 CompareTo(Ray3Df other)
			{
				if (Position > other.Position)
				{
					return 1;
				}
				else
				{
					if (Position == other.Position && Direction > other.Direction)
					{
						return 1;
					}
					else
					{
						return 0;
					}
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение хеш-кода луча
			/// </summary>
			/// <returns>Хеш-код луча</returns>
			//---------------------------------------------------------------------------------------------------------
			public override Int32 GetHashCode()
			{
				return Position.GetHashCode() ^ Direction.GetHashCode();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Полное копирование луча
			/// </summary>
			/// <returns>Копия луча</returns>
			//---------------------------------------------------------------------------------------------------------
			public Object Clone()
			{
				return MemberwiseClone();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование к текстовому представлению
			/// </summary>
			/// <returns>Текстовое представление луча с указанием значений</returns>
			//---------------------------------------------------------------------------------------------------------
			public override String ToString()
			{
				return String.Format(ToStringFormat, Position.X, Position.Y, Position.Z,
					Direction.X, Direction.Y, Direction.Z);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование к текстовому представлению
			/// </summary>
			/// <param name="format">Формат отображения</param>
			/// <returns>Текстовое представление луча с указанием значений</returns>
			//---------------------------------------------------------------------------------------------------------
			public String ToString(String format)
			{
				return "Pos = " + Position.ToString(format) + "; Dir = " + Direction.ToString(format);
			}
			#endregion

			#region ======================================= ОПЕРАТОРЫ =================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение лучей на равенство
			/// </summary>
			/// <param name="left">Первый луч</param>
			/// <param name="right">Второй луч</param>
			/// <returns>Статус равенства лучей</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean operator ==(Ray3Df left, Ray3Df right)
			{
				return left.Position == right.Position && left.Direction == right.Direction;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Сравнение лучей на неравенство
			/// </summary>
			/// <param name="left">Первый луч</param>
			/// <param name="right">Второй луч</param>
			/// <returns>Статус неравенства лучей</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean operator !=(Ray3Df left, Ray3Df right)
			{
				return left.Position != right.Position || left.Direction != right.Direction;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обратный луч
			/// </summary>
			/// <param name="ray">Исходный луч</param>
			/// <returns>Обратный луч</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Ray3Df operator -(Ray3Df ray)
			{
				return new Ray3Df(ray.Position, -ray.Direction);
			}
			#endregion

			#region ======================================= ОПЕРАТОРЫ ПРЕОБРАЗОВАНИЯ ==================================
#if (UNITY_2017_1_OR_NEWER)
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Неявное преобразование в объект типа <see cref="UnityEngine.Ray"/> 
			/// </summary>
			/// <param name="ray">Луч</param>
			/// <returns>Объект <see cref="UnityEngine.Ray"/></returns>
			//---------------------------------------------------------------------------------------------------------
			public static implicit operator UnityEngine.Ray(Ray3Df ray)
			{
				return new UnityEngine.Ray(ray.Position , ray.Direction);
			}
#endif
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение точки на луче
			/// </summary>
			/// <param name="distance">Дистанция от начала луча</param>
			/// <returns>Точка на луче</returns>
			//---------------------------------------------------------------------------------------------------------
			public Vector3Df GetPoint(Single distance)
			{
				return Position + Direction * distance;
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/*@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
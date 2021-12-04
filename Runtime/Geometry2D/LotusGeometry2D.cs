﻿//=====================================================================================================================
// Проект: LotusPlatform
// Раздел: Модуль математической системы
// Подраздел: Подсистема 2D геометрии
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusGeometry2D.cs
*		Вспомогательные методы для работы в 2D пространстве.
*		Работа в 2D пространстве с векторами и углами требует большого количества вспомогательного кода, поэтому многие
*	методы упрощают решение многих типовых задач возникающих при работе с 2D геометрией.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 04.04.2021
//=====================================================================================================================
using System;
using System.Collections.Generic;
//=====================================================================================================================
namespace Lotus
{
	namespace Maths
	{
		//-------------------------------------------------------------------------------------------------------------
		//! \defgroup Geometry2D Подсистема 2D геометрии
		//! Подсистема 2D геометрии реализует работу с геометрическими данными в 2D пространстве.
		//! Сюда входит математические структуры данных для работы в 2D пространстве, алгоритмы поиска и нахождения 
		//! ближайших точек проекции, пересечения и вычисления дистанции для основных геометрических тел/примитивов.
		//! \ingroup Math
		/*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Статический класс для реализации вспомогательных методов для работы с 2D пространством
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XGeometry2D
		{
			#region ======================================= ДАННЫЕ ====================================================
			/// <summary>
			/// Точность вещественного числа используемого при операция поиска/пересечения геометрических примитивов
			/// </summary>
			/// <remarks>
			/// Это не константа, её можно регулировать для обеспечения нужной точности вычислений
			/// </remarks>
			public static Single Eplsilon_f = 0.001f;

			/// <summary>
			/// Точность вещественного числа используемого при операция поиска/пересечения геометрических примитивов
			/// </summary>
			/// <remarks>
			/// Это не константа, её можно регулировать для обеспечения нужной точности вычислений
			/// </remarks>
			public static Single Eplsilon_d = 0.00f;

#pragma warning disable 0414
			//
			// Здесь приняты текстурные координаты как в OpenGL - начало координат нижний-левый угол
			// В Unity используется такая же система координат
			//
			/// <summary>
			/// Текстурные координаты
			/// </summary>
			public static readonly Vector2Df MapUV_TopLeft = new Vector2Df(0, 1);

			/// <summary>
			/// Текстурные координаты
			/// </summary>
			public static readonly Vector2Df MapUV_TopCenter = new Vector2Df(0.5f, 1);

			/// <summary>
			/// Текстурные координаты
			/// </summary>
			public static readonly Vector2Df MapUV_TopRight = new Vector2Df(1, 1);

			/// <summary>
			/// Текстурные координаты
			/// </summary>
			public static readonly Vector2Df MapUV_MiddleLeft = new Vector2Df(0, 0.5f);

			/// <summary>
			/// Текстурные координаты
			/// </summary>
			public static readonly Vector2Df MapUV_MiddleCenter = new Vector2Df(0.5f, 0.5f);

			/// <summary>
			/// Текстурные координаты
			/// </summary>
			public static readonly Vector2Df MapUV_MiddleRight = new Vector2Df(1, 0.5f);

			/// <summary>
			/// Текстурные координаты
			/// </summary>
			public static readonly Vector2Df MapUV_BottomLeft = new Vector2Df(0, 0);

			/// <summary>
			/// Текстурные координаты
			/// </summary>
			public static readonly Vector2Df MapUV_BottomCenter = new Vector2Df(0.5f, 0);

			/// <summary>
			/// Текстурные координаты
			/// </summary>
			public static readonly Vector2Df MapUV_BottomRight = new Vector2Df(1, 0);
#pragma warning restore 0414
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение точки на окружности в плоскости XY
			/// </summary>
			/// <param name="radius">Радиус окружности</param>
			/// <param name="angle">Угол в градусах</param>
			/// <returns>Точка</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector2Df PointOnCircle(Single radius, Single angle)
			{
				Single angle_in_radians = angle * XMath.DegreeToRadian_f;
				return new Vector2Df(radius * XMath.Sin(angle_in_radians), radius * XMath.Cos(angle_in_radians));
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка точек на окружности в плоскости XY
			/// </summary>
			/// <param name="radius">Радиус окружности</param>
			/// <param name="segments">Количество сегментов окружности</param>
			/// <returns>Список точек</returns>
			//---------------------------------------------------------------------------------------------------------
			public static List<Vector2Df> PointsOnCircle(Single radius, Int32 segments)
			{
				Single segment_angle = 360f / segments;
				Single current_angle = 0;
				var ring = new List<Vector2Df>(segments);
				for (var i = 0; i < segments; i++)
				{
					ring.Add(PointOnCircle(radius, current_angle));
					current_angle += segment_angle;
				}
				return ring;
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/*@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
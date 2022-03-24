//=====================================================================================================================
// Проект: LotusPlatform
// Раздел: Модуль математической системы
// Подраздел: Подсистема для работы со сплайнами
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusMathSplineBezier2D.cs
*		Алгоритмы работы с кривыми и путями Безье в двухмерном пространстве.
*		Реализация алгоритмов работы с кривыми и путями Безье в двухмерном пространстве.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 27.03.2022
//=====================================================================================================================
using System;
using System.Collections.Generic;
using UnityEngine;
//=====================================================================================================================
namespace Lotus
{
	namespace Maths
	{
		//-------------------------------------------------------------------------------------------------------------
		//! \addtogroup MathSpline
		/*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Квадратичная кривая Безье
		/// </summary>
		/// <remarks>
		/// Квадратичная кривая Безье второго порядка создается тремя опорным точками.
		/// При этом кривая проходит только через начальную и конечную точку.
		/// Другая точка (будет назвать её управляющей) определяет лишь форму кривой
		/// </remarks>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class CBezierQuadratic2D : CSplineBase2D
		{
			#region ======================================= СТАТИЧЕСКИЕ МЕТОДЫ ========================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление точки на кривой Безье представленной с помощью трех контрольных точек
			/// </summary>
			/// <param name="time">Положение точки от 0 до 1, где 0 соответствует крайней "левой" точки, 1 соответствует крайне
			/// "правой" конечной точки кривой</param>
			/// <param name="start">Начальная точка</param>
			/// <param name="handle_point">Контрольная точка</param>
			/// <param name="end">Конечная точка</param>
			/// <returns>Позиция точки на кривой Безье</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector2 CalculatePoint(Single time, Vector2 start, Vector2 handle_point, Vector2 end)
			{
				Single u = 1 - time;
				Single tt = time * time;
				Single uu = u * u;

				return uu * start + 2 * time * u * handle_point + tt * end;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление точки на кривой Безье представленной с помощью трех контрольных точек
			/// </summary>
			/// <param name="time">Положение точки от 0 до 1, где 0 соответствует крайней "левой" точки, 1 соответствует крайне
			/// "правой" конечной точки кривой</param>
			/// <param name="start">Начальная точка</param>
			/// <param name="handle_point">Контрольная точка</param>
			/// <param name="end">Конечная точка</param>
			/// <returns>Позиция точки на кривой Безье</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector2 CalculatePoint(Single time, ref Vector2 start, ref Vector2 handle_point, ref Vector2 end)
			{
				Single u = 1 - time;
				Single tt = time * time;
				Single uu = u * u;

				return uu * start + 2 * time * u * handle_point + tt * end;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление первой производной точки на кривой Безье представленной с помощью трех контрольных точек
			/// </summary>
			/// <remarks>
			/// Первая производная показывает скорость изменения функции в данной точки.
			/// Физическим смысл производной - скорость в данной точке 
			/// </remarks>
			/// <param name="time">Положение точки от 0 до 1, где 0 соответствует крайней "левой" точки, 1 соответствует крайне
			/// "правой" конечной точки кривой</param>
			/// <param name="start">Начальная точка</param>
			/// <param name="handle_point">Контрольная точка</param>
			/// <param name="end">Конечная точка</param>
			/// <returns>Первая производная точки на кривой Безье</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector2 CalculateFirstDerivative(Single time, Vector2 start, Vector2 handle_point, Vector2 end)
			{
				return(2f * (1f - time) * (handle_point - start) + 2f * time * (end - handle_point));
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление первой производной точки на кривой Безье представленной с помощью трех контрольных точек
			/// </summary>
			/// <remarks>
			/// Первая производная показывает скорость изменения функции в данной точки.
			/// Физическим смысл производной - скорость в данной точке 
			/// </remarks>
			/// <param name="time">Положение точки от 0 до 1, где 0 соответствует крайней "левой" точки, 1 соответствует крайне
			/// "правой" конечной точки кривой</param>
			/// <param name="start">Начальная точка</param>
			/// <param name="handle_point">Контрольная точка</param>
			/// <param name="end">Конечная точка</param>
			/// <returns>Первая производная точки на кривой Безье</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector2 CalculateFirstDerivative(Single time, ref Vector2 start, ref Vector2 handle_point, ref Vector2 end)
			{
				return 2f * (1f - time) * (handle_point - start) + 2f * time * (end - handle_point);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Управляющая точка
			/// </summary>
			public Vector2 HandlePoint
			{
				get { return mControlPoints[1]; }
				set { mControlPoints[1] = value; }
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CBezierQuadratic2D()
				: base(3)
			{
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="start_point">Начальная точка</param>
			/// <param name="end_point">Конечная точка</param>
			//---------------------------------------------------------------------------------------------------------
			public CBezierQuadratic2D(Vector2 start_point, Vector2 end_point)
				: base(start_point, end_point)
			{
			}
			#endregion

			#region ======================================= МЕТОДЫ ILotusSpline2D =====================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление точки на сплайне
			/// </summary>
			/// <param name="time">Положение точки от 0 до 1</param>
			/// <returns>Позиция точки на сплайне</returns>
			//---------------------------------------------------------------------------------------------------------
			public override Vector2 CalculatePoint(Single time)
			{
				Single u = 1 - time;
				Single tt = time * time;
				Single uu = u * u;

				return uu * mControlPoints[0] + 2 * time * u * mControlPoints[1] + tt * mControlPoints[2];
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление первой производной точки на кривой Безье
			/// </summary>
			/// <remarks>
			/// Первая производная показывает скорость изменения функции в данной точки.
			/// Физическим смысл производной - скорость на данной точке 
			/// </remarks>
			/// <param name="time">Положение точки от 0 до 1, где 0 соответствует крайней "левой" точки, 1 соответствует крайне
			/// "правой" конечной точки кривой</param>
			/// <returns>Первая производная точки на кривой Безье</returns>
			//---------------------------------------------------------------------------------------------------------
			public Vector2 CalculateFirstDerivative(Single time)
			{
				return 2f * (1f - time) * (HandlePoint - StartPoint) + 2f * time * (EndPoint - HandlePoint);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка на управляющую точку
			/// </summary>
			/// <param name="index">Позиция(индекс) контрольной точки</param>
			/// <returns>Статус управляющей точки</returns>
			//---------------------------------------------------------------------------------------------------------
			public Boolean IsHandlePoint(Int32 index)
			{
				return index == 1;
			}
			#endregion
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Кубическая кривая Безье
		/// </summary>
		/// <remarks>
		/// Кубическая кривая Безье третьего порядка создается четырьмя опорным точками.
		/// При этом кривая проходит только через начальную и конечную точку.
		/// Другие две точки (будет назвать их управляющими) определяет лишь форму кривой
		/// </remarks>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class CBezierCubic2D : CSplineBase2D
		{
			#region ======================================= СТАТИЧЕСКИЕ МЕТОДЫ ========================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление точки на кривой Безье представленной с помощью четырех контрольных точек
			/// </summary>
			/// <param name="time">Положение точки от 0 до 1, где 0 соответствует крайней "левой" точки, 1 соответствует крайне
			/// "правой" конечной точки кривой</param>
			/// <param name="start">Начальная точка</param>
			/// <param name="handle_point1">Первая управляющая точка</param>
			/// <param name="handle_point2">Вторая управляющая точка</param>
			/// <param name="end">Конечная точка</param>
			/// <returns>Позиция точки на кривой Безье</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector2 CalculatePoint(Single time, Vector2 start, Vector2 handle_point1, Vector2 handle_point2, Vector2 end)
			{
				Single u = 1 - time;
				Single tt = time * time;
				Single uu = u * u;
				Single uuu = uu * u;
				Single ttt = tt * time;

				Vector2 point = uuu * start;

				point += 3 * uu * time * handle_point1;
				point += 3 * u * tt * handle_point2;
				point += ttt * end;

				return point;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление точки на кривой Безье представленной с помощью четырех контрольных точек
			/// </summary>
			/// <param name="time">Положение точки от 0 до 1, где 0 соответствует крайней "левой" точки, 1 соответствует крайне
			/// "правой" конечной точки кривой</param>
			/// <param name="start">Начальная точка</param>
			/// <param name="handle_point1">Первая управляющая точка</param>
			/// <param name="handle_point2">Вторая управляющая точка</param>
			/// <param name="end">Конечная точка</param>
			/// <returns>Позиция точки на кривой Безье</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector2 CalculatePoint(Single time, ref Vector2 start, ref Vector2 handle_point1,
				ref Vector2 handle_point2, ref Vector2 end)
			{
				Single u = 1 - time;
				Single tt = time * time;
				Single uu = u * u;
				Single uuu = uu * u;
				Single ttt = tt * time;

				Vector2 point = uuu * start;

				point += 3 * uu * time * handle_point1;
				point += 3 * u * tt * handle_point2;
				point += ttt * end;

				return point;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление первой производной точки на кривой Безье представленной с помощью четырех контрольных точек
			/// </summary>
			/// <remarks>
			/// Первая производная показывает скорость изменения функции в данной точки.
			/// Физическим смысл производной - скорость в данной точке 
			/// </remarks>
			/// <param name="time">Положение точки от 0 до 1, где 0 соответствует крайней "левой" точки, 1 соответствует крайне
			/// "правой" конечной точки кривой</param>
			/// <param name="start">Начальная точка</param>
			/// <param name="handle_point1">Первая управляющая точка</param>
			/// <param name="handle_point2">Вторая управляющая точка</param>
			/// <param name="end">Конечная точка</param>
			/// <returns>Первая производная точки на кривой Безье</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector2 CalculateFirstDerivative(Single time, Vector2 start, Vector2 handle_point1, Vector2 handle_point2, Vector2 end)
			{
				Single u = 1 - time;
				return 3f * u * u * (handle_point1 - start) +
				       6f * u * time * (handle_point2 - handle_point1) +
				       3f * time * time * (end - handle_point2);

			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление первой производной точки на кривой Безье представленной с помощью четырех контрольных точек
			/// </summary>
			/// <remarks>
			/// Первая производная показывает скорость изменения функции в данной точки.
			/// Физическим смысл производной - скорость в данной точке 
			/// </remarks>
			/// <param name="time">Положение точки от 0 до 1, где 0 соответствует крайней "левой" точки, 1 соответствует крайне
			/// "правой" конечной точки кривой</param>
			/// <param name="start">Начальная точка</param>
			/// <param name="handle_point1">Первая управляющая точка</param>
			/// <param name="handle_point2">Вторая управляющая точка</param>
			/// <param name="end">Конечная точка</param>
			/// <returns>Первая производная точки на кривой Безье</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector2 CalculateFirstDerivative(Single time, ref Vector2 start, ref Vector2 handle_point1,
				ref Vector2 handle_point2, ref Vector2 end)
			{
				Single u = 1 - time;
				return 3f * u * u * (handle_point1 - start) +
				       6f * u * time * (handle_point2 - handle_point1) +
				       3f * time * time * (end - handle_point2);
			}
			#endregion

			#region ======================================= ДАННЫЕ ====================================================
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Первая управляющая точка
			/// </summary>
			public Vector2 HandlePoint1
			{
				get { return mControlPoints[1]; }
				set { mControlPoints[1] = value; }
			}

			/// <summary>
			/// Вторая управляющая точка
			/// </summary>
			public Vector2 HandlePoint2
			{
				get { return mControlPoints[2]; }
				set { mControlPoints[2] = value; }
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CBezierCubic2D()
				:base(4)
			{
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор инициализирует объект класса указанными параметрами
			/// </summary>
			/// <param name="start_point">Начальная точка</param>
			/// <param name="end_point">Конечная точка</param>
			//---------------------------------------------------------------------------------------------------------
			public CBezierCubic2D(Vector2 start_point, Vector2 end_point)
								: base(4)
			{
				mControlPoints[0] = start_point;
				mControlPoints[1] = (start_point + end_point) / 3;
				mControlPoints[2] = (start_point + end_point) / 3 * 2;
				mControlPoints[3] = end_point;
			}
			#endregion

			#region ======================================= МЕТОДЫ ILotusSpline2D =====================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление точки на сплайне
			/// </summary>
			/// <param name="time">Положение точки от 0 до 1</param>
			/// <returns>Позиция точки на сплайне</returns>
			//---------------------------------------------------------------------------------------------------------
			public override Vector2 CalculatePoint(Single time)
			{
				Single u = 1 - time;
				Single tt = time * time;
				Single uu = u * u;
				Single uuu = uu * u;
				Single ttt = tt * time;

				Vector2 point = uuu * mControlPoints[0];

				point += 3 * uu * time * mControlPoints[1];
				point += 3 * u * tt * mControlPoints[2];
				point += ttt * mControlPoints[3];

				return point;
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание кубической кривой проходящий через заданные(опорные) точки на равномерно заданном времени
			/// </summary>
			/// <param name="start">Начальная точка</param>
			/// <param name="point1">Первая точка</param>
			/// <param name="point2">Вторая точка</param>
			/// <param name="end">Конечная точка</param>
			//---------------------------------------------------------------------------------------------------------
			public void CreateFromPivotPoint(Vector2 start, Vector2 point1, Vector2 point2, Vector2 end)
			{
				mControlPoints[0] = start;
				mControlPoints[1].x = (-5 * start.x + 18 * point1.x - 9 * point2.x + 2 * end.x) / 6;
				mControlPoints[1].y = (-5 * start.y + 18 * point1.y - 9 * point2.y + 2 * end.y) / 6;
				mControlPoints[2].x = (2 * start.x - 9 * point1.x + 18 * point2.x - 5 * end.x) / 6;
				mControlPoints[2].y = (2 * start.y - 9 * point1.y + 18 * point2.y - 5 * end.y) / 6;
				mControlPoints[3] = end;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление первой производной точки на кривой Безье
			/// </summary>
			/// <remarks>
			/// Первая производная показывает скорость изменения функции в данной точки.
			/// Физическим смысл производной - скорость на данной точке 
			/// </remarks>
			/// <param name="time">Положение точки от 0 до 1, где 0 соответствует крайней "левой" точки, 1 соответствует крайне
			/// "правой" конечной точки кривой</param>
			/// <returns>Первая производная точки на кривой Безье</returns>
			//---------------------------------------------------------------------------------------------------------
			public Vector2 CalculateFirstDerivative(Single time)
			{
				Single u = 1 - time;
				return 3f * u * u * (HandlePoint1 - StartPoint) +
				       6f * u * time * (HandlePoint2 - HandlePoint1) +
				       3f * time * time * (EndPoint - HandlePoint2);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка на управляющую точку
			/// </summary>
			/// <param name="index">Позиция(индекс) контрольной точки</param>
			/// <returns>Статус управляющей точки</returns>
			//---------------------------------------------------------------------------------------------------------
			public Boolean IsHandlePoint(Int32 index)
			{
				return index == 1 || index == 2;
			}
			#endregion
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Режим редактирования управляющей точки
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public enum TBezierHandleMode
		{
			/// <summary>
			/// Свободный режим
			/// </summary>
			Free,

			/// <summary>
			/// Режим - при котором вторая управляющая точка(смежная по отношению к опорной) располагается симметрично
			/// </summary>
			Aligned,

			/// <summary>
			/// Режим - при котором вторая управляющая точка(смежная по отношению к опорной) располагается симметрично и
			/// на таком же расстоянии как и редактируемая точка
			/// </summary>
			Mirrored
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Путь состоящий из кривых Безье
		/// </summary>
		/// <remarks>
		/// Реализация пути последовательно состоящего из кубических кривых Безье.
		/// Путь проходит через заданные опорные точки, управляющие точки определяют форму пути
		/// </remarks>
		//-------------------------------------------------------------------------------------------------------------
		[Serializable]
		public class CBezierPath2D : CSplineBase2D
		{
			#region ======================================= ДАННЫЕ ====================================================
			// Основные параметры
			[SerializeField]
			internal Boolean mIsClosed;
			[SerializeField]
			internal TBezierHandleMode[] mHandleModes;
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Статус замкнутости сплайна
			/// </summary>
			public Boolean IsClosed
			{
				get { return mIsClosed; }
				set
				{
					if (mIsClosed != value)
					{
						mIsClosed = value;

						if (mIsClosed == true)
						{
							mHandleModes[mHandleModes.Length - 1] = mHandleModes[0];
							SetControlPoint(0, mControlPoints[0]);
						}

						OnUpdateSpline();
					}
				}
			}

			/// <summary>
			/// Количество кривых в пути
			/// </summary>
			public Int32 CurveCount
			{
				get { return (mControlPoints.Length - 1) / 3; }
			}
			#endregion

			#region ======================================= КОНСТРУКТОРЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор по умолчанию инициализирует объект класса предустановленными значениями
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public CBezierPath2D()
				:base(4)
			{
				mHandleModes = new TBezierHandleMode[4];
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Конструктор осуществляет построение пути(связанных кривых) Безье на основе опорных точек пути
			/// </summary>
			/// <remarks>
			/// Промежуточные управляющие точки генерируется автоматически
			/// </remarks>
			/// <param name="pivot_points">Опорные точки пути</param>
			//---------------------------------------------------------------------------------------------------------
			public CBezierPath2D(params Vector2[] pivot_points)
				:base(pivot_points)
			{
				mHandleModes = new TBezierHandleMode[4];
				CreateFromPivotPoints(pivot_points);
			}
			#endregion

			#region ======================================= МЕТОДЫ ILotusSpline2D =====================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление точки на сплайне
			/// </summary>
			/// <param name="time">Положение точки от 0 до 1</param>
			/// <returns>Позиция точки на сплайне</returns>
			//---------------------------------------------------------------------------------------------------------
			public override Vector2 CalculatePoint(Single time)
			{
				Int32 index_curve;
				if (time >= 1f)
				{
					time = 1f;
					index_curve = mControlPoints.Length - 4;
				}
				else
				{
					time = Mathf.Clamp01(time) * CurveCount;
					index_curve = (Int32)time;
					time -= index_curve;
					index_curve *= 3;
				}

				Vector2 point = CBezierCubic2D.CalculatePoint(time,
					ref mControlPoints[index_curve],
					ref mControlPoints[index_curve + 1],
					ref mControlPoints[index_curve + 2],
					ref mControlPoints[index_curve + 3]);

				return point;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Растеризация сплайна - вычисление точек отрезков для рисования сплайна
			/// </summary>
			/// <remarks>
			/// Качество(степень) растеризации зависит от свойства <see cref="SegmentsSpline"/>
			/// </remarks>
			//---------------------------------------------------------------------------------------------------------
			public override void ComputeDrawingPoints()
			{
				mDrawingPoints.Clear();

				for (Int32 i = 0; i < CurveCount; i++)
				{
					Vector2 prev = CalculateCurvePoint(i, 0);
					mDrawingPoints.Add(prev);
					for (Int32 ip = 1; ip < SegmentsSpline; ip++)
					{
						Single time = (Single)ip / SegmentsSpline;
						Vector2 point = CalculateCurvePoint(i, time);

						// Добавляем если длина больше 1,4
						if ((point - prev).sqrMagnitude > MinimalSqrLine)
						{
							mDrawingPoints.Add(point);
							prev = point;
						}
					}
				}

				if (mIsClosed)
				{
					CheckCorrectStartPoint();
				}
				else
				{
					CheckCorrectEndPoint();
				}
			}
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Установка режима редактирования управляющей точки
			/// </summary>
			/// <param name="index">Позиция(индекс) контрольной точки</param>
			//---------------------------------------------------------------------------------------------------------
			private void SetHandleMode(Int32 index)
			{
				Int32 mode_index = (index + 1) / 3;
				TBezierHandleMode mode = mHandleModes[mode_index];
				if (mode == TBezierHandleMode.Free || !mIsClosed && (mode_index == 0 || mode_index == mHandleModes.Length - 1))
				{
					return;
				}

				Int32 middle_index = mode_index * 3;
				Int32 fixed_index, enforced_index;
				if (index <= middle_index)
				{
					fixed_index = middle_index - 1;
					if (fixed_index < 0)
					{
						fixed_index = mControlPoints.Length - 2;
					}
					enforced_index = middle_index + 1;
					if (enforced_index >= mControlPoints.Length)
					{
						enforced_index = 1;
					}
				}
				else
				{
					fixed_index = middle_index + 1;
					if (fixed_index >= mControlPoints.Length)
					{
						fixed_index = 1;
					}
					enforced_index = middle_index - 1;
					if (enforced_index < 0)
					{
						enforced_index = mControlPoints.Length - 2;
					}
				}

				Vector2 middle = mControlPoints[middle_index];
				Vector2 enforced_tangent = middle - mControlPoints[fixed_index];
				if (mode == TBezierHandleMode.Aligned)
				{
					enforced_tangent = enforced_tangent.normalized * Vector2.Distance(middle, mControlPoints[enforced_index]);
				}

				mControlPoints[enforced_index] = middle + enforced_tangent;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Создание пути Безье проходящего через заданные(опорные) точки
			/// </summary>
			/// <remarks>
			/// Промежуточные управляющие точки генерируется автоматически
			/// </remarks>
			/// <param name="pivot_points">Опорные точки пути</param>
			//---------------------------------------------------------------------------------------------------------
			public void CreateFromPivotPoints(params Vector2[] pivot_points)
			{
				// Если точек меньше двух выходим
				if (pivot_points.Length < 2)
				{
					return;
				}

				List<Vector2> points = new List<Vector2>();
				for (Int32 i = 0; i < pivot_points.Length; i++)
				{
					// Первая точка
					if (i == 0)
					{
						Vector2 p1 = pivot_points[i];
						Vector2 p2 = pivot_points[i + 1];

						// Расстояние
						Single distance = (p2 - p1).magnitude;
						Vector2 q1 = p1 + distance * 0.5f * Vector2.right;

						points.Add(p1);
						points.Add(q1);
					}
					else if (i == pivot_points.Length - 1) //last
					{
						Vector2 p0 = pivot_points[i - 1];
						Vector2 p1 = pivot_points[i];

						// Расстояние
						Single distance = (p0 - p1).magnitude;
						Vector2 q0 = p1 + distance * 0.5f * Vector2.left;

						points.Add(q0);
						points.Add(p1);
					}
					else
					{
						Vector2 p0 = pivot_points[i - 1];
						Vector2 p1 = pivot_points[i];
						Vector2 p2 = pivot_points[i + 1];

						// Расстояние
						Single distance1 = (p1 - p0).magnitude;
						Single distance2 = (p2 - p1).magnitude;

						Vector2 q0 = p1 + distance1 * 0.5f * Vector2.left;
						Vector2 q1 = p1 + distance2 * 0.5f * Vector2.right;

						points.Add(q0);
						points.Add(p1);
						points.Add(q1);
					}
				}

				// При необходимости изменяем размер массива
				if (mControlPoints.Length != points.Count)
				{
					Array.Resize(ref mControlPoints, points.Count);
				}

				// Копируем данные
				for (Int32 i = 0; i < points.Count; i++)
				{
					mControlPoints[i] = points[i];
				}

				OnUpdateSpline();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Установка контрольной точки сплайна по индексу в локальных координатах
			/// </summary>
			/// <param name="index">Позиция(индекс) точки</param>
			/// <param name="point">Контрольная точка сплайна в локальных координатах</param>
			/// <param name="update_spline">Статус обновления сплайна</param>
			//---------------------------------------------------------------------------------------------------------
			public override void SetControlPoint(Int32 index, Vector2 point, Boolean update_spline = false)
			{
				if (index % 3 == 0)
				{
					Vector2 delta = point - mControlPoints[index];
					if (mIsClosed)
					{
						if (index == 0)
						{
							mControlPoints[1] += delta;
							mControlPoints[mControlPoints.Length - 2] += delta;
							mControlPoints[mControlPoints.Length - 1] = point;
						}
						else if (index == mControlPoints.Length - 1)
						{
							mControlPoints[0] = point;
							mControlPoints[1] += delta;
							mControlPoints[index - 1] += delta;
						}
						else
						{
							mControlPoints[index - 1] += delta;
							mControlPoints[index + 1] += delta;
						}
					}
					else
					{
						if (index > 0)
						{
							mControlPoints[index - 1] += delta;
						}
						if (index + 1 < mControlPoints.Length)
						{
							mControlPoints[index + 1] += delta;
						}
					}
				}
				mControlPoints[index] = point;
				SetHandleMode(index);

				if (update_spline)
				{
					OnUpdateSpline();
				}
			}
			#endregion

			#region ======================================= МЕТОДЫ РАБОТЫ С ОТДЕЛЬНЫМИ КРИВЫМИ ========================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Добавить кривую
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public void AddCurve()
			{
				Vector2 point = mControlPoints[mControlPoints.Length - 1];
				Array.Resize(ref mControlPoints, mControlPoints.Length + 3);
				point.x += 100f;
				mControlPoints[mControlPoints.Length - 3] = point;
				point.x += 100f;
				mControlPoints[mControlPoints.Length - 2] = point;
				point.x += 100f;
				mControlPoints[mControlPoints.Length - 1] = point;

				Array.Resize(ref mHandleModes, mHandleModes.Length + 1);
				mHandleModes[mHandleModes.Length - 1] = mHandleModes[mHandleModes.Length - 2];
				SetHandleMode(mControlPoints.Length - 4);

				if (mIsClosed)
				{
					mControlPoints[mControlPoints.Length - 1] = mControlPoints[0];
					mHandleModes[mHandleModes.Length - 1] = mHandleModes[0];
					SetHandleMode(0);
				}

				OnUpdateSpline();
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление последней кривой
			/// </summary>
			//---------------------------------------------------------------------------------------------------------
			public void RemoveCurve()
			{
				if (CurveCount > 1)
				{
					Array.Resize(ref mControlPoints, mControlPoints.Length - 3);
					Array.Resize(ref mHandleModes, mHandleModes.Length - 1);
					SetHandleMode(mControlPoints.Length - 2, TBezierHandleMode.Free);
					if (mIsClosed)
					{
						mControlPoints[mControlPoints.Length - 1] = mControlPoints[0];
						mHandleModes[mHandleModes.Length - 1] = mHandleModes[0];
						SetHandleMode(0);
					}

					OnUpdateSpline();
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление точки на отдельной кривой Безье
			/// </summary>
			/// <param name="curve_index">Индекс кривой</param>
			/// <param name="time">Время</param>
			/// <returns>Точка</returns>
			//---------------------------------------------------------------------------------------------------------
			public Vector2 CalculateCurvePoint(Int32 curve_index, Single time)
			{
				Int32 node_index = curve_index * 3;

				return CBezierCubic2D.CalculatePoint(time,
					ref mControlPoints[node_index],
					ref mControlPoints[node_index + 1],
					ref mControlPoints[node_index + 2],
					ref mControlPoints[node_index + 3]);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение контрольной точки на отдельной кривой Безье
			/// </summary>
			/// <param name="curve_index">Индекс кривой</param>
			/// <param name="point_index">Индекс контрольной точки</param>
			/// <returns>Контрольная точка</returns>
			//---------------------------------------------------------------------------------------------------------
			public Vector2 GetCurveControlPoint(Int32 curve_index, Int32 point_index)
			{
				curve_index = curve_index * 3;
				return mControlPoints[curve_index + point_index];
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Установка позиции контрольной точки на отдельной кривой Безье
			/// </summary>
			/// <param name="curve_index">Индекс кривой</param>
			/// <param name="point_index">Индекс точки</param>
			/// <param name="position">Позиция контрольной точки</param>
			//---------------------------------------------------------------------------------------------------------
			public void SetCurveControlPoint(Int32 curve_index, Int32 point_index, Vector2 position)
			{
				curve_index = curve_index * 3;
				mControlPoints[curve_index + point_index] = position;
			}
			#endregion

			#region ======================================= МЕТОДЫ РАБОТЫ С УПРАВЛЯЮЩИМИ ТОЧКАМИ ======================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка на управляющую точку
			/// </summary>
			/// <param name="index">Позиция(индекс) контрольной точки</param>
			/// <returns>Статус управляющей точки</returns>
			//---------------------------------------------------------------------------------------------------------
			public Boolean IsHandlePoint(Int32 index)
			{
				return index == 1 ||
				       index == 2 ||
				       index % 3 == 1 ||
				       index % 3 == 2;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получения режима редактирования управляющей точки
			/// </summary>
			/// <param name="index">Позиция(индекс) контрольной точки</param>
			/// <returns>Режим редактирования управляющей точки</returns>
			//---------------------------------------------------------------------------------------------------------
			public TBezierHandleMode GetHandleMode(Int32 index)
			{
				return mHandleModes[(index + 1) / 3];
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Установка режима редактирования управляющей точки
			/// </summary>
			/// <param name="index">Позиция(индекс) контрольной точки</param>
			/// <param name="mode">Режим редактирования управляющей точки</param>
			//---------------------------------------------------------------------------------------------------------
			public void SetHandleMode(Int32 index, TBezierHandleMode mode)
			{
				Int32 mode_index = (index + 1) / 3;
				mHandleModes[mode_index] = mode;

				if (mIsClosed)
				{
					if (mode_index == 0)
					{
						mHandleModes[mHandleModes.Length - 1] = mode;
					}
					else if (mode_index == mHandleModes.Length - 1)
					{
						mHandleModes[0] = mode;
					}
				}

				SetHandleMode(index);
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/*@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
﻿//=====================================================================================================================
// Проект: LotusPlatform
// Раздел: Модуль математической системы
// Подраздел: Общая математическая подсистема
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusMathCommonBase.cs
*		Основные математические методы и функции.
*		Реализация базовых и вспомогательных методов для работы с математикой и вещественным типом двойной точности.
*		Необходимость обусловлена применением в ряде будущих проектов вычислений с большими значениями. Также реализованы
*	методы интерполяция промежуточных значений величины.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 27.03.2022
//=====================================================================================================================
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
//=====================================================================================================================
namespace Lotus
{
	namespace Maths
	{
		//-------------------------------------------------------------------------------------------------------------
		//! \addtogroup MathCommon
		/*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Статический класс реализующий математические методы и функции
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XMath
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Значение, для которого все абсолютные значения меньше, чем считаются равными нулю
			/// </summary>
			public const Double ZeroTolerance_d = 0.000000001;

			/// <summary>
			/// Значение, для которого все абсолютные значения меньше, чем считаются равными нулю
			/// </summary>
			public const Single ZeroTolerance_f = 0.000001f;

			/// <summary>
			/// Точность вещественного числа
			/// </summary>
			public const Double Eplsilon_d = 0.00000001;

			/// <summary>
			/// Точность вещественного числа
			/// </summary>
			public const Single Eplsilon_f = 0.0000001f;

			/// <summary>
			/// Точность вещественного числа
			/// </summary>
			public const Double Eplsilon_3d = 0.001;

			/// <summary>
			/// Точность вещественного числа
			/// </summary>
			public const Single Eplsilon_3f = 0.001f;

			/// <summary>
			/// Коэффициент для преобразования радианов в градусы
			/// </summary>
			public const Double RadianToDegree_d = 57.29577951;

			/// <summary>
			/// Коэффициент для преобразования радианов в градусы
			/// </summary>
			public const Single RadianToDegree_f = 57.29577951f;

			/// <summary>
			/// Коэффициент для преобразования градусов в радианы
			/// </summary>
			public const Double DegreeToRadian_d = 0.01745329;

			/// <summary>
			/// Коэффициент для преобразования градусов в радианы
			/// </summary>
			public const Single DegreeToRadian_f = 0.01745329f;

			/// <summary>
			/// Экспонента
			/// </summary>
			public const Double Exponent_d = 2.71828182;

			/// <summary>
			/// Экспонента
			/// </summary>
			public const Single Exponent_f = 2.71828182f;

			/// <summary>
			/// Log2(e)
			/// </summary>
			public const Double Log2E_d = 1.44269504;

			/// <summary>
			/// Log2(e)
			/// </summary>
			public const Single Log2E_f = 1.44269504f;

			/// <summary>
			/// Log10(e)
			/// </summary>
			public const Double Log10E_d = 0.43429448;

			/// <summary>
			/// Log10(e)
			/// </summary>
			public const Single Log10E_f = 0.43429448f;

			/// <summary>
			/// Ln(2)
			/// </summary>
			public const Double Ln2d = 0.69314718;

			/// <summary>
			/// Ln(2)
			/// </summary>
			public const Single Ln2f = 0.69314718f;

			/// <summary>
			/// Ln(10)
			/// </summary>
			public const Double Ln10d = 2.30258509;

			/// <summary>
			/// Ln(10)
			/// </summary>
			public const Single Ln10f = 2.30258509f;

			/// <summary>
			/// Число Pi * 2
			/// </summary>
			public const Double PI2d = 6.283185306;

			/// <summary>
			/// Число Pi * 2
			/// </summary>
			public const Single PI2f = 6.283185306f;

			/// <summary>
			/// Число Pi
			/// </summary>
			public const Double PI_d = 3.141592653;

			/// <summary>
			/// Число Pi
			/// </summary>
			public const Single PI_f = 3.141592653f;

			/// <summary>
			/// Число Pi/2
			/// </summary>
			public const Double PI_2d = 1.570796326;

			/// <summary>
			/// Число Pi/2
			/// </summary>
			public const Single PI_2f = 1.570796326f;

			/// <summary>
			/// Число Pi/3
			/// </summary>
			public const Double PI_3d = 1.047197551;

			/// <summary>
			/// Число Pi/3
			/// </summary>
			public const Single PI_3f = 1.047197551f;

			/// <summary>
			/// Число Pi/4
			/// </summary>
			public const Double PI_4d = 0.785398163;

			/// <summary>
			/// Число Pi/4
			/// </summary>
			public const Single PI_4f = 0.785398163f;

			/// <summary>
			/// Число Pi/6
			/// </summary>
			public const Double PI_6d = 0.523598775598;

			/// <summary>
			/// Число Pi/6
			/// </summary>
			public const Double PI_6f = 0.523598775598;
			#endregion

			#region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Обмен значениями двух объектов
			/// </summary>
			/// <typeparam name="TType">Тип объекта</typeparam>
			/// <param name="left">Первое значение</param>
			/// <param name="right">Второе значение</param>
			//---------------------------------------------------------------------------------------------------------
			public static void Swap<TType>(ref TType left, ref TType right)
			{
				TType temp = left;
				left = right;
				right = temp;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка на нулевое значение
			/// </summary>
			/// <param name="value">Значение</param>
			/// <returns>Статус проверки</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean IsZero(Double value)
			{
				return Math.Abs(value) < ZeroTolerance_d;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка на нулевое значение
			/// </summary>
			/// <param name="value">Значение</param>
			/// <returns>Статус проверки</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean IsZero(Single value)
			{
				return Math.Abs(value) < ZeroTolerance_f;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка на единичное значение
			/// </summary>
			/// <param name="value">Значение</param>
			/// <returns>Статус проверки</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean IsOne(Double value)
			{
				return IsZero(value - 1.0);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Проверка на единичное значение
			/// </summary>
			/// <param name="value">Значение</param>
			/// <returns>Статус проверки</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean IsOne(Single value)
			{
				return IsZero(value - 1.0);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Ограничение значения в пределах от 0 до 1
			/// </summary>
			/// <param name="value">Значение</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double Clamp01(Double value)
			{
				if (value < 0) value = 0;
				if (value > 1) value = 1;

				return value;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Ограничение значения в пределах от 0 до 1
			/// </summary>
			/// <param name="value">Значение</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Single Clamp01(Single value)
			{
				if (value < 0) value = 0;
				if (value > 1) value = 1;

				return value;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Ограничение значения в указанных пределах
			/// </summary>
			/// <param name="value">Значение</param>
			/// <param name="min">Минимальное значение</param>
			/// <param name="max">Максимальное значение</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double Clamp(Double value, Double min, Double max)
			{
				if (value < min) value = min;
				if (value > max) value = max;

				return value;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Ограничение значения в указанных пределах
			/// </summary>
			/// <param name="value">Значение</param>
			/// <param name="min">Минимальное значение</param>
			/// <param name="max">Максимальное значение</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Single Clamp(Single value, Single min, Single max)
			{
				if (value < min) value = min;
				if (value > max) value = max;

				return value;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Ограничение значения в указанных пределах
			/// </summary>
			/// <param name="value">Значение</param>
			/// <param name="min">Минимальное значение</param>
			/// <param name="max">Максимальное значение</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Int32 Clamp(Int32 value, Int32 min, Int32 max)
			{
				if (value < min) value = min;
				if (value > max) value = max;

				return value;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Аппроксимация равенства значений
			/// </summary>
			/// <param name="a">Первое значение</param>
			/// <param name="b">Второе значение</param>
			/// <returns>Статус равенства значений</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean Approximately(Double a, Double b)
			{
				if (Math.Abs(a - b) < Eplsilon_3d)
				{
					return true;
				}

				return false;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Аппроксимация равенства значений
			/// </summary>
			/// <param name="a">Первое значение</param>
			/// <param name="b">Второе значение</param>
			/// <returns>Статус равенства значений</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean Approximately(Single a, Single b)
			{
				if (Math.Abs(a - b) < Eplsilon_3f)
				{
					return true;
				}

				return false;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Аппроксимация равенства значений
			/// </summary>
			/// <param name="a">Первое значение</param>
			/// <param name="b">Второе значение</param>
			/// <param name="epsilon">Погрешность</param>
			/// <returns>Статус равенства значений</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean Approximately(Double a, Double b, Double epsilon = 0.0001)
			{
				if (Math.Abs(a - b) < epsilon)
				{
					return true;
				}

				return false;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Аппроксимация равенства значений
			/// </summary>
			/// <param name="a">Первое значение</param>
			/// <param name="b">Второе значение</param>
			/// <param name="epsilon">Погрешность</param>
			/// <returns>Статус равенства значений</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean Approximately(Single a, Single b, Single epsilon = 0.001f)
			{
				if (Math.Abs(a - b) < epsilon)
				{
					return true;
				}

				return false;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление квадратного корня
			/// </summary>
			/// <param name="value">Значение</param>
			/// <returns>Квадратный корень</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Single Sqrt(Single value)
			{
				return ((Single)Math.Sqrt(value));
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление обратного квадратного корня
			/// </summary>
			/// <param name="value">Значение</param>
			/// <returns>Значение обратного квадратного корня</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double InvSqrt(Double value)
			{
				Double result = Math.Sqrt(value);

				if (result > ZeroTolerance_d)
				{
					return 1.0 / result;
				}

				return 1.0;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление обратного квадратного корня
			/// </summary>
			/// <param name="value">Значение</param>
			/// <returns>Значение обратного квадратного корня</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Single InvSqrt(Single value)
			{
				Single result = (Single)Math.Sqrt(value);

				if (result > ZeroTolerance_f)
				{
					return 1.0f / result;
				}

				return 1.0f;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление синуса
			/// </summary>
			/// <param name="radians">Угол в радианах</param>
			/// <returns>Значение синуса</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Single Sin(Single radians)
			{
				return ((Single)Math.Sin(radians));
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Вычисление косинуса
			/// </summary>
			/// <param name="radians">Угол в радианах</param>
			/// <returns>Значение косинуса</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Single Cos(Single radians)
			{
				return ((Single)Math.Cos(radians));
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование интервала одного к другому
			/// </summary>
			/// <remarks>
			/// Под другому это можно интерпретировать как пересечение по Y вертикальной линии отрезка проходящего через точки:
			/// - x1 = dest_start
			/// - x2 = dest_end
			/// - y1 = source_start
			/// - y2 = source_end
			/// - px = value
			/// </remarks>
			/// <param name="dest_start">Начала целевого интервала</param>
			/// <param name="dest_end">Конец целевого интервала</param>
			/// <param name="source_start">Начало исходного интервала</param>
			/// <param name="source_end">Конец исходного интервала</param>
			/// <param name="value">Исходное значение</param>
			/// <returns>Целевое значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double ConvertInterval(Double dest_start, Double dest_end, Double source_start,
				Double source_end, Double value)
			{
				Double x1 = dest_start;
				Double x2 = dest_end;
				Double y1 = source_start;
				Double y2 = source_end;

				Double k = (y2 - y1) / (x2 - x1);
				Double b = y1 - (k * x1);

				Double result = (k * value + b);

				return (result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование интервала одного к другому
			/// </summary>
			/// <remarks>
			/// Под другому это можно интерпретировать как пересечение по Y вертикальной линии отрезка проходящего через точки:
			/// - x1 = dest_start
			/// - x2 = dest_end
			/// - y1 = source_start
			/// - y2 = source_end
			/// - px = value
			/// </remarks>
			/// <param name="dest_start">Начала целевого интервала</param>
			/// <param name="dest_end">Конец целевого интервала</param>
			/// <param name="source_start">Начало исходного интервала</param>
			/// <param name="source_end">Конец исходного интервала</param>
			/// <param name="value">Исходное значение</param>
			/// <returns>Целевое значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Single ConvertInterval(Single dest_start, Single dest_end, Single source_start,
				Single source_end, Single value)
			{
				Single x1 = dest_start;
				Single x2 = dest_end;
				Single y1 = source_start;
				Single y2 = source_end;

				Single k = (y2 - y1) / (x2 - x1);
				Single b = y1 - (k * x1);

				Single result = (k * value + b);

				return (result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование процента в часть
			/// </summary>
			/// <param name="percent">Процент от 0 до 100</param>
			/// <returns>Часть</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Single ToPartFromPercent(Int32 percent)
			{
				Single p = percent;
				if (percent <= 0)
				{
					p = 0;
				}
				if(percent >= 100)
				{
					p = 100;
				}

				return p / 100.0f;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Округление до нужного целого
			/// </summary>
			/// <param name="value">Значение</param>
			/// <param name="round">Степень округления</param>
			/// <returns>Округленное значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double RoundToNearest(Double value, Int32 round)
			{
				if (value >= 0)
				{
					Double result = Math.Floor((value + (Double)round / 2) / round) * round;
					return (result);
				}
				else
				{
					Double result = Math.Ceiling((value - (Double)round / 2) / round) * round;
					return (result);
				}
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Округление до нужного целого
			/// </summary>
			/// <param name="value">Значение</param>
			/// <param name="round">Степень округления</param>
			/// <returns>Округленное значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Single RoundToNearest(Single value, Int32 round)
			{
				if (value >= 0)
				{
					return (Single)(Math.Floor((value + (Single)round / 2) / round) * round);
				}
				else
				{
					return (Single)(Math.Ceiling((value - (Single)round / 2) / round) * round);
				}
			}
			#endregion

			#region ======================================= Int32 =====================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование текста в число
			/// </summary>
			/// <param name="text">Текст</param>
			/// <param name="default_value">Значение по умолчанию если преобразовать не удалось</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Int32 ParseInt(String text, Int32 default_value = 0)
			{
				if (Int32.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out default_value))
				{

				}

				return default_value;
			}
			#endregion

			#region ======================================= Int64 =====================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование текста в число
			/// </summary>
			/// <param name="text">Текст</param>
			/// <param name="default_value">Значение по умолчанию если преобразовать не удалось</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Int64 ParseLong(String text, Int64 default_value = 0)
			{
				if (Int64.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out default_value))
				{

				}

				return default_value;
			}
			#endregion

			#region ======================================= Single ====================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование текста в число
			/// </summary>
			/// <param name="text">Текст</param>
			/// <param name="default_value">Значение по умолчанию если преобразовать не удалось</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Single ParseSingle(String text, Single default_value = 0)
			{
				if (text.IndexOf(',') > -1)
				{
					text = text.Replace(',', '.');
				}

				if (Single.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out default_value))
				{

				}

				return default_value;
			}
			#endregion

			#region ======================================= Double ====================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование текста в число
			/// </summary>
			/// <param name="text">Текст</param>
			/// <param name="default_value">Значение по умолчанию если преобразовать не удалось</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double ParseDouble(String text, Double default_value = 0)
			{
				if (text.IndexOf(',') > -1)
				{
					text = text.Replace(',', '.');
				}

				if (Double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out default_value))
				{

				}

				return default_value;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование форматированного текста в число
			/// </summary>
			/// <param name="text">Текст</param>
			/// <param name="default_value">Значение по умолчанию если преобразовать не удалось</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Double ParseDoubleFormat(String text, Double default_value = 0)
			{
				StringBuilder number = new StringBuilder(text.Length);

				for (Int32 i = 0; i < text.Length; i++)
				{
					Char c = text[i];

					if (c == '-')
					{
						number.Append(c);
						continue;
					}

					if (c == ',' || c == '.')
					{
						if (i != text.Length - 1)
						{
							number.Append('.');
						}
						continue;
					}

					if (c >= '0' && c <= '9')
					{
						number.Append(c);
						continue;
					}

				}

				if (Double.TryParse(number.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out default_value))
				{

				}

				return default_value;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование форматированного текста в число
			/// </summary>
			/// <param name="text">Текст</param>
			/// <param name="result">Значение</param>
			/// <returns>Статус успешности преобразования</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Boolean ParseDoubleFormat(String text, out Double result)
			{
				StringBuilder number = new StringBuilder(text.Length);

				for (Int32 i = 0; i < text.Length; i++)
				{
					Char c = text[i];

					if (c == '-')
					{
						number.Append(c);
						continue;
					}

					if (c == ',' || c == '.')
					{
						if (i != text.Length - 1)
						{
							number.Append('.');
						}
						continue;
					}

					if (c >= '0' && c <= '9')
					{
						number.Append(c);
						continue;
					}

				}

				if (Double.TryParse(number.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out result))
				{
					return (true);
				}

				return (false);
			}
			#endregion

			#region ======================================= Decimal ===================================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование текста в число
			/// </summary>
			/// <param name="text">Текст</param>
			/// <param name="default_value">Значение по умолчанию если преобразовать не удалось</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Decimal ParseDecimal(String text, Decimal default_value = 0)
			{
				if (text.IndexOf(',') > -1)
				{
					text = text.Replace(',', '.');
				}

				if (Decimal.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out default_value))
				{

				}

				return default_value;
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование текста, представленного как отображение валюты, в число
			/// </summary>
			/// <param name="text">Текст</param>
			/// <param name="default_value">Значение по умолчанию если преобразовать не удалось</param>
			/// <returns>Значение</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Decimal ParseCurrency(String text, Decimal default_value = 0)
			{
				if (text.IndexOf(',') > -1)
				{
					text = text.Replace(',', '.');
				}

				if (Decimal.TryParse(text, NumberStyles.Currency, CultureInfo.InvariantCulture, out default_value))
				{

				}

				return default_value;
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/*@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
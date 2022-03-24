﻿//=====================================================================================================================
// Проект: LotusPlatform
// Раздел: Модуль математической системы
// Подраздел: Общая математическая подсистема
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusMathCommonUnityExtension.cs
*		Методы (математические) расширения к типам Unity.
*		Реализация математических методов расширения к типам Unity для обеспечения удобства работы.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 27.03.2022
//=====================================================================================================================
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
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
		/// Статический класс расширяющий методы стандартных математических типов и типов Unity
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public static class XMathExtension
		{
			#region ======================================= МЕТОДЫ ПРЕОБРАЗОВАНИЯ =====================================
			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование в вектор Vector2Df
			/// </summary>
			/// <param name="@this">Вектор</param>
			/// <returns>Вектор Vector2Df</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector2Df ToVector2Df(this Vector2 @this)
			{
				return (new Vector2Df(@this.x, @this.y));
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование в вектор Vector3Df
			/// </summary>
			/// <param name="@this">Вектор</param>
			/// <returns>Вектор Vector3Df</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Vector3Df ToVector3Df(this Vector3 @this)
			{
				return (new Vector3Df(@this.x, @this.y, @this.z));
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Преобразование в кватернион Quaternion3Df
			/// </summary>
			/// <param name="@this">Кватернион</param>
			/// <returns>Кватернион Quaternion3Df</returns>
			//---------------------------------------------------------------------------------------------------------
			public static Quaternion3Df ToQuaternion3Df(this Quaternion @this)
			{
				return (new Quaternion3Df(@this.x, @this.y, @this.z, @this.w));
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/*@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
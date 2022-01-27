﻿//=====================================================================================================================
// Проект: LotusPlatform
// Раздел: Модуль математической системы
// Подраздел: Подсистема сериализации
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusMathSerializationJson.cs
*		Реализация конверторов для упрощения чтения/записи математических типов в формат Json .
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.01.2022
//=====================================================================================================================
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
//---------------------------------------------------------------------------------------------------------------------
using Newtonsoft.Json;
//=====================================================================================================================
namespace Lotus
{
	namespace Maths
	{
		//-------------------------------------------------------------------------------------------------------------
		//! \addtogroup MathSerialization
		/*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Реализация конвертера для типа <see cref="Vector2Df"/>
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class Vector2DfConverter : JsonConverter<Vector2Df>
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Глобальный экземпляр конвертера
			/// </summary>
			public static readonly Vector2DfConverter Instance = new Vector2DfConverter();
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Возможность прочитать свойство
			/// </summary>
			public override Boolean CanRead
			{
				get
				{
					return (true);
				}
			}

			/// <summary>
			/// Возможность записать свойство
			/// </summary>
			public override Boolean CanWrite
			{
				get
				{
					return (true);
				}
			}
			#endregion

			#region ======================================= МЕТОДЫ ==================================================
			//-------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Запись свойства
			/// </summary>
			/// <param name="writer">Писатель Json</param>
			/// <param name="value">Значение свойства</param>
			/// <param name="serializer">Сериализатор Json</param>
			//-------------------------------------------------------------------------------------------------------
			public override void WriteJson(JsonWriter writer, Vector2Df value, JsonSerializer serializer)
			{
				writer.WriteValue(value.SerializeToString());
			}

			//-------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Чтение свойства
			/// </summary>
			/// <param name="reader">Читатель Json</param>
			/// <param name="object_type">Тип объекта</param>
			/// <param name="existing_value">Статус существования значение</param>
			/// <param name="has_existing_value">Статус существования значение</param>
			/// <param name="serializer">Сериализатор Json</param>
			/// <returns>Значение свойства</returns>
			//-------------------------------------------------------------------------------------------------------
			public override Vector2Df ReadJson(JsonReader reader, Type object_type, Vector2Df existing_value, 
				Boolean has_existing_value, JsonSerializer serializer)
			{
				return (Vector2Df.DeserializeFromString((String)reader.Value));
			}
			#endregion
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Реализация конвертера для типа <see cref="Vector2D"/>
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class Vector2DConverter : JsonConverter<Vector2D>
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Глобальный экземпляр конвертера
			/// </summary>
			public static readonly Vector2DConverter Instance = new Vector2DConverter();
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Возможность прочитать свойство
			/// </summary>
			public override Boolean CanRead
			{
				get
				{
					return (true);
				}
			}

			/// <summary>
			/// Возможность записать свойство
			/// </summary>
			public override Boolean CanWrite
			{
				get
				{
					return (true);
				}
			}
			#endregion

			#region ======================================= МЕТОДЫ ==================================================
			//-------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Запись свойства
			/// </summary>
			/// <param name="writer">Писатель Json</param>
			/// <param name="value">Значение свойства</param>
			/// <param name="serializer">Сериализатор Json</param>
			//-------------------------------------------------------------------------------------------------------
			public override void WriteJson(JsonWriter writer, Vector2D value, JsonSerializer serializer)
			{
				writer.WriteValue(value.SerializeToString());
			}

			//-------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Чтение свойства
			/// </summary>
			/// <param name="reader">Читатель Json</param>
			/// <param name="object_type">Тип объекта</param>
			/// <param name="existing_value">Статус существования значение</param>
			/// <param name="has_existing_value">Статус существования значение</param>
			/// <param name="serializer">Сериализатор Json</param>
			/// <returns>Значение свойства</returns>
			//-------------------------------------------------------------------------------------------------------
			public override Vector2D ReadJson(JsonReader reader, Type object_type, Vector2D existing_value,
				Boolean has_existing_value, JsonSerializer serializer)
			{
				return (Vector2D.DeserializeFromString((String)reader.Value));
			}
			#endregion
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Реализация конвертера для типа <see cref="Vector2Di"/>
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class Vector2DiConverter : JsonConverter<Vector2Di>
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Глобальный экземпляр конвертера
			/// </summary>
			public static readonly Vector2DiConverter Instance = new Vector2DiConverter();
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Возможность прочитать свойство
			/// </summary>
			public override Boolean CanRead
			{
				get
				{
					return (true);
				}
			}

			/// <summary>
			/// Возможность записать свойство
			/// </summary>
			public override Boolean CanWrite
			{
				get
				{
					return (true);
				}
			}
			#endregion

			#region ======================================= МЕТОДЫ ==================================================
			//-------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Запись свойства
			/// </summary>
			/// <param name="writer">Писатель Json</param>
			/// <param name="value">Значение свойства</param>
			/// <param name="serializer">Сериализатор Json</param>
			//-------------------------------------------------------------------------------------------------------
			public override void WriteJson(JsonWriter writer, Vector2Di value, JsonSerializer serializer)
			{
				writer.WriteValue(value.SerializeToString());
			}

			//-------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Чтение свойства
			/// </summary>
			/// <param name="reader">Читатель Json</param>
			/// <param name="object_type">Тип объекта</param>
			/// <param name="existing_value">Статус существования значение</param>
			/// <param name="has_existing_value">Статус существования значение</param>
			/// <param name="serializer">Сериализатор Json</param>
			/// <returns>Значение свойства</returns>
			//-------------------------------------------------------------------------------------------------------
			public override Vector2Di ReadJson(JsonReader reader, Type object_type, Vector2Di existing_value,
				Boolean has_existing_value, JsonSerializer serializer)
			{
				return (Vector2Di.DeserializeFromString((String)reader.Value));
			}
			#endregion
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Реализация конвертера для типа <see cref="Vector3Df"/>
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class Vector3DfConverter : JsonConverter<Vector3Df>
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Глобальный экземпляр конвертера
			/// </summary>
			public static readonly Vector3DfConverter Instance = new Vector3DfConverter();
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Возможность прочитать свойство
			/// </summary>
			public override Boolean CanRead
			{
				get
				{
					return (true);
				}
			}

			/// <summary>
			/// Возможность записать свойство
			/// </summary>
			public override Boolean CanWrite
			{
				get
				{
					return (true);
				}
			}
			#endregion

			#region ======================================= МЕТОДЫ ==================================================
			//-------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Запись свойства
			/// </summary>
			/// <param name="writer">Писатель Json</param>
			/// <param name="value">Значение свойства</param>
			/// <param name="serializer">Сериализатор Json</param>
			//-------------------------------------------------------------------------------------------------------
			public override void WriteJson(JsonWriter writer, Vector3Df value, JsonSerializer serializer)
			{
				writer.WriteValue(value.SerializeToString());
			}

			//-------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Чтение свойства
			/// </summary>
			/// <param name="reader">Читатель Json</param>
			/// <param name="object_type">Тип объекта</param>
			/// <param name="existing_value">Статус существования значение</param>
			/// <param name="has_existing_value">Статус существования значение</param>
			/// <param name="serializer">Сериализатор Json</param>
			/// <returns>Значение свойства</returns>
			//-------------------------------------------------------------------------------------------------------
			public override Vector3Df ReadJson(JsonReader reader, Type object_type, Vector3Df existing_value,
				Boolean has_existing_value, JsonSerializer serializer)
			{
				return (Vector3Df.DeserializeFromString((String)reader.Value));
			}
			#endregion
		}

		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Реализация конвертера для типа <see cref="Vector3D"/>
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class Vector3DConverter : JsonConverter<Vector3D>
		{
			#region ======================================= КОНСТАНТНЫЕ ДАННЫЕ ========================================
			/// <summary>
			/// Глобальный экземпляр конвертера
			/// </summary>
			public static readonly Vector3DConverter Instance = new Vector3DConverter();
			#endregion

			#region ======================================= СВОЙСТВА ==================================================
			/// <summary>
			/// Возможность прочитать свойство
			/// </summary>
			public override Boolean CanRead
			{
				get
				{
					return (true);
				}
			}

			/// <summary>
			/// Возможность записать свойство
			/// </summary>
			public override Boolean CanWrite
			{
				get
				{
					return (true);
				}
			}
			#endregion

			#region ======================================= МЕТОДЫ ==================================================
			//-------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Запись свойства
			/// </summary>
			/// <param name="writer">Писатель Json</param>
			/// <param name="value">Значение свойства</param>
			/// <param name="serializer">Сериализатор Json</param>
			//-------------------------------------------------------------------------------------------------------
			public override void WriteJson(JsonWriter writer, Vector3D value, JsonSerializer serializer)
			{
				writer.WriteValue(value.SerializeToString());
			}

			//-------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Чтение свойства
			/// </summary>
			/// <param name="reader">Читатель Json</param>
			/// <param name="object_type">Тип объекта</param>
			/// <param name="existing_value">Статус существования значение</param>
			/// <param name="has_existing_value">Статус существования значение</param>
			/// <param name="serializer">Сериализатор Json</param>
			/// <returns>Значение свойства</returns>
			//-------------------------------------------------------------------------------------------------------
			public override Vector3D ReadJson(JsonReader reader, Type object_type, Vector3D existing_value,
				Boolean has_existing_value, JsonSerializer serializer)
			{
				return (Vector3D.DeserializeFromString((String)reader.Value));
			}
			#endregion
		}
		//-------------------------------------------------------------------------------------------------------------
		/*@}*/
		//-------------------------------------------------------------------------------------------------------------
	}
}
//=====================================================================================================================
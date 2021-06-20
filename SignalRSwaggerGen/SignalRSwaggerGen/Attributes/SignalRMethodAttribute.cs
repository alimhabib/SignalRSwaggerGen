﻿using Microsoft.OpenApi.Models;
using SignalRSwaggerGen.Enums;
using SignalRSwaggerGen.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SignalRSwaggerGen.Attributes
{
	/// <summary>
	/// Use this attribute to enable Swagger documentation for hub methods
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public sealed class SignalRMethodAttribute : Attribute
	{
		public string Name { get; }
		public OperationType OperationType { get; }
		public AutoDiscover AutoDiscover { get; }

		/// <param name="name">Name of the method which will be invoked on the client side.
		/// If name contains "[Method]", this part will be replaced with the name of the method holding this attribute.</param>
		/// <param name="operationType">Same as HTTP verb</param>
		/// <param name="autoDiscover">A flag indicating what components will have Swagger documentation enabled automatically</param>
		/// <exception cref="ArgumentException">Thrown if name is null or empty</exception>
		public SignalRMethodAttribute(
			string name = Constants.MethodNamePlaceholder,
			OperationType operationType = Constants.DefaultOperationType,
			AutoDiscover autoDiscover = AutoDiscover.None)
		{
			if (name.IsNullOrEmpty()) throw new ArgumentException("Name is null or empty", nameof(name));
			if (!ValidAutoDiscoverValues.Contains(autoDiscover)) throw new ArgumentException($"Value {autoDiscover} not allowed for this attribute", nameof(autoDiscover));
			Name = name;
			OperationType = operationType;
			AutoDiscover = autoDiscover;
		}

		private static IEnumerable<AutoDiscover> ValidAutoDiscoverValues { get; } = new List<AutoDiscover>
		{
			AutoDiscover.None,
			AutoDiscover.Args
		};
	}
}
